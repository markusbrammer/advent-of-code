namespace AdventOfCode.Year2022

open System.IO
open AdventOfCode
open Common

module Program =
    
    let YEAR = 2022
    let DAYS_SOLVED = 11
    
    let getSolver runExample day part =
        let run (solver: Day<_, _, _>) =
            Runner.run runExample YEAR day part solver

        match day with
        | 1 -> run Solutions.Day01.solver
        | 2 -> run Solutions.Day02.solver
        | 3 -> run Solutions.Day03.solver
        | 4 -> run Solutions.Day04.solver
        | 5 -> run Solutions.Day05.solver
        | 6 -> run Solutions.Day06.solver
        | 7 -> run Solutions.Day07.solver
        | 8 -> run Solutions.Day08.solver
        | 9 -> run Solutions.Day09.solver
        | 10 -> run Solutions.Day10.solver
        | 11 -> run Solutions.Day11.solver
        | day -> printfn $"Invalid Day: %i{day} (Year {YEAR})"

    let tryInt (s: string) =
        try
            Some <| int s
        with
            | :? System.FormatException -> None
            

    [<EntryPoint>]
    let main argv =
        let runPart runExample day part = getSolver runExample day part

        let runDay runExample day =
            for part in 1..2 do
                runPart runExample day part 

        match argv with
        | [|  |]
        | [| "-a" |] ->
            for day in 1..DAYS_SOLVED do
                runDay false day
        | [| "-e"; day; part |] ->
            // Run a specific part with example input.
            match tryInt day, tryInt part with
            | Some d, Some p -> runPart true d p
            | _ -> printfn $"Day %s{day} or part %s{part} is not an integer"
        | [| day; part |] ->
            match tryInt day, tryInt part with
            | Some d, Some p -> runPart false d p
            | _ -> printfn $"Day %s{day} or part %s{part} is not an integer"
        | [| day |] ->
            match tryInt day with
            | Some d -> runDay false d
            | None -> printfn $"Day %s{day} is not an integer"
        | _ -> printfn "Input not valid"

        0
