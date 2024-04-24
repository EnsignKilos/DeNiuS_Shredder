// See https://aka.ms/new-console-template for more information
string filePath = args[0];
DNSListLoader DNSFileRead = new DNSListLoader();
ConcurrentQueue<string> lines = DNSFileRead.LoadFile(filePath);
