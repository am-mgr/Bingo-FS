module App

open Browser.Dom



let myButton =
    document.querySelector (".my-button") :?> Browser.Types.HTMLButtonElement


// Get a reference to our button and cast the Element to an HTMLButtonElement
let numbersField =
    document.querySelector (".numbers") :?> Browser.Types.HTMLParagraphElement

// Register our listener
myButton.onclick <-
    fun _ ->
        numbersField.innerHTML <-
            [ 0 .. 24 ]
            |> List.map (fun _ -> Table.bingoTable ())
            |> List.fold (fun tables table -> tables + table + "<br/>") ""
