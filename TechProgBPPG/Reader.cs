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
#if DEBUG 
            Console.WriteLine("A reader named: {0} was created", nameSurname);
#endif
        }

        // fields
        private string _nameSurname;
        private string _adress;
        private string _nrTel;

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

        // print a reader
        public string PrintReader()
        {
            return ("A reader named: " + _nameSurname + ", adress: " + _adress + ", telephone number: " + _nrTel + "\n");
        }
    }
}

