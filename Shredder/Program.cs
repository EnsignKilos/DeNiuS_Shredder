string dnsFQDNFilePath = "C:\\Tools\\DNSList\\DNSlist.txt";
//Console.Clear();

// Try to load and check file
Console.WriteLine($"Loading file at: {dnsFQDNFilePath}...");
DNSListLoad loadedDNSFileHashset;
try
{
    //TODO: Seperate and create a new method for loading specifically and seperate this from the constructor.
    loadedDNSFileHashset = new DNSListLoad(dnsFQDNFilePath);
}
catch (DNSListLoadException dnsLoadListException)
{
    Console.WriteLine(dnsLoadListException.ToString());
    return;
}
Console.WriteLine($"Loaded entries from {dnsFQDNFilePath}");

//Create RegexStringGenerator and Call Creatstrings
Console.WriteLine("\nLoading regexlists....");
RegexStringGenerator.CreateRegexStringLists();
Console.WriteLine("\nDone!");

//Start shredding list - Use DNSListSplitRegexList   --- Why the hell is this return a number???
foreach (string dnsEntry in loadedDNSFileHashset.FileHashSet)
{
    foreach (Regex regexPattern in RegexStringGenerator.AWSServiceRegexList)
    {
        if (regexPattern.IsMatch(dnsEntry))
        {
            Console.WriteLine(dnsEntry);
            break;
        }
    }
}