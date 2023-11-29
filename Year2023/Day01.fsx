#if INTERACTIVE 
#r "bin/debug/net7.0/Common.dll"
#else
module Year2022.Day01
#endif

open Common

let puzzle = ("2023", "01")

let input = getInput puzzle

let solution = {
    part1 = fun () -> "IMPLEMENT ME"
    part2 = fun () -> "IMPLEMENT ME"
}

#if INTERACTIVE 
printSol puzzle solution 
#endif
