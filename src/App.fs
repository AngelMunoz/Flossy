[<RequireQualifiedAccess>]
module App

open Lit
open Types

let private init (config: LitConfig<_>) = ()

[<LitElement("root-app")>]
let private app () =
    LitElement.init init |> ignore

    let layout, setLayout = Hook.useState DesktopLayout.Default

    html
        $"""
        <flo-desktop .layout={layout}>
            <flo-wallpaper></flo-wallpaper>
            <flo-taskbar slot="taskbar" .layout={layout}></flo-taskbar>
            <flo-notification-hub slot="notifications"></flo-notification-hub>
        </flo-desktop>
        """

let register () = ()
