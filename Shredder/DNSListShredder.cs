class DNSListShredder
{
    public ConcurrentBag<string> ShreddedQueue { get; private set; }

    public DNSListShredder(ConcurrentQueue<string> shredderqueue)
    {
        ShreddedQueue = ShredQueue(shredderqueue);
    }

    private ConcurrentBag<string> ShredQueue(ConcurrentQueue<string> shredderqueue)
    {
        ConcurrentBag<string> shreddedQueue = new(shredderqueue);
        return ShreddedQueue = shreddedQueue;
    }
}