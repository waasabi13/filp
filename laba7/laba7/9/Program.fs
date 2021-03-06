open System
let method1 str=
    let lower_str=String.filter(fun ch->Char.IsLower(ch)) str
    let srt_list=Seq.toList(lower_str)
    let result=List.map2(fun ch1 ch2-> ch1<=ch2) srt_list.[0..srt_list.Length-2] srt_list.[1..srt_list.Length-1] 
    if (List.fold (fun s x-> if x=false then s+1 else s) 0 result) = 0 then Console.WriteLine("Все хорошо")
    else Console.WriteLine("Все плохо")
let method2 str=
    let a_str=String.filter(fun ch->ch='A') str
    Console.WriteLine(a_str.Length)
let method3 str=
    let rec m1 (str: string) iter ind =
        if (ind = -1) then str
        else
            if (int(str.[ind]) = iter) then str.[(ind+1)..]
            else m1 str iter (ind-1)
    let rec m2 (str: string) iter ind =
        if (ind = str.Length) then str
        else
            if (int(str.[ind]) = iter) then str.[..(ind-1)]
            else m2 str iter (ind+1)
    let justFile = m1 str (int('\\')) (str.Length-1)
    let file=m2 justFile (int('.')) 0
    Console.WriteLine(file)
let choose n=
    Console.WriteLine("Введите строку: ")
    let str= Console.ReadLine()
    match n with
    |"1"-> method1 str
    |"2"-> method2 str
    |"3"->method3 str
[<EntryPoint>]
let main argv =
    Console.WriteLine("Выберите одну из трех предложенных программ:
    1.Проверить, упорядочены ли строчные символы этой строки по возрастанию
    2.Дана строка. Необходимо подсчитать количество букв А в строке.
    3.Дана строка в которой записан путь к файлу. Необходимо найти
    имя файла без расширения.")
    let n=Console.ReadLine()|>choose
    0 // return an integer exit code