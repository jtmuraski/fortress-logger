# Welcome to Fortress Logger

Fortress Logger was created because I was not a fan of the default ILogger system that is the typical option for C# projects. So I opted to build and 
create my own logger library that did what I wanted and how I wanted. After using this in my own projects, I decided to expand on it and make it more useful,
and I figured that I would share it with the world and see if anyone else had a use for it!

## Features
- Four logging levels - Debug, Alert, Error and Info
- Logs can be saved to any file location
- Logs are split => there is a seperate file for each logging level, plus a Full Log file that contains a log of everything
	- This makes it easier to quickly look at just error messages or debug message while also maintaining a way to keep the log of everything in order
 
 ## Development Roadmap
 The following features are what are currently being planned to be implemented to Fortress Logger in the future:
 - Write log messages to Sql Server database table
 - Write log messages to a PostgreSql database table
 - Write log messages to a MySql database table
 - Include configuration options for things like a max file size for log files
 
 ## Release Notes
 __V 0.2.0 December 26th, 2022__

- Allow messages to be saved to a SQL Database table
- When the logger is initialized, the constructor will ensure that the proper database table has been created
- Using the FortressSqlLogger can be configured to write to both the database and the log text files, just like in V 0.1.0
- Added a Database level of logging to the original four
- Currently when using the FortressSqlLogger type, all message will be written to a database, and only writtern to a file if configured to do so. At this time, you CANNOT use FotressSqlLogger to write messages
  to a text file and NOT the database. If you wish to write to a text file and not a database, initialize a new instance of Fortress Logger using the same filepath. If enough people ask for this to be an option
  using FortressSqlLogger, I will look into changing it.
  
 __V 0.1.0__
 
 This is the initial release version of Fortress Logger and include the following features:
- Log 4 different alert levels (Debug, Info, Alert and Error)
- A log messge is stored in 2 places: one in a Full Log file that records all messages and a level specific file
 - The level specific file is mean to make it easier to find specifc type os messages. This was also a pet peeve of mine in other logging methods. I hate sifting through
    thousands of lines of useless log messages to find the error message that I was lookgin for
- Logs can be saved to the file location of your choice, as long as the application has access to that file location
