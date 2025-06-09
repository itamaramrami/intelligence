using intelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.DEL
{
    internal static class DelPeople
    {
        public static void CreatTablePeople()
        {
            DBconnection.DBconnection.Execute
                (
                "CREATE TABLE People (Id INT AUTO_INCREMENT PRIMARY KEY,FullName VARCHAR(100) NOT NULL,SecretCode VARCHAR(100) NOT NULL,CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,AmountReports INT DEFAULT 0 , NumMention INT DEFAULT 0 ,Potential BOOLEAN DEFAULT FALSE)"
                );
        }

        public static void InsertNewPeople(People Newpeople)
        {
            string sql = $"INSERT INTO People (FullName, SecretCode, AmountReports,NumMention, Potential)VALUES (' {Newpeople.GetFullName()}', '{Newpeople.GetSecretCode()}',{Newpeople.GetAmountReports()},'{Newpeople.GetNumMention()}' ,'{Newpeople.GetPotential()}');";
            DBconnection.DBconnection.Execute(sql);
            
            
        }
        public static object GetAllPeople()
        {
            string sql = $"SELECT * FROM People";
            var resolt = DBconnection.DBconnection.Execute(sql);
            DBconnection.DBconnection.PrintResult(resolt);
            return resolt;
        }
        public static List<Dictionary<string, object>> GetPeopleByID(int id)
        {
            string sql = $"SELECT * FROM People WHERE Id = {id}";
            var resolt = DBconnection.DBconnection.Execute(sql);
            DBconnection.DBconnection.PrintResult(resolt);
            return resolt;
        }
        public static object UpdateAmountReports(int id)
        {
            string sql = $"UPDATE People SET AmountReports = AmountReports + 1 WHERE Id = {id}";
            DBconnection.DBconnection.Execute(sql);
            string sql1 = $"SELECT AmountReports FROM People WHERE Id = {id}";
            List<Dictionary<string, object>> AmountReports = DBconnection.DBconnection.Execute(sql1);
            int amount = Convert.ToInt32(AmountReports[0]["AmountReports"]);
            if (amount == 10)
            {
                UpdatePotential(id);
                return AmountReports;
            }
            List<Dictionary<string, object>> resolt = GetPeopleByID(id);
            return AmountReports;

        }
        public static void UpdateNumMention(int id)
        {
            string sql = $"UPDATE People SET NumMention = NumMention + 1 WHERE Id = {id}";
            DBconnection.DBconnection.Execute(sql);
            

        }
        public static void UpdatePotential(int id)
        {
            string sql = $"UPDATE People SET Potential = NOT Potential WHERE Id = {id}";
            DBconnection.DBconnection.Execute(sql);
            List<Dictionary<string, object>>  resolt = GetPeopleByID(id);
            
        }
    }
}
