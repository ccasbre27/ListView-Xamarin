using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListViewRUI.Model;
using ReactiveUI;
using Xamarin.Forms;

namespace ListViewRUI
{
    public class BookViewModel : ReactiveObject
    {
        private ObservableCollection<Book> _books;
        public ICommand TapCommand { get; set; }

        public ObservableCollection<Book> Books
        {
            get => _books;
            set => this.RaiseAndSetIfChanged(ref _books, value);
        }

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>();
            TapCommand = new Command<object>(OnTapped);
           
            for (int i = 0; i < 10; i++)
            {
                Books.Add(new Book()
                {
                    Title = $"name {i}"
                });
            }
        }

        private void OnTapped(object obj)
        {
            var book = obj as Book;
            App.Current.MainPage.DisplayAlert("Message", $"Item: {book.Title}", "Ok");
        }
    }
}
