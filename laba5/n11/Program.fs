open System

let language n=
    match n with
    | "f#" | "prolog" -> "Пoдлизa!"
    | "pascal" -> "Мое почтение, господин"
    | _ -> "Отличный выбор!"

[<EntryPoint>]
let main argv =
    Console.WriteLine("Какoй твoй любимый язык?")
    let n= Console.ReadLine().ToLower()
    Console.WriteLine(language n)
    0