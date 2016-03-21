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
        public List<Reader> readers;
        public Dictionary<int, Book> books;
        public ObservableCollection <Rent> rents;
        
        public DataRepository()
        {
            readers = new List<Reader>();
            books = new Dictionary<int, Book>();
            rents = new ObservableCollection<Rent>();
            Console.WriteLine("Data repository of {0}, {1} and {2} created.", nameof(readers), nameof(books), nameof(rents));
        }

        public bool Create(Reader r)
        {
            if (!readers.Contains(r)) //as not to duplicate information
            {
                readers.Add(r);
                ifSuccessful(true);
                return true;
            }
            ifSuccessful(false);
            return false;
        }

        public bool Create(Book bk)
        {
            if (!books.ContainsKey(bk.ID)) //as to avoid runtime error
            {
                books.Add(bk.ID, bk);
                ifSuccessful(true);
                return true;
            }
            ifSuccessful(false);
            return false;
        }

        public bool Create(Rent rent)
        {
            if (!rents.Contains(rent))
            {
                rents.Add(rent);
                ifSuccessful(true);
                return true;
            }
            ifSuccessful(false);
            return false;
        }

        public Reader Read (Reader r)
        {
            foreach(var reader in readers)
            {
                if (reader == r) return r;
            }
            return null;
        }

        public Book Read (int ID)
        {
            for (int i=0; i<books.Count; i++)
            {
                if (books[i].ID == ID) return books[i];
            }
            return null;
        }

        public Book Read (Book bk)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ID == bk.ID) return books[i];
            }
            return null;
        }

        public Rent Read (Rent rent)
        {
            foreach(var rnt in rents)
            {
                if (rnt == rent) return rnt;
            }
            return null;
        }

        public bool Delete (Reader r)
        {
            foreach (var reader in readers)
            {
                if (reader == r) readers.Remove(r);
                ifSuccessful(true);
                return true;
            }
            ifSuccessful(false);
            return false;
        }

        public bool Delete (Book bk)
        {
            foreach (var book in books)
            {
                if (book.Key == bk.ID)
                {
                    books.Remove(bk.ID);
                    ifSuccessful(true);
                    return true;
                }
            }
            ifSuccessful(false);
            return false;
        }

        public bool Delete (Rent rent)
        {
            foreach (var rnt in rents)
            {
                if (rnt == rent) rents.Remove(rent);
                ifSuccessful(true);
                return true;
            }
            ifSuccessful(false);
            return false;
        }

        private void ifSuccessful(bool x)
        {
            if (x == true) Console.WriteLine("Operation finished successfully");
            else Console.WriteLine("An error occured");
        }
    }
}
