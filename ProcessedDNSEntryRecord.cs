public record ProcessedDNSEntryRecord(string FQDN, string Type, string TopLevelDomain, HashSet<string> SubDomainParts, int SubDomainPartLength)
{
    [Required]
    public string FQDN { get; init; } = FQDN;

    [Required]
    public string Type { get; init; } = Type;

    [Required]
    public string TopLevelDomain { get; init; } = TopLevelDomain;

    [Required]
    public HashSet<string> SubDomainParts { get; init; } = SubDomainParts;

    [Required]
    public int SubDomainPartLength { get; init; } = SubDomainPartLength;
}