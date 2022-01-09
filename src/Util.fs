module Util

open System

let private getRandom () =
    Random(DateTime.Now.Ticks.GetHashCode())

let rec generateNumbers (count: int) =
    let rnd = getRandom ()

    let numbers =
        seq {
            for _ in 1 .. count do
                yield rnd.Next(1, 100)
        }

    if Seq.distinct numbers |> Seq.length < count then
        generateNumbers count
    else
        numbers

let private swap x y (arr: 'a []) =
    let tmp = arr.[x]
    arr.[x] <- arr.[y]
    arr.[y] <- tmp


let shuffle arr =
    let rnd = getRandom ()

    arr
    |> Array.iteri (fun i _ -> arr |> swap i (rnd.Next(1, Array.length arr)))

    arr
