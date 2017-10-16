// 在 http://fsharp.org 上了解有关 F# 的详细信息
// 请参阅“F# 教程”项目以获取更多帮助。

open System

module MyModule = 
    
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

    let r = Console.Read()

    0 // 返回整数退出代码
