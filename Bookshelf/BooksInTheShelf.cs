using static Bookshelf.BookBase;

namespace Bookshelf
{
    public class BooksInTheShelf
    {
        public event BookAddedDelegate BookAdded;
        const string fileName = "books.txt";
        List<BookInMemory> books = new List<BookInMemory>();
        public void AddBookToShelf(BookInMemory book)
        {
            if (int.Parse(book.Grade) >= 0 && int.Parse(book.Grade) <= 10)
            {
                books.Add(new BookInMemory(book.Author, book.Title, book.Grade));
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
        public void Search()
        {
            foreach (var item in books)
            {
                Console.WriteLine(item.Author);
            }
        }
    }
}
