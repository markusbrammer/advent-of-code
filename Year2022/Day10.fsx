#if INTERACTIVE 
#r "bin/debug/net7.0/Common.dll"
#else
module Year2022.Day10
#endif

open System.Text.RegularExpressions
open Common

type Operation =
    | NoOp
    | AddX of int

let noopRegex = Regex @"^noop$"
let addxRegex = Regex @"^addx (-?[0-9]+)$"

let toOperation (str: string) =
    match str with 
    | s when noopRegex.IsMatch(s) -> NoOp
    | s when addxRegex.IsMatch(s) -> addxRegex.Match(s).Groups.[1].Value |> int |> AddX
    | s -> failwith $"%s{s} not a valid operation"

let parseLine = toOperation

let parse = parseEachLine parseLine >> Seq.toList

let exec registerHistory op =
    let x =
        match registerHistory with
        | [] -> failwith "The register history should never be empty"
        | head :: _ -> head

    match op with
    | NoOp -> x :: registerHistory
    | AddX value -> x + value :: x :: registerHistory

let solvePart1 (input) =
    let registerHistory = List.fold exec [ 1 ] input |> List.rev

    List.fold (fun sum cycle -> sum + cycle * List.item (cycle - 1) registerHistory) 0 [ 20; 60; 100; 140; 180; 220 ]

let fillCrtRow registerHistoryChunk =
    let spriteOverlaps cycle spritePosition = abs (spritePosition - (cycle - 1)) <= 1

    let rec fillRow cycle =
        function
        | [] -> ""
        | spritePosition :: xrest when spriteOverlaps cycle spritePosition -> "# " + fillRow (cycle + 1) xrest
        | _ :: xrest -> ". " + fillRow (cycle + 1) xrest

    fillRow 1 registerHistoryChunk

let solvePart2 (input) =
    List.fold exec [ 1 ] input
    |> List.rev
    |> List.chunkBySize 40
    |> List.take 6
    |> List.map fillCrtRow
    |> String.concat "\n"
    |> (+) "FGCUZREC: \n"

// let solver =
//     { parse = parse
//       part1 = solvePart1
//       part2 = solvePart2 }

let input = getInput "2022" "10"

let solution = {
    part1 = unitToStrWrap (solvePart1 (parse input))
    part2 = unitToStrWrap (solvePart2 (parse input))
}