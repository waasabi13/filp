// Learn more about F# at http://fsharp.org
open System
let proc a b max=
    if (max>=b || max <=a) then false 
    else true
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = Program.readlist n
    let max1=Program.find_max list
    let max1_v=snd max1
    Console.WriteLine(proc 1 10 max1_v)
    0 // return an integer exit code
