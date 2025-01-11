using System.ComponentModel.Design;

abstract class LibraryItem
{
    public string title { get; set; }
    public string author { get; set; }
    public DateTime publication_date { get; set; }
    public bool available { get; set; }

    public LibraryItem(string title, string author, DateTime publication_date, bool available)
    {
        this.title = title;
        this.author = author;
        this.publication_date = publication_date;
        this.available = available;
    }
    public abstract void Checkout();
    public abstract void return_item();

}

class Book: LibraryItem
{
    public string genre { get; set; }

    public Book(string genre, string title, string author, DateTime publication_date, bool available) : base( title,  author,  publication_date,  available)
    {
        this.genre = genre;
    }

    public override void Checkout()
    {
        if (available)
        {
          
            Console.WriteLine($"Book {title} is available. You can checkout it");
            available = false;
        }
        else
        {
            Console.WriteLine($"Book {title} is not available.");
        }
    }
    public override void return_item()
    {
        if (!available)
        {
            Console.WriteLine($"Book '{title}' returned successfully.");
            available = true;
        }
        else
        {
            Console.WriteLine($"Book '{title}' is already available");
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book("Fiction", "The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10), true);

        // Test checkout and return functionality
        book1.Checkout();
        book1.return_item();
        book1.return_item();
    }
}