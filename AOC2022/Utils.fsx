open System.IO

let readInputLines fileName =
    File.ReadAllLines(__SOURCE_DIRECTORY__ + "/inputs/" + fileName)
    |> Seq.toList

let printSolution problemNo solution =
    printfn $"Solution to problem %i{problemNo}: %A{solution}"
