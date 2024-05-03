class DNSListSiftDomains
{
    public HashSet<string>? SiftedCanonicalNames { get; private set; }
    public HashSet<string>? SiftedTopLevelDomains { get; private set; }
    public HashSet<string>? SiftedPaaSProviderDomains { get; private set; }
    public HashSet<string>? SiftedAWSDomains { get; private set; }
    public HashSet<string>? SiftedAzureOrMicrosoftDomains { get; private set; }
    public HashSet<string>? SiftedCDNDomains { get; private set; }

    public DNSListSiftDomains(ImmutableHashSet<string> loadedDNSFileHashset)
    {
        SiftedCanonicalNames = [];
        SiftedTopLevelDomains = [];
        SiftedPaaSProviderDomains = [];
        SiftedAWSDomains = [];
        SiftedAzureOrMicrosoftDomains = [];
        SiftedCDNDomains = [];
    }
};