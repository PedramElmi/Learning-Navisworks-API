using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExperiment
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine("HI");

            var newWindow = new WPFCustomPoperty.MainWindow();

            var form = new WPFCustomPoperty.MainWindow() as System.Windows.Window;
            form.Activate();
            

            Console.ReadLine();



            //var filePath = "data.json";

            //var person1 = new Person("David", "Bond", 23);

            //var persons = new List<Person>()
            //{
            //    person1,
            //    new Person("Ahmad","Zoghi",45, person1),
            //    new Person("Mohsen","Sangin",24, person1),
            //    new Person("Mahdi","AghaKarimi",26, person1),
            //    new Person("Ahmad","Qiasi",15, person1),
            //    new Person("Purple","Yawn",29, person1),

            //};

            //DataSerializer<List<Person>>.JsonSerialize(persons, filePath);
            //Console.WriteLine("It's done");

            //var newObject = DataSerializer<List<Person>>.JsonDeserialize(filePath);

            //foreach (var item in newObject)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            ////Console.WriteLine("doing the convertion json to xml");

            ////DataSerializer<List<Person>>.Json2Xml(filePath);

            //Console.ReadKey();

        }

        
    }

}
