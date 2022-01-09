module Util

open System

let private getRandom () =
    Random(DateTime.Now.Ticks.GetHashCode())

let private getRandomNumber () =
    let rnd = getRandom ()
    rnd.Next(1, 100)

let rec private internalGenerator count currentNumber (numbers: array<int>) =
    if count = 0 then
        numbers
    else if Array.contains currentNumber numbers then
        internalGenerator count (getRandomNumber ()) numbers
    else
        internalGenerator (count - 1) (getRandomNumber ()) (Array.append numbers [| currentNumber |])

let rec generateNumbers (count: int) =
    let rnd = getRandom ()
    internalGenerator count (getRandomNumber ()) [||]

let private swap x y (arr: 'a []) =
    let tmp = arr.[x]
    arr.[x] <- arr.[y]
    arr.[y] <- tmp


let shuffle arr =
    let rnd = getRandom ()

    arr
    |> Array.iteri (fun i _ -> arr |> swap i (rnd.Next(1, Array.length arr)))

    arr
