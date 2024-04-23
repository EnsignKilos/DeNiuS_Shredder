// See https://aka.ms/new-console-template for more information
string filePath = args[0];
DNSListFileReader DNSFileRead = new DNSListFileReader();
HashSet<string> lines = DNSFileRead.ReadFile(filePath);
