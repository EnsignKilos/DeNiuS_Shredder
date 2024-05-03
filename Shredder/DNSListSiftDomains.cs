class DNSListSiftDomains
{
    public HashSet<string> SiftedCanonicalNames { get; private set; }
    public HashSet<string> SiftedTopLevelDomains { get; private set; }
    public HashSet<string> SiftedPaaSProviderDomains { get; private set; }
    public HashSet<string> SiftedAWSDomains { get; private set; }
    public HashSet<string> SiftedAWSRegions { get; private set; }
    public HashSet<string> SiftedAzureOrMicrosoftDomains { get; private set; }
    public HashSet<string> SiftedCDNDomains { get; private set; }

    public void DNSListSiftDomains(ConcurrentQueue<string> siftingQueue)
    {
        var regexStrings = RegexStrings.Instance;
        ProcessSiftingQueue(siftingQueue);
    }

    private void ProcessSiftingQueue(ConcurrentQueue<string> siftingQueue)
    {
        while (siftingQueue.TryDequeue(out string? dnsEntryItem))
        {
            bool matchFound = false;

            var tasks = new List<Task>();

            ProcessRegexListPaaSProviders(dnsEntryItem, tasks, ref matchFound);
            if (matchFound)
                continue;

            ProcessRegexListCDNs(dnsEntryItem, tasks, ref matchFound);
            if (matchFound)
                continue;

            ProcessRegexListAzureOrMicrosoft(dnsEntryItem, tasks, ref matchFound);
            if (matchFound)
                continue;

            ProcessRegexListAWS(dnsEntryItem, tasks, ref matchFound);
            if (matchFound)
                continue;

            Task.WaitAny(tasks.ToArray());
        }
    }

    private void ProcessRegexListPaaSProviders(string dnsEntryItem, List<Task> tasks, ref bool matchFound)
    {
        Parallel.ForEach(regexStrings.GenRegexListPaaSProviders, (regexstring, state) =>
        {
            tasks.Add(Task.Run(() =>
            {
                var regex = new Regex(regexstring.Pattern);
                var match = regex.Split(dnsEntryItem);
                if (match.Length > 1)
                {
                    SiftedCanonicalNames.Add(match[1]);
                    SiftedPaaSProviderDomains.Add(match[2]);
                    matchFound = true;
                    state.Stop();
                }
            }));
        });
    }

    private void ProcessRegexListCDNs(string dnsEntryItem, List<Task> tasks, ref bool matchFound)
    {
        Parallel.ForEach(regexStrings.GenRegexListCDNs, (regexstring, state) =>
        {
            tasks.Add(Task.Run(() =>
            {
                var regex = new Regex(regexstring.Pattern);
                var match = regex.Split(dnsEntryItem);
                if (match.Length > 1)
                {
                    SiftedCanonicalNames.Add(match[1]);
                    SiftedCDNDomains.Add(match[2]);
                    matchFound = true;
                    state.Stop();
                }
            }));
        });
    }

    private void ProcessRegexListAzureOrMicrosoft(string dnsEntryItem, List<Task> tasks, ref bool matchFound)
    {
        Parallel.ForEach(regexStrings.GenRegexListAzureOrMicrosoft, (regexstring, state) =>
        {
            tasks.Add(Task.Run(() =>
            {
                var regex = new Regex(regexstring.Pattern);
                var match = regex.Split(dnsEntryItem);
                if (match.Length > 1)
                {
                    SiftedCanonicalNames.Add(match[1]);
                    SiftedAzureOrMicrosoft.Add(match[2]);
                    matchFound = true;
                    state.Stop();
                }
            }));
        });
    }

    private void ProcessRegexListAWS(string dnsEntryItem, List<Task> tasks, ref bool matchFound)
    {
        Parallel.ForEach(regexStrings.GenRegexListAWSService, (regexstring, serviceState) =>
        {
            tasks.Add(Task.Run(() =>
            {
                var serviceRegex = new Regex(regexstring.Pattern);
                var serviceMatch = serviceRegex.Split(dnsEntryItem);
                if (serviceMatch.Length > 1)
                {
                    var awsService = serviceMatch[2];
                    var siftedAWSDomain = awsService;
                    SiftedCanonicalNames.Add(serviceMatch[1]);
                    SiftedAWSDomains.Add(siftedAWSDomain);
                    matchFound = true;
                    serviceState.Stop();
                }
            }));
        });
    }
};