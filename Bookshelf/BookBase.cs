namespace Bookshelf
{
    public abstract class BookBase : IBook
    {
        public abstract void SearchAuthor(string author);
        public abstract void SearchTitle(string title);
        public abstract void SearchGrade(int grade);
        public abstract void SearchDuplicate(string title);
        public abstract void AddBook(string author, string title, string grade);
        public delegate void BookAddedDelegate(object sender, EventArgs args);
        public abstract event BookAddedDelegate BookAdded;
    }
}
