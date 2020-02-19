using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    interface ILog
    {
        string TheLog { get; set; }

        void LogAddMoney(double money);
        void LogGiveChange(double balance);
        void LogTransaction(string pc, int quantity);
        void WriteLog();
    }
}


// This class was implemented out partially out of amusement. 
// We were not required to use interfaces for this project.