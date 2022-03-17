open System

let nod x y =
    let rec nod1 x y i currentnod= 
        if x+1 = i || y+1 = i then currentnod
        else 
            if x%i <> 0 || y%i <> 0 then nod1 x y (i+1) currentnod
            else 
                let nod = i
                nod1 x y (i+1) nod
    nod1 x y 1 1

let processing x f init = 
    let rec processing1 x f init current = 
        if current = 0 then init
        else
            let newInit = if nod x current = 1 then f init current
                          else init
            let newCurrent = current - 1
            processing1 x f newInit newCurrent
    processing1 x f init x

let euler x = 
    processing x (fun x y-> x + 1) 0


[<EntryPoint>]
let main argv =
    
    Console.WriteLine(processing 10 (fun x y -> x + y) 0)
    Console.WriteLine(euler 10)
    0 