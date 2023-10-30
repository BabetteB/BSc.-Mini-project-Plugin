namespace Mini_Project_Note_App;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Notepage());
    }
}

