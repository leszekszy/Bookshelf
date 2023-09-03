using Bookshelf;

const string fileName = "books.txt";

bool CloseApp = false;

var book = new Book();
book.BookAdded += BookDataAdded;
var bookInMemory = new BookInMemory();
bookInMemory.BookAdded += BookDataAdded;

Menu();

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
                AddBookToBookShelfInMemory();
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
                AddBookToBookShelf();
                break;
            case "2":
                SearchBookByAuthor();
                break;
            case "3":
                SearchBookByGrade();
                break;
            case "4":
                SearchBookByTitle();
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
void AddBookToBookShelf()
{
    Console.Write("Autor: ");
    string author = Console.ReadLine();
    Console.Write("Tytuł: ");
    string title = Console.ReadLine();
    Console.Write("Ocena (1-10) : ");
    string grade = Console.ReadLine();
    try
    {
        book.SearchDuplicate(title);
        book.AddBook(author, title, grade);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception handled / {e.Message}");
    }
}
void BookDataAdded(object sender, EventArgs args)
{
    Console.WriteLine();
    Console.WriteLine("+ Dodano nową książkę");
}

void SearchBookByAuthor()
{
    Console.Write("Wpisz autora: ");
    var author = Console.ReadLine().ToUpper();
    Console.WriteLine();
    book.SearchAuthor(author);
}

void SearchBookByGrade()
{
    Console.Write("Wpisz ocenę: ");
    var grade = Console.ReadLine();
    Console.WriteLine();
    book.SearchGrade(int.Parse(grade));
}

void SearchBookByTitle()
{
    Console.Write("Wpisz tytuł: ");
    var title = Console.ReadLine().ToUpper();
    Console.WriteLine();
    book.SearchTitle(title);
}

// Metody InMemory

void AddBookToBookShelfInMemory()
{
    Console.Write("Autor: ");
    string author = Console.ReadLine();
    Console.Write("Tytuł: ");
    string title = Console.ReadLine();
    Console.Write("Ocena (1-10) : ");
    string grade = Console.ReadLine();
    try
    {
        bookInMemory.SearchDuplicate(title);
        bookInMemory.AddBook(author, title, grade);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception handled / {e.Message}");
    }
}
void SearchBookByAuthorInMemory()
{
    Console.Write("Wpisz autora: ");
    var author = Console.ReadLine().ToUpper();
    Console.WriteLine();
    bookInMemory.SearchAuthor(author);
}

void SearchBookByGradeInMemory()
{
    Console.Write("Wpisz ocenę: ");
    var grade = Console.ReadLine();
    Console.WriteLine();
    bookInMemory.SearchGrade(int.Parse(grade));
}

void SearchBookByTitleInMemory()
{
    Console.Write("Wpisz tytuł: ");
    var title = Console.ReadLine().ToUpper();
    Console.WriteLine();
    bookInMemory.SearchTitle(title);
}