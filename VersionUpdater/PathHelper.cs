using System;
using System.IO;

namespace VersionUpdater
{
    public static class PathHelper
    {
        public static string GetSettingsFolder()
        {
            return Path.Combine(AppContext.BaseDirectory, "settings");
        }
    }
}
