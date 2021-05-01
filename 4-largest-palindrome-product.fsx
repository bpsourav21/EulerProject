(*
    Project Euler #4

    Largest palindrome product
    --------------------

    A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    Find the largest palindrome made from the product of two 3-digit numbers.
*)
open System.Diagnostics

let reverse (num: int) : int =
    let rec loop (x: int) (y: int) : int =
        if x <> 0 then
            let current = (y * 10) + (x % 10)
            loop (x / 10) current
        else y

    loop num 0

let isPalindrome (num: int) : bool =
    num = (reverse num)

let stopWatch = new Stopwatch();
stopWatch.Start()

let result: int =
    let lowerBound         = 100
    let higherBound        = 999
    let firstSixDigitValue = 100000

    let generatedSeq: seq<int> = seq {lowerBound .. higherBound}

    generatedSeq
    |> Seq.collect
        (fun x ->
            generatedSeq
            |> Seq.map (fun y -> x * y)
        )
    |> Seq.filter (fun i -> i > firstSixDigitValue && isPalindrome i)
    |> Seq.max

stopWatch.Stop()

printfn "Largest palindrome from the product of two 3-digit numbers: %d" result
printfn "Run time: %A" stopWatch.Elapsed

// Answer   = 906609
// Run time = 00:00:00.0281086 < 00:00:00.4949473 (for converting to string)