// Learn more about F# at http://fsharp.org

open System
let frequency list elem=
    let rec frequency1 list elem count =
        match list with
        |[] -> count
        | h::t -> 
                        let count1 = count + 1
                        if h = elem then frequency1 t elem count1 
                        else frequency1 t elem count
    frequency1 list elem 0
let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |h::t ->    if (h = el) then num
                        else 
                            let num1 = num + 1
                            pos1 t el num1
    pos1 list el 1

let modification (list:'int list) =
    let rec m1 list (resultlist:'int list) =
        match list with
        | h::t->
            if ( ((frequency list h)=1) && (h%(pos list h)=0)) then m1 t (resultlist @ [h])
            else m1 t resultlist
        | []-> resultlist
    m1 list []

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = Program.readlist n
    let result = modification list
    Console.WriteLine(pos list 4)
    0 // return an integer exit code
