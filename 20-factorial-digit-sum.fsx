(*
    Project Euler #20

    Factorial digit sum
    --------------------

    n! means n * (n - 1) * ... * 3 * 2 * 1   
    For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    Find the sum of the digits in the number 100!
*)

open System

let getFactorialDigitSum (num : bigint) =
    let rec getFactorialDigit (digit : bigint , sum : bigint) =
        if (digit / bigint 10 > bigint 0) then
            getFactorialDigit ((digit / bigint 10) , (sum + (digit % bigint 10)))
        else (sum + digit)
    getFactorialDigit (num , bigint 0)

let rec getFactoriaValue (n : bigint) =
    if n = bigint 0 then bigint 1 
    else n * getFactoriaValue (n - bigint 1)

let getNumberFactorialDigitSum (num : bigint) =
    getFactorialDigitSum (getFactoriaValue num)

Console.WriteLine( "Enter N :" )
let input =
    Console.ReadLine()
    |> Convert.ToInt32
    |> bigint

printfn "Sum of the digits in the number %A! is %A" input (getNumberFactorialDigitSum input)