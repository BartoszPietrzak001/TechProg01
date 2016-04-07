using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechProgBPPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //FillDataRepositoryStatic data = new FillDataRepositoryStatic();
            //DataRepository repository = new DataRepository(data);
            //DataService dataservice = new DataService(repository);

            //List<Reader> list = dataservice.FilterReaders("694694694");
            //ObservableCollection<Rent> rents = dataservice.FilterRents("02/04/2016");

            //Console.Write("Show me readers and books: ");
            //Console.WriteLine(dataservice.ShowFilteredReaders(list));

            //Console.WriteLine();

            //Console.Write("Show me rents: ");
            //Console.WriteLine(dataservice.ShowFilteredRents(rents));

            //Console.WriteLine(dataservice.ShowAllData());

            //Console.ReadKey();

            //Console.WriteLine("-------------------------------------------------------");

            FillDataRepositoryFile data = new FillDataRepositoryFile();
            DataRepository repository = new DataRepository(data);
            DataService dataService = new DataService(repository);

            Console.WriteLine(dataService.ShowAllData());

            Console.ReadKey();

            //Console.WriteLine("-----------------------------------------------------");

            //Stopwatch stopWatch = new Stopwatch();

            //stopWatch.Start();

            //// create FillDataRepositoryStatic fillData object (inherits from DataInterface)
            //FillDataRepositoryStatic fillData = new FillDataRepositoryStatic();

            //// create a repository using Dependency Injection pattern (pass FillDataRepositoryStatic object to DataRepository constructor)
            //DataRepository repository = new DataRepository(fillData);

            //// create a data service
            //DataService ds = new DataService(repository);

            //stopWatch.Stop();

            //double staticTime = stopWatch.Elapsed.TotalMilliseconds;

            //stopWatch.Reset();

            //stopWatch.Start();

            //// create FillDataRepositoryFile fileData object (inherits from DataInterface)
            //FillDataRepositoryFile fileData = new FillDataRepositoryFile();

            //// create a repository using Dependency Injection pattern (pass FillDataRepositoryFile object to DataRepository constructor)
            //DataRepository dr = new DataRepository(fileData);

            //// create a data service 
            //DataService dataService = new DataService(dr);

            //stopWatch.Stop();

            //double fileTime = stopWatch.Elapsed.TotalMilliseconds;

            //Console.WriteLine(staticTime);
            //Console.WriteLine(fileTime);

            //Book book = new Book("Me, Ozzy", "Osbourne, Ozzy");
            //Reader reader = new Reader("Hello World", "xxxx", "yyyyy");
            //Rent rent = new Rent(book, reader, "03/04/2016");

            //repository.CreateRent(rent);

            //Console.ReadKey();
        }
    }
}
