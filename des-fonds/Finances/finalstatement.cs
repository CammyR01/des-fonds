using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Finances
{
    public class finalstatement
    {
        private List<double> statements = new List<double>();
        private double totalstatement;
        private List<string> sources = new List<string>();
        public List<double> Statements { get => statements; set => statements = value; }
        public double Totalstatement { get => totalstatement; set => totalstatement = value; }
        public List<string> Sources { get => sources; set => sources = value; }

        public finalstatement(List<double> statements, double totalStatement, List<string> sources) 
        {
        this.statements = statements;
        this.totalstatement = totalStatement;
        this.sources = sources;
        }
    }
}
