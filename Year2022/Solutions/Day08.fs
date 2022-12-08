module AdventOfCode.Year2022.Day08

open AdventOfCode.Common

let parseLine = Seq.map charToInt >> Seq.toList

let parse = parseEachLine parseLine >> Seq.toList



let isVisible (iRow, iColumn) forest forestTransposed =
    let rec f h = function
        | [] -> true
        | ht1 :: tsrest when h > ht1 -> f h tsrest
        | _ -> false
        
    let row = List.item iRow forest |> List.take iColumn
    let revRow = List.item iRow forest |> List.rev |> fun list -> List.take (List.length list - iColumn - 1) list
        
    let column = List.item iColumn forestTransposed |> List.take iRow 
    let revColumn = List.item iColumn forestTransposed |> List.rev |> fun list -> List.take (List.length list - iRow - 1) list
    
    let treeHeight = forest.[iRow].[iColumn]
    
    f treeHeight row || f treeHeight revRow || f treeHeight column || f treeHeight revColumn

let filteri pred list =
    let rec f index pred = function
        | [] -> []
        | x :: xs when pred index x -> x :: f (index + 1) pred xs
        | _ :: xs -> f (index + 1) pred xs
    
    f 0 pred list
    

let solvePart1 (input: int list list) =
    let forest = input
    let forestTransposed = List.transpose forest
        
    List.mapi
        (fun ri row -> filteri (fun ci _ -> isVisible (ri, ci) forest forestTransposed) row |> List.length)
        forest
    |> List.sum
        
        
let getViewDistance (iRow, iColumn) forest forestTransposed =
    let rec f h = function
        | [] -> 0
        | ht1 :: tsrest when h > ht1 -> 1 + f h tsrest
        | _ -> 1
        
    let row = List.item iRow forest |> List.take iColumn |> List.rev
    
    let revRow = List.item iRow forest |> List.skip (iColumn + 1)
        
    let column = List.item iColumn forestTransposed |> List.take iRow |> List.rev
    
    let revColumn = List.item iColumn forestTransposed |> List.skip (iRow + 1)
    
    let treeHeight = forest.[iRow].[iColumn]
    
    f treeHeight row * f treeHeight revRow * f treeHeight column * f treeHeight revColumn
    

let solvePart2 (input) = 
    let forest = input
    let forestTransposed = List.transpose forest
    
    List.mapi
        (fun ri row -> List.mapi (fun ci _ -> getViewDistance (ri, ci) forest forestTransposed) row |> List.max)
        forest
    |>  List.max
    
let solver = { parse = parse; part1 = solvePart1; part2 = solvePart2 }
