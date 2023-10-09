using System.Diagnostics;

namespace Bookshelf
{
    public class BooksInMemory : BookBase
    {
        public override event BookAddedDelegate BookAdded;
        private List<Book> books = new List<Book>();
        public override void AddBook(Book book)
        {
            if (int.Parse(book.Grade) >= 0 && int.Parse(book.Grade) <= 10)
            {
                books.Add(new Book(book.Author, book.Title, book.Grade));
                if (BookAdded != null)
                {
                    BookAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wpisz ocenę w przedziale 1-10");
            }
        }
        public override void SearchAuthor(string author)
        {
            bool isThere = false;
            foreach (var book in books)
            {
                if (book.Author.ToUpper().Contains(author.ToUpper()))
                {
                    Console.WriteLine($"Autor: {book.Author} | Tytuł: {book.Title} | Ocena: {book.Grade}");
                    isThere = true;
                }
                else
                {
                    continue;
                }
            }
            if (!isThere)
            {
                Console.WriteLine("Autora nie ma w bazie");
            }
            else
            {
            }
        }

        public override void SearchTitle(string title)
        {
            foreach (var book in books)
            {
                if (book.Title.ToUpper().Contains(title.ToUpper()))
                {
                    Console.WriteLine($"Autor: {book.Author} | Tytuł: {book.Title} | Ocena: {book.Grade}");
                }
                else
                {
                    continue;
                }
            }
        }

        public override void SearchGrade(int grade)
        {
            foreach (var book in books)
            {
                if (int.Parse(book.Grade) == grade)
                {
                    Console.WriteLine($"Autor: {book.Author} | Tytuł: {book.Title} | Ocena: {book.Grade}");
                }
                else
                {
                    continue;
                }
            }
        }

        public override void SearchDuplicate(string title)
        {
            foreach (var book in books)
            {
                if (book.Title.ToUpper() == title.ToUpper())
                {
                    throw new Exception("Książka istnieje już w bazie");
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
