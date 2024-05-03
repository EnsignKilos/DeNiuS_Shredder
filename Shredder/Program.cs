// See https://aka.ms/new-console-template for more information
string filePath = args[0];
Console.Clear();

// Load and check file
Console.WriteLine($"Loading file at: {filePath}...");
DNSListLoad loadedDNSFileHashset = new(filePath);
Console.WriteLine($"Loaded entries from {filePath}");

// Split the entries into the top level domain, service provider domain, and canonical naming parts
DNSListSiftDomains? siftedDNSList = new(loadedDNSFileHashset.FileHashSet);
if (sifteddnslist == null)
{
    Console.WriteLine("No entries to sift.");
    return;
}
else {
Console.WriteLine($"Sifted {siftedDNSList.SiftedCanonicalNames.Count} canonical names, {siftedDNSList.SiftedTopLevelDomains.Count} top level domains, {siftedDNSList.SiftedPaaSProviderDomains.Count} PaaS provider domains, {siftedDNSList.SiftedAWSDomains.Count} AWS domains, {siftedDNSList.SiftedAzureOrMicrosoftDomains.Count} Azure or Microsoft domains, and {siftedDNSList.SiftedCDNDomains.Count} CDN domains.");
}

// Start shredding
Console.WriteLine("Starting shredding...");
DNSListShredder shreddedlist = new(shredderqueue);
