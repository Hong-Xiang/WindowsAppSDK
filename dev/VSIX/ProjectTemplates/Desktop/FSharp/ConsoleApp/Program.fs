// Learn more about F# at http://fsharp.org

open System
open System.Runtime.InteropServices
open Microsoft.Windows.System
open Microsoft.Windows.AppNotifications
open Microsoft.Windows.AppNotifications.Builder

// A simple F# console app with WinRT capabilities
[<EntryPoint>]
let main argv =
    // Using WinRT APIs that don't require package identity
    let dispatcherQueue = DispatcherQueueController.CreateOnCurrentThread().DispatcherQueue
    printfn "Dispatcher Queue: %A" dispatcherQueue
    
    // Get OS version info
    let osVersionInfo = Environment.OSVersion
    printfn "OS Version: %A" osVersionInfo.VersionString
    
    // Check if running on Windows 11
    let isWindows11OrGreater = 
        Environment.OSVersion.Version.Major > 10 || 
        (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build >= 22000)
    printfn "Running on Windows 11 or greater: %A" isWindows11OrGreater
    
    // Setup app notifications (works unpackaged)
    let notificationManager = AppNotificationManager.Default
    notificationManager.Register()
    
    // Create a simple toast notification
    let toastNotification = 
        new AppNotificationBuilder()
            .AddText("Hello from F# Console App!")
            .AddText("This notification was sent from an unpackaged app")
            .BuildNotification()
    
    // Show a notification if user wants to
    printfn "Would you like to see a test notification? (y/n)"
    let response = Console.ReadLine()
    if response.ToLowerInvariant() = "y" then
        notificationManager.Show(toastNotification)
        printfn "Notification sent!"
    
    // Unregister notifications when done
    notificationManager.Unregister()
    
    printfn "Press any key to exit..."
    Console.ReadKey() |> ignore
    0 // return an integer exit code