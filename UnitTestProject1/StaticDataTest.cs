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
        public void CreateReaderTest()
        {
            //create repository and data
            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");

            //add data to repository
            //expected value: true

            Assert.IsTrue(dr.CreateReader(r));

            //expected value: false
            Assert.IsFalse(dr.CreateReader(r));
        }
        [TestMethod]
        public void CreateBookTest()
        {
            //create repository and data
            DataRepository dr = new DataRepository();
            Book book = new Book("The Shining", "King, Stephen");

            //add data to repository
            //expected value: true

            Assert.IsTrue(dr.CreateBook(book));

            //expected value: false
            Assert.IsFalse(dr.CreateBook(book));
        }
        [TestMethod]
        public void CreateRentTest()
        {
            //create repository and data
            DataRepository dr = new DataRepository();
            Book book = new Book("Needful Things", "King, Stephen");
            Reader reader = new Reader("Bartosz Pietrzak", "xxx", "zzz");
            Rent rent = new Rent(book, reader, "02/10/2017");

            //add data to repository
            //expected value: true

            Assert.IsTrue(dr.CreateRent(rent));

            //expected value: false
            Assert.IsFalse(dr.CreateRent(rent));
        }
        [TestMethod]
        public void CreateExpDateTest()
        {
            // create repository and data
            DataRepository dr = new DataRepository();
            string date = "01/04/2016";

            // add datato the repository
            // expected value: true

            Assert.IsTrue(dr.CreateExpireDate(date));
        }
        [TestMethod]
        public void ReadReaderTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");

            //add data to repository

            dr.CreateReader(r);

            //expected value: true

            Assert.AreEqual(r, dr.ReadReader(r));
        }
        [TestMethod]
        public void ReadBookTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Book book = new Book("The Shining", "King, Stephen");

            //add data to repository

            dr.CreateBook(book);

            //expected value: true

            Assert.AreEqual(book, dr.ReadBook(1));
        }
        [TestMethod]
        public void ReadRentTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Book book = new Book("Needful Things", "King, Stephen");
            Reader reader = new Reader("Bartosz Pietrzak", "xxx", "zzz");
            Rent rent = new Rent(book, reader, "02/10/2017");

            //add data to repository

            dr.CreateRent(rent);

            //expected value: true

            Assert.AreEqual(rent, dr.ReadRent(rent));
        }
        [TestMethod]
        public void DeleteReaderTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");

            //add data to repository

            dr.CreateReader(r);

            //delete data
            //expected value: true

            Assert.IsTrue(dr.DeleteReader(r));

            //try to delete data again
            //expected value: false

            Assert.IsFalse(dr.DeleteReader(r));
        }
        [TestMethod]
        public void DeleteBookTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Book book = new Book("The Shining", "King, Stephen");

            //add data to repository

            dr.CreateBook(book);

            //expected value: true

            Assert.IsTrue(dr.DeleteBook(book));

            //try to delete data again
            //expected value: false

            Assert.IsFalse(dr.DeleteBook(book));

        }
        [TestMethod]
        public void DeleteRentTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Book book = new Book("Needful Things", "King, Stephen");
            Reader reader = new Reader("Bartosz Pietrzak", "xxx", "zzz");
            Rent rent = new Rent(book, reader, "02/10/2017");

            //add data to repository

            dr.CreateRent(rent);

            //expected value: true

            Assert.IsTrue(dr.DeleteRent(rent));

            //try to delete data again
            //expected value: false

            Assert.IsFalse(dr.DeleteRent(rent));
        }
        [TestMethod]
        public void FilterBooksTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data (Books) and add data to the repository
            Book book = new Book("The Shining", "King, Stephen");
            dr.CreateBook(book);
            Book book1 = new Book("Pet Cemetery", "King, Stephen");
            dr.CreateBook(book1);
            Book book2 = new Book("Symfonia C++", "Grebosz, Jerzy");
            dr.CreateBook(book2);

            // create a list of books (capacity = 2 --> 2 books expected in a list returned by Filter method)
            Dictionary<int, Book> bks = new Dictionary<int, Book>(2);
            bks.Add(bks.Count+1, book);
            bks.Add(bks.Count+1, book1);

            // expected value: true
            Assert.AreEqual(2, ds.FilterBooks("King, Stephen").Count);
            Assert.AreEqual(null, ds.FilterBooks("Barker, Steve"));
        }
        [TestMethod]
        public void FilterReadersTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data (Readers)
            Reader reader = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "Osterwy 152", "694954694");
            Reader reader2 = new Reader("Bartosz Pietrzak", "Smetany 150", "694694694");

            // add data to the repository
            dr.CreateReader(reader);
            dr.CreateReader(reader1);
            dr.CreateReader(reader2);

            // expected value: true
            Assert.AreEqual(2, ds.FilterReaders("694694694").Count);
            Assert.AreEqual(null, ds.FilterReaders("11111111"));
        }
        [TestMethod]
        public void FilterRentTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data (books)

            Book book = new Book("Needful Things", "King, Stephen");
            dr.CreateBook(book);
            Book book1 = new Book("The Shining", "King, Stephen");
            dr.CreateBook(book1);
            Book book2 = new Book("Pet Semetery", "King, Stephen");
            dr.CreateBook(book2);

            // create data (Readers)
            Reader reader = new Reader("Bartosz Pietrzak", "xxx", "111");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "yyy", "222");
            Reader reader2 = new Reader("Jan Kowalski", "zzz", "333");

            // create data (Rents)
            Rent rent = new Rent(book, reader, "03/04/2016");
            Rent rent1 = new Rent(book1, reader1, "02/04/2016");
            Rent rent2 = new Rent(book2, reader2, "03/04/2016");

            //add data to the repository
            dr.CreateRent(rent);
            dr.CreateRent(rent1);
            dr.CreateRent(rent2);

            // expected value: true
            Assert.AreEqual(2, ds.FilterRents("03/04/2016").Count);
            Assert.AreEqual(null, ds.FilterRents("01/01/2001"));
        }
        [TestMethod]
        public void ShowFilteredBooksTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data and add data to the repository
            Book book = new Book("The Shining", "King, Stephen");
            dr.CreateBook(book);
            Book book1 = new Book("Pet Cemetery", "King, Stephen");
            dr.CreateBook(book1);
            Book book2 = new Book("Symfonia C++", "Grebosz, Jerzy");
            dr.CreateBook(book2);

            // create a dictionary of books
            Dictionary<int, Book> bks = new Dictionary<int, Book>();

            // assign thr result of the FilterBooks function to the new Dictionary
            bks = ds.FilterBooks("Grebosz, Jerzy");

            // expected value: true
            Assert.AreEqual("A book entitled: Symfonia C++, author: Grebosz, Jerzy\n\n", ds.ShowFilteredBooks(bks));
        }
        [TestMethod]
        public void showFilteredReadersTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data
            Reader reader = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "Osterwy 152", "694954694");
            Reader reader2 = new Reader("Bartosz Pietrzak", "Smetany 150", "694694694");

            // add data to the repository
            dr.CreateReader(reader);
            dr.CreateReader(reader1);
            dr.CreateReader(reader2);

            // create a list of readers
            List<Reader> rds = new List<Reader>();

            // assign thr result of the FilterReaders function to the new List
            rds = ds.FilterReaders("694954694");

            // expected value: true
            Assert.AreEqual("A reader named: Przemyslaw Gesieniec, adress: Osterwy 152, telephone number: 694954694\n\n", ds.ShowFilteredReaders(rds));
        }
        [TestMethod]
        public void showFilteredRentsTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data (books)

            Book book = new Book("Needful Things", "King, Stephen");
            dr.CreateBook(book);
            Book book1 = new Book("The Shining", "King, Stephen");
            dr.CreateBook(book1);
            Book book2 = new Book("Pet Semetery", "King, Stephen");
            dr.CreateBook(book2);

            // create data (Readers)
            Reader reader = new Reader("Bartosz Pietrzak", "xyz", "123");

            // create data (Rents)
            Rent rent = new Rent(book, reader, "03/04/2016");
            Rent rent1 = new Rent(book1, reader, "02/04/2016");
            Rent rent2 = new Rent(book2, reader, "03/04/2016");

            //add data to the repository
            dr.CreateRent(rent);
            dr.CreateRent(rent1);
            dr.CreateRent(rent2);

            // add data to the repository
            dr.CreateRent(rent);
            dr.CreateRent(rent1);
            dr.CreateRent(rent2);

            // create an ObservableCollection of Rents
            ObservableCollection <Rent> rnts = new ObservableCollection<Rent>();

            rnts = ds.FilterRents("02/04/2016");

            // expected value: true
            Assert.AreEqual("Book: The Shining rent data:\nrented by: Bartosz Pietrzak, expire date: 02/04/2016\n\n", ds.ShowFilteredRents(rnts));
        }
        [TestMethod]
        public void AddBooktoRent()
        {
        // create a repository
        DataRepository dr = new DataRepository();

            // create data
            Book book = new Book("Needful Things", "King, Stephen");
            Reader reader = new Reader("Bartosz Pietrzak", "xxx", "000");
            Rent rent = new Rent(book, reader, "02/05/2017");

            dr.CreateBook(book);
            dr.CreateRent(rent);

            Assert.AreEqual("Needful Things", dr.Rents[0].rentedBook.title);

            Assert.AreEqual("Bartosz Pietrzak", dr.Rents[0].reader.nameSurname);  
        }
        [TestMethod]
        public void AddReadertoRent()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create data
            Book book = new Book("Needful Things", "King, Stephen");
            Reader reader = new Reader("xyz", "Ossowskiego 665", "1111111");
            Reader reader1 = new Reader("zyx", "ulica01", "009");
            Rent rent = new Rent(book, reader1, "03/06/2017");

            // add reader to a rent
            Assert.IsTrue(rent.AddReader(reader));

            // add data to the repository
            dr.CreateReader(reader);
            dr.CreateRent(rent);

            // expected value: true
            Assert.AreEqual("xyz", dr.Rents[0].reader.nameSurname);

            // expected NullReferenceException
            Assert.AreEqual("Needful Things", dr.Rents[0].rentedBook.title);
        }
        [TestMethod]
        public void ShowReaderDataStringTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data
            Reader reader = new Reader("Stephen King", "xxx", "123123123");

            // add data to the repository
            dr.CreateReader(reader);

            // expected value: true
            Assert.AreEqual("A reader named: Stephen King, adress: xxx, telephone number: 123123123\n\n", ds.ShowReaderDataString());
        }
        [TestMethod]
        public void ShowBookDataStringTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data
            Book book = new Book("Needful Things", "King, Stephen");

            // add data to the repository
            dr.CreateBook(book);

            // expected value: true
            Assert.AreEqual("A book entitled: Needful Things, author: King, Stephen\n\n", ds.ShowBookDataString());
        }
        public void ShowRentDataStringTest()
        {
            // create a repository
            DataRepository dr = new DataRepository();

            // create a data service
            DataService ds = new DataService(dr);

            // create data
            Reader reader = new Reader("Bartosz Pietrzak", "Bartoka 1250", "111222333");
            Book book = new Book("Needful Things", "King, Stephen");
            Rent rent = new Rent(book, reader, "03/03/2016");

            // add data to the repository
            dr.CreateRent(rent);

            // expected value: true
            Assert.AreEqual("Book: Needful Things rent data:\n is rented: True, expire date: 03/03/2016, rented by: Bartosz Pietrzak\n\n", ds.ShowRentDataString());
        }
    }
}
    

