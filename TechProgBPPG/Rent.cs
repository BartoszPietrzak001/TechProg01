using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class Rent
    {
        // constructor
        public Rent(Book book, Reader reader, string expdate)
        {
            _expireDate = expdate;
            _rentedBook = book;
            _reader = reader;
        }

        // fields
        private string _expireDate;
        private Reader _reader;
        private Book _rentedBook;

        // get; set;
        public string expireDate
        {
            get
            {
                return _expireDate;
            }
            set
            {
                _expireDate = value;
            }
        }
        public Book rentedBook
        {
            get
            {
                return _rentedBook;
            }
        }
        public Reader reader
        {
            get
            {
                return _reader;
            }
        }

        // methods
        public string PrintRent()
        {
            if (_rentedBook != null && _reader != null && _expireDate!=null)
                return ("Book: " + _rentedBook.title + " rent data:\nrented by: " + _reader.nameSurname.ToString() + ", expire date: " + expireDate.ToString() + "\n");
            else return "";
        }

        public bool AddBook(Book bk)
        {
                _rentedBook = bk;
                return true;
        }

        public bool AddReader(Reader r)
        {
                _reader = r;
                return true;
        }

    }
}
