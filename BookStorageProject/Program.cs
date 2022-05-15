using System;
using System.Collections.Generic;

namespace BookStorageProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.Open();
        }
    }

    enum BookGenre
    {
        Fantastic,
        Poem,
        Detective,
        Study,
        History
    }

    class BookStorage
    {
        private List<Book> _books;

        public BookStorage()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void DeleteBook(int index)
        {
            _books.RemoveAt(index);
        }

        public void ShowAllBooks()
        {
            for(int i = 0; i<_books.Count; i++)
            {
                Console.Write($"{i+1}. {_books[i].Author} - {_books[i].Name} - {_books[i].Year} - {_books[i].Genre}");
            }
        }

        public void ShowBookByAuthor(string author)
        {
            foreach(var book in _books)
            {
                for(int i=0; i<_books.Count; i++)
                {
                    if (author == book.Author)
                        Console.WriteLine($"{i + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    else
                        Console.WriteLine("Автор не найден.");
                }
            }
        }

        public void ShowBookByName(string name)
        {
            foreach (var book in _books)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (name == book.Name)
                        Console.WriteLine($"{i + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    else
                        Console.WriteLine("Название книги не найдено.");
                }
            }
        }

        public void ShowBookByYear(int year)
        {
            foreach (var book in _books)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (year == book.Year)
                        Console.WriteLine($"{i + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    else
                        Console.WriteLine("Книги выпуска этого года не найдены.");
                }
            }
        }

        public void ShowBookByGenre(BookGenre genre)
        {
            foreach (var book in _books)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (genre == book.Genre)
                        Console.WriteLine($"{i + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    else
                        Console.WriteLine("Такой жанр не найден.");
                }
            }
        }
    }

    class Library
    {
        public Library()
        {
            BookStorage bookStorage = new BookStorage();
        }

        public void Open()
        {
            bool isOpen = true;
            string userInput = "";

            while (isOpen)
            {
                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Book
    {
        public string Author { get; private set; }
        public string Name { get; private set; }
        public int Year { get; private set; }
        public BookGenre Genre { get; private set; }

        public Book(string author, string name, int year, BookGenre genre)
        {
            Author = author;
            Name = name;
            Year = year;
            Genre = genre;
        }
    }
}
