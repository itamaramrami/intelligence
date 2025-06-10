using intelligence.DEL;
using intelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
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
            choice = int.Parse(Console.ReadLine());
            while (choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                choice = int.Parse(Console.ReadLine());
            }
            do
            {


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("insert reporter id");
                        string input = Console.ReadLine();
                        bool isNumber = int.TryParse(input, out int reporteid);
                        while (!isNumber)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number:");
                            input = Console.ReadLine();
                            isNumber = int.TryParse(input, out reporteid);
                        }
                        if (DelPeople.IsExsistreporter(reporteid))
                        {
                            Console.WriteLine("insert target id:");
                            input = Console.ReadLine();
                            isNumber = int.TryParse(input, out int targetid);
                            while (!isNumber)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number:");
                                input = Console.ReadLine();
                                isNumber = int.TryParse(input, out targetid);
                            }
                            if (DelPeople.IsExsisttarget(targetid))
                            {
                                Console.WriteLine("enter a report:");
                                string rep = Console.ReadLine();
                                Reports newreport = new Reports(reporteid, targetid, rep);
                                DelReports.InsertNewReport(newreport);
                            }
                            else
                            {
                                int newid = DelPeople.InsertRandomPerson();
                                Console.WriteLine("enter a report:");
                                string rep = Console.ReadLine();
                                Reports newreport = new Reports(reporteid, newid, rep);
                                DelReports.InsertNewReport(newreport);

                            }
                        }
                        else
                        {
                            int newidd = DelPeople.InsertRandomPerson();
                            Console.WriteLine("insert target id:");
                            input = Console.ReadLine();
                            isNumber = int.TryParse(input, out int targetid);
                            while (!isNumber)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number:");
                                input = Console.ReadLine();
                                isNumber = int.TryParse(input, out targetid);
                            }
                            if (DelPeople.IsExsisttarget(targetid))
                            {
                                Console.WriteLine("enter a report:");
                                string rep = Console.ReadLine();
                                Reports newreport = new Reports(newidd, targetid, rep);
                                DelReports.InsertNewReport(newreport);
                            }
                            else
                            {
                                int newid = DelPeople.InsertRandomPerson();
                                Console.WriteLine("enter a report:");
                                string rep = Console.ReadLine();
                                Reports newreport = new Reports(newidd, newid, rep);
                                DelReports.InsertNewReport(newreport);
                            }
                        }
                        Console.WriteLine("enter your choice:");
                        menu();
                        break;
                    case 2:
                        
                        Console.WriteLine("Enter your choice:");
                        menu();

                        break;
                    case 3:
                        
                        menu();
                        
                        break;
                    case 4:
                       
                        menu();
                        
                        break;
                    case 5:
                        
                        menu();
                        
                        break;
                    

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;


                }
            } while (choice != 5);




        }
        static void menu()
        {
            Console.WriteLine("Submit report enter 1");
            Console.WriteLine("import from csv enter 2");
            Console.WriteLine("show secret name by name enter 3");
            Console.WriteLine("Analysis Deshboard enter 4");
            Console.WriteLine("exit enter 5");
           
        }
    }
}
