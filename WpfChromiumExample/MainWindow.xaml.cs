using System.Windows;

using OwinFileHost;

namespace WpfChromiumExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string StartAddress {  get { return FileHost.StartupUrl;  } }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
