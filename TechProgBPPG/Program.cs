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
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(1, "The Shining", "King, Stephen");
            Rent rent = new Rent(true, "02/05/2016");

            book.r = rent;

            Console.WriteLine(book.returnBook());

            //add data to repository

            Console.WriteLine("Adding a reader to the repository...");
            dr.Create(r);
            Console.WriteLine("Adding a book to the repository...");
            dr.Create(book);

            Console.WriteLine("Adding a book to the reader...");

            if (dr.Read(r) == r && dr.Read(book) == book) dr.Read(r).addBook(dr.Read(book));

            Console.ReadKey();
        }
    }
}
