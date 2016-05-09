using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
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
            FormClosed += OnFormClosed;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            FileHost.Start();
            var browser = new ChromiumWebBrowser(FileHost.StartupUrl)
            {
                Dock = DockStyle.Fill
            };
            BrowserPanel.Controls.Add(browser);
            Browser = browser;
        }
        
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            FileHost.Stop();
            Cef.Shutdown();
        }
    }
}
