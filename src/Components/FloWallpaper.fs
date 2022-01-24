[<RequireQualifiedAccess>]
module Components.FloWallpaper

open Lit

[<LitElement("flo-wallpaper")>]
let private app () =
    LitElement.init () |> ignore<LitElement>

    html
        $"""
        <section>Wallpaper</section>
        """

let register () = ()
