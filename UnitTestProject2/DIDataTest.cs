using System;
using TechProgBPPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTestProject2
{
    [TestClass]
    public class DIDataTest
    {
        [TestMethod]
        public void fillReaderListTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            FillDataRepository data = new FillDataRepository();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // obtain a new list of filtered readers
            List<Reader> list = repository.FilterReaders("694954694");

            // expected value: true
            Assert.AreEqual(repository.showFilteredReaders(list), "1. Name and surname: Przemyslaw Gesieniec, Adress: Osterwy 152, Telephone Number: 694954694\n"); 
        }
        [TestMethod]
        public void fillBooksDictionaryTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            FillDataRepository data = new FillDataRepository();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // obtain a new dictionary of filtered books
            Dictionary<int, Book> dictionary = repository.FilterBooks("Grębosz, Jerzy");

            // expected value: true
            Assert.AreEqual(repository.showFilteredBooks(dictionary), "1. Title: Symfonia C++, Author: Grębosz, Jerzy\n");
        }
        [TestMethod]
        public void fillRentsCollectionTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            FillDataRepository data = new FillDataRepository();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // obtain a new Observable Collection of filtered rents
            ObservableCollection<Rent> rents  = repository.FilterRents("06/06/2016");

            // expected value: true
            Assert.AreEqual(repository.showFilteredRents(rents), "1. Is rented: True, expire date: 06/06/2016\n");
        }
    }
}
