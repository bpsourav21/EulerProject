(*
    Project Euler #7

    10001st prime
    --------------------

    By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13. 
    What is the 10 001st prime number?
*)

open System

let isPrimeNum ( checkNum : int64 ) =
    let rec check ( i : int64 ) =
         checkNum > 1L && ( double i > sqrt ( double checkNum ) || ( checkNum % i <> 0L && check ( i + 1L ) ) )
    check 2L


let getNthPrimeNumber ( num : int ) = 
    Seq.initInfinite ( fun x -> int64 x )
    |> Seq.filter isPrimeNum
    |> Seq.take num
    |> Seq.max

Console.WriteLine( "Enter N :" )
let input =
    Console.ReadLine()
    |> Convert.ToInt32
printfn "the %dst prime number is %A" input ( getNthPrimeNumber input )