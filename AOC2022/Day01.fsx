#load "Utils.fsx"
open Utils

let testInput = readInputLines "TestDay01.txt"
let input = readInputLines "InputDay01.txt"

(* === PART 1 === *)

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

printResult 1 (List.max <| sumOfInventories input)

(* === PART 2 === *)

sumOfInventories input
|> List.sortDescending
|> List.take 3
|> List.sum
|> printResult 2
