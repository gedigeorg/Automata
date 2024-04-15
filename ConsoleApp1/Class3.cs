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

                "^x(xyz)*z?$"
                //"^x(xyz)*z?$"
                //"^[a-g]{1,2}x?$"
                //"^x*$"
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

            // 1. täiendada algot kõik teekonnad kõikide final stateni, final state isVisited nullida
            // 2. doci lisa näited regexitest mille peal kaitsetasid, joonistega
            // 3. genereeri tekste, testi ulatuslikumalt
            // 4. "*" rohkem testida, "x*", ".*", "x*y*", "((x*)y)*", "((x*)y*)*"
            // 5. milliseid automaate gen kui on mitu *? pane doci kirja koos graafikuga


            Console.WriteLine("Test algo 1 & 2:");
            var sample = rexEngine.TestAlgo1(options, 1, 2, regexes);
            foreach (var s in sample)
            {
                Console.WriteLine(s);
            }

        }
    }
}
