module AdventOfCode.Year2022.Solutions.Day

open AdventOfCode.Common

let parseLine (line : string) =
    int line

let parse = parseEachLine parseLine

let solvePart1 (input) =
    input
    
let solvePart2 (input) = 
    input

let solver = { parse = parse; part1 = solvePart1; part2 = solvePart2 }
