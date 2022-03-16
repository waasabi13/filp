open System

[<EntryPoint>]
let main argv =
    let lower (x: String) = x.ToLower()
    let language x =
        match x with
        | "f#" | "prolog" -> "Пoдлизa!"
        | "pascal" -> "Мое почтение, господин"
        | _ -> "Отличный выбор!"
//каррирование
    Console.WriteLine("Какoй твoй любимый язык?")
    (Console.ReadLine >> lower >> language >> Console.WriteLine)()

//суперпозиция
    Console.WriteLine("Какoй твoй любимый язык?")
    let dop input (output:string->unit) chooser = output (chooser (input ()))
    dop Console.ReadLine Console.WriteLine language

    0