using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    public class Rent
    {
        private bool _ifRented { get; set; }
        private string _expireDate{ get; set; }
        public string printRent()
        {
            return ("Book rent data: is rented: " + _ifRented.ToString() + " expire date: " + expireDate.ToString());
        }
        public bool ifRented
        {
            get
            {
               return _ifRented;
            }
            set
            {
                _ifRented = value;
            }
        }
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
    }
}
