﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using FortressLogger;

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
        private string _schema { get; set; }

        // --Logger File Variables--
        FortressLog _logger { get; set; }
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
        public FortressSqlLogger(string connectionString, string schema = "", bool logToFile = false, string logDir = "", string folderName = "Application")
        {
            // Validate Parameters
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("The connectionString parameter may NOT be left null. A valid connection string must be supplied");

            if (logToFile)
                if (string.IsNullOrEmpty(logDir))
                    throw new ArgumentNullException("If logToFile is set to TRUE, a valid filepath must be provided and may not be left null");


            // Set Up Sql Connection
            _connString = connectionString;
            _schema = schema;
            SqlConnection _conn = new SqlConnection(connectionString);
            if (_conn == null)
                throw new ArgumentNullException("The Sql Connection preperty did not initialize properlhy.");
            _conn.Open();
            // Connect to the database and verify that the logging table is present in the database
            if (!VerifyLoggingTableIsPresent())
                CreateLoggingTable(schema);

            // If logToFile is true, set up the FortressLog instance
            _logger = new FortressLog(logDir, folderName);
        }

        public void SqlLogger(AlertLevel alertLevel, string message = "", string functionName = "")
        {
            string query = string.Format(@"INSERT INTO {0}FortressLoggerMessages (TimeStamp_Utc, AlertLevel, FunctionName, Message)
                                            VALUES( @time, @alertLevel, @functionName, @message);", _schema);
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                // Add Parameters
                cmd.Parameters.Add("@time", SqlDbType.DateTimeOffset).Value = DateTimeOffset.UtcNow;
                cmd.Parameters.Add("@alertLevel", SqlDbType.NVarChar).Value = alertLevel.ToString();
                cmd.Parameters.Add("@functionName", SqlDbType.NVarChar).Value = functionName;
                cmd.Parameters.Add("message", SqlDbType.NVarChar).Value = message;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return;
        }

        private bool VerifyLoggingTableIsPresent()
        {
            bool tableExists = false;
            string query = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FortressLoggerMessages')
                                SELECT 'TRUE' AS 'TableExists'
                             ELSE
                                SELECT 'FALSE' AS 'TableExists'; ";
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                using (conn)
                using (cmd)
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            tableExists = reader["TableExists"].ToString() == "TRUE" ? true : false;
                        }
                    }
                }
                return tableExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void CreateLoggingTable(string schema)
        {
            string query = string.Format(@"CREATE TABLE {0}FortressLoggerMessages (
                                            MessageId int IDENTITY(1,1),
                                            TimeStamp_Utc datetimeoffset(7),
                                            AlertLevel nvarchar(32),
                                            FunctionName nvarchar(128),
                                            Message nvarchar(1500)
                                            );", schema);

            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                using (conn)
                using (cmd)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
        }
    }
}
