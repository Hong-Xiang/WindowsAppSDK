// Learn more about F# at http://fsharp.org

open System
open Microsoft.Windows.System.Power
open Microsoft.Windows.ApplicationModel.DynamicDependency

// A simple F# console app with Windows App SDK capabilities
[<EntryPoint>]
let main argv =
    // For explicit initialization, call Bootstrap.Initialize() to load the Windows App SDK framework package
    // Remove WindowsPackageType=None in project file
    // Bootstrap.Initialize(0x00010000, "preview3")

    // Call a simple Windows App SDK API, and output the result
    let dispStatus = PowerManager.DisplayStatus

    printfn "Hello World!"
    printfn "DisplayStatus: %A" dispStatus

    // When performing explicit initialization, release the Dynamic Dependencies Lifetime Manager
    // Bootstrap.Shutdown()
    
    printfn "\nPress any key to exit..."
    Console.ReadKey() |> ignore
    0 // return an integer exit code