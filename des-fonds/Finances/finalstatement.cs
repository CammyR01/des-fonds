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
        private int totalStatement;

        public finalstatement(List<int> statements, int totalStatement) 
        {
        this.statements = statements;
        this.totalStatement = totalStatement;
        }
    }
}
