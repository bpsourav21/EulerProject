(*
	Project Euler #2

	Even Fibonacci numbers
	--------------------

	Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
	1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
	By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
*)

open System

let generateFibonacciSeq (targetValue: int) : seq<int> =
    let rec fibonacci (a: int) (b: int) =
        seq {
            if a < targetValue then
                yield a
                yield! fibonacci b (a + b)
        }
    fibonacci 1 2

Console.WriteLine("Enter N:")
let input =
    System.Console.ReadLine()
    |> System.Convert.ToInt32

let result : int =
    input
    |> generateFibonacciSeq
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.sum

printfn "sum of the even-valued terms in the Fibonacci sequence whose values do not exceed %d is %d" input result
//Answer = 4613732