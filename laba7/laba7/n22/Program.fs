open System
let result list a b= List.fold (fun s x -> if (x=List.min list && x>a && x<b) then s+1 else s) 0 list
[<EntryPoint>]
let main argv =
    let list= Program.readlist 5
    Console.WriteLine(result list 1 3)
    0
