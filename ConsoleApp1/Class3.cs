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
                //"^[a-g]{1,2}x?$"
                //"^x*$"

                //"^x(xyzt(r)*)*z?$"
                //"^(ax|bx|bzx)$"
                
                //"^a((x*)y*)*$"
                //"^a(12(xy)*)*$"
                
                //"^a(1234)*$"
                //"^a(1234)+$"
                "^Huck[a-zA-Z]+|Saw[a-zA-Z]+$"
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

            rexEngine.Visualize(options, regexes);
            Console.WriteLine();

            Console.WriteLine("Test algo 1 & 2:");
            //var sample = rexEngine.TestAlgo1(options, 1, new List<int> {4}, 4, 7, regexes);
            var sample = rexEngine.TestAlgo1(options, 1, new List<int> {4}, true, regexes: regexes);
            foreach (var s in sample)
            {
                Console.WriteLine(s);
            }

        }
    }
}
