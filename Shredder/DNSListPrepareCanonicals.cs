class DNSListSiftDomains
{
    public HashSet<string> CanonicalNames { get; private set; }
    public HashSet<string> TopLevelDomains { get; private set; }
    public HashSet<string> ServiceProviderDomains { get; private set; }
    public HashSet<string> CloudProviderDomains { get; private set; }
    public HashSet<string> CDNDomains { get; private set; }

    public async Task SiftDomains(ConcurrentQueue<string> siftingqueue)
    {
        CanonicalNames = [];
        TopLevelDomains = [];
        ServiceProviderDomains = [];
        CloudProviderDomains = [];
        CDNDomains = [];

        var regexStrings = RegexStrings.Instance;
        List<GeneratedRegexAttribute> gcp = regexStrings.GCP;
        List<GeneratedRegexAttribute> aws = regexStrings.AWSService;
        List<GeneratedRegexAttribute> awsregion = regexStrings.AWSRegion;
        List<GeneratedRegexAttribute> azure = regexStrings.AzureOrMicrosoft;
        List<GeneratedRegexAttribute> cdn = regexStrings.CDNs;

        await Task.Run(() =>
        {
            while (siftingqueue.TryDequeue(out string? dnsentryitem))
            {
                foreach (var regex in regexStrings.AzureOrMicrosoft)
                {
                    if (regex.IsMatch(dnsentryitem))
                    {
                        // Add to matching part
                        // Example: CanonicalNames.Add(dnsentryitem);
                    }
                    else
                    {
                        // Add to non-matching part
                        // Example: TopLevelDomains.Add(dnsentryitem);
                    }
                }
            }
        });
    }
}