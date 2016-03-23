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
            FillDataRepository data = new FillDataRepository();
            DataRepository repository = new DataRepository(data);

            List<Reader> list = repository.FilterReaders("694695694");

            Assert.AreEqual(repository.showFilteredReaders(list), "1.Name and surname: Przemyslaw Gesieniec, Adress: Osterwy 152, Telephone Number: 694954694\n"); 
        }
    }
}
