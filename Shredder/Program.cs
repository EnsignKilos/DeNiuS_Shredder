// See https://aka.ms/new-console-template for more information
string filePath = args[0];
DNSListFileReader DNSFileRead = new DNSListFileReader();
ConcurrentQueue<string> lines = DNSFileRead.LoadFile(filePath);
