(*
    Project Euler #16

    Power digit sum
    --------------------

    2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
 
    What is the sum of the digits of the number 2^1000?
*)

open System

let getPowerDigitSum (num : bigint) =
    let rec getPowerDigit (digit : bigint , sum : bigint) =
        if (digit / bigint 10 > bigint 0) then
            getPowerDigit ((digit / bigint 10) , (sum + (digit % bigint 10)))
        else (sum + digit)
    getPowerDigit (num , bigint 0)

let digitNumber : bigint = 
    pown (bigint 2) 1000

printfn "Sum of the digits of the number 2^1000 is: %A" (getPowerDigitSum digitNumber)