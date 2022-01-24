[<RequireQualifiedAccess>]
module Components.FloNotificationHub


open Lit

[<LitElement("flo-notification-hub")>]
let private app () =
    LitElement.init () |> ignore<LitElement>

    html
        $"""
        <aside>
            Notifications
        </aside>
        """

let register () = ()
