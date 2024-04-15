using Microsoft.Automata;
using Microsoft.Automata.Rex;
using System.Text.RegularExpressions;


var engine = new RexEngine(BitWidth.BV16);

// let engine1 = System.Text.RegularExpressions.Regex(pattern, RegexOptions.Compiled)
// let engine2 = System.Text.RegularExpressions.Regex(pattern, RegexOptions.None)
// let engine3 = System.Text.RegularExpressions.Regex(pattern, RegexOptions.NonBacktracking)
// len 8-18 , digit, lower, upper, special
// ^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$^&*()_-]).{8,18}$


//var samples =
//    engine.GenerateMembers(RegexOptions.None, 2, [|
//    ".*e.*"
//".*g.*"
//".*1.*"
//"^[a-zA-Z0-9]*$"
//    |])
//    |> Seq.toArray

var samples =
    engine.GenerateMembers(RegexOptions.None, 2, new string[] { "*s", "a*" });

//var automaton = engine.CreateFromRegexes(new string[] {"a?s"});

//var automaton = engine.CreateFromRegexes([|
//                ".*e.*"
//".*g.*"
//".*1.*"
//"^[a-zA-Z0-9]*$"
//    |])


//var chooser = new Chooser();
//var asd = automaton.ChoosePathToSomeFinalState(chooser);

//var path = asd.ToArray();
//var first = path[1];
//var ranges = first.ToRanges();
// [0-9]
//var range1start = ranges[0];
//var range1end = ranges[0];

//char range1start
//char range1end

//var chars = 
//[ for i = range1start to range1end do i]
//    |> List.map char
//var randomChar =
//    chars[System.Random.Shared.Next(chars.Length)]

//var shortest = automaton.FindShortestFinalPath(0)




