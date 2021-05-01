(*
    Project Euler #5

    Smallest multiple
    --------------------

    2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
*)

(*
//Solution 1

let rec calculateGreatestCommonDivisor (a: uint64) (b: uint64) : uint64 =
    if a = 0uL || b = 0uL then
        0uL
    elif a = b then
        a
    elif a > b then
        calculateGreatestCommonDivisor (a - b) b
    else
        calculateGreatestCommonDivisor a (b - a)

let calculateLeastCommonMultiple (x: uint64) (y: uint64) : uint64 =
    let product = x * y
    let gcd     = calculateGreatestCommonDivisor x y

    product / gcd

let stopWatch = System.Diagnostics.Stopwatch()
stopWatch.Start()

let result: uint64 =
    seq {1uL .. 20uL}
    |> Seq.reduce calculateLeastCommonMultiple

stopWatch.Stop()

printfn "Smallest positive number that is evenly divisible from 1 to 20 is: %d" result
printfn "Run Time: %A" stopWatch.Elapsed

// Answer   = 232792560
// Run time = 00:00:00.0211384
*)

//Solution 2

let isPrime (n: uint32) : bool =
    if n > 1ul then
        let sqrRootN: uint32 = uint32 (sqrt (double n))

        let rec loop (i: uint32) : bool =
            if i > sqrRootN then
                true
            elif n % i <> 0ul then
                loop (i + 1ul)
            else
                false

        loop 2ul
    else
        false

let calculatePrimeFactorsAndCounts (num: uint32) : Map<uint32, uint32> =
    let rec ifPrimeNOrNextPrime (n: uint32) : uint32 =
        if isPrime n then
            n
        else
            ifPrimeNOrNextPrime (n + 1ul)

    let rec loop (currVal: uint32) (currPrime: uint32) (count: uint32) (acc: Map<uint32, uint32>) : Map<uint32, uint32> =
        if (currVal % currPrime = 0ul) then
            loop (currVal / currPrime) currPrime (count + 1ul) acc
        else
            let nextAcc = acc.Add(currPrime, count)

            if currVal > 1ul then
                let next = ifPrimeNOrNextPrime (currPrime + 1ul)
                loop currVal next 0ul nextAcc
            else
                nextAcc

    loop num 2ul 0ul Map.empty

let extractPrimeFactors (numbers: seq<uint32>) : seq<Map<uint32, uint32>> =
    numbers
    |> Seq.filter (fun x -> x > 1ul)
    |> Seq.map
        (fun i ->
            match i with
            | i when isPrime i -> Map.empty.Add (i, 1ul)
            | _ -> calculatePrimeFactorsAndCounts i
        )

let mergeMaps (keyConflictResolver: ('U -> 'U -> 'U)) (maps: seq<Map<'T, 'U>>) : Map<'T, 'U> =
    maps
    |> Seq.collect (Seq.map (|KeyValue|))
    |> Seq.fold
        (fun innerMap (k, v) ->
            if innerMap.ContainsKey k then
                let resolvedValue = keyConflictResolver (innerMap.Item k) v
                innerMap
                |> Map.add k resolvedValue
            else
                innerMap
                |> Map.add k v
        ) Map.empty<'T, 'U>

let calculatePowerAndMultiply (numberToPower: Map<uint32, uint32>) : uint32 =
    numberToPower
    |> Seq.fold
        (fun acc x ->
            let power = pown x.Key (int x.Value)
            acc * power
        ) 1ul

let stopWatch = System.Diagnostics.Stopwatch()
stopWatch.Start()

let result: uint32 =
    seq {1ul .. 20ul}
    |> extractPrimeFactors
    |> mergeMaps (fun x y -> System.Math.Max (x, y))
    |> calculatePowerAndMultiply

stopWatch.Stop()

printfn "Smallest positive number that is evenly divisible from 1 to 20 is: %d" result
printfn "Run Time: %A" stopWatch.Elapsed

// Answer   = 232792560
// Run time = 00:00:00.0032363