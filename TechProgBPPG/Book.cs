using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class Book
    {
        public Book (int ID, string title, string author)
        {
            this._ID = ID;
            this._title = title;
            this._author = author;
            Console.WriteLine("Our library has a new book in its collection: {0}, {1}, {2}", _ID, _title, _author);
        }
        private int _ID { get; set; }
        private string _title { get; set; }
        private string _author { get; set; }
        private Rent _r { get; set; }

        public Rent r
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
            }
        }


        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public void addRent(Rent rent)
        {
            r = rent; 
        }
    }
}
