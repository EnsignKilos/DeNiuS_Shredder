// See https://aka.ms/new-console-template for more information
string filePath = args[0];
Console.Clear();

// Load and check file
Console.WriteLine($"Loading file at: {filePath}...");
DNSListLoader dnslistloader = new();
ConcurrentQueue<string> siftingQueue = dnslistloader.LoadFile(filePath);
Console.WriteLine($"Loaded {siftingQueue.Count} entries from {filePath}");

// Split the entries into the top level domain, service provider domain, and canonical naming parts
DNSListSiftDomains? sifteddnslist = new(siftingQueue);
if (sifteddnslist == null)
{
    Console.WriteLine("No entries to sift.");
    return;
}
else {
Console.WriteLine($"Sifted {sifteddnslist.SiftedCanonicalNames.Count} canonical names, {sifteddnslist.SiftedTopLevelDomains.Count} top level domains, {sifteddnslist.SiftedPaaSProviderDomains.Count} PaaS provider domains, {sifteddnslist.SiftedAWSDomains.Count} AWS domains, {sifteddnslist.SiftedAzureOrMicrosoftDomains.Count} Azure or Microsoft domains, and {sifteddnslist.SiftedCDNDomains.Count} CDN domains.");
}

// Start shredding
Console.WriteLine("Starting shredding...");
DNSListShredder shreddedlist = new(shredderqueue);
