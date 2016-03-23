using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class FillDataRepository : DataInterface
    {

        void DataInterface.fillBookDictionary(Dictionary<int, Book> bookDictionary)
        {
            // uniezaleznic book ID od book
            Book book = new Book(1, "The Shining", "King, Stephen");
            Book book1 = new Book(2, "Symfonia C++", "Grębosz, Jerzy");
            Book book2 = new Book(3, "Pet Cemetery", "King, Stephen");

            bookDictionary.Add(book.ID, book);
            bookDictionary.Add(book1.ID, book1);
            bookDictionary.Add(book2.ID, book2);
        }

        void DataInterface.fillReadersList(List<Reader> readerList)
        {
            Reader reader = new Reader("Bartosz Pietrzak", "Smetany 99", "694694694");
            Reader reader1 = new Reader("Przemyslaw Gesieniec", "Osterwy 152", "694954694");
            Reader reader2 = new Reader("Bartosz Pietrzak", "Smetany 150", "694694694");

            readerList.Add(reader);
            readerList.Add(reader1);
            readerList.Add(reader2);
        }

        void DataInterface.fillRentObservableCollection(ObservableCollection<Rent> rentCollection)
        {
            Rent rent = new Rent(true, "03/06/2016");
            Rent rent1 = new Rent(true, "06/06/2016");
            Rent rent2 = new Rent(true, "03/06/2016");

            rentCollection.Add(rent);
            rentCollection.Add(rent1);
            rentCollection.Add(rent2);
        }
    }
}
