using System.Diagnostics;

namespace Bookshelf
{
    public class BooksInFile : BookBase
    {
        public override event BookAddedDelegate BookAdded;
        const string fileName = "books.txt";
        public override void AddBook(Book book)
        {
            if (int.Parse(book.Grade) >= 0 && int.Parse(book.Grade) <= 10)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{book.Author}/{book.Title}/{book.Grade}");
                }
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
                bool isThere = false;
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] currentLine = line.Split("/");
                        if (currentLine[0].ToUpper().Contains(author.ToUpper()))
                        {
                            Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
                            line = reader.ReadLine();
                            isThere = true;
                        }
                        else
                        {
                            line = reader.ReadLine();
                        }
                    }
                    if (!isThere)
                    {
                        Console.WriteLine("Autora nie ma w bazie");
                    }
                }
            }
        }

        public override void SearchGrade(int grade)
        {
            //foreach (string s in books)
            //{
            //    string[] currentLine = s.Split("/");
            //    if (int.Parse(currentLine[2]) == grade)
            //    {
            //        Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
        }

        public override void SearchTitle(string title)
        {
            //foreach (string s in books)
            //{
            //    string[] currentLine = s.Split("/");
            //    if (currentLine[1].ToUpper().Contains(title.ToUpper()))
            //    {
            //        Console.WriteLine($"Autor: {currentLine[0]} | Tytuł: {currentLine[1]} | Ocena: {currentLine[2]}");
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
        }
    }
}
