using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.DEL
{
    internal class DelAlert
    {
        public static void CreatTableAlert()
        {
            DBconnection.DBconnection.Execute
                (
                "CREATE TABLE Alerts (Id INT AUTO_INCREMENT PRIMARY KEY,TargetID INT NOT NULL,AlertDate DATETIME DEFAULT CURRENT_TIMESTAMP,Reason VARCHAR(255) NOT NULL,FOREIGN KEY (TargetID) REFERENCES People(Id))"
                );
        }
        public static void InsertAlert(int id )
        {
            var res = DelPeople.GetPeopleByID(id);
            if (res == null || res.Count == 0)
            {
                Utils.Loger.Logger.Log($"ניסיון להוספת התראה עבור ID {id} נכשל - המשתמש לא נמצא");
                return;
            }

            string fullName = res[0]["FullName"].ToString();

            string reason = $"האדם {fullName} קיבל התראה בעקבות חריגה";

            string sql = $"INSERT INTO Alerts (TargetID, Reason) VALUES ({id}, '{reason}')";
            DBconnection.DBconnection.Execute(sql);

            Utils.Loger.Logger.Log($"נוספה התראה עבור {fullName} (ID: {id}) - סיבה: {reason}");

        }

        public static void PrintAllAlerts()
        {
            string sql = "SELECT * FROM Alerts";
            var result = DBconnection.DBconnection.Execute(sql);

            if (result.Count == 0)
            {
                Console.WriteLine("לא נמצאו דיווחים בטבלת Alerts.");
                return;
            }

            DBconnection.DBconnection.PrintResult(result);
            Utils.Loger.Logger.Log("בוצעה שליפת כל הדיווחים מהטבלה Alerts.");
        }


    }
}
