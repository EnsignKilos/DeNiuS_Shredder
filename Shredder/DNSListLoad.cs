class DNSListLoad(string dnsFQDNFilePath)
{
    public ImmutableHashSet<string> FileImmutableHashSet { get; private set; } = CreateFileHashSet(dnsFQDNFilePath);

    private static ImmutableHashSet<string> CreateFileHashSet(string dnsFQDNFilePath)
    {
        ImmutableHashSet<string>.Builder builder = ImmutableHashSet.CreateBuilder<string>();
        
        try 
        {
            string? line;
            using StreamReader reader = new(dnsFQDNFilePath);
            while ((line = reader.ReadLine()) != null)
            {
                builder.Add(line.ToLowerInvariant());
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
        
        return builder.ToImmutableHashSet();
    }
}