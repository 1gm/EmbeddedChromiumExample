using System;

using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;

using Owin;

namespace OwinFileHost
{
    public class FileHost
    {
        private static IDisposable Server;
        private static readonly string EmbeddedResourcesNamespace = "OwinFileHost.Resources";
        private static readonly string DefaultFileName = "index.html";
        public static readonly string StartupUrl = "http://localhost:1337/";

        public static void Start()
        {
            Server = WebApp.Start<FileHost>(StartupUrl);
        }

        public static void Stop()
        {
            Server?.Dispose();
        }

        public void Configuration(IAppBuilder app)
        {
            var options = new FileServerOptions
            {
                FileSystem = new EmbeddedResourceFileSystem(EmbeddedResourcesNamespace)
            };
            options.DefaultFilesOptions.DefaultFileNames = new[] { DefaultFileName };

            app.UseFileServer(options);
        }
    }
}
