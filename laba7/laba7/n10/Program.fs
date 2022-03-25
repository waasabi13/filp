// Learn more about F# at http://fsharp.org

open System
let method1 arrStr =
    let rec m1 (str:string) ind (acc:int)=
        if (ind = str.Length) then Convert.ToDouble(acc)/Convert.ToDouble(str.Length)
        else
            let nacc = acc + Convert.ToInt32(str.[ind])
            m1 str (ind+1) nacc
    Array.sortBy 
        (fun (str:string) -> 
            m1 str 0 0) 
        arrStr
let writeArray arr = 
    let rec m2 (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            let nextind = ind+1
            System.Console.WriteLine( arr.[ind] )
            m2 arr nextind
    m2 arr 0
[<EntryPoint>]
let main argv =
    System.Console.WriteLine( "Введите количество строк: " )
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine( "Введите строки: " )
    let arrOfStr = [| for i in 1..num -> System.Convert.ToString(System.Console.ReadLine()) |]
    System.Console.WriteLine( "Введите номер задачи: " )
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    writeArray(method1 arrOfStr)
    0
