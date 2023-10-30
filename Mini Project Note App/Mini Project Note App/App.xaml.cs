namespace Mini_Project_Note_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new AppShell());
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 430;
        const int newHeight = 932;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}
