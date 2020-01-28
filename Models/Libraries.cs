using System.Collections.Generic;

namespace console_library.Models
{
  public class Library
  {
    public string Location { get; set; }
    public string Name { get; set; }

    private List<Book> Books { get; set; }
    private List<Book> CheckedOut { get; set; }

    public void AddBook(Book book)
    {
      Books.Add(book);
    }

    public void Checkout(string selection)
    {
      System.Console.Clear();
      Book selectedBook = ValidateBook(selection, Books);
      if (selectedBook == null)
      {
        System.Console.Clear();
        System.Console.WriteLine("Invalid Selection\n");
        return;
      }
      selectedBook.Available = false;
      CheckedOut.Add(selectedBook);
      Books.Remove(selectedBook);
      System.Console.WriteLine("Book successfully checked out! \nBooks checked out:");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        System.Console.WriteLine($"{i + 1}) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
      }

    }

    public void Return(string selection)
    {
      System.Console.Clear();
      Book selectedBook = ValidateBook(selection, Books);
      if (selectedBook == null)
      {
        System.Console.Clear();
        System.Console.WriteLine("Invalid Selection\n");
        return;
      }
      selectedBook.Available = true;
      CheckedOut.Remove(selectedBook);
      Books.Add(selectedBook);
      System.Console.WriteLine("Book successfully returned!");


    }

    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = 0;
      bool valid = int.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > bookList.Count)
      {
        return null;
      }
      return Books[bookIndex - 1];
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
      CheckedOut = new List<Book>();
    }
  }
}
