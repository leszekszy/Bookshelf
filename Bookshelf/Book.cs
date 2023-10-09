namespace Bookshelf
{
    public class Book// : BookBase
    {
        public Book(string author, string title, string grade)
        {
            this.Author = author;
            this.Title = title;
            this.Grade = grade;
        }
        public Book()
        {

        }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Grade { get; private set; }
    }
}
