using System;
using System.Diagnostics;

namespace OnTrial.Desktop
{
    [DebuggerDisplay("BrowserAttribute")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AppAttribute : Attribute
    {
        public string Directory { get; private set; }
        public PlatformType Platform { get; set; }

        public AppAttribute(string pDirectory) : this(pDirectory, PlatformType.Windows) { }

        public AppAttribute(string pDirectory, PlatformType pPlatform)
        {
            this.Directory = pDirectory;
            this.Platform = pPlatform;
        }
    }
}

