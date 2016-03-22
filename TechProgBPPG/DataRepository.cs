﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class DataRepository
    {
        // data containers
        public List<Reader> readers;
        public Dictionary<int, Book> books;
        public ObservableCollection <Rent> rents;
        
        // constructor
        public DataRepository()
        {
            readers = new List<Reader>();
            books = new Dictionary<int, Book>();
            rents = new ObservableCollection<Rent>();
            Console.WriteLine("Data repository of {0}, {1} and {2} created.", nameof(readers), nameof(books), nameof(rents));
        }

        // create methods
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

        // read methods
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
            if (books.ContainsKey(ID))
            {
                foreach(var id in books.Keys)
                {
                    if (id.Equals(ID)) return books[id];
                }
            }
            return null;
        }

        public Book Read (Book bk)
        {
            if (books.ContainsKey(bk.ID))
            {
                foreach(var id in books.Keys)
                {
                    if (bk.ID.Equals(id)) return books[id];
                }
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

        // delete methods
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

        // filter methods
        public Dictionary<int, Book> FilterBooks (string bookAuthor)
        {
            Dictionary<int, Book> bks = new Dictionary<int, Book>();
            foreach (var book in books)
            {
                if (book.Value.author.Equals(bookAuthor)) bks.Add(book.Key, book.Value);
                
            }
            if (bks.Count != 0) return bks;
            else return null;
        }

        public List<Reader> FilterReaders(string telNr)
        {
            List<Reader> filteredReaders = new List<Reader>();
            foreach (var reader in readers)
            {
                if (reader.NrTel.Equals(telNr)) filteredReaders.Add(reader);
            }
            if (filteredReaders.Count != 0) return filteredReaders;
            else return null;
        }

        // show filtered containers
        public string showFilteredBooks(Dictionary<int, Book> books)
        {
            int i = 1;
            string answer = "";
            foreach (var book in books)
            {
                answer += i.ToString() + ". Title: " + book.Value.title + ", Author: " + book.Value.author + "\n";
                i++;
            }
            return answer;
        }

        public string showFilteredReaders(List<Reader> readers)
        {
            string answer = "";
            for (int i = 0; i < readers.Count; i++)
                answer += (i + 1).ToString() + ". Name and surname: " + readers[i].NameSurname + ", Adress: " + readers[i].Adress + ", Telephone Number: " +
                    readers[i].NrTel; // + ", Rented books: \n";
            return answer;
        }

        // check if the operation was successful
        private void ifSuccessful(bool x)
        {
            if (x == true) Console.WriteLine("Operation finished successfully");
            else Console.WriteLine("An error occured");
        }
    }
}
