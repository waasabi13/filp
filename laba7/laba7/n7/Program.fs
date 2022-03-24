open System
let result list=
    (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list) , List.map (fun x->x/3) (List.filter (fun x->x%3=0) list),
        List.map (fun x-> x*x )(List.map (fun x->x/3) (List.filter (fun x->x%3=0) list)), 
            List.filter (fun x-> List.contains(x) (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list))) (List.map (fun x-> x*x )(List.map (fun x->x/3) (List.filter (fun x->x%3=0) list))),
                List.map (fun x->x/3) (List.filter (fun x->x%3=0) list) @ List.map (fun x-> x*x )(List.map (fun x->x/3) (List.filter (fun x->x%3=0) list)) @ List.filter (fun x-> List.contains(x) (List.map (fun x->x/2) (List.filter (fun x->x%2=0) list))) (List.map (fun x-> x*x )(List.map (fun x->x/3) (List.filter (fun x->x%3=0) list))))
let unpack5 tuple idx =
    match idx, tuple with
    | 0, (a,_,_,_,_) -> a
    | 1, (_,b,_,_,_) -> b
    | 2, (_,_,c,_,_) -> c
    | 3, (_,_,_,d,_) -> d
    | 4, (_,_,_,_,e) -> e
    | _, _ -> failwith (sprintf "Несуществующий индекс %i" idx) 
let writetuple5 tuple= 
    let rec wtr tuple index=
        if index<5 then 
            Console.WriteLine("Список номер {0}:",index)
            Program.writelist(unpack5 tuple index)
            let new_index=index+1
            wtr tuple new_index
    wtr tuple 0
[<EntryPoint>]
let main argv =
    let list= Program.readlist 6
    let r=result list
    writetuple5 r
    0
