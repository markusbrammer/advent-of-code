module AdventOfCode.Year2022.Solutions.Day01

open AdventOfCode.Common

let sumOfInventories (calorieList: string list) =
    // Add the sum of calories of each inventory to a list of sums. 
    List.fold
        (fun (sums, inventorySum) entry ->
            match entry with
            | "" -> (inventorySum :: sums, 0)
            | s -> (sums, (int s) + inventorySum))
        ([], 0)
        calorieList
    // Remember the last inventory. 
    |> fun (sums, lastInventorySum) -> lastInventorySum :: sums

let solvePart1 ls = List.max <| sumOfInventories ls

(* === PART 2 === *)

let solvePart2 input = 
    sumOfInventories input
    |> List.sortDescending
    |> List.take 3
    |> List.sum

let solver = { parse = readAllLines; part1 = solvePart1; part2 = solvePart2 }
