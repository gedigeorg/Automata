using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Automata;
using Microsoft.Automata.Rex;

namespace ConsoleApp1
{
    public class ReadableStrings
    {
        public void test()
        {
            RegexOptions options = RegexOptions.None;
            RexEngine rexEngine = new RexEngine(BitWidth.BV16);

            var automaton1 = rexEngine.CreateFromRegexes("[a-z]*Twain");
            var path = CreatePath(automaton1, new HashSet<int>(), new List<Move<BDD>>(), 0);

        }

        //TODO: generate strings based on these: Table 3-3: A (Very) Superficial Look at the Flavor of a Few Common Tools
        //1. samples regexes - kaardista (lihtsusta, osadena)
        //2. GenerateMemberUniformly
        //3. saa aru kuidas genereerimine tootab


        public List<Move<BDD>> CreatePath(Automaton<BDD> automaton, HashSet<int> visitedStates, List<Move<BDD>> currentPath, int currentStateId)
        {
            if (automaton.IsFinalState(currentStateId))
                return currentPath.ToList();
            else
            {
                var possibleMoves = automaton.GetMovesFrom(currentStateId).ToArray();

                // Print possibleMoves labels
                //Console.Write("Moves from state {0}: ", currentStateId);
                foreach (var move in possibleMoves)
                {
                    if (move.Label.ToString() == ".")
                    {
                        
                    }
                    Console.Write("{0} ", move.Label);
                }

                visitedStates.Add(currentStateId);
                var oneMove = possibleMoves.First(v => v.SourceState != v.TargetState);
                return CreatePath(automaton, visitedStates, new List<Move<BDD>>(currentPath) { oneMove }, oneMove.TargetState);
            }
        }

    }
}
