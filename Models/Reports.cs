using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.Models
{
    internal class Reports
    {
        public int ReporterID;
        public int TargetID;
        public string text;


        public Reports(int ReporterID,int TargetID, string text)
        {
            this.ReporterID = ReporterID;
            this.TargetID = TargetID;
            this.text = text;
        }
        public int GetReporterID() => ReporterID;
        public int GetTargetID() => TargetID;
        public string Gettext() => text;


    }
}
