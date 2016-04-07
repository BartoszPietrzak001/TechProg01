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
        public Book (string title, string author)
        {
            _title = title;
            _author = author;
#if DEBUG
            Console.WriteLine(ReturnBook());
#endif
        }


        // fields
        private string _title;
        private string _author;

        // get; set;
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
        public string ReturnBook()
        {
            return "A book entitled: " + _title + ", author: " + _author + "\n";
        }
    }
}
