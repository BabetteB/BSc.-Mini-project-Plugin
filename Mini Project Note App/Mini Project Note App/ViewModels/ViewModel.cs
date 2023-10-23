using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Mini_Project_Note_App.Model;

namespace Mini_Project_Note_App.ViewModels
{
    public class ViewModel
    {
        public ObservableCollection<Note> NotesCollection { get; set; }

        private Note _currentNote;

        // Property for the current note. When set, it raises the OnPropertyChanged event to notify the UI of changes.
        public Note CurrentNote
        {
            get => _currentNote;
            set
            {
                _currentNote = value;
                OnPropertyChanged();
            }
        }

        public ViewModel()
        {
            NotesCollection = new ObservableCollection<Note>
            {
                new Note { Id = 1, Title = "Testing", Content = "Hello", Color = "#ddefe8"},
                new Note { Id = 2, Title = "Testing2", Content = "Hello", Color = "#a0dcff"},
                new Note { Id = 3, Title = "Testing4", Content = "Hello", Color = "#9dd4cf"},
                new Note { Id = 4, Title = "Testing3", Content = "Hello", Color = "#62b5e5"},
            };
        }

        // Raises the PropertyChanged event. Utilizes the CallerMemberName attribute to automatically obtain the property name of the caller.
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Event to notify any subscribers (typically the UI) about changes to a property.
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to add a new note or update an existing one in the NotesCollection.
        public void AddOrUpdateNote(Note note)
        {
            var existingNote = NotesCollection.FirstOrDefault(n => n.Id == note.Id);
            if (existingNote != null)
            {
                var index = NotesCollection.IndexOf(existingNote);
                NotesCollection[index] = note;
            }
            else
            {
                NotesCollection.Add(note);
            }
        }
    }
}
