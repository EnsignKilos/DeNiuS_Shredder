string dnsFQDNFilePath = "C:\\Tools\\DNSList\\DNSlist.txt";
//Console.Clear();

// Try to load and check file
Console.WriteLine($"Loading file at: {dnsFQDNFilePath}...");
DomainListLoader loadedFile;
try
{
    loadedFile = new DomainListLoader(dnsFQDNFilePath);
}
catch (DNSListLoadError dnsLoadListException)
{
    Console.WriteLine(dnsLoadListException.ToString());
    return;
}
Console.WriteLine($"Loaded entries from {dnsFQDNFilePath}");

// Perform regex matching on each entry in the file and print out the matches
Console.WriteLine(loadedFile.LoadedFile.FirstOrDefault());

// Sort the DNS entries
DNSEntryListSortUtility dnsEntryListSortUtility = new DNSEntryListSortUtility();
foreach (string entry in loadedFile.LoadedFile)
{
    dnsEntryListSortUtility.SortDNSEntry(entry);
}
