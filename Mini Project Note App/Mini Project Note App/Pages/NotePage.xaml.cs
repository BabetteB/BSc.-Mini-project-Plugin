using Mini_Project_Note_App.ViewModels;

namespace Mini_Project_Note_App.Pages;

public partial class NotePage : ContentPage
{
	private readonly ViewModel viewModel;

	public NotePage(ViewModel vm)
	{
		InitializeComponent();

		this.viewModel = vm;

		BindingContext = viewModel;

        titleEntry.Text = viewModel.CurrentNote.Title;
        contentEditor.Text = viewModel.CurrentNote.Content;
	}

    // Event handler for when the back button is clicked.
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Check if there's a selected note in the ViewModel.
        // This should usually be the case, but it's good to have a safety check.
        if (viewModel.CurrentNote == null)
        {
            return; // Exit the method if there's no note.
        }

        // Update the title and content of the current note based on user input.
        viewModel.CurrentNote.Title = titleEntry.Text;
        viewModel.CurrentNote.Content = contentEditor.Text;

        // Use the ViewModel to add or update the note in the collection.
        viewModel.AddOrUpdateNote(viewModel.CurrentNote);

        // Navigate back to the previous page (MainPage in this case).
        await Navigation.PopAsync();
    }
}