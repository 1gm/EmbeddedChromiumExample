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
