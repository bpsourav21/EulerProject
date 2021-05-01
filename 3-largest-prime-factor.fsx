(*
    Project Euler #3

    Largest prime factor
    --------------------

    The prime factors of 13195 are 5, 7, 13 and 29.
    What is the largest prime factor of the number 600851475143?
*)

open System.Diagnostics

let isPrime (n: uint64) : bool =
    if (n > 1uL) then
        let sqrRootN: uint64 =  uint64 (sqrt (double n))

        let rec loop (i: uint64) : bool =
            if (i > sqrRootN) then
                true
            elif (n % i <> 0uL) then
                loop (i + 1uL)
            else
                false
        loop 2uL
    else
        false

let input: uint64 = 600851475143uL

let squareRootInput: uint64 = uint64 (sqrt (double input))

let stopWatch = new Stopwatch();
stopWatch.Start()

let result: uint64 =
    seq {1uL .. squareRootInput}
    |> Seq.filter (fun i -> (input % i = 0uL) && isPrime i)
    |> Seq.max

stopWatch.Stop()

printfn "Largest prime factor of the number %A is %A" input result
printfn "Run time: %A" stopWatch.Elapsed

// Answer   = 6857
// Run time = 00:00:00.0113238