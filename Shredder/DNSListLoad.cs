class DNSListLoad(string dnsFQDNFilePath)
{
    public HashSet<string> FileHashSet { get; private set; } = CreateFileHashSet(dnsFQDNFilePath);

    private static HashSet<string> CreateFileHashSet(string dnsFQDNFilePath)
    {
        HashSet<string> fileHashsetTemp = new HashSet<string>();

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
            throw new DNSListLoadException();
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("File Doesn't Exist");
            throw new DNSListLoadException();
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("Path Too Long");
            throw new DNSListLoadException();

        }

        catch (OutOfMemoryException)
        {
            Console.WriteLine("Download more WAM");
            throw new DNSListLoadException();

        }

        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load {dnsFQDNFilePath} - {ex.Message}");
            throw new DNSListLoadException();
        }

        return fileHashsetTemp;
    }
}