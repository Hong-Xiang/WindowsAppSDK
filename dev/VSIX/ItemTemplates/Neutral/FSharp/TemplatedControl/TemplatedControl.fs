namespace $rootnamespace$

open System
open Microsoft.UI.Xaml
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml.Media

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

/// <summary>
/// A templated control.
/// </summary>
type $safeitemname$() =
    inherit Control()

    static do 
        // Set default style key to typeof(current class)
        ControlHelper.setDefaultStyleKey(typeof<$safeitemname$>)

and ControlHelper =
    static member setDefaultStyleKey<'T> (typ: Type) =
        let key = typeof<'T>
        let meth = typ.GetMethod("DefaultStyleKeyProperty")
        if meth <> null then
            let prop = meth.Invoke(null, null) :?> DependencyProperty
            if prop <> null then
                let register = typ.GetMethod("RegisterDefaultStyleKey")
                if register <> null then
                    register.Invoke(null, [| typ, key |]) |> ignore