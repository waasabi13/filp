open System
let rec readList1 n = 
    if n=0 then []
    else
    let Head = System.Convert.ToDouble(System.Console.ReadLine())
    let Tail = readList1 (n-1)
    Head::Tail
let reslist list = List.filter (fun x->x<List.average list) list
[<EntryPoint>]
let main argv =
    let list=readList1 5
    Program.writelist(reslist list)
    0 
