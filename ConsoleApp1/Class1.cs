using System.Text.RegularExpressions;
using Microsoft.Automata;
using Microsoft.Automata.Rex;


namespace ConsoleApp1
{
    internal class Class1
    {
        public void GenerateStringsFromRegex()
        {
            RegexOptions options = RegexOptions.None;
            RexEngine rexEngine = new RexEngine(BitWidth.BV16);

            var regexes = new string[]
            {
                //".*e.*",
                //".*g.*",
                //".*1.*",
                //"^[a-zA-Z0-9]*$"

                "^[0-9]{1}.{1}$",
                "^.{1}[a-z]{1}$",
            };

            // match all regexes
            var samples = rexEngine.GenerateMembers(options, 4, regexes);
            foreach (var str in samples)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("------------");

            // Create a product of the automata of the given regexes.
            var automaton = rexEngine.CreateFromRegexes(regexes);

            var chooser = new Chooser();
            var asd = automaton.ChoosePathToSomeFinalState(chooser);

            var path = asd.ToArray();

            BDD first = path[0];
            Tuple<uint, uint>[] ranges = first.ToRanges();
            // [0-9]
            Tuple<uint, uint> range1 = ranges[0];
            char range1start = (char)range1.Item1;
            char range1end = (char)range1.Item2;

            char[] chars = Enumerable.Range(range1start, range1end - range1start + 1)
                .Select(i => (char)i)
                .ToArray();
            char randomChar = chars[new Random().Next(chars.Length)];
            Console.WriteLine(chars);

            //

            BDD second = path[1];
            Tuple<uint, uint>[] ranges2 = second.ToRanges();

            Tuple<uint, uint> range2 = ranges2[0];
            char range2start = (char)range2.Item1;
            char range2end = (char)range2.Item2;

            char[] chars2 = Enumerable.Range(range2start, range2end - range2start + 1)
                .Select(i => (char)i)
                .ToArray();
            char randomChar2 = chars[new Random().Next(chars.Length)];
            Console.WriteLine(chars2);

            Console.WriteLine("Shortest path: ");
            var shortest = automaton.FindShortestFinalPath(0);
            foreach (BDD t in shortest.Item1)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine(shortest.Item2);
        }
    }
}
