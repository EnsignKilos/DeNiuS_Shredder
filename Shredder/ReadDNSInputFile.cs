public class DNSListFileReader
{
    public HashSet<string> ReadFile(string filePath)
    {
        HashSet<string> lines = [];
        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
        {
            using (StreamReader reader = new(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }
        else 
        {
            throw new FileNotFoundException("File not found or empty", filePath);
        }
        return lines;
    }
}