public class Dvd : Document
{
    //Attributes
    public int Time { get; set; } //Minutes

    //Constructor
    public Dvd(int code, string title, int year, string sector, bool isAvailable, string shelf, string author, int time) : base(code, title, year, sector, isAvailable, shelf, author)
    {
        Time = time;
    }
}