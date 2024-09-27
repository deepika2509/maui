﻿namespace Maui.Controls.Sample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// To test shell scenarios, change this to true
		bool useShell = false;
		bool titleBarWindow = false;

		if (titleBarWindow)
		{
			return new MainWindow();
		}

		if (!useShell)
		{
			return new Window(new NavigationPage(new MainPage()));
		}
		else
		{
			return new Window(new SandboxShell());
		}
	}
}
