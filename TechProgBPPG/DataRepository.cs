using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class DataRepository
    {
        // constructors

        public DataRepository()
        {
            readers = new List<Reader>();
            books = new Dictionary<int, Book>();
            rents = new ObservableCollection<Rent>();
            expireDates = new List<string>();
#if DEBUG
            Console.WriteLine("Data repository of {0}, {1}, {2} and {3} created.", nameof(readers), nameof(books), nameof(rents), nameof(expireDates));
#endif
        }

        public DataRepository(DataInterface dI)
        {
            readers = new List<Reader>();
            expireDates = new List<string>();
            books = new Dictionary<int, Book>();
            rents = new ObservableCollection<Rent>();
            dI.FillExpireDateList(this);
            dI.FillBookDictionary(this);
            dI.FillReadersList(this);
            dI.FillRentsWithData(this);
        }

        // data containers
        private List<Reader> readers;
        private Dictionary<int, Book> books;
        private ObservableCollection <Rent> rents;
        private List<string> expireDates;

        // List<Reader> readers get method 
        // Dictionary<Book> get method
        // Observablecollection<Rent> get method 
        // List<string> expireDates get method(no other neccessary)
        public List<Reader> Readers
        {
            get
            {
                return readers;
            }
        }

        public Dictionary<int, Book> Books
        {
            get
            {
                return books;
            }
        }

        public ObservableCollection<Rent> Rents
        {
            get
            {
                return rents;
            }
        }

        public List<string> ExpireDates
        {
            get
            {
                return expireDates;
            }
        }

        // create methods
        public bool CreateReader(Reader r)
        {
            if (!readers.Contains(r)) //as not to duplicate information
            {
                readers.Add(r);
                return true;
            }
            return false;
        }

        public bool CreateBook(Book bk)
        {
            if (!books.ContainsValue(bk)) //as to avoid runtime error
            {
                books.Add(books.Count+1, bk);
                return true;
            }
            return false;
        }

        public bool CreateRent(Rent rent)
        {
            if (!rents.Contains(rent))
            {
                rents.Add(rent);
                return true;
            }
            return false;
        }

        public bool CreateExpireDate(string expDate)
        {
            expireDates.Add(expDate);
            return true;
        }

        // read methods
        public Reader ReadReader(Reader r)
        {
            foreach(var reader in readers)
            {
                if (reader == r) return r;
            }
            return null;
        }

        public Book ReadBook(int ID)
        {
            if (books.ContainsKey(ID))
            {
                foreach(var id in books.Keys)
                {
                    if (id.Equals(ID)) return books[id];
                }
            }
            return null;
        }

        public Book ReadBook(Book bk)
        {
            if (books.ContainsValue(bk))
            {
                foreach(var value in books.Values)
                {
                    if (bk.title.Equals(value.title)) return value;
                }
            }
            return null;
        }

        public Rent ReadRent(Rent rent)
        {
            foreach(var rnt in rents)
            {
                if (rnt == rent) return rnt;
            }
            return null;
        }

        // delete methods
        public bool DeleteReader(Reader r)
        {
            foreach (var reader in readers)
            {
                if (reader == r) readers.Remove(r);
                return true;
            }
            return false;
        }

        public bool DeleteBook(Book bk)
        {
            foreach (var book in books)
            {
                if (book.Value.title == bk.title)
                {
                    books.Remove(book.Key);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteRent(Rent rent)
        {
            foreach (var rnt in rents)
            {
                if (rnt == rent) rents.Remove(rent);
                return true;
            }
            return false;
        }
    }
}
