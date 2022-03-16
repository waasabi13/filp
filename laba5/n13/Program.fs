open System
let rec pr_down x=
    if x=0 then
        1
    else (x%10)*pr_down(x/10)
let rec pr_up x=
    let rec pr_up x pr=
        if x = 0 then pr
        else
            let newpr= pr*(x%10)
            let x1 = x/10
            pr_up x1 newpr
    pr_up x 1
[<EntryPoint>]
let main argv =
    Console.WriteLine("Произведение чисел числа x: ")
    let x = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(pr_down x)
    Console.WriteLine(pr_up x)
    0 // return an integer exit code
