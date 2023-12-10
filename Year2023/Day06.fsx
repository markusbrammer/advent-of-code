#if INTERACTIVE
#r "bin/debug/net7.0/Common.dll"
#else
module Year2022.Day06
#endif

open Common

let puzzle = ("2023", "06")
let input = getInput puzzle

(****************************************************************************
 ********************************** Part 1 **********************************
 ****************************************************************************)

type Race = { time: uint64; dist: uint64 }

let ex =
    "Time:      7  15   30
Distance:  9  40  200"

let getData lineNo (inputLines: string seq) =
    (Seq.item lineNo inputLines).Split(": ").[1].Split(' ')
    |> Array.filter ((<>) "")
    |> Array.map uint64

let parse (inputLines: string seq) =
    Array.map2 (fun t d -> { time = t; dist = d }) (getData 0 inputLines) (getData 1 inputLines)

let possibleRuns race = 
    Array.init (int race.time) (fun t -> (uint64 t) * (race.time - (uint64 t)))
    |> Array.sumBy (fun d -> if d > race.dist then 1 else 0)

let runPart1 () =
    readLines input // ex.Split('\n')
    |> parse
    |> Array.map possibleRuns
    |> Array.fold (*) 1

runPart1 ()

(****************************************************************************
 ********************************** Part 2 **********************************
 ****************************************************************************)

let getNumber lineNo (inputLines: string seq) = 
    uint64 <| (Seq.item lineNo inputLines).Split(": ").[1].Replace(" ", "")

let parse2 inputLines = 
    { time = getNumber 0 inputLines; dist = getNumber 1 inputLines }

let runPart2 () = 
    // ex.Split('\n')
    readLines input
    |> parse2
    |> possibleRuns 

runPart2 ()

(****************************************************************************
 ********************************* Solution *********************************
 ****************************************************************************)

let solution = { part1 = runPart1; part2 = runPart2 }

#if INTERACTIVE
printSol puzzle solution
#endif
