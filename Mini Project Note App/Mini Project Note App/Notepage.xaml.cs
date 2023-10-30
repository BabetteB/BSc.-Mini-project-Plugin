namespace Mini_Project_Note_App;

public partial class Notepage : ContentPage
{
	public Notepage()
	{
		InitializeComponent();
	}

	public async void GoBack(object sender, EventArgs args)
	{
        await Navigation.PopModalAsync();
    }

}

