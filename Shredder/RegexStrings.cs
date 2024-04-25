class RegexStrings
{
    // Compile regex for 'com', 'uk', and 'aws'
    public static readonly Regex compileRegex = new(@"(com|uk|aws)$", RegexOptions.Compiled);

    // Azure and Microsoft


    // Google Cloud Platform
    public static readonly ImmutableHashSet<string> GCP =
    [
        ".appspot.com",".assets.onestore.ms",".cloudfunctions.net",".firebaseapp.com",".google.com",".googleapis.com",
        ".googleusercontent.com",".run.app",".storage.googleapis.com",".withgoogle.com",".withyoutube.com",".youtube.com",
        ".ytimg.com", ".googleusercontent.com", ".googlesyndication.com", ".youtube.com", ".ytimg.com", ".googlevideo.com",
    ];

    // PaaS Providers (Platform as a Service)
    public static readonly ImmutableHashSet<string> PaaSProviders =
    [
        ".000webhostapp.com", ".acompli.net", ".adobeaemcloud.com", ".alibabacloud.com", ".anaplan.com",
        ".appiancloud.com", ".bitbucket.io", ".boomi.com", ".caspio.com", ".cfapps.eu10.hana.ondemand.com",
        ".circleci.com", ".cloud.ibm.com", ".cloud.rackspace.com", ".cloudaccess.host", ".cloudbees.com",
        ".cloudfoundry.org", ".digitaloceanspaces.com", ".docker.io", ".entrust.net", ".fastly.net",
        ".flywheelsites.com", ".force.com", ".github.io", ".gitlab.io", ".hana.ondemand.com",
        ".herokuapp.com", ".informatica.com", ".isrg.trustid.ocsp.identrust.com", ".jenkins.io", ".jitterbit.com",
        ".kinstacdn.com", ".knack.com", ".kubernetes.io", ".linodeusercontent.com", ".mendixcloud.com",
        ".mesosphere.com", ".mulesoft.com", ".my.salesforce.com", ".myfreesites.net", ".netlify.com",
        ".nps.onyx.azure.net", ".openshift.com", ".openshiftapps.com", ".outsystemscloud.com", ".pantheonsite.io",
        ".quickbase.com", ".rackcdn.com", ".rancher.com", ".redhat.com", ".salesforce.com",
        ".sapcloud.com", ".snaplogic.com", ".stackpath.com", ".stackpathdns.com", ".staffhub.ms",
        ".talend.com", ".travis-ci.com", ".vercel.app", ".zoho.com"
    ];

    // CDN Providers (Content Delivery Networks)
    public static readonly ImmutableHashSet<string> CDNs =
    [
        ".akamai.net", ".akamaiedge.net", ".akamaihd.net", ".akamai-staging.net", ".akamaiedge-staging.net",
        ".akamaihd-staging.net", ".akamaiorigin-staging.net", ".akamaiorigin.net", ".akamaized-staging.net", ".akamaized.net",
        ".edgesuite.net", ".edgekey.net", ".srip.net", ".akamaitechnologies.com", ".akamaitechnologies.fr", ".tl88.net",
        ".cloudflare.com", ".llnwd.net", ".edgecastcdn.net", ".systemcdn.net", ".transactcdn.net", ".yottaa.net",
        ".o0bc.com", ".tauk0.com", ".hwcdn.net", ".fastlylb.net", ".nocookie.net", ".gslb.taobao.com",
        ".cdn20.com", ".cdn77.org", ".cdn77.net", ".cachefly.net", ".bo.lt", ".cloudfront.net",
        ".gvt1.com", ".doubleclick.net", ".rncdn1.com", ".fpbns.net",
        ".yahooapis.com", ".yimg.", ".yahoo.",".anankecdn.com.br", ".netdna-cdn.com", ".netlify.com", ".voxcdn.com"
    ];


}