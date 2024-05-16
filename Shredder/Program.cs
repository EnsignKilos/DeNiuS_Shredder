﻿using System.Security;

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

//Start shredding list - Use DNSListSplitRegexList   --- WHy the hell is this return a number???
foreach (string dnsEntry in loadedDNSFileHashset.FileHashSet)
{
    foreach (Regex regexPattern in RegexStringGenerator.GCPRegexList)
    {
        var parts = regexPattern.Split(dnsEntry);
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
    }
}