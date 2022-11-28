open System.IO

let readLines fileName =
    Seq.toList <| File.ReadAllLines(fileName)
