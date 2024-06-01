class DNSEntryListSortUtility(HashSet<string> loadedFile)
{
    public DNSEntryListSortUtility()
    {
        DNSListSort();
    }

    private static void DNSListSort()
    {
        List<ProcessedDNSEntryRecord> processedEntries = new List<ProcessedDNSEntryRecord>();

        Parallel.ForEach(loadedFile, entry =>
        {
            // Perform multiple regex splits
            string[] split1 = Regex.Split(entry, "regexPattern1");
            string[] split2 = Regex.Split(entry, "regexPattern2");
            string[] split3 = Regex.Split(entry, "regexPattern3");

            // Create a ProcessedDNSEntryRecord and store the elements of the regex split
            ProcessedDNSEntryRecord processedEntry = new ProcessedDNSEntryRecord
            {
                Split1Elements = split1,
                Split2Elements = split2,
                Split3Elements = split3
            };

            lock (processedEntries)
            {
                processedEntries.Add(processedEntry);
            }
        });

        // Use the processedEntries list as needed
    }
}