namespace $safeprojectname$

open System
open Windows.ApplicationModel
open Windows.ApplicationModel.Activation
open Windows.Foundation
open Microsoft.UI.Xaml
open Microsoft.UI.Xaml.Controls
open Microsoft.UI.Xaml.Data
open Microsoft.UI.Xaml.Input
open Microsoft.UI.Xaml.Media
open Microsoft.UI.Xaml.Navigation
open Microsoft.UI.Xaml.Shapes

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
type App() =
    inherit Application()
    
    let mutable _window : Window option = None

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    do
        this.InitializeComponent()

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    override this.OnLaunched(args) =
        _window <- Some(MainWindow())
        _window.Value.Activate()