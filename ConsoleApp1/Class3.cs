using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Automata;
using Microsoft.Automata.Rex;


namespace ConsoleApp1
{
    internal class Class3
    {
        public void GenerateStringsFromRegex()
        {
            RegexOptions options = RegexOptions.None;
            RexEngine rexEngine = new RexEngine(BitWidth.BV16);
            Console.OutputEncoding = Encoding.Unicode;

            var regexes = new string[]
            {
                //"^([0-9]{1,2}[:][0-9]{1,2}[:]{0,2}[0-9]{0,2}[\\s]{0,}[AMPamp]{0,2})$",
                //"^([A-Za-z]{0,}[\\.\\,\\s]{0,}[A-Za-z]{1,}[\\.\\s]{1,}[0-9]{1,2})$",
                //  [\\,\\s]{0,}[0-9]{4})| ([0-9]{0,4}[-,\\s]{0,}[A-Za-z]{3,9}[-,\\s]{0,}[0-9]{1,2}[-,\\s]{0,}[A-Za-z]{0,8})| ([0-9]{1,4}[\\/\\.\\-][0-9]{1,4}[\\/\\.\\-][0-9]{1,4})
                //"^[a-q]{1,2}[^u-z]{0,1}x*$",
                //"^[a-c]{1}x*$",
                //"^[a-c]{1}",
                //"x*$"
                
                //"^[a-q][^u-z]{13}x$",

                //".*",
                //"^a*$",
                //"^(ab)*$",
                //"^(abc)*$",
                //"^x(xyz)*$",
                //"^x(xyz)*z$"

                //"^(adhi?|be(i)?|cfe(i)?|cg)$"
                //"^(a*b*c*|1*2*3*)*$"

                //"^(a|bc)$"

                //"^x(xyz)*z?$"
                //"^x(xyz)*z?$"
                //"^x*y*$"
                //"^a(1234)*b?$"

                //"^(abcd)*$"

                //"^x(xyz)*z?$"
                //"^x(xyz){0,5}z?$"

                //"^[a-g]{1,2}x?$"
                //"^x*$"

                //"^x(xyzt(r)*)*z?$"
                //"^(ax|bx|bzx)$"
                
                //"^a((x*)y*)*$"
                //"^a(12(xy)*)*$"
                
                //"^a(1234)*$"
                //"^a(1234)+$"
                //"^Huck[a-zA-Z]+|Saw[a-zA-Z]+$"

                "^x(xyz){0,5}z?$"
                //@"^((19\d\d01[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d01[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d02[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d02[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d03[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d03[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d04[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d04[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d05[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d05[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d06[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d06[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d07[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d07[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d08[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d08[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d09[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d09[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d10[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d10[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d11[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d11[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d12[0-3]\d[0-5]\d[0-5]\d[0-5]\d|20\d\d12[0-3]\d[0-5]\d[0-5]\d[0-5]\d|19\d\d01[0123]\d|20\d\d01[0123]\d|19\d\d02[0123]\d|20\d\d02[0123]\d|19\d\d03[0123]\d|20\d\d03[0123]\d|19\d\d04[0123]\d|20\d\d04[0123]\d|19\d\d05[0123]\d|20\d\d05[0123]\d|19\d\d06[0123]\d|20\d\d06[0123]\d|19\d\d07[0123]\d|20\d\d07[0123]\d|19\d\d08[0123]\d|20\d\d08[0123]\d|19\d\d09[0123]\d|20\d\d09[0123]\d|19\d\d10[0123]\d|20\d\d10[0123]\d|19\d\d11[0123]\d|20\d\d11[0123]\d|19\d\d12[0123]\d|20\d\d12[0123]\d|19\d\d01|20\d\d01|19\d\d02|20\d\d02|19\d\d03|20\d\d03|19\d\d04|20\d\d04|19\d\d05|20\d\d05|19\d\d06|20\d\d06|19\d\d07|20\d\d07|19\d\d08|20\d\d08|19\d\d09|20\d\d09|19\d\d10|20\d\d10|19\d\d11|20\d\d11|19\d\d12|20\d\d12|(-?(:[1-9][0-9]*)?[0-9]{4})-(1[0-2]|0[1-9])-(3[01]|0[1-9]|[12][0-9])T(2[0-3]|[01][0-9]):([0-5][0-9]):([0-5][0-9])(?:[.,]+([0-9]+))?((?:Z|[+-](?:2[0-3]|[01][0-9]):[0-5][0-9]))?)|((((\d{1,2}):(\d{1,2})(:(\d{1,2}))?([.,](\d{1,6}))?\s*(a.m.|am|p.m.|pm)?\s*(ACDT|ACST|ACT|ACWDT|ACWST|ADDT|ADMT|ADT|AEDT|AEST|AFT|AHDT|AHST|AKDT|AKST|AKTST|AKTT|ALMST|ALMT|AMST|AMT|ANAST|ANAT|ANT|APT|AQTST|AQTT|ARST|ART|ASHST|ASHT|AST|AWDT|AWST|AWT|AZOMT|AZOST|AZOT|AZST|AZT|BAKST|BAKT|BDST|BDT|BEAT|BEAUT|BIOT|BMT|BNT|BORT|BOST|BOT|BRST|BRT|BST|BTT|BURT|CANT|CAPT|CAST|CAT|CAWT|CCT|CDDT|CDT|CEDT|CEMT|CEST|CET|CGST|CGT|CHADT|CHAST|CHDT|CHOST|CHOT|CIST|CKHST|CKT|CLST|CLT|CMT|COST|COT|CPT|CST|CUT|CVST|CVT|CWT|CXT|ChST|DACT|DAVT|DDUT|DFT|DMT|DUSST|DUST|EASST|EAST|EAT|ECT|EDDT|EDT|EEDT|EEST|EET|EGST|EGT|EHDT|EMT|EPT|EST|ET|EWT|FET|FFMT|FJST|FJT|FKST|FKT|FMT|FNST|FNT|FORT|FRUST|FRUT|GALT|GAMT|GBGT|GEST|GET|GFT|GHST|GILT|GIT|GMT|GST|GYT|HAA|HAC|HADT|HAE|HAP|HAR|HAST|HAT|HAY|HDT|HKST|HKT|HLV|HMT|HNA|HNC|HNE|HNP|HNR|HNT|HNY|HOVST|HOVT|HST|ICT|IDDT|IDT|IHST|IMT|IOT|IRDT|IRKST|IRKT|IRST|ISST|IST|JAVT|JCST|JDT|JMT|JST|JWST|KART|KDT|KGST|KGT|KIZST|KIZT|KMT|KOST|KRAST|KRAT|KST|KUYST|KUYT|KWAT|LHDT|LHST|LINT|LKT|LMT|LMT|LMT|LMT|LRT|LST|MADMT|MADST|MADT|MAGST|MAGT|MALST|MALT|MART|MAWT|MDDT|MDST|MDT|MEST|MET|MHT|MIST|MIT|MMT|MOST|MOT|MPT|MSD|MSK|MSM|MST|MUST|MUT|MVT|MWT|MYT|NCST|NCT|NDDT|NDT|NEGT|NEST|NET|NFT|NMT|NOVST|NOVT|NPT|NRT|NST|NT|NUT|NWT|NZDT|NZMT|NZST|OMSST|OMST|ORAST|ORAT|PDDT|PDT|PEST|PET|PETST|PETT|PGT|PHOT|PHST|PHT|PKST|PKT|PLMT|PMDT|PMMT|PMST|PMT|PNT|PONT|PPMT|PPT|PST|PT|PWT|PYST|PYT|QMT|QYZST|QYZT|RET|RMT|ROTT|SAKST|SAKT|SAMT|SAST|SBT|SCT|SDMT|SDT|SET|SGT|SHEST|SHET|SJMT|SLT|SMT|SRET|SRT|SST|STAT|SVEST|SVET|SWAT|SYOT|TAHT|TASST|TAST|TBIST|TBIT|TBMT|TFT|THA|TJT|TKT|TLT|TMT|TOST|TOT|TRST|TRT|TSAT|TVT|ULAST|ULAT|URAST|URAT|UTC|UYHST|UYST|UYT|UZST|UZT|VET|VLAST|VLAT|VOLST|VOLT|VOST|VUST|VUT|WARST|WART|WAST|WAT|WDT|WEDT|WEMT|WEST|WET|WFT|WGST|WGT|WIB|WIT|WITA|WMT|WSDT|WSST|WST|WT|XJT|YAKST|YAKT|YAPT|YDDT|YDT|YEKST|YEKST|YEKT|YEKT|YERST|YERT|YPT|YST|YWT|zzz|pacific|eastern|mountain|central)?)|((\d{1,2})\s*(a.m.|am|p.m.|pm)\s*(ACDT|ACST|ACT|ACWDT|ACWST|ADDT|ADMT|ADT|AEDT|AEST|AFT|AHDT|AHST|AKDT|AKST|AKTST|AKTT|ALMST|ALMT|AMST|AMT|ANAST|ANAT|ANT|APT|AQTST|AQTT|ARST|ART|ASHST|ASHT|AST|AWDT|AWST|AWT|AZOMT|AZOST|AZOT|AZST|AZT|BAKST|BAKT|BDST|BDT|BEAT|BEAUT|BIOT|BMT|BNT|BORT|BOST|BOT|BRST|BRT|BST|BTT|BURT|CANT|CAPT|CAST|CAT|CAWT|CCT|CDDT|CDT|CEDT|CEMT|CEST|CET|CGST|CGT|CHADT|CHAST|CHDT|CHOST|CHOT|CIST|CKHST|CKT|CLST|CLT|CMT|COST|COT|CPT|CST|CUT|CVST|CVT|CWT|CXT|ChST|DACT|DAVT|DDUT|DFT|DMT|DUSST|DUST|EASST|EAST|EAT|ECT|EDDT|EDT|EEDT|EEST|EET|EGST|EGT|EHDT|EMT|EPT|EST|ET|EWT|FET|FFMT|FJST|FJT|FKST|FKT|FMT|FNST|FNT|FORT|FRUST|FRUT|GALT|GAMT|GBGT|GEST|GET|GFT|GHST|GILT|GIT|GMT|GST|GYT|HAA|HAC|HADT|HAE|HAP|HAR|HAST|HAT|HAY|HDT|HKST|HKT|HLV|HMT|HNA|HNC|HNE|HNP|HNR|HNT|HNY|HOVST|HOVT|HST|ICT|IDDT|IDT|IHST|IMT|IOT|IRDT|IRKST|IRKT|IRST|ISST|IST|JAVT|JCST|JDT|JMT|JST|JWST|KART|KDT|KGST|KGT|KIZST|KIZT|KMT|KOST|KRAST|KRAT|KST|KUYST|KUYT|KWAT|LHDT|LHST|LINT|LKT|LMT|LMT|LMT|LMT|LRT|LST|MADMT|MADST|MADT|MAGST|MAGT|MALST|MALT|MART|MAWT|MDDT|MDST|MDT|MEST|MET|MHT|MIST|MIT|MMT|MOST|MOT|MPT|MSD|MSK|MSM|MST|MUST|MUT|MVT|MWT|MYT|NCST|NCT|NDDT|NDT|NEGT|NEST|NET|NFT|NMT|NOVST|NOVT|NPT|NRT|NST|NT|NUT|NWT|NZDT|NZMT|NZST|OMSST|OMST|ORAST|ORAT|PDDT|PDT|PEST|PET|PETST|PETT|PGT|PHOT|PHST|PHT|PKST|PKT|PLMT|PMDT|PMMT|PMST|PMT|PNT|PONT|PPMT|PPT|PST|PT|PWT|PYST|PYT|QMT|QYZST|QYZT|RET|RMT|ROTT|SAKST|SAKT|SAMT|SAST|SBT|SCT|SDMT|SDT|SET|SGT|SHEST|SHET|SJMT|SLT|SMT|SRET|SRT|SST|STAT|SVEST|SVET|SWAT|SYOT|TAHT|TASST|TAST|TBIST|TBIT|TBMT|TFT|THA|TJT|TKT|TLT|TMT|TOST|TOT|TRST|TRT|TSAT|TVT|ULAST|ULAT|URAST|URAT|UTC|UYHST|UYST|UYT|UZST|UZT|VET|VLAST|VLAT|VOLST|VOLT|VOST|VUST|VUT|WARST|WART|WAST|WAT|WDT|WEDT|WEMT|WEST|WET|WFT|WGST|WGT|WIB|WIT|WITA|WMT|WSDT|WSST|WST|WT|XJT|YAKST|YAKT|YAPT|YDDT|YDT|YEKST|YEKST|YEKT|YEKT|YERST|YERT|YPT|YST|YWT|zzz|pacific|eastern|mountain|central)*))|(19\d\d|20\d\d)|(first|second|third|fourth|fifth|sixth|seventh|eighth|nineth|tenth)|(\d+)(st|th|rd|nd)?|(monday|tuesday|wednesday|thursday|friday|saturday|sunday|mandag|tirsdag|onsdag|torsdag|fredag|lordag|sondag|mon|tue|tues|wed|thu|thur|thurs|fri|sat|sun|man|tir|tirs|ons|tor|tors|fre|lor|son)|(january|february|march|april|may|june|july|august|september|october|november|december|enero|febrero|marzo|abril|mayo|junio|julio|agosto|septiembre|octubre|noviembre|diciembre|januar|februar|marts|april|maj|juni|juli|august|september|oktober|november|december|jan[.\s]|ene[.\s]|feb[.\s]|mar[.\s]|apr[.\s]|abr[.\s]|may[.\s]|maj[.\s]|jun[.\s]|jul[.\s]|aug[.\s]|ago[.\s]|sep[^A-Za-z]|sept[.\s]|oct[.\s]|okt[.\s]|nov[.\s]|dec[.\s]|dic[.\s])|([/:\-,.\s_+@]+)|(next|last)|(due|by|on|during|standard|daylight|savings|time|date|dated|of|to|through|between|until|at|day)){1,1})$"
                //@"(?:[A-Z][a-z]+\s*){10,100}"
                //@"^[A-Za-z]{10}\s+[\s\S]{0,100}Result[\s\S]{0,100}\s+[A-Za-z]{10}$"
                //"^(.*A.*B.*C.*|.*B.*A.*C.*|.*B.*C.*A.*|.*A.*C.*B.*|.*C.*A.*B.*|.*C.*B.*A.*)$"
            };

            // match all regexes
            //var samples = rexEngine.GenerateMembers(options, 1, regexes);
            //foreach (var str in samples)
            //{
            //    Console.WriteLine(str);
            //}

            //var sample = rexEngine.GenerateMembersReadable(options, 3, regexes);
            //foreach (var c in sample)
            //{
            //    Console.WriteLine(c);
            //}

            //var sample2 = rexEngine.GenerateMembersReadable2(options, 1, 2, regexes);
            //foreach (var s in sample2)
            //{
            //    Console.WriteLine(s);
            //}

            //rexEngine.Visualize(options, regexes);
            //Console.WriteLine();

            Console.WriteLine("Test algo 1 & 2:");
            //var sample = rexEngine.TestAlgo1(options, 1, new List<int> {4}, 4, 7, regexes);
            var sample = rexEngine.TestAlgo1(options, 1, new List<int> {4}, false, regexes: regexes);
            foreach (var s in sample)
            {
                Console.WriteLine(s);
            }

            // NFA -> DFA
            // def * kui midagi muud nt vahemik {}
            // nt {0,100}, hiljem parametriseerida, kui ei saa asenda
            // paranda indexid ComputeShortestPathsToFinal

            // case pika stringi genereerimiseks, 10k olekut



        }
    }
}
