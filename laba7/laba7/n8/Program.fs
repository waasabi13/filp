open System

[<EntryPoint>]
let main argv =
    let array1=[|1;2;3|]
    let array2=[|4;5;7|]
    let result=Array.append array1 [|(Array.item(array2.Length-1) array2)|] 
    printfn"%A"result
    0 // return an integer exit code
