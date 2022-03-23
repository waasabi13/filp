// Learn more about F# at http://fsharp.org

open System
let frequency list elem=
    let rec frequency1 list elem count =
        match list with
        |[] -> count
        | h::t ->
            if h=elem then
                let newCount=count + 1
                frequency1 t elem newCount
            else frequency1 t elem count
    frequency1 list elem 0
let proc list =
    let rec m1 common list resultlist index =
        match list with
        | h::t->
            let newIndex=index+1
            if ((h% newIndex=0) && ((frequency common h)=1)) then m1 common t (resultlist @[h]) newIndex
            else m1 common t resultlist newIndex
        | []-> resultlist
    m1 list list [] 0

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = Program.readlist n
    let result = proc list
    Program.writelist(result)
    0 // return an integer exit code
