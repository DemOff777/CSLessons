using System;
using System.Collections.Generic;

namespace Задание6_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library workLibrary = new Library();

            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandShowBookByArgument = "4";
            const string CommandExit = "5";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добавить книгу - {CommandAddBook}");
                Console.WriteLine($"Удалить книгу - {CommandRemoveBook}");
                Console.WriteLine($"Показать все книги - {CommandShowAllBooks}");
                Console.WriteLine($"Показать книгу по параметру - {CommandShowBookByArgument}");
                Console.WriteLine($"Выход - {CommandExit}");

                string userInput = Console.ReadLine();

                switch(userInput )
                {
                    case (CommandAddBook):
                        workLibrary.AddBook();
                        break;
                    case (CommandRemoveBook):
                        workLibrary.RemoveBook();
                        break;
                    case (CommandShowAllBooks):
                        workLibrary.ShowAllBooks();
                        break;
                    case (CommandShowBookByArgument):
                        workLibrary.ShowFindBook();
                        break;
                    case (CommandExit):
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неверный формат ввода");
                        break;
                }
            }
        }
    }

    class Book
    {
        public Book(int index, string name, string autor, int releaseYear)
        {
            Index = index;
            Name = name;
            Autor = autor;
            ReleaseYear = releaseYear;
        }

        public int Index { get; private set; }
        public string Name { get; private set; }
        public string Autor { get; private set; }
        public int ReleaseYear { get; private set; }

        public void ShowBook()
        {
            Console.WriteLine($"ID - {Index}, Название книги - {Name}, имя автора - {Autor}, год выпуска - {ReleaseYear}");
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        int _indexCounter = 1;

        public void AddBook()
        {
            Console.WriteLine("Введите название книги");
            string name = Console.ReadLine();

            Console.WriteLine("Введите имя автора");
            string autor = Console.ReadLine();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = GetNumber();

            Book book = new Book(_indexCounter, name, autor, releaseYear);

            _indexCounter++;

            _books.Add(book);
        }

        public void ShowFindBook()
        {
            const string CommandByName = "1";
            const string CommandByAutor = "2";
            const string CommandByReleaseYear = "3";

            Console.WriteLine("Введите параметр по которому будет осуществляться поиск:");
            Console.WriteLine($"По названию книги - {CommandByName}");
            Console.WriteLine($"По имени автора книги - {CommandByAutor}");
            Console.WriteLine($"По году выпуска книги - {CommandByReleaseYear}");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandByName:
                    ShowByName();
                    break;
                case CommandByAutor:
                    ShowByAutor();
                    break;
                case CommandByReleaseYear:
                    ShowByReleaseYear();
                    break;
                default:
                    Console.WriteLine("Неправильный формат ввода");
                    break;
            }
        }

        public void RemoveBook()
        {
            Console.WriteLine("Введите номер книги:");
            int userInput = GetNumber();

            if (userInput < _indexCounter)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Index == userInput)
                    {
                        _books.Remove(_books[i]);
                    }
                }

                Console.WriteLine("Книга удалена");
            }
            else
            {
                Console.WriteLine("Книга с таким номером не найдена");
            }
        }

        public void ShowByName()
        {
            List<Book> temporaryBooks = null;

            Console.WriteLine("Введите название книги");
            string userInput = Console.ReadLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Name == userInput)
                {
                    temporaryBooks.Add(_books[i]);
                }
            }

            if (temporaryBooks == null)
            {
                Console.WriteLine("Книг с таким названием не найдено");
            }
            else 
            {
                Console.WriteLine("Найдены книги:");

                ShowBooks(temporaryBooks);
            }
        }

        public void ShowByAutor()
        {
            List<Book> temporaryBooks = null;

            Console.WriteLine("Введите имя автора книги");
            string userInput = Console.ReadLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Autor == userInput)
                {
                    temporaryBooks.Add(_books[i]);
                }
            }

            if (temporaryBooks == null)
            {
                Console.WriteLine("Книг такого автора не найдено");
            }
            else
            {
                Console.WriteLine("Найдены книги:");

                ShowBooks(temporaryBooks);
            }
        }

        public void ShowByReleaseYear()
        {
            List<Book> temporaryBooks = null;

            Console.WriteLine("Введите год выпуска книги");
            int userInput = GetNumber();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].ReleaseYear == userInput)
                {
                    temporaryBooks.Add(_books[i]);
                }
            }

            if (temporaryBooks == null)
            {
                Console.WriteLine("Книг этого года выпуска не найдено");
            }
            else
            {
                Console.WriteLine("Найдены книги:");

                ShowBooks(temporaryBooks);
            }
        }

        public void ShowAllBooks()
        {
            ShowBooks(_books);
        }

        public void ShowBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                book.ShowBook();
            }
        }

        private int GetNumber()
        {
            int userInsert = 0;

            while (int.TryParse(Console.ReadLine(), out userInsert) == false)
            {
                Console.WriteLine("Неверный формат");
            }

            return userInsert;
        }
    }
}
