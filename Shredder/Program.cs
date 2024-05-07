string dnsFQDNFilePath = args[0];
Console.Clear();

// Try to load and check file
Console.WriteLine($"Loading file at: {dnsFQDNFilePath}...");
try
{
    //TODO: Seperate and create a new method for laoding specifically and seperate this from the constructor.
    DNSListLoad loadedDNSFileHashset = new(dnsFQDNFilePath);
}
catch (DNSListLoadException dnsLoadListException)
{
    Console.WriteLine(dnsLoadListException.ToString());
    return;
}
Console.WriteLine($"Loaded entries from {dnsFQDNFilePath}");

// Split the entries into the top level domain, service provider domain, and canonical naming parts
DNSListSiftDomains siftedDNSList = new(loadedDNSFileHashset.FileImmutableHashSet);
if (sifteddnslist == null)
{
    Console.WriteLine("No entries to sift.");
    return;
}
else
{
    Console.WriteLine($"Sifted {siftedDNSList.SiftedCanonicalNames.Count} canonical names, {siftedDNSList.SiftedTopLevelDomains.Count} top level domains, {siftedDNSList.SiftedPaaSProviderDomains.Count} PaaS provider domains, {siftedDNSList.SiftedAWSDomains.Count} AWS domains, {siftedDNSList.SiftedAzureOrMicrosoftDomains.Count} Azure or Microsoft domains, and {siftedDNSList.SiftedCDNDomains.Count} CDN domains.");
}

// Start shredding
Console.WriteLine("Starting shredding...");
DNSListShredder shreddedlist = new(shredderqueue);
