
using System.Linq;

List<Book> books = new List<Book>
{ 
    new Book(5534, "Lo Hobbit", 2019, "Fantasy", true, "AB", "J.R.R Tolkien", 540),
    new Book(2305, "Psicologo", 1980, "Drammatic", true, "CB", "Frank John", 230),
    new Book(2312, "Chthulu", 1970, "Fantasy", false, "CS", "Lovecraft", 999),
    new Book(4321, "Arthur", 2019, "Mitologia", false, "ERB", "Il Re", 250),
};

List<Dvd> dvds = new List<Dvd>
{
    new Dvd(1234, "Do You Breath?", 2019, "Rock", true, "as", "Frank Conley", 20),
    new Dvd(5321, "Summer Vibes", 1980, "Lo-Fi", true, "CB", "Cinegar John", 60),
    new Dvd(6742, "Worms Carves Your Mind", 1970, "Metal", false, "CS", "Lovecraft", 50),
    new Dvd(1111, "Jordie", 2019, "Storytelling", false, "ERB", "De Andrè", 110),
};

Console.WriteLine("Salve! Vuole effettuare una ricerca(0) o registrarsi?(1)");
int choice = Convert.ToInt32(Console.ReadLine());

if(choice == 0)
{
    Console.WriteLine("Vuole cercare un dvd(0) o un libro?(1)");
    int productChoice = Convert.ToInt32(Console.ReadLine());

    Search(productChoice);
}
else
{
   User user = Registration();

   Console.WriteLine($"Salve {user.Name + user.Surname}! Che cosa vuole prenotare? Libro(0) Dvd(1)");
   int productChoice = Convert.ToInt32(Console.ReadLine());

    Search(productChoice);
}

void Search(int productChoice)
{
    if (productChoice == 0)
    {
        Console.WriteLine("Inserire il nome del dvd");
        string searchedDvd = Console.ReadLine();

        bool dvdFounded = false;
        Dvd chosenDvd = null;

        foreach (Dvd dvd in dvds)
        {
            if (dvd.Title.ToLower().Contains(searchedDvd.ToLower()))
            {
                dvdFounded = true;
                chosenDvd = dvd;
            }
        }

        if (dvdFounded)
        {
            Console.WriteLine("Dvd trovato, ecco i suoi dettagli: ");

            Console.WriteLine($"Codice: {chosenDvd.Code}");
            Console.WriteLine($"Titolo: {chosenDvd.Title}");
            Console.WriteLine($"Anno di produzione: {chosenDvd.Year}");
            Console.WriteLine($"Genere: {chosenDvd.Sector}");
            Console.WriteLine($"Disponibile: {chosenDvd.IsAvailable}");
            Console.WriteLine($"Scaffale: {chosenDvd.Shelf}");
            Console.WriteLine($"Autore: {chosenDvd.Author}");
            Console.WriteLine($"Numero di pagine: {chosenDvd.Time}");
        }
        else
        {
            Console.WriteLine("Dvd non trovato");
        }
    }
    else
    {
        Console.WriteLine("Inserire il nome del libro");
        string searchedBook = Console.ReadLine();

        bool bookFounded = false;
        Book chosenBook = null;

        foreach (Book book in books)
        {
            if (book.Title.ToLower().Contains(searchedBook.ToLower()))
            {
                bookFounded = true;
                chosenBook = book;
            }
        }

        if (bookFounded)
        {
            Console.WriteLine("Libro trovato, ecco i suoi dettagli: ");

            Console.WriteLine($"Codice: {chosenBook.Code}");
            Console.WriteLine($"Titolo: {chosenBook.Title}");
            Console.WriteLine($"Anno di produzione: {chosenBook.Year}");
            Console.WriteLine($"Genere: {chosenBook.Sector}");
            Console.WriteLine($"Disponibile: {chosenBook.IsAvailable}");
            Console.WriteLine($"Scaffale: {chosenBook.Shelf}");
            Console.WriteLine($"Autore: {chosenBook.Author}");
            Console.WriteLine($"Numero di pagine: {chosenBook.NumberOfPages}");
        }
        else
        {
            Console.WriteLine("Libro non trovato");
        }
    }
}

User Registration()
{
    int userDataAccepted = 0;
    User registedUser = new User();
    do
    {
        Console.WriteLine("Inserire cognome");
        string surname = Console.ReadLine();

        Console.WriteLine("Inserire nome");
        string name = Console.ReadLine();

        Console.WriteLine("Inserire email");
        string email = Console.ReadLine();

        Console.WriteLine("Inserire password");
        string password = Console.ReadLine();

        Console.WriteLine("Inserire numero di telefono");
        string phone = Console.ReadLine();

        registedUser = new User(surname, name, email, password, phone);

        Console.WriteLine("Ecco il riepilogo dei dati da lei inseriti: ");

        Console.WriteLine($"Cognome: {registedUser.Surname}");
        Console.WriteLine($"Nome: {registedUser.Name}");
        Console.WriteLine($"Email: {registedUser.Email}");
        Console.WriteLine($"Password: {registedUser.Password}");
        Console.WriteLine($"Phone: {registedUser.Phone}");

        Console.WriteLine("Le vanno bene? Si(1) No(0)");
        userDataAccepted = Convert.ToInt32(Console.ReadLine());

    } while (userDataAccepted == 0);

    return registedUser;
}

