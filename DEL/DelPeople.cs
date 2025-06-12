using intelligence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
            Utils.Loger.Logger.Log($"{Newpeople.GetFullName()} נוסף בהצלחה");
        }

        public static int CheckedInput(string input)
        {
            bool isNumber = int.TryParse(input, out int number);
            while (!isNumber)
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out number);
            }
            return number;
        }
        public static int IsGoodNumber(int num)
        {
            
            while (num < 1 || num > 8)
            {
                Console.WriteLine("Enter a number between 1 and 8:");
                string input = Console.ReadLine();
                 num = CheckedInput(input);
            }
            return num;
        }
        public static int GetOrCreatPerson(int id)
        {
            int res = GetPepoleById(id);
            if (res==-1)
            {
                int ress = InsertRandomPerson();
                return ress;

            }
            return res;
            
           

        }
        public static int GetPepoleById(int id)
        {
            string sql = $"SELECT Id FROM People WHERE Id = {id}";
            var result = DBconnection.DBconnection.Execute(sql);
            if (result.Count == 0) return -1;

            int idd= Convert.ToInt32(result[0]["Id"]);
            return idd;
        }









        public static int InsertRandomPerson(string name ="")
        {
            Random rnd = new Random();

            string[] firstNames = { "David", "Sarah", "Daniel", "Lea", "Avi", "Noa", "Itay", "Yael" };
            string[] lastNames = { "Cohen", "Levi", "Mizrahi", "Peretz", "Katz", "Ben David" };
            string fullName = $"{firstNames[rnd.Next(firstNames.Length)]} {lastNames[rnd.Next(lastNames.Length)]}";

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string secretCode = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
            People newPerson = new People(fullName, secretCode);
            InsertNewPeople(newPerson);
            string getIdSql = "SELECT LAST_INSERT_ID() AS NewId;";
            var result = DBconnection.DBconnection.Execute(getIdSql);
            int newId = Convert.ToInt32(result[0]["NewId"]);
            return newId;
        }
        public static object GetAllPeople()
        {
            string sql = $"SELECT * FROM People";
            var resolt = DBconnection.DBconnection.Execute(sql);
            DBconnection.DBconnection.PrintResult(resolt);
            Utils.Loger.Logger.Log("בקשה של כל האנשים");
            return resolt;
        }
        public static object GetAllPotentially()
        {
            string sql = $"SELECT * FROM People WHERE Potential = true";
            var resolt = DBconnection.DBconnection.Execute(sql);
            DBconnection.DBconnection.PrintResult(resolt);
            Utils.Loger.Logger.Log("בקשה של כל הפוטנציאלים");
            return resolt;
        }
       





        public static List<Dictionary<string, object>> GetPeopleByID(int id)
        {
            string sql = $"SELECT * FROM People WHERE Id = {id}";
            var resolt = DBconnection.DBconnection.Execute(sql);
            DBconnection.DBconnection.PrintResult(resolt);
            Utils.Loger.Logger.Log("בקשה שם לפי ID");
            return resolt;
        }
        public static string GetSecretCodeByName(string fullName)
        {
            string trimmedName = fullName.Trim();
            string sql = $"SELECT SecretCode FROM People WHERE LOWER(TRIM(FullName)) = LOWER('{trimmedName}')LIMIT 1";

            var result = DBconnection.DBconnection.Execute(sql);
            

            if (result.Count == 0)
            {
                Utils.Loger.Logger.Log($"לא נמצא אדם בשם: {fullName}");
                return null; 
            }

            string secretCode = result[0]["SecretCode"].ToString();
            Utils.Loger.Logger.Log($"התקבל SecretCode של {fullName}");
            DBconnection.DBconnection.PrintResult(result);
            return secretCode;
        }

        public static bool IsExsistreporter(int reporterid)
        {
            string sql = $"SELECT EXISTS(SELECT 1 FROM People WHERE ID = {reporterid}) AS ExistsFlag";
            var result = DBconnection.DBconnection.Execute(sql);
            bool exists = Convert.ToBoolean(result[0]["ExistsFlag"]);
            return exists;
        }
        public static bool IsExsisttarget(int targetid)
        {
            string sql = $"SELECT EXISTS(SELECT 1 FROM People WHERE ID = {targetid}) AS ExistsFlag";
            var result = DBconnection.DBconnection.Execute(sql);
            bool exists = Convert.ToBoolean(result[0]["ExistsFlag"]);
            return exists;
        }
        public static object UpdateAmountReports(int id)
        {
            string sql = $"UPDATE People SET AmountReports = AmountReports + 1 WHERE Id = {id}";
            DBconnection.DBconnection.Execute(sql);
            Utils.Loger.Logger.Log("עודכן כמות דיווחים");

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
            Utils.Loger.Logger.Log("עודכן כמות דיווחים");



        }
        public static void UpdatePotential(int id)
        {
            string sql = $"UPDATE People SET Potential = NOT Potential WHERE Id = {id}";
            DBconnection.DBconnection.Execute(sql);
            List<Dictionary<string, object>>  resolt = GetPeopleByID(id);
            Utils.Loger.Logger.Log("הלקוח נהייה בפוטנציאל");


        }
        public static int CountAlerts(int id)
        {
            string sql = $"SELECT COUNT(*) AS AlertCount FROM Alerts WHERE TargetID = {id}";
            var result = DBconnection.DBconnection.Execute(sql);
            int count = Convert.ToInt32(result[0]["AlertCount"]);
            return count;

        }
        public static bool Is3Mussegin15Minutes(int id)
        {
            string sql = $"SELECT COUNT(*) AS RecentAlertCount FROM Reports WHERE TargetID = {id} AND CreatedAt >= NOW() - INTERVAL 15 MINUTE";
            var result = DBconnection.DBconnection.Execute(sql);
            int recentCount = Convert.ToInt32(result[0]["RecentAlertCount"]);

            if (recentCount == 3)
            {
                return true;
            }
            return false;
        }

        public static bool IsSuspect(int id)
        {
            int totalAlerts = CountAlerts(id);
            bool hasRecentAlerts = Is3Mussegin15Minutes(id);

            if (totalAlerts == 20 || hasRecentAlerts)
            {
                return true;
            }
            return false;
        }
    }
}
