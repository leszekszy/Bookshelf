using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Bookshelf
{
    public class BookInMemory : BookBase
    {
        public BookInMemory(string author, string title, string grade)
        {
            this.Author = author;
            this.Title = title;
            this.Grade = grade;
        }
        public BookInMemory()
        {
        }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Grade { get; private set; }

        private List<string> books = new List<string>();
        public override event BookAddedDelegate BookAdded;

        public override void AddBook()
        {
            if (int.Parse(this.Grade) >= 0 && int.Parse(this.Grade) <= 10)
            {
                    books.Add($"{this.Author}/{this.Title}/{this.Grade}");
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

        public override void SearchDuplicate(string title)
        {
            foreach(string s in books)
            {
                string[] currentLine = s.Split("/");
                if (currentLine[1].ToUpper() == title.ToUpper())
                {
                    throw new Exception("Książka istnieje już w bazie");
                }
                else
                {
                    continue;
                }
            }
        }

        public override void SearchAuthor(string author)
        {
            bool isThere = false;
            foreach (string s in books)
            {
                string[] currentLine = s.Split("/");
                if (currentLine[0].ToUpper().Contains(author))
                {
                    Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
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

        public override void SearchGrade(int grade)
        {
            foreach (string s in books)
            {
                string[] currentLine = s.Split("/");
                if (int.Parse(currentLine[2]) == grade)
                {
                    Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                }
                else
                {
                    continue;
                }
            }
        }

        public override void SearchTitle(string title)
        {
            foreach (string s in books)
            {
                string[] currentLine = s.Split("/");
                if (currentLine[1].ToUpper().Contains(title))
                {
                    Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
