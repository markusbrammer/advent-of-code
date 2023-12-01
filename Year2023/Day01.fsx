#if INTERACTIVE
#r "bin/debug/net7.0/Common.dll"
#else
module Year2022.Day01
#endif

open Common
open System.Text.RegularExpressions

let puzzle = ("2023", "01")
let example = getExample puzzle
let input = getInput puzzle

(****************************************************************************
 ********************************** Part 1 **********************************
 ****************************************************************************)

let digits = "0123456789"

let isDigit (c: char) =
    // A string is a sequence of chars
    Seq.contains c digits

let getCalibrationVal (s: string) =
    int $"%c{Seq.find isDigit s}%c{Seq.findBack isDigit s}"

let solPart1 input =
    Seq.sumBy getCalibrationVal (readLines input)

(****************************************************************************
 ********************************** Part 2 **********************************
 ****************************************************************************)

// Clever idea from https://www.reddit.com/user/DrunkHacker/
// https://www.reddit.com/r/adventofcode/comments/1883ibu/comment/kbj2stu/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button
let lettersToInt =
    Map.ofList
        [ ("zero", "z0o")
          ("one", "o1e")
          ("two", "t2o")
          ("three", "t3e")
          ("four", "f4r")
          ("five", "f5e")
          ("six", "s6x")
          ("seven", "s7n")
          ("eight", "e8t")
          ("nine", "n9e") ]

let replaceSpelled (s: string) =
    Seq.fold (fun (snew: string) key -> snew.Replace(key, Map.find key lettersToInt)) s (Map.keys lettersToInt)

let solPart2 input =
    (readLines input)
    |> Seq.map replaceSpelled
    |> Seq.sumBy getCalibrationVal

(****************************************************************************
 ********************************* Solution *********************************
 ****************************************************************************)

let solution =
    { part1 = fun () -> solPart1 input
      part2 = fun () -> solPart2 input }

#if INTERACTIVE
printSol puzzle solution
#endif
