namespace Bookshelf
{
    public class BookInMemory : BookBase
    {
        public override event BookAddedDelegate BookAdded;

        public override void AddBook(string author, string title, string grade)
        {
            throw new NotImplementedException();
        }

        public override void SearchAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public override void SearchDuplicate(string title)
        {
            throw new NotImplementedException();
        }

        public override void SearchGrade(int grade)
        {
            throw new NotImplementedException();
        }

        public override void SearchTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
