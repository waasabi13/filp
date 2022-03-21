open System
let procession list a b=
    let rec pr1 list a b count=
        match list with
        | h::t-> 
            if (h>a && h<b) then pr1 t a b count+1
            else pr1 t a b count
        | []-> count
    pr1 list a b 0
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = Program.readlist n
    Console.WriteLine(procession list 1 10)
    0 // return an integer exit code
