(*
    Project Euler #17

    Number letter counts
    --------------------

    If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
*)

open System

let one_thousand = "onethousand"
let hundred = "hundred"
let hundred_and = "hundredand"
let zero_to_nine = ["" ; "one" ; "two" ; "three" ; "four" ; "five" ; "six" ; "seven" ; "eight" ; "nine"]
let ten_to_nineteen = ["ten" ; "eleven" ; "twelve" ; "thirteen" ; "fourteen" ; "fifteen" ; "sixteen" ; "seventeen" ; "eighteen" ; "nineteen"]
let twenty_to_ninety = [""; ""; "twenty" ; "thirty" ; "forty" ; "fifty" ; "sixty" ; "seventy" ; "eighty" ; "ninety"]

let getLengthOfHundredsAndThousands (x : int) =
     match x with
        | x when x % 100 = 0 -> zero_to_nine.[x / 100] + hundred
        | x when x % 100 <> 0 -> zero_to_nine.[x / 100] + hundred_and + twenty_to_ninety.[(x % 100) / 10] + zero_to_nine.[(x % 100) % 10]
        | _ -> failwith "no condition exist!"

let calculateLetters (x : int) =
    match x with
        | x when x < 10 -> zero_to_nine.[x]
        | x when x < 20 -> ten_to_nineteen.[x % 10]
        | x when x < 100 -> twenty_to_ninety.[x / 10] + zero_to_nine.[x % 10]
        | x when x < 1000 -> getLengthOfHundredsAndThousands x
        | x when x = 1000 -> one_thousand
        | _ -> failwith "Number is big!"

let getLettersInANumber (n : int) =
    String.length (calculateLetters n)

let totalLettersFromOneToN (N : int)=
    [1..N]
    |> List.fold (fun acc x -> acc + getLettersInANumber(x)) 0

printfn "from 1 to 1000 (one thousand) inclusive were written out in words, total letters would be used: %d" (totalLettersFromOneToN 1000)