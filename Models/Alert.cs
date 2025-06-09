using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.Models
{
    internal class Alert
    {
        public int TargetID;
        public DateTime StartTime;
        public DateTime EndTime;
        public string Vearson;


        public Alert(int TargetID, DateTime StartTime, DateTime EndTime, string Vearson)
        {
            this.TargetID = TargetID;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Vearson = Vearson;
        }
        public int GetTargetID() => TargetID;
        public DateTime GetStartTime() => StartTime;
        public DateTime GetEndTime() => EndTime;
        public string GetVearson() => Vearson;

    }
    
}
