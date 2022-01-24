[<RequireQualifiedAccess>]
module Components.FloDesktop

open Lit
open Types

let private init (config: LitConfig<_>) =

    config.props <-
        {| layout = Prop.Of(DesktopLayout.Default, "layout")
           showNotifications = Prop.Of(false, "show-notifications") |}

    config.styles <- [ Styles.floDesktop ]

[<LitElement("flo-desktop")>]
let private app () =
    let _, props = LitElement.init init

    let showNotifications, setShowNotifications =
        Hook.useState props.showNotifications.Value

    let classes =
        Lit.classes [ match props.layout.Value with
                      | DesktopLayout.MacOsish -> "osx"
                      | DesktopLayout.Default
                      | DesktopLayout.Winish -> "win" ]

    html
        $"""
        <article class={classes}>
            <section>
                <slot></slot>
            </section>
            <aside class={if showNotifications then "show" else ""}>
                <slot name="notifications">Notifications</slot>
            </aside>
            <footer @show-notifications={fun _ -> setShowNotifications (showNotifications |> not)}>
                <slot name="taskbar">Taskbar</slot>
            </footer>
        </article>
        """

let register () = ()
