module Table

let private bingoRows () =

    let numbers =
        Util.generateNumbers (15)
        |> Array.map (fun x -> x.ToString())
        |> Array.splitInto 3

    numbers
    |> Array.map (fun numbersRow ->
        Array.append numbersRow (Array.init 4 (fun _ -> ""))
        |> Util.shuffle
        |> Array.fold (fun state curr -> state + "<td>" + curr + "</td>") "")
    |> Array.fold (fun rows curr -> rows + "<tr>" + curr + "</tr>") ""



let bingoTable () =

    "<table>" + bingoRows () + "</table>"
