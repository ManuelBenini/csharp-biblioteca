
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

List<Loan> loans = new List<Loan>
{
    new Loan(users[0], "20/09/2022", "27/09/2022"),
    new Loan(users[0], "23/09/2022", "31/10/2022"),
    new Loan(users[1], "20/09/2022", "27/09/2022"),
    new Loan(users[2], "23/09/2022", "31/10/2022"),
    new Loan(users[3], "23/09/2022", "31/10/2022"),
};

loans[0].Book = books[0];
loans[1].Dvd = dvds[1];
loans[2].Dvd = dvds[3];
loans[3].Book = books[2];

Console.WriteLine(typeof(Dvd));

Menu:

Console.WriteLine("Salve! Vuole effettuare una ricerca(0) , registrarsi?(1) o effettuare il login(2)");
int choice = Convert.ToInt32(Console.ReadLine());

if(choice == 0)
{
    Console.WriteLine("Vuole cercare un dvd(0), un libro?(1) oppure i prestiti di un utente?(2)");
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

    Console.WriteLine($"Salve {user.Name} {user.Surname}! Vuole prenotare? Dvd(0) Libro(1) || Lista prenotazioni(2)");
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
    //RICERCA DVD
    if (productChoice == 0)
    {
        Console.WriteLine("Effettuare la ricerca sul titolo(0) o sul codice?(1)");
        int searchParameter = Convert.ToInt32(Console.ReadLine());

        bool dvdFounded = false;
        Dvd chosenDvd = null;

        if (searchParameter == 0)
        {
            Console.WriteLine("Inserire il titolo del dvd");
            string searchedDvd = Console.ReadLine();

            foreach (Dvd dvd in dvds)
            {
                if (dvd.Title.ToLower().Contains(searchedDvd.ToLower()))
                {
                    dvdFounded = true;
                    chosenDvd = dvd;
                }
            }
        }
        else
        {
            Console.WriteLine("Inserire il codice del dvd");
            int searchedDvd = Convert.ToInt32(Console.ReadLine());

            foreach (Dvd dvd in dvds)
            {
                if (dvd.Code == searchedDvd)
                {
                    dvdFounded = true;
                    chosenDvd = dvd;
                }
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
            Console.WriteLine($"Durata del dvd: {chosenDvd.Time}");

            return chosenDvd;
        }
        else
        {
            Console.WriteLine("Dvd non trovato");
            return chosenDvd;
        }
    }
    //RICERCA LIBRI
    else if(productChoice == 1)
    {

        Console.WriteLine("Effettuare la ricerca sul titolo(0) o sul codice?(1)");
        int searchParameter = Convert.ToInt32(Console.ReadLine());

        bool bookFounded = false;
        Book chosenBook = null;

        if (searchParameter == 0)
        {
            Console.WriteLine("Inserire il titolo del libro");
            string searchedBook = Console.ReadLine();

            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(searchedBook.ToLower()))
                {
                    bookFounded = true;
                    chosenBook = book;
                }
            }
        }
        else
        {
            Console.WriteLine("Inserire il codice del libro");
            int searchedBook = Convert.ToInt32(Console.ReadLine());

            foreach (Book book in books)
            {
                if (book.Code == searchedBook)
                {
                    bookFounded = true;
                    chosenBook = book;
                }
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
    //RICERCA PRENOTAZIONI
    else
    {
        Console.WriteLine("Inserire nome utente");
        string searchedUserName = Console.ReadLine();

        Console.WriteLine("Inserire cognome utente");
        string searchedUserSurname = Console.ReadLine();

        bool userFounded = false;
        List<Loan> userLoans = new List<Loan>();

        foreach (Loan loan in loans)
        {
            if (loan.User.Name.ToLower().Contains(searchedUserName.ToLower()))
            {
                if (loan.User.Surname.ToLower().Contains(searchedUserSurname.ToLower()))
                {
                    userFounded = true;
                    userLoans.Add(loan);
                }
            }
        }
        if(userLoans.Count > 0)
        {
            Console.WriteLine($"Utente: {userLoans[0].User.Name} {userLoans[0].User.Surname}");
            foreach (Loan loan in userLoans)
            {
                if(loan.Dvd != null)
                {
                    Console.WriteLine($"Dvd: {loan.Dvd.Title}");
                }
                else
                {
                    Console.WriteLine($"Libro: {loan.Book.Title}");
                }
                Console.WriteLine($"Dal: {loan.LoanStart}");
                Console.WriteLine($"al: {loan.LoanEnd}");
            }
            return userLoans[0];
        }
        else
        {
            Console.WriteLine("L'utente non ha nessun prestito.");
            Loan loan = new Loan();
            return loan;
        }
    }
}

User Registration()
{
    int userDataAccepted = 0;
    User registedUser;
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
                    loans.Add(new Loan(user, DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString()));
                    loans[loans.Count - 1].Dvd = chosenDvd;

                    Console.WriteLine($"la prenotazione del Dvd {chosenDvd.Title} è avvenuta con successo! Visualizzare la lista dei propri Dvd? Si(1) No(0)");
                    int toList = Convert.ToInt32(Console.ReadLine());

                    if (toList == 1)
                    {
                        GetLoans(user, "dvd");
                    }
                }
            }
            else
            {
                Console.WriteLine("Il Dvd non è prenotabile.");
            }
        }
    }
    else if(productChoice == 1)
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
                    loans.Add(new Loan(user, DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString()));
                    loans[loans.Count - 1].Book = chosenBook;

                    Console.WriteLine($"la prenotazione del libro {chosenBook.Title} è avvenuta con successo! Visualizzare la lista dei propri libri? Si(1) No(0)");
                    int toList = Convert.ToInt32(Console.ReadLine());

                    if (toList == 1)
                    {
                        GetLoans(user, "libri");
                    }
                }
            }
            else
            {
                Console.WriteLine("Il libro non è prenotabile.");
            }
        }

    }
    else
    {
        Console.WriteLine($"Di cosa vuole mostrare le prenotazioni? Dvd(0) Libri(1)");
        int searchType = Convert.ToInt32(Console.ReadLine());

        if(searchType == 0)
        {
            GetLoans(user, "dvd");
        }
        else
        {
            GetLoans(user, "libri");
        }
    }
}

void GetLoans(User user, string testo)
{
    Console.WriteLine($"Ecco la lista dei {testo} da lei prenotati: ");
    bool LoanExist = false;
    foreach (Loan loan in loans)
    {
        if (loan.User.Name == user.Name)
        {
            if(testo == "dvd")
            {
                if (loan.Dvd != null)
                {
                    Console.WriteLine(loan.Dvd.Title);
                    LoanExist = true;
                }
            }
            else
            {
                if (loan.Book != null)
                {
                    Console.WriteLine(loan.Book.Title);
                    LoanExist = true;
                }
            }
            
        }
    }
    if (!LoanExist)
    {
        Console.WriteLine($"Non vi sono prenotazioni di {testo} a suo nome.");
    }
}

