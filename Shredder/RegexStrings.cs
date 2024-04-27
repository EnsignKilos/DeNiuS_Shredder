class RegexStrings
{
    public List<GeneratedRegexAttribute> AzureOrMicrosoft { get; private set; }
    public List<GeneratedRegexAttribute> AWSService { get; private set; }
    public List<GeneratedRegexAttribute> AWSRegion { get; private set; }
    public List<GeneratedRegexAttribute> GCP { get; private set; }
    public List<GeneratedRegexAttribute> PaaSProviders { get; private set; }
    public List<GeneratedRegexAttribute> CDNs { get; private set; }
    private static readonly object padlock = new();
    private static RegexStrings? _instance;
    private RegexStrings()
    {
        AzureOrMicrosoft = GenerateRegexes(AzureOrMicrosoftDomainsList);
        AWSService = GenerateRegexes(AWSServiceDomainsList);
        AWSRegion = GenerateRegexes(AWSRegionDomainsList);
        GCP = GenerateRegexes(GCPDomainsList);
        PaaSProviders = GenerateRegexes(PaaSProvidersDomainsList);
        CDNs = GenerateRegexes(CDNDomainsList);
    }
    public static RegexStrings Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new RegexStrings();
                }
                return _instance;
            }
        }
    }
    private static List<GeneratedRegexAttribute> GenerateRegexes(List<string> patterns)
    {
        List<GeneratedRegexAttribute> regexes = [];

        Parallel.ForEach(patterns, item =>
        {
            regexes.Add(new GeneratedRegexAttribute(item, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.RightToLeft));
        });

        return regexes;
    }
    private static readonly List<string> AzureOrMicrosoftDomainsList =
    [
        @"\.aadrm\.com$",
        @"\.ajax\.aspnetcdn\.com$",
        @"\.aka\.ms$",
        @"\.appex-rf\.msn\.com$",
        @"\.appex\.bing\.com$",
        @"\.assets-yammer\.com$",
        @"\.auth\.gfx\.ms$",
        @"\.autologon\.microsoftazuread-sso\.com$",
        @"\.azmk8s\.io$",
        @"\.azure-api\.net$",
        @"\.azure-apim\.net$",
        @"\.azure-mobile\.net$",
        @"\.azure\.com$",
        @"\.azure\.net$",
        @"\.azurecontainer\.io$",
        @"\.azurecr\.io$",
        @"\.azureedge\.net$",
        @"\.azurefd\.net$",
        @"\.azurerms\.com$",
        @"\.azurestaticapps\.net$",
        @"\.azurewebsites\.net$",
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
        @"\.login\.microsoftonline-p\.com$",
        @"\.login\.windows-ppe\.net$",
        @"\.lync\.com$",
        @"\.mem\.gfx\.ms$",
        @"\.microsoft\.com$",
        @"\.microsoft$",
        @"\.microsoft365\.com$",
        @"\.microsoftonline-p\.com$",
        @"\.microsoftonline\.com$",
        @"\.microsoftstream\.com$",
        @"\.microsoftusercontent\.com$",
        @"\.msauth\.net$",
        @"\.msauthimages\.net$",
        @"\.msedge\.net$",
        @"\.msft\.net$",
        @"\.msftauth\.net$",
        @"\.msftauthimages\.net$",
        @"\.msftidentity\.com$",
        @"\.msidentity\.com$",
        @"\.msocdn\.com$",
        @"\.nexus\.microsoftonline-p\.com$",
        @"\.o365weve\.com$",
        @"\.ocsp\.msocsp\.com$",
        @"\.office\.com$",
        @"\.office\.net$",
        @"\.office365\.com\.edgesuite\.net$",
        @"\.office365\.com$",
        @"\.officespeech\.platform\.bing\.com$",
        @"\.onedrive\.com$",
        @"\.outlook\.com$",
        @"\.outlook\.office365\.com$",
        @"\.outlookmobile\.com$",
        @"\.partnerservices\.getmicrosoftkey\.com$",
        @"\.phonefactor\.net$",
        @"\.portal\.cloudappsecurity\.com$",
        @"\.powerapps\.com$",
        @"\.powerautomate\.com$",
        @"\.prod\.msocdn\.com$",
        @"\.protection\.outlook\.com$",
        @"\.sharepoint\.com$",
        @"\.sharepointonline\.com$",
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
        @"\.wus-www\.sway-cdn\.com$",
        @"\.wus-www\.sway-extensions\.com$",
        @"\.yammer\.com$",
        @"\.yammerusercontent\.com$"
    ];
    private static readonly List<string> AWSServiceDomainsList =
    [
        @"amazonaws\.com$",
        @"amazonaws\.com\.cn$",
        @"amazoncognito\.com$",
        @"api\.aws$",
        @"awsapps\.com$",
        @"awscloud\.com$",
        @"awscloudfront\.com$",
        @"awsdns\.com$",
        @"awsedge\.com$",
        @"awseducate\.com$",
        @"awsglobalaccelerator\.com$",
        @"awsmp\.com$",
        @"awspersonalize\.com$",
        @"awsstatic\.com$",
        @"awsstepfunctions\.com$",
        @"cloudfront\.net$",
        @"cloudfunctions\.net$",
        @"elasticbeanstalk\.com$",
        @"sagemaker\.aws$",
        @"sagemaker\.com\.cn$",
        @"autoscaling\.amazonaws\.com$",
        @"autoscaling\.api\.aws$",
        @"ec2\.amazonaws\.com$",
        @"ec2\.api\.aws$",
        @"elasticmapreduce\.amazonaws\.com$",
        @"elasticmapreduce\.api\.aws$",
        @"elb\.amazonaws\.com$",
        @"elb\.api\.aws$"
    ];
    private static readonly List<string> AWSRegionDomainsList =
    [
        @"\.af-south-1\.",
        @"\.ap-east-1\.",
        @"\.ap-northeast-1\.",
        @"\.ap-northeast-2\.",
        @"\.ap-northeast-3\.",
        @"\.ap-south-1\.",
        @"\.ap-south-2\.",
        @"\.ap-southeast-1\.",
        @"\.ap-southeast-2\.",
        @"\.ap-southeast-3\.",
        @"\.ap-southeast-4\.",
        @"\.ca-central-1\.",
        @"\.ca-west-1\.",
        @"\.eu-central-1\.",
        @"\.eu-central-2\.",
        @"\.eu-north-1\.",
        @"\.eu-south-1\.",
        @"\.eu-south-2\.",
        @"\.eu-west-1\.",
        @"\.eu-west-2\.",
        @"\.eu-west-3\.",
        @"\.il-central-1\.",
        @"\.me-central-1\.",
        @"\.me-south-1\.",
        @"\.sa-east-1\.",
        @"\.us-east-1\.",
        @"\.us-east-2\.",
        @"\.us-gov-east-1\.",
        @"\.us-gov-west-1\.",
        @"\.us-west-1\.",
        @"\.us-west-2\."
    ];
    private static readonly List<string> GCPDomainsList =
    [
        @"\.appspot\.com$",
        @"\.assets\.onestore\.ms$",
        @"\.cloudfunctions\.net$",
        @"\.firebaseapp\.com$",
        @"\.google\.com$",
        @"\.googleapis\.com$",
        @"\.googlesyndication\.com$",
        @"\.googleusercontent\.com$",
        @"\.googlevideo\.com$",
        @"\.run\.app$",
        @"\.storage\.googleapis\.com$",
        @"\.withgoogle\.com$",
        @"\.withyoutube\.com$",
        @"\.youtube\.com$",
        @"\.ytimg\.com$"
    ];
    private static readonly List<string> PaaSProvidersDomainsList = [
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
        @"\.cloud\.ibm\.com$",
        @"\.cloud\.rackspace\.com$",
        @"\.cloudaccess\.host$",
        @"\.cloudbees\.com$",
        @"\.cloudfoundry\.org$",
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
        @"\.my\.salesforce\.com$",
        @"\.myfreesites\.net$",
        @"\.netlify\.com$",
        @"\.nps\.onyx\.azure\.net$",
        @"\.openshift\.com$",
        @"\.openshiftapps\.com$",
        @"\.outsystemscloud\.com$",
        @"\.pantheonsite\.io$",
        @"\.quickbase\.com$",
        @"\.rackcdn\.com$",
        @"\.rancher\.com$",
        @"\.redhat\.com$",
        @"\.salesforce\.com$",
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
    private static readonly List<string> CDNDomainsList = [
        @"\.akamai-staging\.net$",
        @"\.akamai\.net$",
        @"\.akamaiedge-staging\.net$",
        @"\.akamaiedge\.net$",
        @"\.akamaihd-staging\.net$",
        @"\.akamaihd\.net$",
        @"\.akamaiorigin-staging\.net$",
        @"\.akamaiorigin\.net$",
        @"\.akamaitechnologies\.com$",
        @"\.akamaitechnologies\.fr$",
        @"\.akamaized-staging\.net$",
        @"\.akamaized\.net$",
        @"\.anankecdn\.com\.br$",
        @"\.bo\.lt$",
        @"\.cachefly\.net$",
        @"\.cdn20\.com$",
        @"\.cdn77\.net$",
        @"\.cdn77\.org$",
        @"\.cloudflare\.com$",
        @"\.cloudfront\.net$",
        @"\.doubleclick\.net$",
        @"\.edgecastcdn\.net$",
        @"\.edgekey\.net$",
        @"\.edgesuite\.net$",
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
        @"\.vox-cdn\.com$",
        @"\.vox-cdn\.net$",
        @"\.voxcdn\.com$",
        @"\.voxmedia\.com$",
        @"\.yahoo\.",
        @"\.yahooapis\.com$",
        @"\.yimg\.",
        @"\.yottaa\.net$",
        @"\.ytimg\.com$"
    ];
}