using FortressLogger;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

FortressSqlLogger? logger = new FortressSqlLogger("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LogTesting;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
