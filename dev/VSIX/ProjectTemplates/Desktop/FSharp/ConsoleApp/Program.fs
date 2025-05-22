// Learn more about F# at http://fsharp.org

open System
open Windows.ApplicationModel
open Windows.Foundation
open Microsoft.Windows.AppLifecycle

// A simple F# console app with WinRT capabilities
[<EntryPoint>]
let main argv =
    // Getting application information using WinRT APIs
    let appInfo = Package.Current.Id
    printfn "Application Name: %s" appInfo.Name
    printfn "Version: %A.%A.%A.%A" appInfo.Version.Major appInfo.Version.Minor appInfo.Version.Build appInfo.Version.Revision
    printfn "Architecture: %A" appInfo.Architecture

    // Using App Lifecycle API
    let instance = AppInstance.GetCurrent()
    printfn "Instance Key: %s" instance.Key
    
    printfn "Press any key to exit..."
    Console.ReadKey() |> ignore
    0 // return an integer exit code