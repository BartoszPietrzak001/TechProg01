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
            this.nameSurname = nameSurname;
            this.adress = adress;
            this.nrTel = nrTel;
            readersBooks = new Dictionary<int, Book>();
            Console.WriteLine("A reader named: {0} was created", nameSurname);
            Console.WriteLine("testpoaczenia");
        }

        // fields
        private string nameSurname { get; set; }
        private string adress { get; set; }
        private string nrTel { get; set; }

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
        public string NameSurname
        {
            get
            {
                return nameSurname;
            }
            set
            {
                nameSurname = value;
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
            }
        }
        public string NrTel
        {
            get
            {
                return nrTel;
            }
            set
            {
                nrTel = value;
            }

        }
    }
}

