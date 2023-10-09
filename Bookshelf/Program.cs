using Bookshelf;
using System.Diagnostics;
using static Bookshelf.BookBase;

var booksInMemory = new BooksInMemory();
booksInMemory.BookAdded += BookDataAdded;

var booksInFile = new BooksInFile();
booksInFile.BookAdded += BookDataAdded;

bool CloseApp = false;

var book = new Book();

Menu();

void BookDataAdded(object sender, EventArgs args)
{
    Console.WriteLine();
    Console.WriteLine("+ Dodano nową książkę");
}
void Menu()
{
    while (!CloseApp)

    {
        Console.WriteLine();
        Console.WriteLine("1. Operuj na Pamięci");
        Console.WriteLine("2. Operuj na Pliku");
        Console.WriteLine("X. Zakończ");
        Console.WriteLine();
        var input = Console.ReadLine().ToUpper();
        switch (input)
        {
            case "1":
                InMemory();
                break;
            case "2":
                SaveIt();
                break;
            case "X":
                CloseApp = true;
                break;
            default:
                Console.WriteLine("Nieprawidłowa Operacja");
                continue;
        }
    }
}
void InMemory()
{
    while (!CloseApp)
    {
        Console.WriteLine();
        Console.WriteLine("1. Dodaj Książkę");
        Console.WriteLine("2. Wyszukaj Książki Według Autora");
        Console.WriteLine("3. Wyszukaj Książki Według Oceny");
        Console.WriteLine("4. Wyszukaj Książkę Po Tytule");
        Console.WriteLine("X. Wstecz");
        Console.WriteLine();
        var input = Console.ReadLine().ToUpper();
        switch (input)
        {
            case "1":
                AddBookToMemory();
                break;
            case "2":
                SearchBookByAuthorInMemory();
                break;
            case "3":
                SearchBookByGradeInMemory();
                break;
            case "4":
                SearchBookByTitleInMemory();
                break;
            case "X":
                Menu();
                break;
            default:
                Console.WriteLine("Nieprawidłowa Operacja");
                continue;
        }
    }
}

void SaveIt()
{
    while (!CloseApp)
    {
        Console.WriteLine();
        Console.WriteLine("1. Dodaj Książkę");
        Console.WriteLine("2. Wyszukaj Książki Według Autora");
        Console.WriteLine("3. Wyszukaj Książki Według Oceny");
        Console.WriteLine("4. Wyszukaj Książkę Po Tytule");
        Console.WriteLine("X. Wstecz");
        Console.WriteLine();
        var input = Console.ReadLine().ToUpper();
        switch (input)
        {
            case "1":
                AddBookToFile();
                break;
            case "2":
                SearchBookByAuthorInFile();
                break;
            case "3":
                SearchBookByGradeInFile();
                break;
            case "4":
                SearchBookByTitleInFile();
                break;
            case "X":
                Menu();
                break;
            default:
                Console.WriteLine("Nieprawidłowa Operacja");
                continue;
        }
    }
}
void AddBookToFile()
{
    Console.WriteLine();
    Console.Write("Autor: ");
    string author = Console.ReadLine();
    Console.Write("Tytuł: ");
    string title = Console.ReadLine();
    Console.Write("Ocena (1-10) : ");
    string grade = Console.ReadLine();
    var book = new Book(author, title, grade);
    try
    {
        booksInFile.SearchDuplicate(title);
        booksInFile.AddBook(book);
    }
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine($"Exception handled / {e.Message}");
    }
}
void SearchBookByAuthorInFile()
{
    Console.WriteLine();
    Console.Write("Wpisz autora: ");
    var author = Console.ReadLine().ToUpper();
    Console.WriteLine();
    booksInFile.SearchAuthor(author);
}

void SearchBookByGradeInFile()
{
    Console.WriteLine();
    Console.Write("Wpisz ocenę: ");
    var grade = Console.ReadLine();
    Console.WriteLine();
    //book.SearchGrade(int.Parse(grade));
}

void SearchBookByTitleInFile()
{
    Console.WriteLine();
    Console.Write("Wpisz tytuł: ");
    var title = Console.ReadLine().ToUpper();
    Console.WriteLine();
    //book.SearchTitle(title);
}

// Metody InMemory

void AddBookToMemory()
{
    Console.WriteLine();
    Console.Write("Autor: ");
    string author = Console.ReadLine();
    Console.Write("Tytuł: ");
    string title = Console.ReadLine();
    Console.Write("Ocena (1-10) : ");
    string grade = Console.ReadLine();
    var book = new Book(author, title, grade);
    try
    {
        booksInMemory.SearchDuplicate(title);
        booksInMemory.AddBook(book);
    }
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine($"Exception handled / {e.Message}");
    }
}
void SearchBookByAuthorInMemory()
{
    Console.WriteLine();
    Console.Write("Wpisz autora: ");
    var author = Console.ReadLine();
    Console.WriteLine();
    booksInMemory.SearchAuthor(author);
}

void SearchBookByGradeInMemory()
{
    Console.WriteLine();
    Console.Write("Wpisz ocenę: ");
    var grade = Console.ReadLine();
    Console.WriteLine();
    booksInMemory.SearchGrade(int.Parse(grade));
}

void SearchBookByTitleInMemory()
{
    Console.WriteLine();
    Console.Write("Wpisz tytuł: ");
    var title = Console.ReadLine();
    Console.WriteLine();
    booksInMemory.SearchTitle(title);
}