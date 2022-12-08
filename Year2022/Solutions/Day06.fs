module AdventOfCode.Year2022.Day06

open AdventOfCode.Common

(* === PART 1 === *)

let getStartOfPacketMarker (inputLine: string) =
    let rec f i =
        function
        | c0 :: c1 :: c2 :: c3 :: csrest ->
            if List.length (List.distinct [ c0; c1; c2; c3 ]) = 4 then
                i + 3
            else
                f (i + 1) (c1 :: c2 :: c3 :: csrest)
        | _ -> failwith "Cannot find four distinct"

    f 1 <| Seq.toList inputLine

let resultPart1 (inputLines: string list) =
    match inputLines with
    | [ s ] -> getStartOfPacketMarker s
    | _ -> failwith "Wrong input"


(* === PART 2 === *)

let getStartOfPacketMarker2 (inputLine: string) =
    let rec f i cs =
        let first14 = List.take 14 cs

        if List.length (List.distinct first14) = 14 then
            i + 13
        else
            f (i + 1) <| List.tail cs

    f 1 <| Seq.toList inputLine

let resultPart2 inputLines =
    match inputLines with
    | [ s ] -> getStartOfPacketMarker2 s
    | _ -> failwith "Wrong input"

let solver = { parse = readAllLines; part1 = resultPart1; part2 = resultPart2 }
