using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "1234",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Author = "HICTOR HUGO";
            book.Title = "SEFILLER";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private DateTime _lastEdited;
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        private string _isbn;
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}", Isbn, Title, Author, _lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdit)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdit;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}