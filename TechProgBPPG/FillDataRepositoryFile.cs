using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TechProgBPPG
{
    public class FillDataRepositoryFile : DataInterface
    {
        public void FillBookDictionary(DataRepository dr)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Bartek\\Desktop\\TechProg01\\TechProgBPPG\\data.txt");
            string book = "";
            string title;
            string author;
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine()=="Books:")
                {
                    while (!sr.EndOfStream)
                    {
                        book = sr.ReadLine();
                        string[] parts = book.Split(';');
                        title = parts[0];
                        author = parts[1];

                        dr.CreateBook(new Book(title, author));
                    }
                }

            }
            sr.Close();
        }

        public void FillExpireDateList(DataRepository dr)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Bartek\\Desktop\\TechProg01\\TechProgBPPG\\data.txt");
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Expire Dates:"))
                {
                    while (!lines[i+1].Contains("Books:"))
                    {
                        dr.CreateExpireDate(lines[i + 1]);
                        i++;
                    }
                }
            }
            sr.Close();
        }

        public void FillReadersList(DataRepository dr)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Bartek\\Desktop\\TechProg01\\TechProgBPPG\\data.txt");
            string text = sr.ReadToEnd();
            string[] lines = text.Split('\n');

            for (int i=0; i<lines.Length; i++)
            {
                if (lines[i].Contains("Readers:"))
                {
                    while (!lines[i+1].Contains("Expire Dates:"))
                    {
                        string[] data = lines[i+1].Split(';');
                        dr.CreateReader(new Reader(data[0], data[1], data[2]));
                        i++;
                    }
                }
            }
            sr.Close();
        }   

        public void FillRentsWithData(DataRepository dr)
        {
            for (int i = 0; i < dr.Books.Count; i++)
            {
                dr.CreateRent(new Rent(dr.Books[i + 1], dr.Readers[i], dr.ExpireDates[i]));
            }
        }
    }
}
