public class DNSListLoader
{
    public ImmutableHashSet<string>? FileHashSet { get; private set; }
    public ConcurrentQueue<string>? FileQueue { get; private set; }

    public ConcurrentQueue<string> LoadFile(string filePath)
    {
        FileHashSet = CreateFileHashSet(filePath);
        return CreateMultithreadedQueue(FileHashSet);
    }

    private ImmutableHashSet<string> CreateFileHashSet(string filePath)
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
            using (StreamReader reader = new(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    builder.Add(line);
                }
            }
        }
        return builder.ToImmutable();
    }

    private ConcurrentQueue<string> CreateMultithreadedQueue(ImmutableHashSet<string> Entries)
    {
        ConcurrentQueue<string> lines = new ConcurrentQueue<string>(Entries);
        return FileQueue = lines;
    }
} 