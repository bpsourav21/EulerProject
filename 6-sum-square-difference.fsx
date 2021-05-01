(*
    Project Euler #6

    Sum square difference
    --------------------
    
    The sum of the squares of the first ten natural numbers is,
    1^2 + 2^2 + ... + 10^2 = 385
    The square of the sum of the first ten natural numbers is,
    (1 + 2 + ... + 10)^2 = 55^2 = 3025
    Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640
    Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
*)

open System

let squareValue ( x : int ) = x * x

let sumOfSquares ( n : int ) =
    [1..n]
    |> List.map squareValue
    |> List.sum

let squaresOfSum ( n : int ) =
    [1..n]
    |> List.sum
    |> squareValue

let differenceBetweenTwoSums ( n : int ) =
    squaresOfSum n - sumOfSquares n    

Console.WriteLine( "Enter N :" )
let input =
    Console.ReadLine()
    |> Convert.ToInt32

printfn "Difference between the sum of the squares of the first %d natural numbers and the square of the sum is %d" input ( differenceBetweenTwoSums input )