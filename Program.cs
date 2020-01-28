using System;
using console_library.Models;

namespace console_library
{
  class Program
  {
    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
    static void Main(string[] args)
    {
      Enum activeMenu = Menus.CheckoutBook;
      bool inLibrary = true;
      Console.Clear();
      Book whereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");

      Book ancillaryJustice = new Book("Ancillary Justice", "Ann Leckie");

      Book aART = new Book("An Absolutely Remarkable Thing", "Hank Green");

      Library myLibrary = new Library("715 S Capitol Blvd, Boise, ID 83702", "Boise Downtown Library");

      myLibrary.AddBook(whereTheSidewalkEnds);
      myLibrary.AddBook(ancillaryJustice);
      myLibrary.AddBook(aART);

      System.Console.WriteLine("Welcome to the Library!\n");

      while (inLibrary)
      {
        System.Console.WriteLine("\nAvailable books:");
        myLibrary.PrintBooks();

        System.Console.WriteLine("\nSelect a book number to checkout, (q)uit, or (r)eturn a book");
        string selection = Console.ReadLine();
        if (selection.ToLower() == "q")
        {
          inLibrary = false;
        }
        else
        {
          myLibrary.Checkout(selection);
        }
      }
    }
  }
}
