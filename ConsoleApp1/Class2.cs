using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Automata;
using Microsoft.Automata.Rex;


namespace ConsoleApp1
{
    internal class Class2
    {
        public void GenerateStringsFromRegex()
        {
            RegexOptions options = RegexOptions.None;
            // pean olema 16 bit
            RexEngine rexEngine = new RexEngine(BitWidth.BV16);

            Console.OutputEncoding = Encoding.Unicode;
            string copyrightSymbolPattern = @"\u00a9";
            string registeredTrademarkSymbolPattern = @"\u00ae";
            string symbolRangePattern = @"[\u2000-\u3300]";
            string firstSupplementaryPlaneEmojiPattern = @"\ud83c[\ud000-\udfff]";
            string secondSupplementaryPlaneEmojiPattern = @"\ud83d[\ud000-\udfff]";
            string thirdSupplementaryPlaneEmojiPattern = @"\ud83e[\ud000-\udfff]";
            string fullPattern = $"({copyrightSymbolPattern}|{registeredTrademarkSymbolPattern}|{symbolRangePattern}|{firstSupplementaryPlaneEmojiPattern}|{secondSupplementaryPlaneEmojiPattern}|{thirdSupplementaryPlaneEmojiPattern})";

            string specialCharacters = "[^A-Za-z0-9]";

            var regexes = new string[]
            {
                //"^[^u-z]{1}$",
                //"[^\\u4E00-\\u9FFF\\u3000-\\u303F]",

                // Regex to match all emojis:
                //$"^{fullPattern}{1}$",
                //$"^[a - q][^u - z]{13}x$",
                //"^[A-Za-z0-9]{4}$"

                //".{0,2}(Tom|Sawyer|Huckleberry|Finn)",
                "\\A.{0,2}(Tom|Sawyer|Huckleberry|Finn)\\z"
            };

            // Create a product of the automata of the given regexes.
            var automaton = rexEngine.CreateFromRegexes(regexes);
            // contains matching string!!!
            //var tr = rexEngine.GenerateMembers(options, 5, regexes);

            var chooser = new Chooser();
            var asd = automaton.ChoosePathToSomeFinalState(chooser);

            var path = asd.ToArray();

            for (int i = 0; i < path.Length; i++)
            {
                BDD bdd = path[i];
                Tuple<uint, uint>[] ranges = bdd.ToRanges();

                Tuple<uint, uint> range = ranges[0];
                char rangeStart = (char)range.Item1;
                char rangeEnd = (char)range.Item2;

                char[] chars = Enumerable.Range(rangeStart, rangeEnd - rangeStart + 1)
                    .Select(i => (char)i)
                    .ToArray();
                char randomChar = chars[new Random().Next(chars.Length)];

                Console.WriteLine(chars);
                Console.WriteLine();
                Console.WriteLine();
            }

            //BDD first = path[0];
            //Tuple<uint, uint>[] ranges = first.ToRanges();

            //Tuple<uint, uint> range1 = ranges[0];
            //char range1start = (char)range1.Item1;
            //char range1end = (char)range1.Item2;

            //char[] chars = Enumerable.Range(range1start, range1end - range1start + 1)
            //    .Select(i => (char)i)
            //    .ToArray();
            //char randomChar = chars[new Random().Next(chars.Length)];

            //Console.WriteLine(chars);

            ////

            //BDD second = path[1];
            //Tuple<uint, uint>[] ranges2 = second.ToRanges();

            //Tuple<uint, uint> range2 = ranges2[0];
            //char range2start = (char)range2.Item1;
            //char range2end = (char)range2.Item2;

            //char[] chars2 = Enumerable.Range(range2start, range2end - range2start + 1)
            //    .Select(i => (char)i)
            //    .ToArray();
            //char randomChar2 = chars[new Random().Next(chars.Length)];
            //Console.WriteLine(chars2);

            Console.WriteLine("Shortest path: ");
            var shortest = automaton.FindShortestFinalPath(0);
            foreach (BDD t in shortest.Item1)
            {
                Console.Write(t);
            }
            Console.WriteLine();
            //Console.WriteLine(shortest.Item2);

            Console.WriteLine("------------");
            // match all regexes
            var samples = rexEngine.GenerateMembers(options, 3, regexes);
            foreach (var str in samples)
            {
                Console.WriteLine(str);
            }
        }
    }
}
