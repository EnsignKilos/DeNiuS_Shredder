class DomainListLoader(string dnsFQDNFilePath)
{
    public HashSet<string> LoadedFile { get; private set; } = CreateFileHashSet(dnsFQDNFilePath);

    private static HashSet<string> CreateFileHashSet(string dnsFQDNFilePath)
    {
        HashSet<string> fileHashsetTemp = [];
        try
        {
            string? line;
            using StreamReader reader = new(dnsFQDNFilePath);
            while ((line = reader.ReadLine()) != null)
            {
                fileHashsetTemp.Add(line.ToLowerInvariant());
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory Not Found");
            throw new DNSListLoadError();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File Doesn't Exist");
            throw new DNSListLoadError();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Path Too Long");
            throw new DNSListLoadError();
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Download more WAM");
            throw new DNSListLoadError();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load {dnsFQDNFilePath} - {ex.Message}");
            throw new DNSListLoadError();
        }

        return fileHashsetTemp;
    }
}
class DNSListLoadError : Exception
{
    public DNSListLoadError()
    : base("Failed to do my job :(")
    {

    }
}