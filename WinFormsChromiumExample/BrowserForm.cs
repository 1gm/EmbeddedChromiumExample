using System;
using System.Windows.Forms;

using CefSharp.WinForms;

using OwinFileHost;

namespace WinFormsChromiumExample
{
    public partial class BrowserForm : Form
    {
        public IWinFormsWebBrowser Browser { get; private set; }

        public BrowserForm()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            var browser = new ChromiumWebBrowser(FileHost.StartupUrl)
            {
                Dock = DockStyle.Fill
            };
            BrowserPanel.Controls.Add(browser);
            Browser = browser;
        }
    }
}
