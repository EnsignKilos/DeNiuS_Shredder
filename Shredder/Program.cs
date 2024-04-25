// See https://aka.ms/new-console-template for more information
string filePath = args[0];
Console.Clear();

// Load and check file
Console.WriteLine($"Loading file at: {filePath}...");
DNSListLoader dnslistloader = new();
ConcurrentQueue<string> siftingqueue = dnslistloader.LoadFile(filePath);
Console.WriteLine($"Loaded {siftingqueue.Count} entries from {filePath}");

// Split the entries into the top level domain, service provider domain, and canonical naming parts
DNSListSiftDomains sifteddnslist = new();
await sifteddnslist.SiftDomains(siftingqueue);
Console.WriteLine($"Sifted {sifteddnslist.CanonicalNames.Count} cnames, {sifteddnslist.TopLevelDomains.Count} top level domains, {sifteddnslist.ServiceProviderDomains.Count} service provider domains, {sifteddnslist.CloudProviderDomains.Count} cloud provider domains, and {sifteddnslist.CDNDomains.Count} CDN domains from {filePath}.");
Console.WriteLine("Proceeding to list analysis...");

// Start shredding
Console.WriteLine("Starting shredding...");
DNSListShredder shreddedlist = new(shredderqueue);
