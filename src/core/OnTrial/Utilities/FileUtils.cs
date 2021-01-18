using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OnTrial.Utilities
{
    public static class FileUtils
    {
        /// <summary>
        /// Will get the current directory of our library
        /// </summary>
        public static string CurrentDirectory
        {
            get => Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Sanitize filename by removing the path
        /// </summary>
        /// <param name="pFilename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string pFilename)
        {
            Match match = Regex.Match(pFilename, @".*[/\\](.*)$");
            return match.Success ? match.Groups[1].Value : pFilename;
        }

        /// <summary>
        /// Will attempt to find a file under and directory found in the PATH environment variable
        /// </summary>
        /// <param name="pExecutableName"></param>
        /// <returns></returns>
        public static string FindFile(string pExecutableName)
        {
            if (string.IsNullOrEmpty(pExecutableName))
                throw new ArgumentException($"Could not locate {pExecutableName} in the enviornmental PATH variable.");

            return FileUtils.FindFile("PATH", pExecutableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEnvironmentVariableName"></param>
        /// <param name="pExecutableName"></param>
        /// <returns></returns>
        public static string FindFile(string pEnvironmentVariableName, string pExecutableName)
        {
            string path = Environment.GetEnvironmentVariable(pEnvironmentVariableName);

            if (string.IsNullOrEmpty(path))
                return string.Empty;

            string directory = CurrentDirectory;
            if (File.Exists(Path.Combine(directory, pExecutableName)))
                return directory;

            string[] directories = Environment.ExpandEnvironmentVariables(path).Split(Path.PathSeparator);
            foreach (string dir in directories)
            {
                if (File.Exists(Path.Combine(dir, pExecutableName)))
                    return dir;
            }

            throw new ArgumentException($"Could not locate {pExecutableName} in the current directory or in the {pEnvironmentVariableName} directory.");
        }
    }
}
