open System

let f n predicate init =
    let rec f_add x func init divider =
        if divider = 0 then init
        else
            let newInit = 
                if x % divider = 0 then 
                    func init divider 
                else init
            let newDivider = divider - 1
            f_add x func newInit newDivider
    f_add n predicate init n
    
[<EntryPoint>]
let main argv =
    System.Console.WriteLine(f 12 (fun x y -> x + y) 0)
    0