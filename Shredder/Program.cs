// See https://aka.ms/new-console-template for more information
string filePath = args[0];
HashSet<string> inputList = [];
if (args.Length == 0)
{
    Console.WriteLine("No arguments provided, exiting...");
    Environment.Exit(1);
}
if (!File.Exists(filePath))
{
    Console.WriteLine("File does not exist, exiting...");
    Environment.Exit(1);
}
if (File.ReadAllLines(filePath).Length == 0)
{
    Console.WriteLine("File is empty, exiting...");
    Environment.Exit(1);
}
if (File.ReadAllLines(filePath).GetType() != typeof(string[]))
{
    Console.WriteLine("File is not a list of strings, exiting...");
    Environment.Exit(1);
}
else
{
    Console.WriteLine("File exists, and appears to be of a valid type - reading it now..."); ;
    inputList = new HashSet<string>(File.ReadAllLines(filePath));
}