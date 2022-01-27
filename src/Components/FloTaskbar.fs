[<RequireQualifiedAccess>]
module Components.FloTaskbar

open Lit
open Types

let private init (config: LitConfig<_>) =
    config.props <-
        {| layout = Prop.Of(DesktopLayout.Default, "layout")
           apps = Prop.Of(Array.empty<App>, "apps") |}

    config.styles <- [ Styles.floTaskbar ]

let private getApps (apps: App []) =
    let unpinned = ResizeArray()
    let pinned = ResizeArray()

    for app in apps do
        if app.pinned then
            unpinned.Add(app)
        else
            pinned.Add(app)

    pinned, unpinned

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

/// A taskbar like component
/// Emits at least the following events:
/// - on-taskbar-app-click
///     Emitted any time an app in the taskbar is clicked
/// - on-open-start
///     Emitted any time the start button is pressed
[<LitElement("flo-taskbar")>]
let private floTaskbar () =
    let host, props = LitElement.init init
    let appTpl = appTpl host

    let classes =
        [ match props.layout.Value with
          | DesktopLayout.MacOsish -> "osx"
          | DesktopLayout.Winish
          | DesktopLayout.Default -> "win" ]

    let onStartClick _ = host.dispatchEvent "on-open-start"


    let pinned, unpinned = getApps props.apps.Value

    html
        $"""
        <nav classes={Lit.classes classes}>
            <menu>
                <sl-button type="primary" @click={onStartClick} >Start</sl-button>
            </menu>
            <ul>
                {appTpl pinned}
            </ul>
            <ul>
                {appTpl unpinned}
            </ul>
            <section>
                <slot name="tray-area"></slot>
            </section>
        </nav>
        """

let register () = ()
