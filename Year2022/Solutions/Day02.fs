module AdventOfCode.Year2022.Day02

open AdventOfCode
open Common

type Shape =
    | Rock
    | Paper
    | Scissors

(* === PART 1 === *)

let toPair = function
    | [| a; b |] -> (a, b)
    | _ -> failwith "Only meant to pair the output of s.split in this exercise"

let collectPairs (inputLines: string list) =
    List.map ((fun (s: string) -> s.Split ' ') >> toPair) inputLines
   
let getShapeScore = function
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3
    
let decryptPart1 = function
    | "A"
    | "X" -> Rock
    | "B"
    | "Y" -> Paper
    | "C"
    | "Z" -> Scissors
    | _ -> failwith "Incorrectly-formed encrypted message"

let resultOfGame (shape1, shape2) =
    match decryptPart1 shape1, decryptPart1 shape2 with
    | h1, h2 when h1 = h2 -> 3
    | Scissors, Rock
    | Paper, Scissors
    | Rock, Paper -> 6
    | _ -> 0

let sumOfGame (_, shape2 as game) =
    resultOfGame game + getShapeScore (decryptPart1 shape2)

let getResultPart1 inputLines =
    List.sumBy sumOfGame <| collectPairs inputLines

(* === PART 2 === *)

type Outcome =
    | Win
    | Lose
    | Draw
    
let decryptOutcome = function
    | "X" -> Lose
    | "Y" -> Draw
    | "Z" -> Win
    | _ -> failwith "Can not be decrypted to an outcome"
    
let decryptShape = function
    | "A" -> Rock
    | "B" -> Paper
    | "C" -> Scissors
    | _ -> failwith "Cannot be decrypted to a shape"
    
let getOutcomeScore = function
    | Win -> 6
    | Lose -> 0
    | Draw -> 3
    
let deduceGame (shape1, encryptedOutcome) =
    let decryptedShape = decryptShape shape1
    match decryptOutcome encryptedOutcome with
    | Lose ->
        match decryptedShape with
        | Rock -> Scissors
        | Paper -> Rock
        | Scissors -> Paper
    | Draw ->
        match decryptedShape with
        | Rock -> Rock
        | Paper -> Paper
        | Scissors -> Scissors
    | Win ->
        match decryptedShape with
        | Rock -> Paper
        | Paper -> Scissors
        | Scissors -> Rock

let sumOfGamePart2 (_, outcome as game) =
    getOutcomeScore (decryptOutcome outcome) + getShapeScore (deduceGame game)
    
let getResultPart2 inputList =
    collectPairs inputList
    |> List.sumBy sumOfGamePart2

let solver = { parse = readAllLines; part1 = getResultPart1; part2 = getResultPart2}
