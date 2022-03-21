// Learn more about F# at http://fsharp.org

open System
let find_min list =
    let rec find_min_r list current_min min_idx current_idx =
        match list with
        | [] -> (min_idx, current_min)
        | h::t ->
            let new_min = if h < current_min then h else current_min
            let new_min_idx = if h < current_min then current_idx else min_idx
            let new_idx = current_idx + 1
            find_min_r t new_min new_min_idx new_idx
    find_min_r list list.Head 0 0
let find_min2 list min2=
    let rec find_min_r list min2 current_min min_idx current_idx =
        match list with
        | [] -> (min_idx, current_min)
        | h::t ->
            let new_min = if (h < current_min && h<>min2) then h else current_min
            let new_min_idx = if (h < current_min && h<>min2) then current_idx else min_idx
            let new_idx = current_idx + 1
            find_min_r t min2 new_min new_min_idx new_idx
    find_min_r list min2 list.Head 0 0
let length list=
    let rec l1 list count=
        match list with
        | h::t-> l1 t count+1
        | []-> count
    l1 list 0
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = Program.readlist n
    let min1=find_min list
    let min1_v=snd min1
    let min1_i=fst min1
    let min2=find_min2 list min1_v
    let min2_v=snd min2
    let min2_i=fst min2
    Console.WriteLine("Первый минимум:{0} ",min1)
    Console.WriteLine("Второй минимум:{0} ",min2)
    let start=Math.Min(min1_i,min2_i)
    let endpoint=Math.Max(min1_i,min2_i)
    Console.WriteLine("Result: ")
    let result=list.[start+1..endpoint-1]
    Program.writelist(result)
    Console.WriteLine(length result)
    0 // return an integer exit code
