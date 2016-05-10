using System.Windows;

using CefSharp;

using OwinFileHost;

namespace WpfChromiumExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var cefSettings = new CefSettings();
            cefSettings.SetOffScreenRenderingBestPerformanceArgs();
            if (Cef.Initialize(cefSettings))
            {
                FileHost.Start();
                base.OnStartup(e);
            }
            else
            {
                Current.Shutdown();
            }

        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            if (Cef.IsInitialized)
            {
                Cef.Shutdown();
            }
            FileHost.Stop();
        }
    }
}
