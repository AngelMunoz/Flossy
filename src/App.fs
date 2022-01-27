[<RequireQualifiedAccess>]
module App

open Lit
open Types

let private init (config: LitConfig<_>) = ()

let private appTpl (host: LitElement) =
    let tpl app =
        let onAppClick _ =
            host.dispatchCustomEvent ("on-taskbar-app-click", app)

        html
            $"""
            <li @click={onAppClick}>
                <div>{app.icon}</div>
                <div>{app.title}</div>
            </li>
        """

    Lit.mapUnique (fun app -> app.id.ToString()) tpl

[<LitElement("root-app")>]
let private app () =
    let host = LitElement.init ()
    let appsTpl = appTpl host

    let appState, setAppState =
        Hook.useState
            { isStartOpen = false
              apps = Array.empty<App>
              layout = DesktopLayout.Default }

    html
        $"""
        <flo-desktop
            .layout={appState.layout}
            @on-taskbar-app-click={fun _ -> printfn "App Clicked"}
            @on-open-start={fun _ -> printfn "Start Clicked"}>
            <flo-start .is-open={appState.isStartOpen}>
                {appsTpl appState.apps}
            </flo-start>
            <flo-wallpaper></flo-wallpaper>
            <flo-taskbar
                slot="taskbar"
                .layout={appState.layout}
                .apps={appState.apps}>
                <div slot="tray-area">tray</div>
            </flo-taskbar>
            <flo-notification-hub slot="notifications"></flo-notification-hub>
        </flo-desktop>
        """

let register () = ()
