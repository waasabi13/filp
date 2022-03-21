open System
let rec readlist n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readlist (n-1)
    Head::Tail

let rec writelist = function
    [] -> ()
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writelist tail

let sumlist a b c = (a+b)+c

let modification (list:'int list)=
    let rec m1 list (resultlist:'int list) =
        match list with
        | a::b::c::t-> m1 t (resultlist @ [sumlist a b c])
        | a::b::[]->(resultlist @ [sumlist a b 1])
        | a::[]-> (resultlist @ [sumlist a 1 1])
        | []-> resultlist
    m1 list List.empty
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = readlist n
    writelist (modification list)
    0
