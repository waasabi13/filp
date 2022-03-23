// Learn more about F# at http://fsharp.org

open System
let proc number =
    let rec pr num del =
        if num <= 1 then []
        else 
            let new_del = del+1
            if num % del =0 then List.append[del] (pr (num/del) del)                        
            else pr num new_del  
    pr number 2 
[<EntryPoint>]
let main argv =
    let number = System.Convert.ToInt32(System.Console.ReadLine())
    Program.writelist(proc number)
    0