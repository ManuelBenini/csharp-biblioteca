public class User
{
    //Attributes
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }

    //Constructor
    public User(string surname, string name, string email, string password, string phone)
    {
        Surname = surname;
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
    }

    public User()
    {

    }
}
