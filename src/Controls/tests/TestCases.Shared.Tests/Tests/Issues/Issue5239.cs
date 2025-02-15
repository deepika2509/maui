﻿#if IOS
using NUnit.Framework;
using NUnit.Framework.Legacy;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue5239 : _IssuesUITest
	{
		public Issue5239(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[iOS] Top Padding not working on iOS when it is set alone";

		[Test]
		[Category(UITestCategories.Layout)]
		[Category(UITestCategories.Compatibility)]
		public void PaddingEqualToSafeAreaWorks()
		{
			var somePadding = App.WaitForElement("Hello").GetRect();
			Assert.That(20f, Is.EqualTo(somePadding.Y));
		}
	}
}
#endif