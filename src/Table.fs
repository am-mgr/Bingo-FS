module Table

let tableRows () =

    let numbers =
        Util.generateNumbers (15)
        |> Seq.map (fun x -> x.ToString())
        |> Seq.splitInto 3

    numbers
    |> Array.ofSeq
    |> Array.map (fun numbersRow ->
        Array.append numbersRow (Array.init 4 (fun _ -> ""))
        |> Util.shuffle
        |> Array.fold (fun state curr -> state + "<td>" + curr + "</td>") "")
    |> Array.fold (fun rows curr -> rows + "<tr>" + curr + "</tr>") ""



let table () =

    "<table>" + tableRows () + "</table>"
