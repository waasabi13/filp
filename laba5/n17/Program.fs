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

let dividers x func init =
    let rec process_divs_internal x func init current_divider =
        if current_divider = 0 then init
        else
            let new_init = if x % current_divider = 0 then func init current_divider else init
            let new_divider = current_divider - 1
            process_divs_internal x func new_init new_divider
    process_divs_internal x func init x

let primes x func init =
    let rec primes_internal x func init candidate =
        if candidate <= 0 then
            init
        else
            let new_init = if nod x candidate = 1 then func init candidate else init
            let new_cand = candidate - 1
            primes_internal x func new_init new_cand
    primes_internal x func init x

let div_pred x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    dividers x func1 init

let primes_pred x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    primes x func1 init

[<EntryPoint>]
let main argv =
    0