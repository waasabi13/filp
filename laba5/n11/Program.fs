open System

let language = function
    | "f#" | "prolog" -> "Пoдлизa!"
    | "pascal" -> "Мое почтение, господин"
    | _ -> "Отличный выбор!"

[<EntryPoint>]
let main argv =
    Console.WriteLine("Какoй твoй любимый язык?")
    let s= Console.ReadLine().ToLower()
    Console.WriteLine(language s)
    0