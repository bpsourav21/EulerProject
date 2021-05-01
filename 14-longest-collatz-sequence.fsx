(*
    Project Euler #14

    Longest Collatz sequence
    --------------------

    The following iterative sequence is defined for the set of positive integers: 
    n -> n/2 (n is even)
    n -> 3n + 1 (n is odd)   
    Using the rule above and starting with 13, we generate the following sequence:
    13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1
    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    Which starting number, under one million, produces the longest chain? 
    NOTE: Once the chain starts the terms are allowed to go above one million.
*)

open System

let collatzLogic x = 
    if x % 2 = 0 then
        x / 2
    else
        3 * x + 1

let getSequenceForValue (number : int) = 
    let rec collatzSequence x count = 
        if x = 1 then Some(count)
        else collatzSequence (collatzLogic x) (count + 1)

    if number <= 0 then None
    else collatzSequence number 0

let longestCollatzSequence (N : int) =
    [for i in 1 .. (N - 1) do
        yield (i , (getSequenceForValue i))
    ]
    |> Seq.maxBy snd
    |> fun (x , y) -> x

Console.WriteLine("Enter N : ")
let input =
    Console.ReadLine()
    |> Convert.ToInt32

printfn "Starting number under %d, which produces the longest chain is %d" input (longestCollatzSequence input)