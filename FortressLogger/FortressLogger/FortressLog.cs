using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortressLogger
{
    public class FortressLog
    {
        private static string _logPath { get; set; }

        public FortressLog(string filePath)
        {
            _logPath = filePath;
        }


    }
}
