using System;
using System.Windows.Forms;

using CefSharp;

using OwinFileHost;

namespace WinFormsChromiumExample
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var settings = new CefSettings();
            settings.CefCommandLineArgs.Add("disable-extensions", "1");
            settings.CefCommandLineArgs.Add("disable-pdf-extension", "1");
            Cef.Initialize(settings);

            var browserForm = new BrowserForm();

            Application.Run(browserForm);
        }
    }
}
