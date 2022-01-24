[<RequireQualifiedAccess>]
module Components.FloTaskbar

open Lit
open Types

let private init (config: LitConfig<_>) =
    config.props <-
        {| layout = Prop.Of(DesktopLayout.Default, "layout")
           apps = Prop.Of([], "pinned-apps") |}

    config.styles <- [ Styles.floTaskbar ]

[<LitElement("flo-taskbar")>]
let private app () =
    let _, props = LitElement.init init

    let classes =
        [ match props.layout.Value with
          | DesktopLayout.MacOsish -> "osx"
          | DesktopLayout.Winish
          | DesktopLayout.Default -> "win" ]

    let appTpl =
        let tpl app =
            html
                $"""
                <li>
                    <div>{app.icon}</div>
                    <div>{app.title}</div>
                </li>
            """

        Lit.mapUnique (fun app -> app.id.ToString()) tpl

    let pinned =
        props.apps.Value
        |> List.filter (fun app -> app.pinned)

    let notPinned =
        props.apps.Value
        |> List.filter (fun app -> app.pinned |> not)

    html
        $"""
        <nav classes={Lit.classes classes}>
            <sl-button type="primary">Start</sl-button>
            <ul>
                {appTpl pinned}
            </ul>
            <ul>
                {appTpl notPinned}
            </ul>
        </nav>
        """

let register () = ()
