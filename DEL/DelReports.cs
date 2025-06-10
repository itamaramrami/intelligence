using intelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.DEL
{
    internal class DelReports
    {
        public static void CreatTableReports()
        {
            DBconnection.DBconnection.Execute
                (
                "CREATE TABLE Reports (Id INT AUTO_INCREMENT PRIMARY KEY,ReporterID INT NOT NULL,TargetID INT NOT NULL,Text TEXT NOT NULL,CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,FOREIGN KEY (ReporterID) REFERENCES People(Id),FOREIGN KEY (TargetID) REFERENCES People(Id))"
                );
        }
        public static void InsertNewReport(Reports NewReport)
        {
            string sql = $"INSERT INTO Reports (reporterID, targetID, text) VALUES ({NewReport.GetReporterID()}, {NewReport.GetTargetID()}, ' {NewReport.Gettext()}')";
            DBconnection.DBconnection.Execute(sql);
            DelPeople.UpdateAmountReports(NewReport.GetReporterID());
            DelPeople.UpdateNumMention(NewReport.GetTargetID());
            int result = NewReport.GetTargetID();
           
            if (DelPeople.IsSuspect(result))
            {
                DelAlert.InsertAlert(result);
            }
            Utils.Loger.Logger.Log("נוסף דיווח חדש");

        }

    }
}
