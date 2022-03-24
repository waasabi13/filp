open System
let method1()=
    Console.WriteLine("Введите строку: ")
    let str= Console.ReadLine()
    let lower_str=String.filter(fun ch->Char.IsLower(ch)) str
    let srt_list=Seq.toList(lower_str)
    let result=List.map2(fun ch1 ch2-> ch1<=ch2) srt_list.[0..srt_list.Length-2] srt_list.[1..srt_list.Length-1] 
    if (List.fold (fun s x-> if x=false then s+1 else s) 0 result) = 0 then Console.WriteLine("Все хорошо")
    else Console.WriteLine("Все плохо")
let choose n=
    match n with
    |"1"-> method1()

[<EntryPoint>]
let main argv =
    Console.WriteLine("Выберите одну из трех предложенных программ:
    1.Проверить, упорядочены ли строчные символы этой строки по возрастанию
    2.Дана строка. Необходимо подсчитать количество букв А в строке.
    3.Дана строка в которой записан путь к файлу. Необходимо найти
    имя файла без расширения.")
    let n=Console.ReadLine()|>choose
    0 // return an integer exit code
