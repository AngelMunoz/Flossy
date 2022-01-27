[<RequireQualifiedAccess>]
module Components.FloStart

open Lit

[<LitElement("flo-start")>]
let private app () =
    LitElement.init () |> ignore<LitElement>

    html
        $"""
        <section>
            <nav>Config and other stuff</nav>
            <section>
                <slot>apps</slot>
            </section>
        </section>
        """

let register () = ()
