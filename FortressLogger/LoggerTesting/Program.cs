using FortressLogger;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

FortressSqlLogger? logger = new FortressSqlLogger("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LogTesting;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", "", true, "C:\\Projects\\Testing Apps\\TestFortressLogger\\Test Logs");
logger.SqlLogger(AlertLevel.Debug, "Testing DEbug Logger", "Program.cs");
Console.WriteLine("Debigger logged");
logger.SqlLogger(AlertLevel.Error, "Testing Error logger", "Program.cs");
Console.WriteLine("Error logged");
logger.SqlLogger(AlertLevel.Alert, "Testing Alert logger", "Program.cs");
Console.WriteLine("Alert logged");
logger.SqlLogger(AlertLevel.Info, "Testing Info logger", "Program.cs");
Console.WriteLine("Info logged");
logger.SqlLogger(AlertLevel.Database, "Testing Database logger", "Program.cs");
Console.WriteLine("Database logged");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
