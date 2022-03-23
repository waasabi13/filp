open System
let find_min list=List.findIndex(fun x->x=List.min list) list
let find_max list=List.findIndex(fun x->x=List.max list) list
let result_list_reverse_between_index_of_min_and_max_element_special_for_arseniy_sergeevich_juk_from_kirill_titov_gruppa_26_1_fiit_fktipm_kubsu_plz_postavte_5 list= 
    let start=Math.Min(find_max list,find_min list)
    let endpoint=Math.Max(find_min list,find_max list)
    let piece=list.[start+1..endpoint-1]
    list.[0..start]@ (List.rev piece) @ list.[endpoint..list.Length-1]
[<EntryPoint>]
let main argv =
    let list= Program.readlist 7
    Program.writelist(result_list_reverse_between_index_of_min_and_max_element_special_for_arseniy_sergeevich_juk_from_kirill_titov_gruppa_26_1_fiit_fktipm_kubsu_plz_postavte_5 list)
    0 
