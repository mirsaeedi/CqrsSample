using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Kaftar.RuntimePolicyInjection.Core
{
    public class PolicyInjectionBootstrapper
    {
        public static readonly string ConfigFilePath = "PolicyConfiguration.json";
        static ICollection<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();
        public static void DiscoverPolicies()
        {
            if (ConfigFileExists())
            {
                FilePolicyDiscoverySetting setting = GetFilePolicyDiscoverySetting();
                new FilePolicyLocator(setting).Locate();

                ConfigFileSystemWatcher(setting);
            }

            var locator = new ClassPolicyLocator();
            locator.Locate();

            PolicyProvider.CreateSigletonInstance(locator.Policies);

            
        }

        private static void ConfigFileSystemWatcher(FilePolicyDiscoverySetting setting)
        {
            foreach (var searchPath in setting.SearchPaths)
            {
                var fileSystemWatcher = new FileSystemWatcher
                {
                    Path = FileSystemPathResolver.Resolve(searchPath),
                    IncludeSubdirectories = true,
                    Filter = setting.MatchPattern,
                    NotifyFilter = NotifyFilters.LastWrite,
                    EnableRaisingEvents = true
                };

                fileSystemWatcher.Changed += FileSystemWatcher_Changed;
                fileSystemWatcher.Deleted += FileSystemWatcher_Changed;
                fileSystemWatcher.Created += FileSystemWatcher_Changed;

                _fileSystemWatchers.Add(fileSystemWatcher);
            }
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            DiscoverPolicies();
        }

        private static bool ConfigFileExists()
        {
            return File.Exists(FileSystemPathResolver.Resolve(ConfigFilePath));
        }

        private static FilePolicyDiscoverySetting GetFilePolicyDiscoverySetting()
        {
            JObject jsonConfig = JObject.Parse(File.ReadAllText(FileSystemPathResolver.Resolve(ConfigFilePath)));
            FilePolicyDiscoverySetting setting =new FilePolicyDiscoverySetting();

            for (int i = 0; i < jsonConfig["referencePaths"].Children().Count(); i++)
            {
                setting.AssemblyReferencesPaths.Add(jsonConfig["referencePaths"][i].ToString());
            }

            for (int i = 0; i < jsonConfig["searchPaths"].Children().Count(); i++)
            {
                setting.SearchPaths.Add(jsonConfig["searchPaths"][i].ToString());
            }

            setting.MatchPattern = jsonConfig["matchPattern"].ToString();

            return setting;
        }
    }
}
