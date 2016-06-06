using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Kaftar.RuntimePolicyInjection.Core.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Kaftar.RuntimePolicyInjection.Core
{
    internal class FilePolicyLocator : IPolicyLocator
    {
        private readonly FilePolicyDiscoverySetting _settings;

        public FilePolicyLocator(FilePolicyDiscoverySetting settings)
        {
            _settings = settings;
        }

        public void Locate()
        {
            var files = GetPolicyFiles();
            var syntaxTrees = new List<SyntaxTree>();

            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file);
                syntaxTrees.Add(CSharpSyntaxTree.ParseText(fileContent));    
            }

            LoadAssembly(syntaxTrees);
        }

        private Assembly LoadAssembly(ICollection<SyntaxTree> syntaxTrees)
        {
            var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(true)
                .WithOptimizationLevel(OptimizationLevel.Release);

            CSharpCompilation compilation = CSharpCompilation.Create(
                "DynamicPolicies")
                .AddSyntaxTrees(syntaxTrees)
                .AddReferences(GetMetadataReferences())
                .WithOptions(compilationOptions);

            using (var dllStream = new MemoryStream())
            {
                using (var pdbStream = new MemoryStream())
                {
                    var emitResult = compilation.Emit(dllStream, pdbStream);

                    if (!emitResult.Success)
                    {
                        IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
                            diagnostic.IsWarningAsError ||
                            diagnostic.Severity == DiagnosticSeverity.Error);

                        foreach (Diagnostic diagnostic in failures)
                        {
                            Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                        }
                    }
                    else
                    {
                        return  Assembly.Load(dllStream.GetBuffer());
                    }
                }
            }

            throw new Exception("Unabled To Do Compiling");
        }

        private IEnumerable<MetadataReference> GetMetadataReferences()
        {
            var references = new List<MetadataReference>();

            var gacPath = new FileInfo(typeof(object).Assembly.Location)
                .Directory
                .FullName;

            foreach (var assemblyReferencesPath in _settings.AssemblyReferencesPaths)
            {
                var path = assemblyReferencesPath.EndsWith(".dll")
                        ? assemblyReferencesPath :
                        assemblyReferencesPath + ".dll";

                if (assemblyReferencesPath.Contains("/"))
                {
                    MetadataReference.CreateFromFile(assemblyReferencesPath);
                }
                else
                {
                    // first check current directory and then in gac
                    references.Add(File.Exists(FileSystemPathResolver.Resolve(path)) 
                        ? MetadataReference.CreateFromFile(FileSystemPathResolver.Resolve(path))
                        : MetadataReference.CreateFromFile(Path.Combine(gacPath , path)));
                }
            }
            return references;
        }

        private ICollection<string> GetPolicyFiles()
        {
            var hashset = new HashSet<string>();
            var policyFiles = new List<string>();

            foreach (var path in _settings.SearchPaths)
            {
                var files = Directory.GetFiles(FileSystemPathResolver.Resolve(path),
                        _settings.MatchPattern,
                        SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    if (hashset.Contains(file))
                        continue;

                    policyFiles.Add(file);
                    hashset.Add(file);
                }
            }

            return policyFiles;
        }
    }
}
