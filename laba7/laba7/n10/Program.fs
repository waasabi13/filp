// Learn more about F# at http://fsharp.org

open System
let metod1 arrStr =
    let rec foundAvgOfKode (str:string) ind (acc:int)=
        if (ind = str.Length) then Convert.ToDouble(acc)/Convert.ToDouble(str.Length)
        else
            let nacc = acc + Convert.ToInt32(str.[ind])
            foundAvgOfKode str (ind+1) nacc

    Array.sortBy 
        (fun (str:string) -> 
            foundAvgOfKode str 0 0) 
        arrStr

let metod2 arrStr =
    let rateInAlp = [|
                        8.17
                        ;8.17
                        ;1.49
                        ;2.78
                        ;4.25
                        ;12.70
                        ;2.23
                        ;2.02
                        ;6.09
                        ;6.97
                        ;0.15
                        ;0.77
                        ;4.03
                        ;2.41
                        ;6.75
                        ;7.51
                        ;1.93
                        ;0.10
                        ;5.99
                        ;6.33
                        ;9.06
                        ;2.76
                        ;0.98
                        ;2.36
                        ;0.15
                        ;1.97
                        ;0.07
                    |]
    let getKvadrOtkl str =
        let rec getMostRatedChar (str:string) ind (count:int) (letter:char)=
            if (ind = str.Length) then letter
            else
                let countOfThisLetter = (String.filter (fun c -> c = str.[ind]) str).Length
                if (countOfThisLetter > count) then getMostRatedChar str (ind+1) countOfThisLetter str.[ind]
                else getMostRatedChar str (ind+1) count letter
        
        let mostRatedLetter = getMostRatedChar str 0 0 ' '
        let rateOfMostRatedLetter = 
            (((String.filter (fun c -> c = mostRatedLetter) str).Length |> Convert.ToDouble) 
                / ( str.Length |> Convert.ToDouble))
            * 100.0

        let rateInAlpOfMostRatedLetter = 
            if (Char.IsLower mostRatedLetter) 
            then rateInAlp.[(Convert.ToInt32(mostRatedLetter) - 97)]
            else rateInAlp.[(Convert.ToInt32(mostRatedLetter) - 65)]

        (rateInAlpOfMostRatedLetter-rateOfMostRatedLetter)*(rateInAlpOfMostRatedLetter-rateOfMostRatedLetter)


    let OtklArr = Array.map (fun str -> getKvadrOtkl str) arrStr
    Array.sort arrStr

let writeArray arr = 
    let rec realWriteArray (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            let nextind = ind+1
            System.Console.WriteLine( arr.[ind] )
            realWriteArray arr nextind
    realWriteArray arr 0

let multimetod n str =
    match n with
    1 -> writeArray (metod1 str)
    | _ -> writeArray (metod2 str)

[<EntryPoint>]
let main argv =
    System.Console.WriteLine( "Введите количество строк: " )
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine( "Введите строки: " )
    let arrOfStr = [| for i in 1..num -> System.Convert.ToString(System.Console.ReadLine()) |]
    System.Console.WriteLine( "Введите номер задачи: " )
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    multimetod n arrOfStr
    0
