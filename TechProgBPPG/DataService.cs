using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class DataService
    {
        // constructor
        public DataService(DataRepository dr)
        {
            this.dr = dr;
            this.dr.Rents.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedMethod);
        }

        // fields
        private DataRepository dr;

        // methods

        // ObservableCollection<Rent> CollectionChanged method
        private void CollectionChangedMethod(object s, NotifyCollectionChangedEventArgs evnt)
        {
            if (evnt.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                foreach (Rent rent in evnt.NewItems)
                {
                    Console.WriteLine("New rent added: " + rent.PrintRent());
                }
            }
            if (evnt.Action.Equals(NotifyCollectionChangedAction.Remove))
            {
                foreach (Rent rent in evnt.OldItems)
                {
                    Console.WriteLine("Rent removed");
                }
            }
        }

        // return a string value of readers data
        public string ShowReaderDataString()
        {
            string returnStatement = "";
            foreach (var reader in dr.Readers)
            {
                returnStatement+=reader.PrintReader();
            }
            returnStatement += "\n";
            if (returnStatement != "\n") return returnStatement;
            else return null;
        }

        // return a string value of readers data
        public string ShowBookDataString()
        {
            string returnStatement = "";
            foreach(var book in dr.Books)
            {
                returnStatement += book.Value.ReturnBook();
            }
            returnStatement += "\n";
            if (returnStatement != "") return returnStatement;
            else return null;
        }

        public string ShowRentDataString()
        {
            string returnStatement = "";
            foreach (var rent in dr.Rents)
            {
                returnStatement += rent.PrintRent();
            }
            if (returnStatement != "") return returnStatement;
            else return null;
        }

        // show everything
        public string ShowAllData()
        {
            string rents = "";
            string readers = "Readers: \n\n";
            readers += ShowReaderDataString();
            string books = "Books: \n\n";
            books += ShowBookDataString();
            if (dr.Rents.Count!=0)
            {
                foreach(var rent in dr.Rents)
                {
                    rents += rent.PrintRent();
                }
            }
            return readers + books + rents;
        }

        // filter methods
        public Dictionary<int, Book> FilterBooks(string bookAuthor)
        {
            Dictionary<int, Book> bks = new Dictionary<int, Book>();
            foreach (var book in dr.Books)
            {
                if (book.Value.author == bookAuthor)
                {
                    bks.Add(book.Key, book.Value);
                }
            }
            if (bks.Count != 0) return bks;
            else return null;
        }

        public List<Reader> FilterReaders(string telNr)
        {
            List<Reader> filteredReaders = new List<Reader>();
            foreach (var rdr in dr.Readers)
            {
               if (rdr.nrTel==telNr) filteredReaders.Add(rdr);
            }
           if (filteredReaders.Count != 0) return filteredReaders;
           else  return null;
        }

        public ObservableCollection<Rent> FilterRents(string expDate)
        {
            ObservableCollection<Rent> rnts = new ObservableCollection<Rent>();
            foreach (var rent in dr.Rents)
            {
                if (rent.expireDate==expDate) rnts.Add(rent);
            }
            if (rnts.Count != 0) return rnts;
            else return null;
        }

        // show filtered containers
        public string ShowFilteredBooks(Dictionary<int, Book> books)
        {
            string answer = "";
            foreach (var book in books)
            {
                answer += book.Value.ReturnBook();
            }
            answer += "\n";
            return answer;
        }

        public string ShowFilteredReaders(List<Reader> readers)
        {
            string answer = "";
            if (readers != null)
            {
                foreach (var reader in readers)
                {
                    answer += reader.PrintReader();
                }
                answer += "\n";
            }
            return answer;
        }

        public string ShowFilteredRents(ObservableCollection<Rent> rnts)
        {
            string answer = "";
            foreach (var rent in rnts)
            {
                answer += rent.PrintRent();
            }
            answer += "\n";
            return answer;
        }
    }
}
