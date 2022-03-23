open System
let rec readlist n =
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)
let rec writelist list=
    List.iter(fun x->printfn "%O" x) list
let find_min list=List.findIndex(fun x->x=List.min list) list

[<EntryPoint>]
let main argv =
    let list= readlist 5
    Console.WriteLine(find_min list)
    0 // return an integer exit code
