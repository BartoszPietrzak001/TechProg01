using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Book book = new Book(1, "The Shining", "King, Stephen");
            Book book1 = new Book(2, "Symfonia C++", "Grębosz, Jerzy");
            Book book2 = new Book(3, "Pet Cemetery", "King, Stephen");
            Rent rent = new Rent(true, "02/05/2016");

            book.r = rent;

            Console.WriteLine(book.returnBook());

            //add data to repository
            Console.WriteLine("Adding a reader to the repository...");
            dr.Create(r);
            Console.WriteLine("Adding a book to the repository...");
            dr.Create(book);
            Console.WriteLine("Adding a book to the repository...");
            dr.Create(book1);
            Console.WriteLine("Adding a book to the repository...");
            dr.Create(book2);


            Console.WriteLine("Adding a book to the reader...");

            if (dr.Read(r) == r && dr.Read(book) == book) dr.Read(r).addBook(dr.Read(book));
            if (dr.Read(r) == r && dr.Read(book1) == book1) dr.Read(r).addBook(dr.Read(book1));
            if (dr.Read(r) == r && dr.Read(book2) == book2) dr.Read(r).addBook(dr.Read(book2));

            Dictionary<int, Book> bks = new Dictionary<int, Book>();
            bks =  dr.FilterBooks("King, Stephen");

            Console.WriteLine(dr.showFilteredBooks(bks));

            Console.ReadKey();
        }
    }
}
