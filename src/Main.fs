module Main

Fable.Core.JsInterop.importSideEffects "./main.css"
Fable.Core.JsInterop.importSideEffects "@shoelace-style/shoelace"
open Components


FloDesktop.register ()
FloNotificationHub.register ()
FloTaskbar.register ()
App.register ()
