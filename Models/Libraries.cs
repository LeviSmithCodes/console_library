using System.Collections.Generic;

namespace console_library.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }

    private List<Book> Books { get; set; }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
      }
    }
    // constructor 
    public Library(string location, string name)
    {
      Location = location;
      Name = name;
      Books = new List<Book>();
    }
  }
}
