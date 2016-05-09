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
            if(Cef.Initialize())
            {
                FileHost.Start();

                Application.Run(new BrowserForm());

                FileHost.Stop();

                Cef.Shutdown();
            }
        }
    }
}
