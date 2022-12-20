using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FortressLogger
{
    /// <summary>
    /// Log message statements to a SQL-Server database. Message logged with the SQL Db Logger will only be logged to the database.
    /// By setting the LogToFile parameter of the FOrtressSqlLogger constructor to TRUE, messages will also be logged to a log text file
    /// </summary>
    public class FortressSqlLogger
    {
        // ---Class Variables---
        //
        // --Sql Variables--
        private string _connString { get; set; }
        private SqlConnection _conn { get; set; }

        // --Logger File Variables--
        private static string _logPath { get; set; }
        private static string _folderName { get; set; }
        private static string _logDir { get; set; }
        private static string _debuggerFile { get; set; }
        private static string _errorFile { get; set; }
        private static string _alertFile { get; set; }
        private static string _infoFile { get; set; }
        private static string _fullLogFile { get; set; }
        private static string _whiteSpace = "     ";
        private static bool logToFile { get; set; } = false;

        // ---Constructors---
        /// <summary>
        /// Initialize the connection to the Sql Server database that the log files will be logged to. The Constructor will verify that the logging table is present
        /// in the database. If the table is NOT present, then the table will be created for you.
        /// If you wish to create the table yourself, refer to the Readme or Github directions to set up your table
        /// </summary>
        /// <param name="connectionString">REQUIRED: Connection string to the Sql Server Database that the logs will be writtern to. Will throw an ArgumentNullException if left null</param>
        /// <param name="logToFile">REQUIRED: Defaults to FALSE. If set to true, will log to text file, but logDir must be supplied</param>
        /// <param name="logDir">REQUIRED IF logToFile is TRUE. If logToFile is true, and logDir is null/empty, the constr will throw an ArgumentNullException</param>
        public FortressSqlLogger(string connectionString, bool logToFile = false, string logDir = "")
        {

        }
    }
}
