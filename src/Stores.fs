module Stores

open Fable
open Types

let private notifications: IStore<Notification list> = Store.make id ignore []

let Notifier =
    { new INotifier with
        override _.Cancel(notifId: string) : unit =
            notifications.Update(fun values -> values |> List.filter (fun n -> n.id <> notifId))

        override _.Notify(notification: Notification) : unit =
            notifications.Update(fun notifications -> notification :: notifications) }
