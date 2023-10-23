using Mini_Project_Note_App.ViewModels;
using Mini_Project_Note_App.Model;

namespace Mini_Project_Note_App.Pages;

public partial class MainPage : ContentPage
{
	private ViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();

		viewModel = new ViewModel();

		this.BindingContext= viewModel;

		notesView.ItemsSource = viewModel.NotesCollection;
	}

    // Event handler for when a note is selected (tapped) from the list.
    private async void OnNoteSelected(object sender, EventArgs e)
    {
        // Check if the sender of this event is a Label and that its context is a Note.
        if (sender is VerticalStackLayout vert && vert.BindingContext is Note tappedNote)
        {
            // Set the CurrentNote in the ViewModel to the tappedNote.
            viewModel.CurrentNote = tappedNote;

            // Create a new MakeNotePage to edit/view the selected note and pass the ViewModel instance to it.
            var makeNotePage = new NotePage(viewModel);

            // Navigate to the MakeNotePage.
            await Navigation.PushAsync(makeNotePage);
        }
    }
}

