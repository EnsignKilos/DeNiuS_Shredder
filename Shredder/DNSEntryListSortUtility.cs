public class DNSEntryListSortUtility
{
    public ProcessedDNSEntryRecord SortDNSEntry(string entry)
    {
        string type = string.Empty;
        string topLevelDomain = string.Empty;
        List<string> subDomainParts = new List<string>();
        int subDomainPartLength = 0;

        // Define a local function to process regex lists in parallel
        void ProcessRegexListParallel(List<Regex> regexList, string typeName)
        {
            Parallel.ForEach(regexList, (regexString, state) =>
            {
                if (regexString.IsMatch(entry))
                {
                    type = typeName;
                    var matches = regexString.Split(entry);
                    topLevelDomain = matches[^1];
                    subDomainParts = new List<string>(matches[1..^2]);
                    subDomainPartLength = subDomainParts.Count;
                    state.Stop();
                }
            });
        }

        // Process each regex list in parallel
        ProcessRegexListParallel(RegexStringGenerator.MicrosoftRegexList, "Microsoft");
        if (string.IsNullOrEmpty(type))
            ProcessRegexListParallel(RegexStringGenerator.GCPRegexList, "Google");
        if (string.IsNullOrEmpty(type))
            ProcessRegexListParallel(RegexStringGenerator.AWSServiceRegexList, "Amazon");
        if (string.IsNullOrEmpty(type))
            ProcessRegexListParallel(RegexStringGenerator.CDNsRegexList, "CDNServices");
        if (string.IsNullOrEmpty(type))
            ProcessRegexListParallel(RegexStringGenerator.DigitalOceanRegexList, "DigitalOcean");
        if (string.IsNullOrEmpty(type))
            ProcessRegexListParallel(RegexStringGenerator.PaaSProvidersRegexList, "PaaSProviders");
        else Console.WriteLine("No match found for: " + entry);
        {
            type = "Unknown";
            var splitEntry = new List<string>(entry.Split('.', StringSplitOptions.RemoveEmptyEntries));
            topLevelDomain = splitEntry[^2..^1];
            subDomainParts = ;
            subDomainPartLength = 0;
        };
        Console.WriteLine($"FQDN: {entry} Type: {type}, Top Level Domain: {topLevelDomain}, Sub Domain Parts Count: {subDomainPartLength}");
            return new ProcessedDNSEntryRecord(entry, type, topLevelDomain, subDomainParts, subDomainPartLength);
    }
}