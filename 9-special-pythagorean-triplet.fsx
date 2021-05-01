(*
    Project Euler #9

    Special Pythagorean triplet
    --------------------

    A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
                a^2 + b^2 = c^2
    For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

    There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    Find the product abc.
*)

open System

let isPythagoreanTriplet a b c =
    let sqrA = pown a 2
    let sqrB = pown b 2
    let sqrC = pown c 2
    sqrA + sqrB = sqrC


let productOfPythagoreanTriplet sum =
    [for a in 1 .. ( sum / 3 ) do
        for b in ( a + 1 ) .. ( sum / 2 ) do
            if ( isPythagoreanTriplet a b ( sum - a - b ) ) then yield ( a * b * ( sum - a - b ) )]
    |> List.max

printfn "Pythagorean triplet for which a + b + c = 1000, its product value abc is: %A" ( productOfPythagoreanTriplet 1000 )