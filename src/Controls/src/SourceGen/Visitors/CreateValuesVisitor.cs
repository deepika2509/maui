using System;
using System.Linq;

using Microsoft.Maui.Controls.Xaml;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Xml;

namespace Microsoft.Maui.Controls.SourceGen;

class CreateValuesVisitor : IXamlNodeVisitor
{
   public CreateValuesVisitor(SourceGenContext context) => Context = context;

    SourceGenContext Context { get; }
    IndentedTextWriter Writer => Context.Writer;

    public TreeVisitingMode VisitingMode => TreeVisitingMode.BottomUp;
    public bool StopOnDataTemplate => true;
    public bool StopOnResourceDictionary => false;
    public bool VisitNodeOnDataTemplate => false;
    public bool SkipChildren(INode node, INode parentNode) => false;
    public bool IsResourceDictionary(ElementNode node) => node.IsResourceDictionary(Context);

    public void Visit(ValueNode node, INode parentNode)
    {
        Context.Values[node] = node.Value;
    }

    public void Visit(MarkupNode node, INode parentNode)
    {
        //At this point, all MarkupNodes are expanded to ElementNodes
    }

    public void Visit(ElementNode node, INode parentNode)
    {
        var type = node.XmlType.ResolveTypeSymbol(Context) 
            ?? throw new Exception($"Type {node.XmlType.Name} not found");

		//TODO if type is ArrayExtension

		//if type is Xaml2009Primitive
		if (IsXaml2009LanguagePrimitive(node)) {
            var variableName = NamingHelpers.CreateUniqueVariableName(Context, type!.Name!.Split('.').Last());
            Context.Variables[node] = new LocalVariable(type, variableName);

            Writer.WriteLine($"{type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)} {variableName} = {ValueForLanguagePrimitive(type, node)};");
            return;
        }

        //TODO xome markup extensions can be vcompiled here

		//TODO suports factorymethod, ctor args, etc

        IMethodSymbol? ctor = null;
        INamedTypeSymbol? namedType = type as INamedTypeSymbol;
        var ctors = namedType?.InstanceConstructors;
        
        //does it has a default parameterless ctor ?
        ctor = ctors?.FirstOrDefault(c => c.Parameters.Length == 0);

        if (ctor is null /* && factoryMethod is null*/)
        {
            //TODO we need an extension method for that and cache the result. it happens eveytime we have a Style
            ctor = ctors?.FirstOrDefault(c 
                => c.Parameters.Length >=0
                && c.Parameters.All(p => p.GetAttributes().Any(a => a?.AttributeClass?.Equals(Context.Compilation.GetTypeByMetadataName("Microsoft.Maui.Controls.ParameterAttribute"), SymbolEqualityComparer.Default)?? false))
                );
            //TODO validate ctor arguments
            if (ctor is not null)
            {
                var variableName = NamingHelpers.CreateUniqueVariableName(Context, type!.Name!.Split('.').Last());
                var parameters = ctor.Parameters
                    .Select(p => (  p.Type, 
                                    p.GetAttributes().FirstOrDefault(a => a.AttributeClass!.Equals(Context.Compilation.GetTypeByMetadataName("Microsoft.Maui.Controls.ParameterAttribute"), SymbolEqualityComparer.Default))?.ConstructorArguments[0].Value as string,
                                    p.GetAttributes().FirstOrDefault(a => a.AttributeClass!.Equals(Context.Compilation.GetTypeByMetadataName("System.ComponentModel.TypeConverterAttribute"), SymbolEqualityComparer.Default))?.ConstructorArguments[0].Value as ITypeSymbol
                                    ))
                    .Select(p => (p.Item1, node.Properties[new XmlName("", p.Item2)], p.Item3))
                    .Select(p => p.Item2 is ValueNode vn ? vn.ConvertTo(p.Item1, p.Item3, Context, vn as IXmlLineInfo) : p.Item2 is ElementNode en ? Context.Variables[en].Name : "null").ToList();

                Context.Variables[node] = new LocalVariable(type, variableName);
                Writer.WriteLine($"var {variableName} = new {type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}({string.Join(", ", parameters)});");
                return;
            }

        }

        bool isColor = type.Equals(Context.Compilation.GetTypeByMetadataName("Microsoft.Maui.Graphics.Color"), SymbolEqualityComparer.Default);

        if (   node.CollectionItems.Count == 1 
            && node.CollectionItems[0] is ValueNode valueNode
            && (isColor || type.IsValueType))
        { //<Color>HotPink</Color>
            var variableName = NamingHelpers.CreateUniqueVariableName(Context, type!.Name!.Split('.').Last());
            var valueString = valueNode.ConvertTo(type, Context, valueNode as IXmlLineInfo);
            
            Context.Variables[node] = new LocalVariable(type, variableName);
            Writer.WriteLine($"var {variableName} = {valueString};");
            return;
        } 
        else if (ctor != null)
        {
            var variableName = NamingHelpers.CreateUniqueVariableName(Context, type!.Name!.Split('.').Last());
            
            Context.Variables[node] = new LocalVariable(type, variableName);
            Writer.WriteLine($"var {variableName} = new {type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}();");
            return;
        }

	}

    public void Visit(ListNode node, INode parentNode)
    {
        if (node.TryGetPropertyName(parentNode, out XmlName name))
            node.XmlName = name;
    }

    public void Visit(RootNode node, INode parentNode)
    {
        var variableName = "__root";

        Context.Variables[node] = new LocalVariable(Context.RootType, variableName);
        Writer.WriteLine($"{Context.RootType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)} {variableName} = this;");
    }
    		
    static bool IsXaml2009LanguagePrimitive(IElementNode node)
    {
        if (node.NamespaceURI == XamlParser.X2009Uri)
        {
            var n = node.XmlType.Name.Split(':')[1];
            return n != "Array";
        }
        if (node.NamespaceURI != "clr-namespace:System;assembly=mscorlib")
            return false;
        var name = node.XmlType.Name.Split(':')[1];
        if (name == "SByte" ||
            name == "Int16" ||
            name == "Int32" ||
            name == "Int64" ||
            name == "Byte" ||
            name == "UInt16" ||
            name == "UInt32" ||
            name == "UInt64" ||
            name == "Single" ||
            name == "Double" ||
            name == "Boolean" ||
            name == "String" ||
            name == "Char" ||
            name == "Decimal" ||
            name == "TimeSpan" ||
            name == "Uri")
            return true;
        return false;
    }

    // TODO duplicate code with NodeSGExtensions.cs, should we share somehow?
    static string ValueForLanguagePrimitive(ITypeSymbol type, ElementNode node)
    {
        var hasValue = node.CollectionItems.Count == 1 && node.CollectionItems[0] is ValueNode &&
                ((ValueNode)node.CollectionItems[0]).Value is string;
        if (!hasValue)
            return "default";
        var valueString = (string)((ValueNode)node.CollectionItems[0]).Value;
        switch (type.SpecialType)
        {
            case SpecialType.System_SByte:
            case SpecialType.System_Int16:
            case SpecialType.System_Int32:
            case SpecialType.System_Int64:
            case SpecialType.System_Byte:
            case SpecialType.System_UInt16:
            case SpecialType.System_UInt32:
            case SpecialType.System_UInt64:
            case SpecialType.System_Single:
            case SpecialType.System_Double:
            case SpecialType.System_Decimal: return valueString;
            case SpecialType.System_Boolean: return valueString.ToLowerInvariant();
            case SpecialType.System_String: return $"\"{valueString}\"";
            case SpecialType.System_Object: return "new()";
            case SpecialType.System_Char: return $"'{valueString}'";
            case SpecialType.None: return DetermineToType(type, valueString);
            default: return "default";
        }
    }

    static string DetermineToType(ITypeSymbol toType, string valueString)
    {
        if (toType.TypeKind == TypeKind.Enum)
        {
            var enumValues = valueString.Split([','], StringSplitOptions.RemoveEmptyEntries)
                                        .Select(v => $"{toType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}.{v.Trim()}");
            return string.Join(" | ", enumValues);
        }

        return toType.ToString() switch
        {
            "System.TimeSpan" => $"new global::System.TimeSpan({TimeSpan.Parse(valueString).Ticks})",
            "System.Uri" => $"new global::System.Uri(\"{valueString}\", global::System.UriKind.RelativeOrAbsolute)",
            _ => "default"
        };
    }
}

class LocalVariable (ITypeSymbol type, string name)
{
    public ITypeSymbol Type => type;
    public string Name => name;
}