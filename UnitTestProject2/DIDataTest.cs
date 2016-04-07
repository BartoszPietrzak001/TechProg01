using System;
using TechProgBPPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace UnitTestProject2
{
    [TestClass]
    public class DIDataTest
    {
        [TestMethod]
        public void FillReaderListStaticTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            FillDataRepositoryStatic data = new FillDataRepositoryStatic();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new list of filtered readers
            List<Reader> rds = null;
            rds = ds.FilterReaders("694954694");

            // expected value: true
            Assert.IsNull(rds);

            // obtain another list
            rds = ds.FilterReaders("004694694");

            // expected value: true
            Assert.AreEqual("A reader named: Bartosz Pietrzak, adress: Smetany 99, telephone number: 004694694\n\n", ds.ShowFilteredReaders(rds));
        }
        [TestMethod]
        public void FillBooksDictionaryStaticTest()
        {
            // create FillDataRepository data object (inherits from DataInterface)
            FillDataRepositoryStatic data = new FillDataRepositoryStatic();

            // create repository using Dependency Injection pattern (pass FillDataRepository object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new dictionary of filtered books
            Dictionary<int, Book> dictionary = ds.FilterBooks("Harper Lee");

            // expected value: true
            Assert.AreEqual("A book entitled: Zabić drozda, author: Harper Lee\n\n", ds.ShowFilteredBooks(dictionary));
        }
        [TestMethod]
        public void FillRentsCollectionStaticTest()
        {
            // create FillDataRepositoryStatic data object (inherits from DataInterface)
            FillDataRepositoryStatic data = new FillDataRepositoryStatic();

            // create repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            DataRepository repository = new DataRepository(data);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new Observable Collection of filtered rents
            ObservableCollection<Rent> rents  = ds.FilterRents("01/04/2016");

            // expected value: true
            Assert.AreEqual("Book: The Shining rent data:\nrented by: Bartosz Pietrzak, expire date: 01/04/2016\n\n", ds.ShowFilteredRents(rents));
        }
        [TestMethod]
        public void FillReaderListFileTest()
        {
            // create FillDataRepositoryFile fillData object (inherits from DataInterface)
            FillDataRepositoryFile fillData = new FillDataRepositoryFile();

            // create repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            DataRepository repository = new DataRepository(fillData);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new List of readers
            List<Reader> readers = ds.FilterReaders("0011223345");

            // expected value: true
            Assert.AreEqual("A reader named: Bartosz Pietrzak, adress: ul. Bartoka 123, telephone number: 0011223345\n\n", ds.ShowFilteredReaders(readers));
        }
        [TestMethod]
        public void FillBookDictionaryFileTest()
        {
            // create FillDataRepositoryFile fillData object (inherits from DataInterface)
            FillDataRepositoryFile fillData = new FillDataRepositoryFile();

            // create repository using Dependency Injection pattern (pass FillDataRepositoryFile object to DataRepository constructor)
            DataRepository repository = new DataRepository(fillData);

            // create a data service
            DataService ds = new DataService(repository);

            // obtain a new Dictionary of filtered books
            Dictionary<int, Book> bks = ds.FilterBooks("Smith, Scott");

            // expected value: true
            Assert.AreEqual("A book entitled: Ruins, author: Smith, Scott\n\n", ds.ShowFilteredBooks(bks));
        }
        [TestMethod]
        public void EfficiencyTest()
        {
            Stopwatch stopWatch = new Stopwatch();
            // check the time of the static mode
            stopWatch.Start();

            // create FillDataRepositoryStatic fillData object (inherits from DataInterface)
            FillDataRepositoryStatic fillData = new FillDataRepositoryStatic();

            // create a repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            DataRepository repository = new DataRepository(fillData);

            // create a data service
            DataService ds = new DataService(repository);

            // elapsed time (ms)
            stopWatch.Stop();
            double staticTime = stopWatch.Elapsed.TotalMilliseconds;

            stopWatch.Reset();

            // check the time of the file mode
            stopWatch.Start();

            // create FillDataRepositoryFile fileData object (inherits from DataInterface)
            FillDataRepositoryFile fileData = new FillDataRepositoryFile();

            // create a repository using Dependency Injection pattern (pass FillDataRepositoryFile object to DataRepository constructor)
            DataRepository dr = new DataRepository(fileData);

            // create a data service 
            DataService dataService = new DataService(dr);

            // elapsed time (ms)
            stopWatch.Stop();
            double fileTime = stopWatch.Elapsed.TotalMilliseconds;

            // expected value: true
            Assert.IsTrue(fileTime > staticTime);

        }
    }
}
