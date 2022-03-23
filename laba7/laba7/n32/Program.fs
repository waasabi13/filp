open System
let proc (list:'int list)=List.fold (fun s x->if x then s+1 else s) 0 (List.map3 (fun x y z->(y>x)&&(y>z)) list.[0..list.Length-3] list.[1..list.Length-2] list.[2..list.Length-1]) 
[<EntryPoint>]
let main argv =
    let list= Program.readlist 6
    Console.WriteLine(proc list)
    0 // return an integer exit code