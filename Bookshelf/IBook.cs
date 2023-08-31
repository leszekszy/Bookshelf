using static bookshelf.BookBase;

namespace bookshelf
{
    public interface IBook
    {
        void SearchAuthor(string author);
        void SearchTitle(string title);
        void SearchGrade(int grade);
        void SearchDuplicate(string title);
        void AddBook(string author, string title, string grade);
        event BookAddedDelegate BookAdded;
    }
}
