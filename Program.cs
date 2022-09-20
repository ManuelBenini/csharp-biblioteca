
using System.Linq;

List<User> users = new List<User>
{
    new User("Benini", "Manuel", "manuelbenini1905@gmail.com", "ciao19", "3913325333"),
    new User("John", "Snow", "cicciolino@gmail.com", "beppe19", "3913325333"),
    new User("artoris", "eleggis", "ercole@gmail.com", "nonloso", "3913325333"),
    new User("peppe", "Gianluca", "elementare@gmail.com", "wattson", "3913325333"),
};

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

Menu:

Console.WriteLine("Salve! Vuole effettuare una ricerca(0) , registrarsi?(1) o effettuare il login(2)");
int choice = Convert.ToInt32(Console.ReadLine());

if(choice == 0)
{
    Console.WriteLine("Vuole cercare un dvd(0) o un libro?(1)");
    int productChoice = Convert.ToInt32(Console.ReadLine());

    Search(productChoice);

    Console.WriteLine("Tornare al menù? Si(1) No(0)");
    if (Convert.ToInt32(Console.ReadLine()) == 1)
    {
        goto Menu;
    }
}
else if(choice == 1)
{
   User user = Registration();
   users.Add(user);

   Console.WriteLine($"Salve {user.Name} {user.Surname}! Che cosa vuole prenotare? Dvd(0) Libro(1)");
   int productChoice = Convert.ToInt32(Console.ReadLine());

    UserList(productChoice, user);

    Console.WriteLine("Tornare al menù? Si(1) No(0)");
    if (Convert.ToInt32(Console.ReadLine()) == 1)
    {
        goto Menu;
    }
}
else
{
    User user = Login();

    Console.WriteLine($"Salve {user.Name} {user.Surname}! Che cosa vuole prenotare? Dvd(0) Libro(1)");
    int productChoice = Convert.ToInt32(Console.ReadLine());

    UserList(productChoice, user);

    Console.WriteLine("Tornare al menù? Si(1) No(0)");
    if (Convert.ToInt32(Console.ReadLine()) == 1)
    {
        goto Menu;
    }
}

Object Search(int productChoice)
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

            return chosenDvd;
        }
        else
        {
            Console.WriteLine("Dvd non trovato");
            return chosenDvd;
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

            return chosenBook;
        }
        else
        {
            Console.WriteLine("Libro non trovato");
            return chosenBook;
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

User Login()
{
    Console.WriteLine("Inserire la password");
    string searchedPassword = Console.ReadLine();

    bool userFounded = false;
    User chosenUser = null;

    foreach (User user in users)
    {
        if (user.Password.ToLower().Contains(searchedPassword.ToLower()))
        {
            userFounded = true;
            chosenUser = user;
        }
    }
    if (userFounded)
    {
        Console.WriteLine("Utente trovato, ecco i suoi dettagli: ");

        Console.WriteLine($"Cognome: {chosenUser.Surname}");
        Console.WriteLine($"Nome: {chosenUser.Name}");
        Console.WriteLine($"Email: {chosenUser.Email}");
        Console.WriteLine($"Password: {chosenUser.Password}");
        Console.WriteLine($"Phone: {chosenUser.Phone}");

        return chosenUser;
    }
    else
    {
        Console.WriteLine("Utente non trovato");
        return chosenUser;
    }
}

void UserList(int productChoice, User user)
{
    if (productChoice == 0)
    {
        Dvd chosenDvd = (Dvd)Search(productChoice);

        if(chosenDvd != null)
        {
            if (chosenDvd.IsAvailable == true)
            {
                Console.WriteLine("Il dvd è prenotabile, procedere? Si(1) No(0)");
                int isUserBooking = Convert.ToInt32(Console.ReadLine());

                if (isUserBooking == 1)
                {
                    chosenDvd.IsAvailable = false;
                    user.DvdPush(chosenDvd);

                    Console.WriteLine($"la prenotazione del Dvd {chosenDvd.Title} è avvenuta con successo! Visualizzare la lista dei propri Dvd? Si(1) No(0)");
                    int toList = Convert.ToInt32(Console.ReadLine());

                    if (toList == 1)
                    {
                        Console.WriteLine("Ecco la lista dei Dvd da lei prenotati: ");
                        foreach (Dvd dvd in user.getDvds())
                        {
                            Console.WriteLine(dvd.Title);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Il Dvd non è prenotabile.");
            }
        }
    }
    else
    {
        Book chosenBook = (Book)Search(productChoice);

        if(chosenBook != null)
        {
            if (chosenBook.IsAvailable == true)
            {
                Console.WriteLine("Il libro è prenotabile, procedere? Si(1) No(0)");
                int isUserBooking = Convert.ToInt32(Console.ReadLine());

                if (isUserBooking == 1)
                {
                    chosenBook.IsAvailable = false;
                    user.BookPush(chosenBook);

                    Console.WriteLine($"la prenotazione del libro {chosenBook.Title} è avvenuta con successo! Visualizzare la lista dei propri libri? Si(1) No(0)");
                    int toList = Convert.ToInt32(Console.ReadLine());

                    if (toList == 1)
                    {
                        Console.WriteLine("Ecco la lista dei libri da lei prenotati: ");
                        foreach (Book book in user.getBooks())
                        {
                            Console.WriteLine(book.Title);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Il libro non è prenotabile.");
            }
        }
        
    }
}

