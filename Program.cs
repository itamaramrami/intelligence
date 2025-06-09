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
            Console.WriteLine("hello");
            //DelPeople.CreatTablePeople();
            //DelReports.CreatTableReports();
            DelPeople.GetAllPeople();
            People person1 = new People("itamar", "aa2");
            People person2 = new People("haim", "aa2");


            //DelPeople.InsertNewPeople(person1);
            //DelPeople.InsertNewPeople(person2);
            Reports rep1 = new Reports(11, 12, "heloooo");
            DelReports.InsertNewReport(rep1);
            DelPeople.GetAllPeople();
            //DelPeople.GetPeopleByID(1);
            //DelPeople.UpdatePotential(3);
            //DelPeople.GetAllPeople();
            //DelPeople.UpdateAmountReports(1);
        }
    }
}
