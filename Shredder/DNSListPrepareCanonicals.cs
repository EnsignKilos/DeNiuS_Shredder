class DNSListSiftDomains
{
    public HashSet<string> CanonicalNames { get; private set; }
    public HashSet<string> TopLevelDomains { get; private set; }
    public HashSet<string> SaaSProviderDomains { get; private set; }
    public HashSet<string> AWSDomains { get; private set; }
    public HashSet<string> AzureOrMicrosoftDomains { get; private set; }
    public HashSet<string> CDNDomains { get; private set; }

    public async Task SiftDomains(ConcurrentQueue<string> siftingqueue)
    {
        var regexStrings = RegexStrings.Instance;

        await Task.Run(() =>
        {
            while (siftingqueue.TryDequeue(out string? dnsentryitem))
            {
                ConcurrentBag<string> AWSService = [];
                ConcurrentBag<string> AWSRegion = [];
                ConcurrentBag<string> PaaSProviders = [];
                ConcurrentBag<string> CDN = [];
                ConcurrentBag<string> AzureOrMicrosoft = [];
                ConcurrentBag<string> CanonicalNames = [];
                ConcurrentBag<string> TopLevelDomain = [];

                Parallel.ForEach(regexStrings.PaaSProviders, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Split(dnsentryitem);
                    if (match.Length > 1)
                    {
                        CanonicalNames.Add(match[1]);
                        PaaSProviders.Add(match[2]);
                    }
                });

                Parallel.ForEach(regexStrings.CDNs, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Split(dnsentryitem);
                    if (match.Length > 1)
                    {
                        CanonicalNames.Add(match[1]);
                        CDN.Add(match[2]);
                    }
                });

                Parallel.ForEach(regexStrings.AzureOrMicrosoft, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Split(dnsentryitem);
                    if (match.Length > 1)
                    {
                        CanonicalNames.Add(match[1]);
                        AzureOrMicrosoft.Add(match[2]);
                    }
                });

                Parallel.ForEach(regexStrings.AWSService, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Split(dnsentryitem);
                    if (match.Length > 1)
                    {
                        CanonicalNames.Add(match[1]);
                        AWSService.Add(match[2]);
                    }
                });

                Parallel.ForEach(regexStrings.AWSRegion, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Split(dnsentryitem);
                    if (match.Length > 1)
                    {
                        CanonicalNames.Add(match[1]);
                        AWSRegion.Add(match[2]);
                    }
                });
            }
        }
                );

    }
};