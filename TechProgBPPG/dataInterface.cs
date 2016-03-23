using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public interface DataInterface
    {
        void fillReadersList(List<Reader> readerList);
        void fillBookDictionary(Dictionary<int, Book> bookDictionary);
        void fillRentObservableCollection(ObservableCollection<Rent> rentCollection);
    }
}
