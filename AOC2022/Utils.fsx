open System.IO

let readInputLines fileName =
    File.ReadAllLines(__SOURCE_DIRECTORY__ + "/inputs/" + fileName)
    |> Seq.toList

// Result is not necessarily of type int, can be unsigned int, float etc. 
let printResult part result =
    printfn $"Solution to part %i{part}: %A{result}"
