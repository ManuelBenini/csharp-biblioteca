public class Book : Document
{
    //Attributes
    public int NumberOfPages { get; set; }

    //Constructor
    public Book(int code, string title, int year, string sector, bool isAvailable, string shelf, string author, int numberOfPages) : base(code, title, year, sector, isAvailable, shelf, author)
    {
        NumberOfPages = numberOfPages;
    }
}
