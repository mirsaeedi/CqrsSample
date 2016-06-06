using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Kaftar.RuntimePolicyInjection.Core
{
    internal class FilePolicyDiscoverySetting
    {
        public ICollection<string> AssemblyReferencesPaths { get; private set; } = new List<string>();
        public ICollection<string> SearchPaths  { get; private set; } = new List<string>();
        public string MatchPattern { get;  set; } = "*Policy.cs";


        public FilePolicyDiscoverySetting(IEnumerable<string> assemblyReferenesPaths=null, IEnumerable<string> searchPaths=null,string matchPattern=null)
        {
            if (assemblyReferenesPaths != null)
            {
                foreach (var assemblyReferenesPath in assemblyReferenesPaths)
                {
                    AssemblyReferencesPaths.Add(assemblyReferenesPath);
                }
            }

            if (searchPaths != null)
            {
                foreach (var searchPath in searchPaths)
                {
                    SearchPaths.Add(searchPath);
                }
            }

            if (matchPattern != null)
                MatchPattern = matchPattern;
        }

        public FilePolicyDiscoverySetting AddAssemblyReferencePath(string path)
        {
            AssemblyReferencesPaths.Add(path);
            return this;
        }

        public FilePolicyDiscoverySetting AddSearchPath(string path)
        {
            SearchPaths.Add(path);
            return this;
        }
    }
}
