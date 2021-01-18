using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OnTrial.Utilities
{
    public static class ResourceUtils
    {
        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        private static string assemblyVersion;

        public static string AssemblyVersion
        {
            get
            {
                if (string.IsNullOrEmpty(assemblyVersion))
                {
                    Assembly executingAssembly = Assembly.GetCallingAssembly();
                    Version versionResource = executingAssembly.GetName().Version;
                    assemblyVersion = string.Format("{0}.{1}.{2}", versionResource.Major, versionResource.Minor, versionResource.Revision);
                }

                return assemblyVersion;
            }
        }

        public static string PlatformFamily
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return "windows";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return "linux";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return "mac";
                else
                    return "unknown";
            }
        }
    }
}
