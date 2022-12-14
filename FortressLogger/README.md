# Welcome to Fortress Logger

Fortress Logger was created because I was not a fan of the default ILogger system that is the typical option for C# projects. So I opted to build and 
create my own logger library that did what I wanted and how I wanted. After using this in my own projects, I decided to expand on it and make it more useful,
and I figured that I would share it with the world and see if anyone else had a use for it!

## Features
- Five logging levels - Debug, Alert, Error and Info and NEW! Database
- Logs can be saved to any file location
- Logs are split => there is a seperate file for each logging level, plus a Full Log file that contains a log of everything
	- This makes it easier to quickly look at just error messages or debug message while also maintaining a way to keep the log of everything in order

**Link To Github Repo**: [Fortress Logger GitHub Repo](https://github.com/jtmuraski/fortress-logger)

## Bug Reporting
If you encounter any bugs, errors or issues, please open an Issue on the GitHub page, and I will work on fixing at asap!

## Release Notes

__V 0.2.0 December 26th, 2022__

- Allow messages to be saved to a SQL Database table
- When the logger is initialized, the constructor will ensure that the proper database table has been created
- Using the FortressSqlLogger can be configured to write to both the database and the log text files, just like in V 0.1.0
- Added a Database level of logging to the original four
- Currently when using the FortressSqlLogger type, all message will be written to a database, and only writtern to a file if configured to do so. At this time, you CANNOT use FotressSqlLogger to write messages
  to a text file and NOT the database. If you wish to write to a text file and not a database, initialize a new instance of Fortress Logger using the same filepath. If enough people ask for this to be an option
  using FortressSqlLogger, I will look into changing it.

__V 0.1.0 December 19th, 2022__

- Initial build release of Fortress Logger
- Allows for logging of 3 different logging levels
- Assign directory for files to be created



