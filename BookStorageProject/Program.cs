using System;
using System.Collections.Generic;

namespace BookStorageProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            BookStorage bookStorage = new BookStorage();
            library.Open(bookStorage);
        }
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
            Console.Clear();

            if (_books.Count > 0)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_books[i].Author} - {_books[i].Name} - {_books[i].Year} - {_books[i].Genre}");
                }

                Console.WriteLine();
            }
            else
                Console.WriteLine("В библиотеке нет ни одной книги.");
        }

        public void ShowBookByAuthor(string author)
        {
            int bookIndex = 0;
            Console.Clear();

            foreach (var book in _books)
            {
                if (author == book.Author)
                {
                    Console.WriteLine($"{bookIndex + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    bookIndex++;
                }
            }

            if (bookIndex == 0)
                Console.WriteLine("Автор не найден.\n");
        }

        public void ShowBookByName(string name)
        {
            int bookIndex = 0;
            Console.Clear();

            foreach (var book in _books)
            {
                if (name == book.Name)
                {
                    Console.WriteLine($"{bookIndex + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    bookIndex++;
                }
            }

            if (bookIndex == 0)
                Console.WriteLine("Название не найдено.\n");
        }

        public void ShowBookByYear(int year)
        {
            int bookIndex = 0;
            Console.Clear();

            foreach (var book in _books)
            {
                if (year == book.Year)
                {
                    Console.WriteLine($"{bookIndex + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    bookIndex++;
                }
            }

            if (bookIndex == 0)
                Console.WriteLine("Год не найден.\n");
        }

        public void ShowBookByGenre(string genre)
        {
            int bookIndex = 0;
            Console.Clear();

            foreach (var book in _books)
            {
                if (genre == book.Genre)
                {
                    Console.WriteLine($"{bookIndex + 1}. {book.Author} - {book.Name} - {book.Year} - {book.Genre}");
                    bookIndex++;
                }
            }

            if (bookIndex == 0)
                Console.WriteLine("Жанр не найден.\n");
        }

        public int GetStorageCount()
        {
            return _books.Count;
        }
    }

    class Library
    {
        public void Open(BookStorage bookStorage)
        {
            bool isOpen = true;
            string userInput = "";

            while (isOpen)
            {
                Console.WriteLine("Библиотека\n\n" +
                    "Меню:\n" +
                    "1 - Добавить книгу\n" +
                    "2 - Удалить книгу\n" +
                    "3 - Показать все книги\n" +
                    "4 - Выбрать книгу по...\n" +
                    "5 - Выход\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SendBookTo(bookStorage);
                        break;
                    case "2":
                        RemoveBookFrom(bookStorage);
                        break;
                    case "3":
                        bookStorage.ShowAllBooks();
                        break;
                    case "4":
                        SearchBookByFeature(bookStorage);
                        break;
                    case "5":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует.\n");
                        break;
                }
            }
        }



        private void SearchBookByFeature(BookStorage bookStorage)
        {
            Console.WriteLine("1 - ...автору книги\n" +
                "2 - ...названию книги\n" +
                "3 - ...году издания\n" +
                "4 - ...жанру\n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    SendAuthor(bookStorage);
                    break;
                case "2":
                    SendName(bookStorage);
                    break;
                case "3":
                    SendYear(bookStorage);
                    break;
                case "4":
                    SendGenre(bookStorage);
                    break;
                default:
                    Console.WriteLine("Такой команды не существует.\n");
                    break;
            }
        }

        private void SendAuthor(BookStorage bookStorage)
        {
            Console.Write("Введите автора: ");
            string author = Console.ReadLine();
            bookStorage.ShowBookByAuthor(author);
        }

        private void SendName(BookStorage bookStorage)
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            bookStorage.ShowBookByName(name);
        }

        private void SendYear(BookStorage bookStorage)
        {
            int yearNumber;
            Console.Write("Введите год: ");
            string year = Console.ReadLine();

            if (IsNumber(year))
            {
                yearNumber = Convert.ToInt32(year);
                bookStorage.ShowBookByYear(yearNumber);
            }
            else
                Console.WriteLine("Такого года не существует.");
        }

        private void SendGenre(BookStorage bookStorage)
        {
            Console.Write("Введите жанр: ");
            string genre = Console.ReadLine();
            bookStorage.ShowBookByGenre(genre);
        }

        private void SendBookTo(BookStorage bookStorage)
        {
            Console.Clear();
            Book book = CreateBook();
            bookStorage.AddBook(book);
            Console.Clear();
            Console.WriteLine($"Книга успешно добавлена в библиотеку.\n");
        }

        private Book CreateBook()
        {
            int yearNumber = 0;
            bool isWorking = true;

            Console.Write("Введите автора книги: ");
            string authorInput = Console.ReadLine();
            Console.Write("Введите название книги: ");
            string nameInput = Console.ReadLine();
            Console.Write("Введите год издания: ");

            while (isWorking)
            {
                string yearInput = Console.ReadLine();

                if (isCorrectYear(yearInput))
                {
                    yearNumber = Convert.ToInt32(yearInput);
                    isWorking = false;
                }
                else
                    Console.WriteLine("Такого года не существует. Попробуйте еще раз:");
            }

            Console.Write("Введите жанр книги: ");
            string genreInput = Console.ReadLine();

            Book book = new Book(authorInput, nameInput, yearNumber, genreInput);
            return book;
        }

        private bool isCorrectYear(string userInput)
        {
            int currentYear = 2022;
            int yearNumber = 0;

            if (IsNumber(userInput))
                yearNumber = Convert.ToInt32(userInput);

            return yearNumber > 0 && yearNumber <= currentYear;
        }

        private void RemoveBookFrom(BookStorage bookStorage)
        {
            Console.Clear();
            Console.Write("Введите номер книги для удаления из библиотеки:");
            string bookNumberInput = Console.ReadLine();

            if (IsNumber(bookNumberInput))
            {
                int bookNumber = Convert.ToInt32(bookNumberInput);

                if (bookNumber <= bookStorage.GetStorageCount())
                {
                    int bookIndex = bookNumber - 1;
                    Console.WriteLine("Книга удалена из библиотеки\n");
                    bookStorage.DeleteBook(bookIndex);
                }
                else
                    Console.WriteLine("Книги под таким номером не существует.\n");
            }
            else
                Console.WriteLine("Книги под таким номером не существует.\n");
        }

        private bool IsNumber(string userInput)
        {
            return int.TryParse(userInput, out int number);
        }
    }

    class Book
    {
        public string Author { get; private set; }
        public string Name { get; private set; }
        public int Year { get; private set; }
        public string Genre { get; private set; }

        public Book(string author, string name, int year, string genre)
        {
            Author = author;
            Name = name;
            Year = year;
            Genre = genre;
        }
    }
}
