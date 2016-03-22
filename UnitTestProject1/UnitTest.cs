using System;
using TechProgBPPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Book book = new Book(1, "The Shining", "King, Stephen");
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
            Book book = new Book(1, "The Shining", "King, Stephen");
            Rent rent = new Rent(true, "02/05/2016");

            //add data to repository

            dr.Create(r);
            dr.Create(book);
            dr.Create(rent);

            //expected value: true

            Assert.AreEqual(dr.Read(r), r);
            //Assert.AreEqual(dr.Read(book), book);
            //Assert.AreEqual(dr.Read(1), book.ID);
            Assert.AreEqual(dr.Read(1), book);
            Assert.AreEqual(dr.Read(rent), rent);
        }
        [TestMethod]
        public void DeleteTest()
        {
            //create repository and data

            DataRepository dr = new DataRepository();
            Reader r = new Reader("Bartosz Pietrzak", "Smetany 3", "694145623");
            Book book = new Book(1, "The Shining", "King, Stephen");
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
            Book book = new Book(1, "The Shining", "King, Stephen");

            //add data to repository

            dr.Create(r);
            dr.Create(book);

            //add the book to the reader
            //expected value: true

            foreach (var reader in dr.readers)
            {
                if (reader.NameSurname == r.NameSurname) Assert.IsTrue(reader.addBook(book));
            }
        }
    }
}
    

