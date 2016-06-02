using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    /*
    internal class FileRuleDiscoverer : IRuleDiscoverer
    {
        private readonly ICollection<string> _searchPaths;

        public FileRuleDiscoverer(ICollection<string> searchPaths )
        {
            _searchPaths = searchPaths;
        }

        public ICollection<Contracts.IRule> Discover()
        {
            var files = GetRuleFiles(_searchPaths);
            var codeOfRules = MergeCodes(files);
            var assembly = CreateAssembly(codeOfRules);
            return new ClassRuleDiscoverer().Discover(assembly);
        }

        private Assembly CreateAssembly(string codeOfRules)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(codeOfRules);

            CSharpCompilation compilation = CSharpCompilation.Create(
                "DSL.Rules",
                new[] { syntaxTree },
                new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(true)
                .WithOptimizationLevel(OptimizationLevel.Release));

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

        private string MergeCodes(ICollection<string> files)
        {
            throw new NotImplementedException();
        }

        private ICollection<string> GetRuleFiles(ICollection<string> searchPaths)
        {
            var hashset = new HashSet<string>();
            var ruleFiles = new List<string>();

            foreach (var path in searchPaths)
            {
                var files = Directory.GetFiles(path,
                        "*Rule.cs",
                        SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    if (hashset.Contains(file))
                        continue;

                    ruleFiles.Add(file);
                    hashset.Add(file);
                }

            }

            return ruleFiles;
        }
    }*/
}
