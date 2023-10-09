using static Bookshelf.BookBase;

namespace Bookshelf
{
    public interface IBook
    {
        void SearchAuthor(string author);
        void SearchTitle(string title);
        void SearchGrade(int grade);
        void SearchDuplicate(string title);
        void AddBook(Book book);
        event BookAddedDelegate BookAdded;
    }
}
