using System.Collections.ObjectModel;
using System.ComponentModel;

using System.IO;

namespace Mini_Project_Note_App;
public class MyItem
{
    public string ItemName { get; set; }
}
// A viewmodel to hold items for the list
public class MyListPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<MyItem> _myItems;

    public ObservableCollection<MyItem> MyItems
    {
        get { return _myItems; }
        set
        {
            _myItems = value;
            OnPropertyChanged(nameof(MyItems));
        }
    }

    public MyListPageViewModel()
    {
        MyItems = new ObservableCollection<MyItem>();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class MainPage : ContentPage
{

    //int count = 0;

    public MainPage()
	{
		InitializeComponent();
		// For list of items
        BindingContext = new MyListPageViewModel();

        string filePath = "Resources/Images/trash.png";
        bool fileExists = File.Exists(filePath);

        if (fileExists)
        {
            Console.WriteLine("The file exists at the specified path.");
        }
        else
        {
            Console.WriteLine("The file does not exist at the specified path.");
        }

    }

    private void OnAddItemClicked(object sender, EventArgs e)
    {

        var viewModel = (MyListPageViewModel)BindingContext;
        var newItemName = newItemEntry.Text; // Accessing the first declaration
        viewModel.MyItems.Add(new MyItem { ItemName = newItemName });
        newItemEntry.Text = string.Empty;
    }

}

