namespace AdventOfCode

open System.IO

module Common =

    type Day<'a, 'b, 'c> = { parse: string -> 'a; part1: 'a -> 'b; part2: 'a -> 'c }

    let readAllLines = File.ReadLines >> Seq.toList

    let parseEachLine f = File.ReadLines >> Seq.map f

    let parseEachLineIndexed f = File.ReadLines >> Seq.mapi f

    // Result is not necessarily of type int, can be unsigned int, float etc. 
    let printResult part result =
        printfn $"Solution to part %i{part}: %A{result}"

    let charToInt (c: char) = int c - int '0'
