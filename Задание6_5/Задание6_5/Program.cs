using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Book(string name, string autor, int releaseYear)
        {
            Name = name;
            Autor = autor;
            ReleaseYear = releaseYear;
        }

        public string Name { get; set; }
        public string Autor { get; set; }
        public int ReleaseYear { get; set; }

        public void ShowBook()
        {
            Console.WriteLine($"Название книги - {Name}, имя автора - {Autor}, год выпуска - {ReleaseYear}");
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {
            Console.WriteLine("Введите название книги");
            string name = Console.ReadLine();

            Console.WriteLine("Введите имя автора");
            string autor = Console.ReadLine();

            Console.WriteLine("Введите год выпуска книги");
            int releaseYear = TryTakeInsert();

            Book book = new Book(name, autor, releaseYear);

            _books.Add(book);
        }

        public Book TryGetBook()
        {
            List<Book> books = _books;

            Book book = null;

            const string CommandByName = "1";
            const string CommandByAutor = "2";
            const string CommandByReleaseYear = "3";

            bool isBookGet = false;

            while (isBookGet == false)
            {
                Console.WriteLine("Введите параметр по которому будет осуществляться поиск:");
                Console.WriteLine($"По названию книги - {CommandByName}");
                Console.WriteLine($"По имени автора книги - {CommandByAutor}");
                Console.WriteLine($"По году выпуска книги - {CommandByReleaseYear}");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandByName:
                        book = SortListByName(ref isBookGet, ref books);
                        break;
                    case CommandByAutor:
                        book = SortListByAutor(ref isBookGet, ref books);
                        break;
                    case CommandByReleaseYear:
                        book = SortListByReleaseYear(ref isBookGet, ref books);
                        break;
                    default:
                        Console.WriteLine("Неправильный формат ввода");
                        break;
                }
            }

            return book;
        }

        public void RemoveBook()
        {
            _books.Remove(TryGetBook());
            Console.WriteLine("Книга удалена");
        }

        public Book SortListByName(ref bool isBookGet, ref List<Book> books)
        {
            List<Book> temporaryBooks = new List<Book>();
            
            Book book = null;

            Console.WriteLine("Введите название книги");
            string userInput = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Name == userInput)
                {
                    temporaryBooks.Add(books[i]);
                    isBookGet = true;
                }
            }

            books = temporaryBooks;

            if (isBookGet == false)
            {
                Console.WriteLine("Книг с таким названием не найдено");
            }
            else 
            {
                Console.WriteLine("Найдены книги:");

                foreach (Book findBook in books)
                {
                    findBook.ShowBook();
                }
            }

            return book = GetBook(ref isBookGet, books);
        }

        public Book SortListByAutor(ref bool isBookGet, ref List<Book> books)
        {
            List<Book> temporaryBooks = new List<Book>();

            Book book = null;

            Console.WriteLine("Введите имя автора книги");
            string userInput = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Autor == userInput)
                {
                    temporaryBooks.Add(books[i]);
                    isBookGet = true;
                }
            }

            books = temporaryBooks;

            if (isBookGet == false)
            {
                Console.WriteLine("Книг с таким названием не найдено");
            }
            else
            {
                Console.WriteLine("Найдены книги:");

                foreach (Book findBook in books)
                {
                    findBook.ShowBook();
                }
            }

            return book = GetBook(ref isBookGet, books);
        }

        public Book SortListByReleaseYear(ref bool isBookGet, ref List<Book> books)
        {
            List<Book> temporaryBooks = new List<Book>();

            Book book = null;

            Console.WriteLine("Введите год выпуска книги");
            int userInput = TryTakeInsert();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ReleaseYear == userInput)
                {
                    temporaryBooks.Add(books[i]);
                    isBookGet = true;
                }
            }

            books = temporaryBooks;

            if (isBookGet == false)
            {
                Console.WriteLine("Книг с таким названием не найдено");
            }
            else
            {
                Console.WriteLine("Найдены книги:");

                foreach (Book findBook in books)
                {
                    findBook.ShowBook();
                }
            }

            return book = GetBook(ref isBookGet, books);
        }



        public Book GetBook(ref bool isBookGet, List<Book> books)
        {
            Book book = null;

            string сommandContinueResearch = "1";
            string сommandGetBook = "2";

            Console.WriteLine($"Продолжить сортировку - {сommandContinueResearch}");
            Console.WriteLine($"Взять книгу - {сommandGetBook}");

            string userInput = Console.ReadLine();

            bool isInputCorect = false;

            while (isInputCorect == false)
            {
                if (userInput == сommandContinueResearch)
                {
                    isBookGet = false;
                    isInputCorect = true;
                }

                if (userInput == сommandGetBook)
                {
                    book = books[0];
                    isInputCorect = true;
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода");
                }

            }

            return book;
        }

        public void ShowFindBook()
        {
            Book book = null;
            book = TryGetBook();
            Console.WriteLine("Ваша книга:");
            book.ShowBook();
        }

        public void ShowAllBooks()
        {
            foreach (Book book in _books)
            {
                book.ShowBook();
            }
        }

        private int TryTakeInsert()
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
