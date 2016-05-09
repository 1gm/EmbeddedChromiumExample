using System;

using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;

using Owin;

namespace OwinFileHost
{
    public class FileHost
    {
        private static IDisposable WebServer;
        private static readonly string EmbeddedResourcesNamespace = "OwinFileHost.Resources";
        public static readonly string StartupUrl = "http://localhost:1337/";

        public static void Start()
        {
            WebServer = WebApp.Start<FileHost>(StartupUrl);
        }

        public static void Stop()
        {
            WebServer?.Dispose();
        }

        public void Configuration(IAppBuilder app)
        {
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = new EmbeddedResourceFileSystem(EmbeddedResourcesNamespace)
            };
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };

            app.UseFileServer(options);
        }
    }
}
