using intelligence.DEL;
using intelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace intelligence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            //DelAlert.CreatTableAlert();
            //DelPeople.CreatTablePeople();
            //DelReports.CreatTableReports();
            //DelPeople.GetAllPeople();
            //People person1 = new People("itamar", "aa2");
            //People person2 = new People("haim", "aa2");


            //DelPeople.InsertNewPeople(person1);
            //DelPeople.InsertNewPeople(person2);
            //Console.WriteLine(DelPeople.IsSuspect(12));
            //Reports rep1 = new Reports(13, 16, "hel");
            //DelReports.InsertNewReport(rep1);
            //DelPeople.GetAllPeople();
            //DelPeople.GetPeopleByID(1);
            //DelPeople.UpdatePotential(3);
            //DelPeople.GetAllPeople();
            //DelPeople.UpdateAmountReports(1);
            menu();
            Console.WriteLine("enter your choice:");
            string choic = Console.ReadLine();
            int choice = DelPeople.CheckedInput(choic);
            choice = DelPeople.IsGoodNumber(choice);


            do
            {


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter a reporter id:");
                        string res = Console.ReadLine();
                        int Newreort = DelPeople.CheckedInput(res);
                        int nwereportt = DelPeople.GetOrCreatPerson(Newreort);


                        Console.WriteLine("enter a target id:");
                        string ress = Console.ReadLine();
                        int Newtarget = DelPeople.CheckedInput(ress);
                        int newtargett = DelPeople.GetOrCreatPerson(Newtarget);

                        Console.WriteLine("enter a report:");
                        string rep = Console.ReadLine();
                        Reports nwerep = new Reports(nwereportt, newtargett, rep);
                        DelReports.InsertNewReport(nwerep);








                        Console.WriteLine("enter your choice:");
                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);
                        break;
                    case 2:
                        Console.WriteLine("enter your name:");
                        string name = Console.ReadLine();
                        DelPeople.GetSecretCodeByName(name);
                        menu();

                        break;
                    case 3:
                        Utils.CSV.ImportCSV.ImportCsv();
                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);
                        break;
                    case 4:
                        Console.WriteLine("Alerts");
                        DelAlert.PrintAllAlerts();
                        

                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);

                        break;
                    case 5:
                        
                        Console.WriteLine("Potentially");
                        DelPeople.GetAllPotentially();

                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);

                        break;
                    case 6:

                        Console.WriteLine("all people:");
                        DelPeople.GetAllPeople();
                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);

                        break;
                    case 7:

                        Console.WriteLine("enter your name:");
                        string name1 = Console.ReadLine(); 
                        Console.WriteLine("enter secret code:");
                        string scode = Console.ReadLine();
                        People pers = new People(name1, scode);
                        DelPeople.InsertNewPeople(pers);
                        menu();
                        Console.WriteLine("enter your choice:");
                        choic = Console.ReadLine();
                        choice = DelPeople.CheckedInput(choic);
                        choice = DelPeople.IsGoodNumber(choice);

                        break;
                    case 8:

                        Console.WriteLine("You went out successfully");

                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;


                }
            } while (choice != 8);
         }




        static void menu()
        {

            Console.WriteLine("=======================================");
            Console.WriteLine("               MAIN MENU               ");
            Console.WriteLine("=======================================");
            Console.WriteLine(" 1. Submit Report");
            Console.WriteLine(" 2. Show Secret Name by Name");
            Console.WriteLine(" 3. Import from CSV");
            Console.WriteLine(" 4. Get all alert");
            Console.WriteLine(" 5. Get all Potentially");
            Console.WriteLine(" 6. get all people");
            Console.WriteLine(" 7. Entering a user");
            Console.WriteLine(" 8. Exit");
            Console.WriteLine("=======================================");
            Console.Write("Please enter your choice (1-8): ");
        }

    }
}
