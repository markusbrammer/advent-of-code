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

let lettersToInt =
    Map.ofList
        [ ("one", 1)
          ("two", 2)
          ("three", 3)
          ("four", 4)
          ("five", 5)
          ("six", 6)
          ("seven", 7)
          ("eight", 8)
          ("nine", 9) ]

let findDigits (s: string) =
    let pattern = @"\d|zero|one|two|three|four|five|six|seven|eight|nine"
    let rgx = sprintf @"(%s).*(%s)" pattern pattern
    let m = Regex.Match(s, rgx)

    if m.Success then
        (m.Groups.[1].Value, m.Groups.[2].Value)
    else
        let rgx' = sprintf @"(%s)" pattern
        let m' = Regex.Match(s, rgx')
        let value = m'.Groups.[1].Value

        (value, value)

let digitToNumber (digit: string) =
    match digit.Length with
    | 1 -> int digit
    | _ -> Map.find digit lettersToInt

let getCalibrationVal2 (s: string) =
    let (first, last) = findDigits s

    10 * (digitToNumber first) + digitToNumber last

let solPart2 input =
    Seq.sumBy getCalibrationVal2 (readLines input)

(****************************************************************************
 ********************************* Solution *********************************
 ****************************************************************************)

let solution =
    { part1 = fun () -> solPart1 input
      part2 = fun () -> solPart2 input }

#if INTERACTIVE
printSol puzzle solution
#endif
