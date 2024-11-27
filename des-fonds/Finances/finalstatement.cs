using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Finances
{
    public class finalstatement
    {
        private List<int> statements = new List<int>();
        private int totalstatement;
        private List<string> sources = new List<string>();
        public List<int> Statements { get => statements; set => statements = value; }
        public int Totalstatement { get => totalstatement; set => totalstatement = value; }
        public List<string> Sources { get => sources; set => sources = value; }

        public finalstatement(List<int> statements, int totalStatement, List<string> sources) 
        {
        this.statements = statements;
        this.totalstatement = totalStatement;
        this.sources = sources;
        }
    }
}
