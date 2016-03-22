using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class Reader
    {
        // constructor
        public Reader(string nameSurname, string adress, string nrTel)
        {
            _nameSurname = nameSurname;
            _adress = adress;
            _nrTel = nrTel;
            readersBooks = new Dictionary<int, Book>();
            Console.WriteLine("A reader named: {0} was created", nameSurname);
        }

        // fields
        private string _nameSurname { get; set; }
        private string _adress { get; set; }
        private string _nrTel { get; set; }

        // container of books rented by a reader
        public Dictionary<int, Book> readersBooks;
            
        // add a book to a container
        public bool addBook(Book b)
        {
            if(!readersBooks.ContainsKey(b.ID))
            {
                readersBooks.Add(b.ID, b);
                return true;
            }
            return false;
        } 

        // get; set;
        public string nameSurname
        {
            get
            {
                return _nameSurname;
            }
            set
            {
                _nameSurname = value;
            }
        }
        public string adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
            }
        }
        public string nrTel
        {
            get
            {
                return _nrTel;
            }
            set
            {
                _nrTel = value;
            }

        }
    }
}

