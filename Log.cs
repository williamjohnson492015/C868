using System;
using System.IO;

namespace C868
{
    public static class Log
    {
        private static readonly string file = "Login_History.txt";
        private static readonly string executablePath = Path.GetFullPath("C868.exe");
        private static readonly string directory = Path.GetDirectoryName(executablePath);
        private static readonly string logPath = Path.Combine(directory, file);

        public static void LogLogin(User user)
        {
            string log = $"{DateTime.Now.ToUniversalTime()} (UTC) INFO app - User \"{user.UserName}\" logged in.";
            File.AppendAllText(logPath, log + Environment.NewLine);
        }
    }
}