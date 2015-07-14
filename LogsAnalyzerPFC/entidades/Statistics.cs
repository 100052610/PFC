using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAnalyzerPFC.entidades
{
    public class Statistics
    {
        private bool connection;        
        private int baseCommands;
        private int usedCommands;
        private int commonCommands;

        public bool Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public int BaseCommands
        {
            get { return baseCommands; }
            set { baseCommands = value; }
        }

        public int UsedCommands
        {
            get { return usedCommands; }
            set { usedCommands = value; }
        }

        public int CommonCommands
        {
            get { return commonCommands; }
            set { commonCommands = value; }
        }
    }
}
