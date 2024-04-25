class RegexStrings
{
    // Compile regex for 'com', 'uk', and 'aws'
    public static readonly Regex compileRegex = new(@"(com|uk|aws)", RegexOptions.Compiled);

    // TLDs with two parts, or ccTLDs (Mainly country specific, and not complete)
    public static readonly ImmutableHashSet<string> ccTLDsOrTwoPartTlds = [
         ".ac.il", ".ac.jp", ".ac.kr", ".ac.nz", ".ac.uk", ".ad.jp", ".co.il", ".co.jp", ".co.kr", ".co.nz", ".co.th", ".co.za", ".com.al", ".com.am", ".com.ar", ".com.at", ".com.au", ".com.ba", ".com.bg", ".com.br", ".com.by", ".com.cn", ".com.cy", ".com.cz", ".com.de",
         ".com.dk", ".com.ee", ".com.es", ".com.fi", ".com.fr", ".com.gr", ".com.hk", ".com.hr", ".com.hu", ".com.ie", ".com.in", ".com.is", ".com.it", ".com.li", ".com.lt", ".com.lu", ".com.lv", ".com.mc", ".com.md", ".com.me", ".com.mk", ".com.mt", ".com.nl", ".com.ph", ".com.pl",
         ".com.pt", ".com.ro", ".com.rs", ".com.ru", ".com.se", ".com.si", ".com.sk", ".com.sm", ".com.tr", ".com.tw", ".com.ua", ".com.us", ".com.vu", ".csiro.au", ".edu.al", ".edu.at", ".edu.au", ".edu.ba", ".edu.bg", ".edu.by", ".edu.cn", ".edu.cy", ".edu.cz", ".edu.ee", ".edu.es",
         ".edu.fi", ".edu.gr", ".edu.hk", ".edu.hr", ".edu.hu", ".edu.ie", ".edu.is", ".edu.it", ".edu.jp", ".edu.li", ".edu.lt", ".edu.lv", ".edu.mc", ".edu.md", ".edu.mk", ".edu.mt", ".edu.mx", ".edu.my", ".edu.nl", ".edu.ph", ".edu.pl", ".edu.rs", ".edu.se", ".edu.sg", ".edu.si",
         ".edu.sm", ".edu.tw", ".edu.ua", ".edu.us", ".edu.za", ".geek.nz", ".go.jp", ".go.kr", ".go.th", ".gob.es", ".gob.mx", ".gov.al", ".gov.am", ".gov.ar", ".gov.at", ".gov.au", ".gov.ba", ".gov.bg", ".gov.br", ".gov.by", ".gov.cy", ".gov.cz", ".gov.de", ".gov.dk", ".gov.ee",
         ".gov.fi", ".gov.gr", ".gov.hk", ".gov.hr", ".gov.hu", ".gov.ie", ".gov.is", ".gov.it", ".gov.jp", ".gov.li", ".gov.lt", ".gov.lu", ".gov.lv", ".gov.mc", ".gov.md", ".gov.me", ".gov.mk", ".gov.mt", ".gov.my", ".gov.nl", ".gov.ph", ".gov.pl", ".gov.pt", ".gov.ro", ".gov.rs",
         ".gov.ru", ".gov.se", ".gov.sg", ".gov.si", ".gov.sk", ".gov.sm", ".gov.tr", ".gov.tw", ".gov.ua", ".gov.uk", ".gov.za", ".govt.nz", ".hs.kr", ".in.th", ".int.ar", ".k12.il", ".kg.kr", ".ltd.uk", ".maori.nz", ".me.uk", ".mil.ar", ".mil.br", ".mil.de", ".mil.fr", ".mil.in",
         ".mil.my", ".mil.ru", ".mil.tr", ".mil.tw", ".mil.us", ".ms.kr", ".ne.jp", ".net.ar", ".net.br", ".net.cn", ".net.de", ".net.fr", ".net.hk", ".net.il", ".net.in", ".net.kr", ".net.mx", ".net.my", ".net.nz", ".net.ph", ".net.ru", ".net.sg", ".net.th", ".net.tr", ".net.tw",
         ".net.uk", ".net.us", ".net.za", ".or.jp", ".org.al", ".org.am", ".org.ar", ".org.at", ".org.au", ".org.ba", ".org.bg", ".org.br", ".org.cn", ".org.cy", ".org.de", ".org.dk", ".org.ee", ".org.es", ".org.fi", ".org.fr", ".org.gr", ".org.hk", ".org.hr", ".org.hu", ".org.il",
         ".org.in", ".org.it", ".org.kr", ".org.li", ".org.lt", ".org.lu", ".org.lv", ".org.mc", ".org.md", ".org.me", ".org.mk", ".org.mx", ".org.my", ".org.nz", ".org.ph", ".org.pl", ".org.pt", ".org.ro", ".org.ru", ".org.se", ".org.sg", ".org.si", ".org.sk", ".org.sm", ".org.th",
         ".org.tr", ".org.tw", ".org.ua", ".org.uk", ".org.us", ".org.vu", ".org.za", ".pe.kr", ".plc.uk", ".re.kr", ".sc.kr", ".sch.uk", ".web.za",".ab.ca",".abudhabi",".ac.at",".ac.cn",".ac.il",".ac.jp",".ac.nz",".ac.th",".ac.uk",".ac.za",".ac",".ad.jp",".ad",
        ".ae",".af",".ag",".ai",".al",".am",".an",".ao",".aq",".ar",".as",".asn.au",".at",".au",".aw",".ax",".az",".ba",".bb",".bc.ca",".bd",".be",".bf",".bg",".bh",
        ".bi",".bj",".bl",".bm",".bn",".bo",".bq",".br",".bs",".bt",".busan.kr",".bv",".bw",".by",".bz",".ca",".cat",".cc.us",".cc",".cd",".cf",".cg",".ch",".chungbuk.kr",".chungnam.kr",
        ".ci",".ck",".cm",".cn",".co.at",".co.de",".co.es",".co.ie",".co.il",".co.in",".co.it",".co.jp",".co.kr",".co.nz",".co.th",".co.uk",".co.za",".co",".com.ae",".com.au",".com.br",".com.cn",".com.es",".com.fr",".com.hk",
        ".com.mx",".com.my",".com.po",".com.sa",".com.sg",".com.tw",".cr",".cu",".cv",".cw",".cx",".cy",".cz",".daegu.kr",".daejeon.kr",".de",".dj",".dk",".dm",".dni.us",".do",".dz",".ec",".ed.jp",".edu.ae",
        ".edu.am",".edu.ar",".edu.au",".edu.cn",".edu.dk",".edu.es",".edu.hk",".edu.it",".edu.lu",".edu.me",".edu.my",".edu.po",".edu.pt",".edu.ro",".edu.sa",".edu.sg",".edu.sk",".edu.tr",".edu.tw",".edu.vu",".ee",".eg",".eh",".er",".es.kr",
        ".es",".et",".eu",".eus",".fed.us",".fi",".firm.in",".fj",".fk",".fm",".fo",".fr",".ga",".gal",".gc.ca",".gd",".ge",".gen.in",".gf",".gg",".gh",".gi",".gl",".gm",".gn",
        ".go.jp",".go.kr",".go.th",".gob.es",".gov.ae",".gov.at",".gov.au",".gov.br",".gov.cn",".gov.fr",".gov.hk",".gov.ie",".gov.il",".gov.in",".gov.it",".gov.my",".gov.po",".gov.sa",".gov.sg",".gov.tw",".gov.uk",".gov.us",".gov.za",".gp",".gq",
        ".gr.jp",".gr",".gs",".gt",".gu",".gw",".gwangju.kr",".gy",".hk",".hm",".hn",".hr",".ht",".hu",".hyogo.jp",".id.au",".id",".idf.il",".idv.hk",".idv.tw",".ie",".il",".im",".in.th",".in",
        ".incheon.kr",".ind.in",".io",".iq",".ir",".is",".it",".iwi.nz",".je",".jeju.kr",".jeonbuk.kr",".jeonnam.kr",".jm",".jo",".jp",".k12.il",".k12.us",".kangwon.kr",".ke",".kg",".kh",".ki",".kiwi.nz",".km",".kn",
        ".kp",".kr",".kw",".ky",".kyongbuk.kr",".kyonggi.kr",".kyongnam.kr",".kz",".la",".lb",".lc",".lg.jp",".li",".lib.us",".lk",".lr",".ls",".lt",".ltd.uk",".lu",".lv",".ly",".ma",".maori.nz",".mb.ca",
        ".mc",".md",".me.uk",".me",".med.sa",".mf",".mg",".mh",".mi.th",".mil.ae",".mil.br",".mil.it",".mil.po",".mil.sa",".mil.us",".mil.za",".mk",".ml",".mm",".mn",".mo",".mod.uk",".mp",".mq",".mr",
        ".ms",".mt",".mu",".muni.il",".mv",".mw",".mx",".my",".mz",".na.us",".na",".nb.ca",".nc.tr",".nc",".ne.de",".ne.jp",".ne.kr",".ne",".net.ae",".net.au",".net.br",".net.cn",".net.fr",".net.hk",".net.ie",
        ".net.il",".net.in",".net.it",".net.my",".net.nz",".net.po",".net.sa",".net.sg",".net.tw",".net.uk",".net.za",".nf",".ng",".nhs.uk",".ni",".nl.ca",".nl",".no.de",".no",".nom.es",".nom.fr",".np",".nr",".ns.ca",".nt.ca",
        ".nu.ca",".nu",".nz",".om",".on.ca",".or.at",".or.jp",".or.kr",".or.th",".org.ae",".org.au",".org.br",".org.by",".org.cn",".org.cz",".org.es",".org.fr",".org.hk",".org.ie",".org.il",".org.in",".org.is",".org.it",".org.mt",".org.my",
        ".org.nl",".org.nz",".org.po",".org.rs",".org.sa",".org.sg",".org.tw",".org.uk",".org.za",".osaka.jp",".pa",".pe.ca",".pe.kr",".pe",".pf",".pg",".ph",".pk",".pl",".plc.uk",".pm",".pn",".po",".police.uk",".pr",
        ".ps",".pt",".pw",".py",".qa",".qc.ca",".re.kr",".re",".ro",".rs",".ru",".rw",".sa",".saarland",".sb",".sc",".sch.uk",".school.nz",".school.za",".sd",".se",".seoul.kr",".sg",".sh",".si",
        ".sj",".sk.ca",".sk",".sl",".sm",".sn",".so",".sr",".ss",".st",".state.ak.us",".state.al.us",".state.ar.us",".state.as.us",".state.az.us",".state.ca.us",".state.co.us",".state.ct.us",".state.dc.us",".state.de.us",".state.fl.us",".state.ga.us",".state.gu.us",".state.hi.us",".state.ia.us",
        ".state.id.us",".state.il.us",".state.in.us",".state.ks.us",".state.ky.us",".state.la.us",".state.ma.us",".state.md.us",".state.me.us",".state.mi.us",".state.mn.us",".state.mo.us",".state.ms.us",".state.mt.us",".state.nc.us",".state.nd.us",".state.ne.us",".state.nh.us",".state.nj.us",".state.nm.us",".state.nv.us",".state.ny.us",".state.oh.us",".state.ok.us",".state.or.us",
        ".state.pa.us",".state.pr.us",".state.ri.us",".state.sc.us",".state.sd.us",".state.tn.us",".state.tx.us",".state.us",".state.ut.us",".state.va.us",".state.vi.us",".state.vt.us",".state.wa.us",".state.wi.us",".state.wv.us",".state.wy.us",".sv",".sx",".sy",".sz",".tc",".td",".tf",".tg",".th",
        ".tj",".tk",".tl",".tm",".tn",".to",".tokyo.jp",".tr",".tt",".tv",".tw",".tz",".ua",".ug",".uk",".ulsan.kr",".us",".uy",".uz",".va",".vc",".ve",".vg",".vi",".vn",
        ".vu",".web.za",".wf",".ws",".ye",".yk.ca",".yt",".za",".zm",".zw",
    ];

    // AWS (Amazon Web Services)
    public static readonly ImmutableHashSet<string> AWS =
    [
        ".amazonaws.com", ".api.aws", ".cloudfront.net", ".cloudfunctions.net", ".elasticbeanstalk.com",
        ".amazoncognito.com", ".sagemaker.aws", ".amazonaws.com.cn", ".awsapps.com", ".awsglobalaccelerator.com",
        ".awsmp.com", ".awspersonalize.com", ".awsstatic.com", ".awsstepfunctions.com", ".awseducate.com",
        ".awscloud.com", ".awscloudfront.com", ".awsdns.com", ".awsedge.com", ".sagemaker.com.cn",
        "af-south-1.amazonaws.com","af-south-1.api.aws","af-south-1.autoscaling.amazonaws.com","af-south-1.autoscaling.api.aws","af-south-1.ec2.amazonaws.com","af-south-1.ec2.api.aws","af-south-1.elasticmapreduce.amazonaws.com","af-south-1.elasticmapreduce.api.aws","af-south-1.elb.amazonaws.com","af-south-1.elb.api.aws",
        "ap-east-1.amazonaws.com","ap-east-1.api.aws","ap-east-1.autoscaling.amazonaws.com","ap-east-1.autoscaling.api.aws","ap-east-1.ec2.amazonaws.com","ap-east-1.ec2.api.aws","ap-east-1.elasticmapreduce.amazonaws.com","ap-east-1.elasticmapreduce.api.aws","ap-east-1.elb.amazonaws.com","ap-east-1.elb.api.aws",
        "ap-northeast-1.amazonaws.com","ap-northeast-1.api.aws","ap-northeast-1.autoscaling.amazonaws.com","ap-northeast-1.autoscaling.api.aws","ap-northeast-1.ec2.amazonaws.com","ap-northeast-1.ec2.api.aws","ap-northeast-1.elasticmapreduce.amazonaws.com","ap-northeast-1.elasticmapreduce.api.aws","ap-northeast-1.elb.amazonaws.com","ap-northeast-1.elb.api.aws",
        "ap-northeast-2.amazonaws.com","ap-northeast-2.api.aws","ap-northeast-2.autoscaling.amazonaws.com","ap-northeast-2.autoscaling.api.aws","ap-northeast-2.ec2.amazonaws.com","ap-northeast-2.ec2.api.aws","ap-northeast-2.elasticmapreduce.amazonaws.com","ap-northeast-2.elasticmapreduce.api.aws","ap-northeast-2.elb.amazonaws.com","ap-northeast-2.elb.api.aws",
        "ap-northeast-3.amazonaws.com","ap-northeast-3.api.aws","ap-northeast-3.autoscaling.amazonaws.com","ap-northeast-3.autoscaling.api.aws","ap-northeast-3.ec2.amazonaws.com","ap-northeast-3.ec2.api.aws","ap-northeast-3.elasticmapreduce.amazonaws.com","ap-northeast-3.elasticmapreduce.api.aws","ap-northeast-3.elb.amazonaws.com","ap-northeast-3.elb.api.aws",
        "ap-south-1.amazonaws.com","ap-south-1.api.aws","ap-south-1.autoscaling.amazonaws.com","ap-south-1.autoscaling.api.aws","ap-south-1.ec2.amazonaws.com","ap-south-1.ec2.api.aws","ap-south-1.elasticmapreduce.amazonaws.com","ap-south-1.elasticmapreduce.api.aws","ap-south-1.elb.amazonaws.com","ap-south-1.elb.api.aws",
        "ap-south-2.amazonaws.com","ap-south-2.api.aws","ap-south-2.autoscaling.amazonaws.com","ap-south-2.autoscaling.api.aws","ap-south-2.ec2.amazonaws.com","ap-south-2.ec2.api.aws","ap-south-2.elasticmapreduce.amazonaws.com","ap-south-2.elasticmapreduce.api.aws","ap-south-2.elb.amazonaws.com","ap-south-2.elb.api.aws",
        "ap-southeast-1.amazonaws.com","ap-southeast-1.api.aws","ap-southeast-1.autoscaling.amazonaws.com","ap-southeast-1.autoscaling.api.aws","ap-southeast-1.ec2.amazonaws.com","ap-southeast-1.ec2.api.aws","ap-southeast-1.elasticmapreduce.amazonaws.com","ap-southeast-1.elasticmapreduce.api.aws","ap-southeast-1.elb.amazonaws.com","ap-southeast-1.elb.api.aws",
        "ap-southeast-2.amazonaws.com","ap-southeast-2.api.aws","ap-southeast-2.autoscaling.amazonaws.com","ap-southeast-2.autoscaling.api.aws","ap-southeast-2.ec2.amazonaws.com","ap-southeast-2.ec2.api.aws","ap-southeast-2.elasticmapreduce.amazonaws.com","ap-southeast-2.elasticmapreduce.api.aws","ap-southeast-2.elb.amazonaws.com","ap-southeast-2.elb.api.aws",
        "ap-southeast-3.amazonaws.com","ap-southeast-3.api.aws","ap-southeast-3.autoscaling.amazonaws.com","ap-southeast-3.autoscaling.api.aws","ap-southeast-3.ec2.amazonaws.com","ap-southeast-3.ec2.api.aws","ap-southeast-3.elasticmapreduce.amazonaws.com","ap-southeast-3.elasticmapreduce.api.aws","ap-southeast-3.elb.amazonaws.com","ap-southeast-3.elb.api.aws",
        "ap-southeast-4.amazonaws.com","ap-southeast-4.api.aws","ap-southeast-4.autoscaling.amazonaws.com","ap-southeast-4.autoscaling.api.aws","ap-southeast-4.ec2.amazonaws.com","ap-southeast-4.ec2.api.aws","ap-southeast-4.elasticmapreduce.amazonaws.com","ap-southeast-4.elasticmapreduce.api.aws","ap-southeast-4.elb.amazonaws.com","ap-southeast-4.elb.api.aws",
        "ca-central-1.amazonaws.com","ca-central-1.api.aws","ca-central-1.autoscaling.amazonaws.com","ca-central-1.autoscaling.api.aws","ca-central-1.ec2.amazonaws.com","ca-central-1.ec2.api.aws","ca-central-1.elasticmapreduce.amazonaws.com","ca-central-1.elasticmapreduce.api.aws","ca-central-1.elb.amazonaws.com","ca-central-1.elb.api.aws",
        "ca-west-1.amazonaws.com","ca-west-1.api.aws","ca-west-1.autoscaling.amazonaws.com","ca-west-1.autoscaling.api.aws","ca-west-1.ec2.amazonaws.com","ca-west-1.ec2.api.aws","ca-west-1.elasticmapreduce.amazonaws.com","ca-west-1.elasticmapreduce.api.aws","ca-west-1.elb.amazonaws.com","ca-west-1.elb.api.aws",
        "eu-central-1.amazonaws.com","eu-central-1.api.aws","eu-central-1.autoscaling.amazonaws.com","eu-central-1.autoscaling.api.aws","eu-central-1.ec2.amazonaws.com","eu-central-1.ec2.api.aws","eu-central-1.elasticmapreduce.amazonaws.com","eu-central-1.elasticmapreduce.api.aws","eu-central-1.elb.amazonaws.com","eu-central-1.elb.api.aws",
        "eu-central-2.amazonaws.com","eu-central-2.api.aws","eu-central-2.autoscaling.amazonaws.com","eu-central-2.autoscaling.api.aws","eu-central-2.ec2.amazonaws.com","eu-central-2.ec2.api.aws","eu-central-2.elasticmapreduce.amazonaws.com","eu-central-2.elasticmapreduce.api.aws","eu-central-2.elb.amazonaws.com","eu-central-2.elb.api.aws",
        "eu-north-1.amazonaws.com","eu-north-1.api.aws","eu-north-1.autoscaling.amazonaws.com","eu-north-1.autoscaling.api.aws","eu-north-1.ec2.amazonaws.com","eu-north-1.ec2.api.aws","eu-north-1.elasticmapreduce.amazonaws.com","eu-north-1.elasticmapreduce.api.aws","eu-north-1.elb.amazonaws.com","eu-north-1.elb.api.aws",
        "eu-south-1.amazonaws.com","eu-south-1.api.aws","eu-south-1.autoscaling.amazonaws.com","eu-south-1.autoscaling.api.aws","eu-south-1.ec2.amazonaws.com","eu-south-1.ec2.api.aws","eu-south-1.elasticmapreduce.amazonaws.com","eu-south-1.elasticmapreduce.api.aws","eu-south-1.elb.amazonaws.com","eu-south-1.elb.api.aws",
        "eu-south-2.amazonaws.com","eu-south-2.api.aws","eu-south-2.autoscaling.amazonaws.com","eu-south-2.autoscaling.api.aws","eu-south-2.ec2.amazonaws.com","eu-south-2.ec2.api.aws","eu-south-2.elasticmapreduce.amazonaws.com","eu-south-2.elasticmapreduce.api.aws","eu-south-2.elb.amazonaws.com","eu-south-2.elb.api.aws",
        "eu-west-1.amazonaws.com","eu-west-1.api.aws","eu-west-1.autoscaling.amazonaws.com","eu-west-1.autoscaling.api.aws","eu-west-1.ec2.amazonaws.com","eu-west-1.ec2.api.aws","eu-west-1.elasticmapreduce.amazonaws.com","eu-west-1.elasticmapreduce.api.aws","eu-west-1.elb.amazonaws.com","eu-west-1.elb.api.aws",
        "eu-west-2.amazonaws.com","eu-west-2.api.aws","eu-west-2.autoscaling.amazonaws.com","eu-west-2.autoscaling.api.aws","eu-west-2.ec2.amazonaws.com","eu-west-2.ec2.api.aws","eu-west-2.elasticmapreduce.amazonaws.com","eu-west-2.elasticmapreduce.api.aws","eu-west-2.elb.amazonaws.com","eu-west-2.elb.api.aws",
        "eu-west-3.amazonaws.com","eu-west-3.api.aws","eu-west-3.autoscaling.amazonaws.com","eu-west-3.autoscaling.api.aws","eu-west-3.ec2.amazonaws.com","eu-west-3.ec2.api.aws","eu-west-3.elasticmapreduce.amazonaws.com","eu-west-3.elasticmapreduce.api.aws","eu-west-3.elb.amazonaws.com","eu-west-3.elb.api.aws",
        "il-central-1.amazonaws.com","il-central-1.api.aws","il-central-1.autoscaling.amazonaws.com","il-central-1.autoscaling.api.aws","il-central-1.ec2.amazonaws.com","il-central-1.ec2.api.aws","il-central-1.elasticmapreduce.amazonaws.com","il-central-1.elasticmapreduce.api.aws","il-central-1.elb.amazonaws.com","il-central-1.elb.api.aws",
        "me-central-1.amazonaws.com","me-central-1.api.aws","me-central-1.autoscaling.amazonaws.com","me-central-1.autoscaling.api.aws","me-central-1.ec2.amazonaws.com","me-central-1.ec2.api.aws","me-central-1.elasticmapreduce.amazonaws.com","me-central-1.elasticmapreduce.api.aws","me-central-1.elb.amazonaws.com","me-central-1.elb.api.aws",
        "me-south-1.amazonaws.com","me-south-1.api.aws","me-south-1.autoscaling.amazonaws.com","me-south-1.autoscaling.api.aws","me-south-1.ec2.amazonaws.com","me-south-1.ec2.api.aws","me-south-1.elasticmapreduce.amazonaws.com","me-south-1.elasticmapreduce.api.aws","me-south-1.elb.amazonaws.com","me-south-1.elb.api.aws",
        "sa-east-1.amazonaws.com","sa-east-1.api.aws","sa-east-1.autoscaling.amazonaws.com","sa-east-1.autoscaling.api.aws","sa-east-1.ec2.amazonaws.com","sa-east-1.ec2.api.aws","sa-east-1.elasticmapreduce.amazonaws.com","sa-east-1.elasticmapreduce.api.aws","sa-east-1.elb.amazonaws.com","sa-east-1.elb.api.aws",
        "us-east-1.amazonaws.com","us-east-1.api.aws","us-east-1.autoscaling.amazonaws.com","us-east-1.autoscaling.api.aws","us-east-1.ec2.amazonaws.com","us-east-1.ec2.api.aws","us-east-1.elasticmapreduce.amazonaws.com","us-east-1.elasticmapreduce.api.aws","us-east-1.elb.amazonaws.com","us-east-1.elb.api.aws",
        "us-east-2.amazonaws.com","us-east-2.api.aws","us-east-2.autoscaling.amazonaws.com","us-east-2.autoscaling.api.aws","us-east-2.ec2.amazonaws.com","us-east-2.ec2.api.aws","us-east-2.elasticmapreduce.amazonaws.com","us-east-2.elasticmapreduce.api.aws","us-east-2.elb.amazonaws.com","us-east-2.elb.api.aws",
        "us-gov-east-1.amazonaws.com","us-gov-east-1.api.aws","us-gov-east-1.autoscaling.amazonaws.com","us-gov-east-1.autoscaling.api.aws","us-gov-east-1.ec2.amazonaws.com","us-gov-east-1.ec2.api.aws","us-gov-east-1.elasticmapreduce.amazonaws.com","us-gov-east-1.elasticmapreduce.api.aws","us-gov-east-1.elb.amazonaws.com","us-gov-east-1.elb.api.aws",
        "us-gov-west-1.amazonaws.com","us-gov-west-1.api.aws","us-gov-west-1.autoscaling.amazonaws.com","us-gov-west-1.autoscaling.api.aws","us-gov-west-1.ec2.amazonaws.com","us-gov-west-1.ec2.api.aws","us-gov-west-1.elasticmapreduce.amazonaws.com","us-gov-west-1.elasticmapreduce.api.aws","us-gov-west-1.elb.amazonaws.com","us-gov-west-1.elb.api.aws",
        "us-west-1.amazonaws.com","us-west-1.api.aws","us-west-1.autoscaling.amazonaws.com","us-west-1.autoscaling.api.aws","us-west-1.ec2.amazonaws.com","us-west-1.ec2.api.aws","us-west-1.elasticmapreduce.amazonaws.com","us-west-1.elasticmapreduce.api.aws","us-west-1.elb.amazonaws.com","us-west-1.elb.api.aws",
        "us-west-2.amazonaws.com","us-west-2.api.aws","us-west-2.autoscaling.amazonaws.com","us-west-2.autoscaling.api.aws","us-west-2.ec2.amazonaws.com","us-west-2.ec2.api.aws","us-west-2.elasticmapreduce.amazonaws.com","us-west-2.elasticmapreduce.api.aws","us-west-2.elb.amazonaws.com","us-west-2.elb.api.aws",
    ];

    // Azure and Microsoft
    public static readonly ImmutableHashSet<string> AzureOrMicrosoft =
    [
        ".aadrm.com", ".ajax.aspnetcdn.com", ".aka.ms", ".appex-rf.msn.com", ".appex.bing.com",
        ".assets-yammer.com", ".auth.gfx.ms", ".autologon.microsoftazuread-sso.com", ".azmk8s.io", ".azure-api.net",
        ".azure-apim.net", ".azure-mobile.net", ".azure.com", ".azure.net", ".azurecontainer.io", ".azurecr.io",
        ".azureedge.net", ".azurefd.net", ".azurerms.com", ".azurestaticapps.net", ".azurewebsites.net",
        ".bing.com", ".cdn.onenote.net", ".clientconfig.microsoftonline-p.net", ".cloud.microsoft", ".cloudapp.net",
        ".d.docs.live.net", ".dc.services.visualstudio.com", ".ecn.dev.virtualearth.net", ".linkedin.com", ".live.com",
        ".login.microsoftonline-p.com", ".login.windows-ppe.net", ".lync.com", ".mem.gfx.ms", ".microsoft",
        ".microsoft365.com", ".microsoftonline-p.com", ".microsoftstream.com", ".microsoftusercontent.com",
        ".msauth.net", ".msauthimages.net", ".msedge.net", ".msft.net", ".msftauth.net", ".msftauthimages.net", 
        ".msftidentity.com", ".msidentity.com", ".msocdn.com", ".nexus.microsoftonline-p.com", ".o365weve.com",
        ".ocsp.msocsp.com", ".office.com", ".office.net", ".office365.com.edgesuite.net", ".office365.com",
        ".officespeech.platform.bing.com", ".onedrive.com", ".outlook.com", ".outlook.office365.com",
        ".outlookmobile.com", ".partnerservices.getmicrosoftkey.com", ".phonefactor.net", ".portal.cloudappsecurity.com",
        ".powerapps.com", ".powerautomate.com", ".prod.msocdn.com", ".protection.outlook.com", ".sharepoint.com",
        ".sharepointonline.com", ".shellprod.msocdn.com", ".skype.com", ".svc.ms", ".sway.com",
        ".table.core.windows.net", ".trafficmanager.net", ".tse1.mm.bing.net", ".visualstudio.com", ".vo.msecnd.net",
        ".windows.net", ".wpengine.com", ".wus-www.sway-cdn.com", ".wus-www.sway-extensions.com", ".yammer.com",
        ".yammerusercontent.com", ".vo.msecnd.net"
    ];

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