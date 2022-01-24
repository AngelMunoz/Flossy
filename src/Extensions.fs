[<AutoOpen>]
module Extensions

open Fable.Core

[<Emit("import $0 from '$1' { assert: 'css' }; $0")>]
let importCssModule<'T> (defaultName: string) (path: string) : 'T = jsNative
