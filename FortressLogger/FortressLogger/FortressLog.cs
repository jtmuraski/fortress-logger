using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortressLogger
{
    public class FortressLog
    {
        private static string _logPath { get; set; }
        private static string _folderName { get; set; }
        private static string _logDir { get; set; }
        private static string _debuggerFile { get; set; }
        private static string _errorFile { get; set; }
        private static string _alertFile { get; set; }
        private static string _infoFile { get; set; }
        private static string _fullLogFile { get; set;}
        private static string _databaseFile { get; set; }
        private static string _whiteSpace = "     ";

        /// <summary>
        /// Initialize the logger with a file path and an option name for the folder. The constructor will create the folder if it does not already exist
        /// If a folder name is not supplied, it will default to Fortress Logger Logs.
        /// </summary>
        /// <param name="filePath">REQUIRED: File path for the logs to be stored. Do NOT include a '/' at the end of the filepath</param>
        /// <param name="folderName">OPTIONAL: Name of the folder that the logs should be stored in</param>
        public FortressLog(string filePath, string folderName = "")
        {
            // Create the log directory if it is not already present
            _logPath = filePath;
            _folderName = string.IsNullOrEmpty(folderName) ? "Fortress Logger Logs" : folderName;
            _logDir = _logPath + "\\" + _folderName;
            var dirInfo = Directory.CreateDirectory(_logDir);

            // Set up File Name for levels
            _debuggerFile = _logDir + "\\Debugger.txt";
            _errorFile = _logDir + "\\Errors.txt";
            _alertFile = _logDir + "\\Alerts.txt";
            _infoFile = _logDir + "\\Info.txt";
            _databaseFile = _logDir + "\\Database.txt";
            var fullLogDir = Directory.CreateDirectory(_logDir + "\\Full Logs");
            _fullLogFile = _logDir + "\\Full Logs\\FullLogs.txt";
        }

        /// <summary>
        /// Writer a log message to the Debugger File. You may supply a function name to aid in logger readability
        /// </summary>
        /// <param name="message">REQUIRED: THe log message being recorded</param>
        /// <param name="functionName">OPTIONAL: The name of the method or function that the message is being recorded from. Defaults to 'Application'</param>
        public void LogDebugger(string message, string functionName = "")
        {
            // Build the message
            StringBuilder loggerLine = new StringBuilder();
            loggerLine.Append(DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(string.IsNullOrEmpty(functionName) ? "Application" : functionName);
            loggerLine.Append(_whiteSpace);
            loggerLine.Append("DEBUGGER");
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(message);

            // Write the message to the Debug file and the Full Log file
            using (StreamWriter writer = new StreamWriter(_debuggerFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }

            using (StreamWriter writer = new StreamWriter(_fullLogFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }
            return;
        }

        /// <summary>
        /// Write a message to the Error logger file
        /// </summary>
        /// <param name="message">REQUIRED: The message to be logged</param>
        /// <param name="functionName">OPTIONAL: Name of the function that the message is from</param>
        public void LogError(string message, string functionName = "")
        {
            // Build the message
            string header = "***** AN UNEXPECTED ERROR HAS OCCURED *****";
            StringBuilder loggerLine = new StringBuilder();
            loggerLine.Append(DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(string.IsNullOrEmpty(functionName) ? "Application" : functionName);
            loggerLine.Append(_whiteSpace);
            loggerLine.Append("ERROR");
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(message);
            string footer = "******************************************";

            // Write the message to the Debug file and the Full Log file
            using (StreamWriter writer = new StreamWriter(_errorFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }

            using (StreamWriter writer = new StreamWriter(_fullLogFile, true))
            {
                writer.WriteLine(header);
                writer.WriteLine(loggerLine.ToString());
                writer.WriteLine(footer);
            }
            return;
        }
        /// <summary>
        /// Write a message to the Alert logger file
        /// </summary>
        /// <param name="message">REQUIRED: The message to be logged</param>
        /// <param name="functionName">OPTIONAL: The name of the function that the message is being logged from</param>
        public void LogAlert(string message, string functionName = "")
        {
            // Build the message
            string header = "***** ALERT! *****";
            StringBuilder loggerLine = new StringBuilder();
            loggerLine.Append(DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(string.IsNullOrEmpty(functionName) ? "Application" : functionName);
            loggerLine.Append(_whiteSpace);
            loggerLine.Append("ALERT");
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(message);
            string footer = "****************************";

            // Write the message to the Debug file and the Full Log file
            using (StreamWriter writer = new StreamWriter(_alertFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }

            using (StreamWriter writer = new StreamWriter(_fullLogFile, true))
            {
                writer.WriteLine(header);
                writer.WriteLine(loggerLine.ToString());
                writer.WriteLine(footer);
            }
            return;
        }
        /// <summary>
        /// Log a message to the Info logger file
        /// </summary>
        /// <param name="message">REQUIRED: The message that is being logged</param>
        /// <param name="functionName">OPTIONAL: The name of the function that the message is being logged from</param>
        public void LogInfo(string message, string functionName = "")
        {
            // Build the message
            StringBuilder loggerLine = new StringBuilder();
            loggerLine.Append(DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(string.IsNullOrEmpty(functionName) ? "Application" : functionName);
            loggerLine.Append(_whiteSpace);
            loggerLine.Append("INFO");
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(message);

            // Write the message to the Debug file and the Full Log file
            using (StreamWriter writer = new StreamWriter(_infoFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }

            using (StreamWriter writer = new StreamWriter(_fullLogFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }
            return;
        }

        /// <summary>
        /// Log a message to log to the Database Log file. This level is meant to be used to write database related messages
        /// </summary>
        /// <param name="message">REQUIRED: The message that is being logged</param>
        /// <param name="functionName">OPTIONAL: The name of the function that the message is being logged from</param>
        public void LogDatabase(string message, string functionName = "")
        {
            // Build the message
            StringBuilder loggerLine = new StringBuilder();
            loggerLine.Append(DateTimeOffset.Now.ToString("MM/dd/yyyy HH:mm:ss"));
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(string.IsNullOrEmpty(functionName) ? "Application" : functionName);
            loggerLine.Append(_whiteSpace);
            loggerLine.Append("DATABASE");
            loggerLine.Append(_whiteSpace);
            loggerLine.Append(message);

            // Write the message to the Debug file and the Full Log file
            using (StreamWriter writer = new StreamWriter(_databaseFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }

            using (StreamWriter writer = new StreamWriter(_fullLogFile, true))
            {
                writer.WriteLine(loggerLine.ToString());
            }
            return;
        }
    }
}
