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
        CanonicalNames = [];
        TopLevelDomains = [];
        SaaSProviderDomains = [];
        AWSDomains = [];
        AzureOrMicrosoftDomains = [];
        CDNDomains = [];

        var regexStrings = RegexStrings.Instance;



        await Task.Run(() =>
        {
            while (siftingqueue.TryDequeue(out string? dnsentryitem))
            {
                var match = string.Empty;
                var match2 = string.Empty;
                var canonicalname = string.Empty;
                var topleveldomain = string.Empty;

                Parallel.ForEach(regexStrings.CDNs, (regexstring) =>
                {
                    var regex = new Regex(regexstring.Pattern);
                    var match = regex.Match(dnsentryitem);
                    if (match.Success)
                    {
                        canonicalname = match.Groups[1].Value;
                        topleveldomain = match.Groups[2].Value;
                    }
                });
            }
        }
                );
    }
};