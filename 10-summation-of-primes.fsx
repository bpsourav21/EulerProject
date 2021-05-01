(*
    Project Euler #10

    Summation of primes
    --------------------

    The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17. 
    Find the sum of all the primes below two million.
*)

open System


let isPrimeNum ( checkNum : int64 ) =
    let rec check ( i : int64 ) =
         checkNum > 1L && ( double i > sqrt ( double checkNum ) || ( checkNum % i <> 0L && check ( i + 1L ) ) )
    check 2L

let sumOfAllPrimeNumbersBelow ( num : int64 ) = 
   [2L.. num]
   |> List.filter isPrimeNum
   |> List.sum

Console.WriteLine( "Enter N :" )
let input =
    Console.ReadLine()
    |> Convert.ToInt64
printfn "Sum of all the primes below %d is: %d" input ( sumOfAllPrimeNumbersBelow input )