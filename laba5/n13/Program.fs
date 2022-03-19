open System
let rec pr_up x=
    if x=0 then
        1
    else (x%10)*pr_up(x/10)
let rec pr_down x=
    let rec pr_down x pr=
        if x = 0 then pr
        else
            let newpr= pr*(x%10)
            let x1 = x/10
            pr_down x1 newpr
    pr_down x 1
let rec max_digitup x=
    if x < 10 then x
    else max (x%10) (max_digitup (x/10))
let max_digitdown x =
    let rec max_digitdown1 x max=
        if x=0 then max
        else
            let curCif = x%10
            let x1 = x/10
            if curCif>max then max_digitdown1 x1 curCif else max_digitdown1 x1 max
    max_digitdown1 x 0
let rec min_digitup x=
    if x < 10 then x
    else min (x%10) (min_digitup (x/10))
let min_digitdown x =
    let rec min_digitdown1 x min=
        if x=0 then min
        else
            let curCif = x%10
            let x1 = x/10
            if curCif<min then min_digitdown1 x1 curCif else min_digitdown1 x1 min
    min_digitdown1 x 9

[<EntryPoint>]
let main argv =
    let x = Convert.ToInt32(Console.ReadLine())
    Console.Write("Произведение чисел числа: ")
    Console.WriteLine(pr_up x)
    //Console.WriteLine(pr_up x)
    Console.Write("Максимальная цифра числа: ")
    Console.WriteLine(max_digitup x)
    Console.Write("Минимальная цифра числа: ")
    Console.WriteLine(min_digitdown x)
    0 // return an integer exit code
