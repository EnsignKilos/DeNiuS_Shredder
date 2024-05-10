static class RegexStringGenerator
{
    public static ImmutableList<Regex> MicrosoftRegexList { get; private set; }
    public static ImmutableList<Regex> AWSServiceRegexList { get; private set; }
    public static ImmutableList<Regex> GCPRegexList { get; private set; }
    public static ImmutableList<Regex> PaaSProvidersRegexList { get; private set; }
    public static ImmutableList<Regex> CDNsRegexList { get; private set; }
    public static ImmutableList<Regex> DigitalOceanRegexList { get; private set; }

    static RegexStringGenerator()
    {
        Console.WriteLine("Regex search strings are being generated.");
        MicrosoftRegexList = GenerateRegexList(MicrosoftRegexSearchStringList);
        AWSServiceRegexList = GenerateRegexList(AWSRegexSearchStringList);
        GCPRegexList = GenerateRegexList(GCPRegexSearchStringList);
        DigitalOceanRegexList = GenerateRegexList(DigitalOceanRegexSearchStringList);
        PaaSProvidersRegexList = GenerateRegexList(PaaSProvidersRegexSearchStringList);
        CDNsRegexList = GenerateRegexList(CDNRegexSearchStringList);
    }

    private static ImmutableList<Regex> GenerateRegexList(List<string> regexSearchStringList)
    {
        List<Regex> localCompiledRegexList = new List<Regex>();

        foreach (string regexPattern in regexSearchStringList)
        {
            GeneratedRegexAttribute generatedAttribute = new GeneratedRegexAttribute(regexPattern, RegexOptions.CultureInvariant | RegexOptions.RightToLeft);
            localCompiledRegexList.Add(new Regex(generatedAttribute.Pattern, generatedAttribute.Options));
        }

        return localCompiledRegexList.ToImmutableList();
    }

    private static readonly List<string> MicrosoftRegexSearchStringList =
    [
        @"\.aadrm\.com$",
        @"\.ajax\.aspnetcdn\.com$",
        @"\.aka\.ms$",
        @"\.appex(?:-rf\.msn|\.bing)\.com$",
        @"\.assets-yammer\.com$",
        @"\.auth\.gfx\.ms$",
        @"\.autologon\.microsoftazuread-sso\.com$",
        @"\.azmk8s\.io$",
        @"\.azure(?:-api|-apim|-mobile|container|cr|edge|fd|rms|staticapps|websites)?(?:\.net|\.com|\.io)$",
        @"\.bing\.com$",
        @"\.cdn\.onenote\.net$",
        @"\.clientconfig\.microsoftonline-p\.net$",
        @"\.cloud\.microsoft$",
        @"\.cloudapp\.net$",
        @"\.d\.docs\.live\.net$",
        @"\.dc\.services\.visualstudio\.com$",
        @"\.ecn\.dev\.virtualearth\.net$",
        @"\.linkedin\.com$",
        @"\.live\.com$",
        @"\.login\.(?:microsoftonline-p\.com|windows-ppe\.net)$",
        @"\.lync\.com$",
        @"\.mem\.gfx\.ms$",
        @"\.microsoft$",
        @"\.microsoft(?:365|online(?:-p)?|stream|usercontent)?\.com$",
        @"\.ms(?:auth(?:images)?|edge|ft(?:auth(?:images)?|identity)?|identity|ocdn)\.(?:net|com)$",
        @"\.nexus\.microsoftonline-p\.com$",
        @"\.o365weve\.com$",
        @"\.ocsp\.msocsp\.com$",
        @"\.office(?:365\.com\.edgesuite\.net|365\.com|\.com|\.net)$|\.officespeech\.platform\.bing\.com$",
        @"\.onedrive\.com$",
        @"\.outlook(?:office365|mobile)?\.com$",
        @"\.partnerservices\.getmicrosoftkey\.com$",
        @"\.phonefactor\.net$",
        @"\.portal\.cloudappsecurity\.com$",
        @"\.(?:powerapps|powerautomate)\.com$",
        @"\.prod\.msocdn\.com$",
        @"\.protection\.outlook\.com$",
        @"\.sharepoint(?:\.com|online\.com)$",
        @"\.shellprod\.msocdn\.com$",
        @"\.skype\.com$",
        @"\.svc\.ms$",
        @"\.sway\.com$",
        @"\.table\.core\.windows\.net$",
        @"\.trafficmanager\.net$",
        @"\.tse1\.mm\.bing\.net$",
        @"\.visualstudio\.com$",
        @"\.vo\.msecnd\.net$",
        @"\.windows\.net$",
        @"\.wpengine\.com$",
        @"\.wus-www\.sway-(?:cdn|extensions)\.com$",
        @"\.yammer(?:usercontent)?\.com$"
    ];
    private static readonly List<string> AWSRegexSearchStringList =
    [
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?(?:amazon(?:aws\.com\.cn|cognito\.com|aws\.com)|elb|ec2|autoscaling|elasticmapreduce)\.(?:amazonaws\.com|api\.aws)$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?api\.aws$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?aws(?:apps|cloud(?:front)?|dns|edge|educate|globalaccelerator|mp|personalize|static|stepfunctions)?\.com$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?cloudfront\.net$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?cloudfunctions\.net$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?elasticbeanstalk\.com$",
        @"\.(?:(?:af-south-1|ap-(?:east-1|northeast-[1-3]|south-[1-2]|southeast-[1-4])|ca-(?:central-1|west-1)|eu-(?:central-[1-2]|north-1|south-[1-2]|west-[1-3])|il-central-1|me-(?:central-1|south-1)|sa-east-1|us-(?:east-[1-2]|gov-(?:east-1|west-1)|west-[1-2]))\.)?sagemaker\.(?:aws|com\.cn|\.com)$",
    ];
    private static readonly List<string> GCPRegexSearchStringList =
    [
        @"\.appspot\.com$",
        @"\.assets\.onestore\.ms$",
        @"\.cloudfunctions\.net$",
        @"\.firebaseapp\.com$",
        @"\.google(apis|syndication|usercontent|video)?\.com$",
        @"\.run\.app$",
        @"\.storage\.googleapis\.com$",
        @"\.withgoogle\.com$",
        @"\.withyoutube\.com$",
        @"\.youtube\.com$",
        @"\.ytimg\.com$"
    ];
    private static readonly List<string> PaaSProvidersRegexSearchStringList = [
        @"\.000webhostapp\.com$",
        @"\.acompli\.net$",
        @"\.adobeaemcloud\.com$",
        @"\.alibabacloud\.com$",
        @"\.anaplan\.com$",
        @"\.appiancloud\.com$",
        @"\.bitbucket\.io$",
        @"\.boomi\.com$",
        @"\.caspio\.com$",
        @"\.cfapps\.eu10\.hana\.ondemand\.com$",
        @"\.circleci\.com$",
        @"\.(?:cloud\.ibm\.com|cloud\.rackspace\.com|cloudaccess\.host|cloudbees\.com|cloudfoundry\.org)$",
        @"\.digitaloceanspaces\.com$",
        @"\.docker\.io$",
        @"\.entrust\.net$",
        @"\.fastly\.net$",
        @"\.flywheelsites\.com$",
        @"\.force\.com$",
        @"\.github\.io$",
        @"\.gitlab\.io$",
        @"\.hana\.ondemand\.com$",
        @"\.herokuapp\.com$",
        @"\.informatica\.com$",
        @"\.kinstacdn\.com$",
        @"\.knack\.com$",
        @"\.kubernetes\.io$",
        @"\.linodeusercontent\.com$",
        @"\.mendixcloud\.com$",
        @"\.mesosphere\.com$",
        @"\.mulesoft\.com$",
        @"\.myfreesites\.net$",
        @"\.netlify\.com$",
        @"\.nps\.onyx\.azure\.net$",
        @"\.openshift(?:apps)?\.com$",
        @"\.outsystemscloud\.com$",
        @"\.pantheonsite\.io$",
        @"\.quickbase\.com$",
        @"\.rackcdn\.com$",
        @"\.rancher\.com$",
        @"\.redhat\.com$",
        @"(?:\.my)?\.salesforce\.com$",
        @"\.sapcloud\.com$",
        @"\.snaplogic\.com$",
        @"\.stackpath\.com$",
        @"\.stackpathdns\.com$",
        @"\.staffhub\.ms$",
        @"\.talend\.com$",
        @"\.travis-ci\.com$",
        @"\.vercel\.app$",
        @"\.zoho\.com$",
    ];
    private static readonly List<string> CDNRegexSearchStringList = [
        @"\.akamai(?:staging|edge(?:-staging)?|hd(?:-staging)?|origin(?:-staging)?|technologies(?:\.com|\.fr)?|ized(?:-staging)?)?\.net$",
        @"\.anankecdn\.com\.br$",
        @"\.bo\.lt$",
        @"\.cachefly\.net$",
        @"\.cdn77\.(?:com|net|org)$",
        @"\.cloudflare\.com$",
        @"\.cloudfront\.net$",
        @"\.cloudflare(?:-dns|-net|-ipfs|insights|stream|status|workers)?\.com$",
        @"\.fastly(?:-lb|-cdn|-pic|-terrarium|-insights)?\.net$|\.fastly(?:-cdn|-pic|-terrarium|-insights)?\.com$",
        @"\.maxcdn(?:-edge|-ssl|-cdn|-dns|-logs|-mail|-status|-sv|-tickets|-tools|-zendesk|-zopim)?\.com$"
        @"\.doubleclick\.net$",
        @"\.(?:edgecastcdn|edgekey|edgesuite)\.net$",
        @"\.fastlylb\.net$",
        @"\.fpbns\.net$",
        @"\.gslb\.taobao\.com$",
        @"\.gvt1\.com$",
        @"\.hwcdn\.net$",
        @"\.llnwd\.net$",
        @"\.netdna-cdn\.com$",
        @"\.netlify\.com$",
        @"\.nocookie\.net$",
        @"\.o0bc\.com$",
        @"\.rncdn1\.com$",
        @"\.srip\.net$",
        @"\.systemcdn\.net$",
        @"\.tauk0\.com$",
        @"\.tl88\.net$",
        @"\.transactcdn\.net$",
        @"\.vox(?:-cdn(?:\.com|\.net)|cdn\.com|media\.com)$",
        @"\.yahoo(?:\.|apis\.com)$",
        @"\.yimg\.",
        @"\.yottaa\.net$",
        @"\.ytimg\.com$"
    ];

    private static readonly List<string> DigitalOceanRegexSearchStringList =
    [
    @"\.(?:digitaloceanspaces\.com|do-(?:usercontent|userfiles|cloud|dns|cdn|api|apis|ssl|secure|static|db|dbfiles|webfiles|webcontent|cdnfiles|cdncontent|sslfiles|sslcontent|securefiles|securecontent|staticfiles|staticcontent)\.com)$",
    ];
}