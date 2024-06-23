public class DNSEntryListSortUtility
{
    public ProcessedDNSEntryRecord SortDNSEntry(string entry)
    {
        string type = string.Empty;
        string topLevelDomain = string.Empty;
        HashSet<string> subDomainParts = new HashSet<string>();
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
                    subDomainParts = new HashSet<string>(matches[1..^2]);
                    subDomainPartLength = subDomainParts.Count;
                    state.Stop();
                }
            });
        }

        // Process each regex list in parallel - starts ms then looks for hits elsewhere if no type is set yet (loop will break on match).
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

        else Console.WriteLine("No match found for: " + entry + " in any of the regex lists, defaulting to Unknown Type and 2 parts for subdomain.");
        {
            type = "Unknown";
            var splitEntry = entry.Split('.', StringSplitOptions.RemoveEmptyEntries);
            topLevelDomain = string.Join(".", splitEntry[^2..]);
            subDomainParts = new HashSet<string>(splitEntry[..^2]);
            subDomainPartLength = 0;
        };
        Console.WriteLine($"FQDN: {entry} Type: {type}, Top Level Domain: {topLevelDomain}, Sub Domain Parts Count: {subDomainPartLength}");
            return new ProcessedDNSEntryRecord(entry, type, topLevelDomain, subDomainParts, subDomainPartLength);
    }
}