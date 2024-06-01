class DNSEntryListSortUtility(HashSet<string> loadedFile)
{
    public List<ProcessedDNSEntryRecord> SortLoadedFileData()
    {
        DNSListSort();
    }

    private static void DNSListSort()
    {
        List<ProcessedDNSEntryRecord> processedEntries = new List<ProcessedDNSEntryRecord>();
        foreach (string entry in loadedFile)
        {
            string[] entryParts = entry.Split('.');
            string topLevelDomain = entryParts[^1];
            List<string> subDomainParts = entryParts.ToList();
            subDomainParts.RemoveAt(subDomainParts.Count - 1);
            ProcessedDNSEntryRecord processedEntry = new ProcessedDNSEntryRecord(entry, "A", topLevelDomain, subDomainParts, subDomainParts.Count);
            processedEntries.Add(processedEntry);
        }
    }
}