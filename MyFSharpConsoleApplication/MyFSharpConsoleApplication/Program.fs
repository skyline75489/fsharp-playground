// 在 http://fsharp.org 上了解有关 F# 的详细信息
// 请参阅“F# 教程”项目以获取更多帮助。

open System

module MyModule = 
    open System.Net
    
    let number = 1

    let private number2 = 5

    type Temp = 
        | DegreesC of float
        | DegreesF of float
    
    type Person = 
        { First:string; Last: string}

    type Employee = 
        | Worker of Person
        | Manager of Employee list

    let rec quicksort = function
        | [] -> []
        | first::rest ->
            let smaller, larger = List.partition((>=) first) rest
            List.concat [quicksort smaller; [first]; quicksort larger]

    let fetchUrl callback url = 
        let req = WebRequest.Create(Uri(url))
        use resp = req.GetResponse()
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        callback reader url

open MyModule

[<EntryPoint>]
let main argv = 

    let square x = x * x

    let sumOfSquareTo100 = 
        [1..100] |> List.map square |> List.sum


    let matched input = 
        match input with
        | Some i -> printf("11")
        | None -> printf("123")

    let x = true
    let y = not x

    let t = MyModule.DegreesC 85.5

    let sumOfSqureasF n = 
        [1..n]
        |> List.map square
        |> List.sum

    sumOfSqureasF 15
    |> printfn "%d"

    printfn "%A" (MyModule.quicksort [1;5;23;9;7;3;88;16])

    let myCallback (reader:IO.StreamReader) url =
        let html = reader.ReadToEnd()
        let html1000 = html.Substring(0, 10000)
        let ignore = printfn "Downloaded %s, First 1000 is %s" url html1000
        html
    
    let baidu = fetchUrl myCallback "http://www.baidu.com"

    let r = Console.Read()

    0 // 返回整数退出代码
