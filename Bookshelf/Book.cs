using System.Diagnostics;

namespace Bookshelf
{
    public class Book : BookBase
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
        public override event BookAddedDelegate BookAdded;
        const string fileName = "books.txt";
        public override void AddBook()
        {
            if (int.Parse(this.Grade) >= 0 && int.Parse(this.Grade) <= 10)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{this.Author}/{this.Title}/{this.Grade}");
                    if (BookAdded != null)
                    {
                        BookAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Wpisz ocenę w przedziale 1-10");
            }
        }
        public override void SearchDuplicate(string title)
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] currentLine = line.Split("/");
                        if (currentLine[1].ToUpper() == title.ToUpper())
                        {
                            throw new Exception("Książka istnieje już w bazie");
                        }
                        else
                        {
                            line = reader.ReadLine();
                        }
                    }
                }
            }
        }
        public override void SearchAuthor(string author)
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] currentLine = line.Split("/");
                        if (currentLine[0].ToUpper().Contains(author))
                        {
                            Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                        }
                        else
                        {
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public override void SearchGrade(int grade)
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] currentLine = line.Split("/");
                        if (int.Parse(currentLine[2]) == grade)
                        {
                            Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                        }
                        else
                        {
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }

        public override void SearchTitle(string title)
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] currentLine = line.Split("/");
                        if (currentLine[1].ToUpper().Contains(title))
                        {
                            Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                        }
                        else
                        {
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
