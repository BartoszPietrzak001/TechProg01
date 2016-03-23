using System;
using TechProgBPPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            //create repository and data
            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(dr.Books.Count+1, "The Shining", "King, Stephen");
            Rent rent = new Rent(true, "02/05/2016");

            //add data to repository
            //expected value: true

            Assert.IsTrue(dr.Create(r));
            Assert.IsTrue(dr.Create(book));
            Assert.IsTrue(dr.Create(rent));

            //expected value: false
            Assert.IsFalse(dr.Create(r));
            Assert.IsFalse(dr.Create(book));
            Assert.IsFalse(dr.Create(rent));
        }
        [TestMethod]
        public void ReadTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(dr.Books.Count + 1, "The Shining", "King, Stephen");
            Rent rent = new Rent(true, "02/05/2016");

            //add data to repository

            dr.Create(r);
            dr.Create(book);
            dr.Create(rent);

            //expected value: true

            Assert.AreEqual(dr.Read(r), r);
            Assert.AreEqual(dr.Read(1), book);
            Assert.AreEqual(dr.Read(rent), rent);
        }
        [TestMethod]
        public void DeleteTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(dr.Books.Count + 1, "The Shining", "King, Stephen");
            Rent rent = new Rent(true, "03/05/2016");

            //add data to repository

            dr.Create(r);
            dr.Create(book);
            dr.Create(rent);

            //delete data
            //expected value: true

            Assert.IsTrue(dr.Delete(r));
            Assert.IsTrue(dr.Delete(book));
            Assert.IsTrue(dr.Delete(rent));

            //try to delete data again
            //expected value: false

            Assert.IsFalse(dr.Delete(r));
            Assert.IsFalse(dr.Delete(book));
            Assert.IsFalse(dr.Delete(rent));
        }
        [TestMethod]
        public void addBookTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(dr.Books.Count + 1, "The Shining", "King, Stephen");

            //add data to repository

            dr.Create(r);
            dr.Create(book);

            //add the book to the reader
            //expected value: true

            foreach (var reader in dr.Readers)
            {
                if (reader.nameSurname == r.nameSurname) Assert.IsTrue(reader.addBook(book));
            }
        }
        [TestMethod]
        public void FilterTest()
        {
            // create a dispository
            DataRepository dr = new DataRepository();

            // create data (Books) and add data to the repository
            Book book = new Book(dr.Books.Count + 1, "The Shining", "King, Stephen");
            dr.Create(book);
            Book book1 = new Book(dr.Books.Count + 1, "Pet Cemetery", "King, Stephen");
            dr.Create(book1);
            Book book2 = new Book(dr.Books.Count + 1, "Symfonia C++", "Grebosz, Jerzy");
            dr.Create(book2);

            // create a list of books (capacity = 2 --> 2 books expected in a list returned by Filter method)
            Dictionary<int, Book> bks = new Dictionary<int, Book>(2);
            bks.Add(book.ID, book);
            bks.Add(book1.ID, book1);

            // expected value: true
            Assert.AreEqual(dr.FilterBooks("King, Stephen").Count, 2);
            Assert.AreEqual(dr.FilterBooks("Barker, Steve"), null);

            // create data (Readers)
            Reader reader = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "Osterwy 152", "694954694");
            Reader reader2 = new Reader("Bartosz Pietrzak", "Smetany 150", "694694694");

            // add data to the repository
            dr.Create(reader);
            dr.Create(reader1);
            dr.Create(reader2);

            // expected value: true
            Assert.AreEqual(dr.FilterReaders("694694694").Count, 2);
            Assert.AreEqual(dr.FilterReaders("11111111"), null);

            //create data (Rents)
            Rent rent = new Rent(true, "03/06/2016");
            Rent rent1 = new Rent(true, "06/06/2016");
            Rent rent2 = new Rent(true, "03/06/2016");

            //add data to the repository
            dr.Create(rent);
            dr.Create(rent1);
            dr.Create(rent2);

            // expected value: true
            Assert.AreEqual(dr.FilterRents("03/06/2016").Count, 2);
            Assert.AreEqual(dr.FilterRents("01/01/2001"), null);
        }
        [TestMethod]
        public void showFilteredBooksTest()
        {
            // create a dispository
            DataRepository dr = new DataRepository();

            // create data and add data to the repository
            Book book = new Book(dr.Books.Count+1, "The Shining", "King, Stephen");
            dr.Create(book);
            Book book1 = new Book(dr.Books.Count+1, "Pet Cemetery", "King, Stephen");
            dr.Create(book1);
            Book book2 = new Book(dr.Books.Count+1, "Symfonia C++", "Grebosz, Jerzy");
            dr.Create(book2);

            // create a dictionary of books
            Dictionary<int, Book> bks = new Dictionary<int, Book>();

            // assign thr result of the FilterBooks function to the new Dictionary
            bks = dr.FilterBooks("Grebosz, Jerzy");

            // expected value: true
            Assert.AreEqual(dr.showFilteredBooks(bks), "1. Title: Symfonia C++, Author: Grebosz, Jerzy\n");
        }
        [TestMethod]
        public void showFilteredReadersTest()
        {
            // create a dispository
            DataRepository dr = new DataRepository();

            // create data
            Reader reader = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "Osterwy 152", "694954694");
            Reader reader2 = new Reader("Bartosz Pietrzak", "Smetany 150", "694694694");

            // add data to the repository
            dr.Create(reader);
            dr.Create(reader1);
            dr.Create(reader2);

            // create a list of readers
            List<Reader> rds = new List<Reader>();

            // assign thr result of the FilterReaders function to the new List
            rds = dr.FilterReaders("694954694");

            // expected value: true
            Assert.AreEqual(dr.showFilteredReaders(rds), "1. Name and surname: Przemyslaw Gesieniec, Adress: Osterwy 152, Telephone Number: 694954694");
        }
        [TestMethod]
        public void showFilteredRentsTest()
        {
            // create a dispository
            DataRepository dr = new DataRepository();

            // create data
            Rent rent = new Rent(true, "03/06/2016");
            Rent rent1 = new Rent(true, "06/06/2016");
            Rent rent2 = new Rent(true, "03/06/2016");

            // add data to the repository
            dr.Create(rent);
            dr.Create(rent1);
            dr.Create(rent2);

            // create an ObservableCollection of Rents
            ObservableCollection <Rent> rnts = new ObservableCollection<Rent>();

            rnts = dr.FilterRents("06/06/2016");

            // expected value: true
            Assert.AreEqual(dr.showFilteredRents(rnts), "1. Is rented: True, expire date: 06/06/2016\n");
        }
    }
}
    

