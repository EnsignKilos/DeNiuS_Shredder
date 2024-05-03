class DNSListSiftDomains
{
    public HashSet<string>? SiftedCanonicalNames { get; private set; }
    public HashSet<string>? SiftedTopLevelDomains { get; private set; }
    public HashSet<string>? SiftedPaaSProviderDomains { get; private set; }
    public HashSet<string>? SiftedAWSDomains { get; private set; }
    public HashSet<string>? SiftedAzureOrMicrosoftDomains { get; private set; }
    public HashSet<string>? SiftedCDNDomains { get; private set; }

    public DNSListSiftDomains(ConcurrentQueue<string> siftingQueue)
    {
        SiftedCanonicalNames = new HashSet<string>();
        SiftedTopLevelDomains = new HashSet<string>();
        SiftedPaaSProviderDomains = new HashSet<string>();
        SiftedAWSDomains = new HashSet<string>();
        SiftedAzureOrMicrosoftDomains = new HashSet<string>();
        SiftedCDNDomains = new HashSet<string>();
        SiftDomains(siftingQueue);
    }

    private void SiftDomains(ConcurrentQueue<string> siftingQueue)
    {
        
        while (siftingQueue.TryDequeue(out string? queueitem))
        {
            
        }
    }
};