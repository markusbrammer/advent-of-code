#if INTERACTIVE 
#r "bin/debug/net7.0/Common.dll"
#else
module Year2022.Day01
#endif

open Common

let input = getInput "2022" "01"

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

let solution = {
    part1 = fun () -> solvePart1 (readAllLines input) |> string
    part2 = fun () -> solvePart2 (readAllLines input) |> string
}
