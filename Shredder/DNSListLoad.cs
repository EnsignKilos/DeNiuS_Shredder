class DNSListLoad(string filePath)
{
    public ImmutableHashSet<string>? FileHashSet { get; private set; } = CreateFileHashSet(filePath);

    private static ImmutableHashSet<string> CreateFileHashSet(string filePath)
    {
        var builder = ImmutableHashSet.CreateBuilder<string>();
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found", filePath);
        }
        else if (new FileInfo(filePath).Length == 0)
        {
            throw new FileNotFoundException("File is empty", filePath);
        }
        else
        {
            using StreamReader reader = new(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                builder.Add(line.ToLowerInvariant());
            }
        }
        return builder.ToImmutable();
    }
}