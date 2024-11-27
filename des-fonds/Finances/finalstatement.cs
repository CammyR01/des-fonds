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
        public List<int> Statements { get => statements; set => statements = value; }
        public int Totalstatement { get => totalstatement; set => totalstatement = value; }

        public finalstatement(List<int> statements, int totalStatement) 
        {
        this.statements = statements;
        this.totalstatement = totalStatement;
        }
    }
}
