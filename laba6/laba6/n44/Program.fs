﻿//1.44
//Дан массив чисел. Необходимо проверить, чередуются ли в нем
//целые и вещественные числа.
open System
let rec readlist1 n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToDouble
    let Tail = readlist1 (n-1)
    Head::Tail

let check list check=
    let rec c1 list b check=
        match list with
        | a::b::t-> 
            if ((a%1.0=0.0 && b%1.0=0.0) ||(a%1.0<>0.0 && b%1.0<>0.0)) then false
            else c1 t b check
        | a::t->
            if ((a%1.0=0.0 && b%1.0=0.0) ||(a%1.0<>0.0 && b%1.0<>0.0)) then false
            else true
        | []-> check
    c1 list 0.0 true
[<EntryPoint>]
let main argv =
   let n = Console.ReadLine()|> Int32.Parse
   let list = readlist1 n
   Console.WriteLine(check list true)
   0 // return an integer exit code
