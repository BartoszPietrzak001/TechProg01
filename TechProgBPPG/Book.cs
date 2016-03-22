using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class Book
    {
        // constructor
        public Book (int ID, string title, string author)
        {
            _ID = ID;
            _title = title;
            _author = author;
            _r = new Rent(false, "--");
            Console.WriteLine(returnBook());
        }

        // fields
        private int _ID { get; set; }
        private string _title { get; set; }
        private string _author { get; set; }
        private Rent _r { get; set; }

        // get; set;
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

        // methods
        public string returnBook()
        { 
            return "A book of ID: " + _ID + " entitled: " + _title + ", author: " + _author + ", rented: " + _r.ifRented + ", expire date: " + _r.expireDate + " is in our library \n";
        }
    }
}
