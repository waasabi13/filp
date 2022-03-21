open System
let find_max list =
    let rec find_max_r list current_max max_idx current_idx =
        match list with
        | [] -> (max_idx, current_max)
        | h::t ->
            let new_max = if h > current_max then h else current_max
            let new_max_idx = if h > current_max then current_idx else max_idx
            let new_idx = current_idx + 1
            find_max_r t new_max new_max_idx new_idx
    find_max_r list list.Head 0 0
let find_min list =
    let rec find_min_r list current_min min_idx current_idx =
        match list with
        | [] -> (min_idx, current_min)
        | h::t ->
            let new_min = if h < current_min then h else current_min
            let new_min_idx = if h < current_min then current_idx else min_idx
            let new_idx = current_idx + 1
            find_min_r t new_min new_min_idx new_idx
    find_min_r list list.[0] 0 0
let reverse list=
    let rec rev1 list new_list=
        match list with
        |[]->new_list
        |h::t->
            let newnew_list=[h] @ new_list
            rev1 t newnew_list
    rev1 list []
[<EntryPoint>]
let main argv =
   let n = Console.ReadLine()|> Int32.Parse
   let list = Program.readlist n
   Console.WriteLine()
   let max=fst (find_max list)
   let min= fst (find_min list)
   let start=Math.Min(max,min)
   let endpoint=Math.Max(min,max)
   let piece=list.[start+1..endpoint-1]
   let result= list.[0..start]@ (reverse piece) @ list.[endpoint..n-1]
   Program.writelist(result)
   0 // return an integer exit code
