module Common

open System.IO

type Solution = {
    part1: unit -> string
    part2: unit -> string
}

let printSolution year day solution = 
    printfn $"Solution to Day %s{day} Year %s{year}:"
    printfn $"Part 1: %A{solution.part1}"
    printfn $"Part 2: %A{solution.part2}"

let readAllLines = File.ReadLines >> Seq.toList

let parseEachLine f = File.ReadLines >> Seq.map f

let parseEachLineIndexed f = File.ReadLines >> Seq.mapi f

let charToInt (c: char) = int c - int '0'

let getExample year day = 
    Path.Combine(__SOURCE_DIRECTORY__, "..", $"Year%s{year}", "example", $"day%s{day}.txt")

let getInput year day = 
    Path.Combine(__SOURCE_DIRECTORY__, "..", $"Year%s{year}", "input", $"day%s{day}.txt")

let unitToStrWrap f = 
    fun () -> string f

