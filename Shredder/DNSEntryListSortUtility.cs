class DNSEntryListSortUtility(HashSet<string> loadedFile)
{
    public List<ProcessedDNSEntryRecord> SortLoadedFileData()
    {
        return DNSListSort(loadedFile);
    }

    private static List<ProcessedDNSEntryRecord> DNSListSort(HashSet<string> loadedFile)
    {
        List<ProcessedDNSEntryRecord> processedEntries = new List<ProcessedDNSEntryRecord>();
        foreach (string entry in loadedFile)
        {
            string fqdn = entry;
            string type;
            string topLevelDomain;
            List<string> subDomainParts;
            int subDomainPartLength;



            ProcessedDNSEntryRecord processedEntry = new ProcessedDNSEntryRecord(fqdn, type, topLevelDomain, subDomainParts, subDomainPartLength);
        }
        return processedEntries;
    }
}




// public record ProcessedDNSEntryRecord(string FQDN, string Type, string TopLevelDomain, List<string> SubDomainParts, int SubDomainPartLength)
