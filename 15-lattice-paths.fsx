(*
    Project Euler #15

    Lattice paths
    --------------------

  Starting in the top left corner of a 2X2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
  How many such routes are there through a 20X20 grid?
*)

open System

let rec factorialNumber (num : int) =
    if num = 0 then 1 else num * factorialNumber (num - 1)

let combinationN_K val_N val_K = 
    factorialNumber( val_N ) / ( factorialNumber( val_K ) * factorialNumber( val_N - val_K ) )

let getPresentRoutes m n =
    let totalSteps = m + n
    let possibleWays = m
    combinationN_K totalSteps possibleWays

Console.WriteLine( "Enter number of Row, m =" )
let input_m =
    Console.ReadLine()
    |> Convert.ToInt32

Console.WriteLine( "Enter number of Column, n =" )
let input_n =
    Console.ReadLine()
    |> Convert.ToInt32

printfn "Routes present from top left corner to bottom right corner in a %d X %d grid is: %d" input_m input_n ( getPresentRoutes input_m input_n )