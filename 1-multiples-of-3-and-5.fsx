(*
    Project Euler #1

    Multiples of 3 and 5
    --------------------

    If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    Find the sum of all the multiples of 3 or 5 below 1000.
*)

open System

let multiplesOf3And5BelowN (n: seq<int>) : seq<int> =
    n
    |> Seq.filter (
           fun x ->
               x % 3 = 0 || x % 5 = 0
    )

let sumIntegers (n: seq<int>) : int =
    n 
    |> Seq.sum

let calculateMultiplesOf3And5BelowN (n: int) : int =
    seq {1 .. (n - 1)}
    |> multiplesOf3And5BelowN
    |> sumIntegers

Console.WriteLine("Enter N: ")
let input =
    Console.ReadLine()
    |> Convert.ToInt32

printfn "Sum of Multiples of 3 And 5 Below %d is %d" input (calculateMultiplesOf3And5BelowN input)
// Answer = 233168