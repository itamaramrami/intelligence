using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intelligence.Models
{
    internal class People
    {
        
        public string FullName;
        public string SecretCode;
        public int AmountReports;
        public int NumMention;
        public bool Potential;

        public People (string FullName,string SecretCode, int AmountReports=0, int NumMention=0, bool Potential=false)
        {
            this.FullName = FullName;
            this.SecretCode = SecretCode;
            this.AmountReports = AmountReports;
            this.NumMention = NumMention;
            this.Potential = Potential;
        }
        public string GetFullName() => FullName;
        public string GetSecretCode() => SecretCode;
        public int GetAmountReports() => AmountReports;
        public int GetNumMention() => NumMention;
        public bool GetPotential() => Potential;


    }
}
