module Types

open Fable.Core
open Fable.Core.JS
open System

[<StringEnum>]
type NotificationPosition =
    | TopLeft
    | TopRight
    | BottomLeft
    | BottomRight

[<StringEnum; RequireQualifiedAccess>]
type DesktopLayout =
    | Default
    | MacOsish
    | Winish

type Notification =
    {| id: string
       title: string
       content: string option
       duration: float option
       position: NotificationPosition option |}

type AppWindowState =
    | Minimized
    | Maximized
    | Active
    | Inactive

type App =
    { appWindowState: AppWindowState
      id: Guid
      title: string
      icon: string option
      pinned: bool
      canOpenMultiple: bool }

type RootState =
    { isStartOpen: bool
      apps: App []
      layout: DesktopLayout }

type INotifier =
    abstract Notify: Notification -> unit
    abstract Cancel: string -> unit
