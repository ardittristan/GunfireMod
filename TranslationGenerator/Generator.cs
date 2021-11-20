using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace TranslationGenerator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) {}

        public void Execute(GeneratorExecutionContext context)
        {
            string projPath = context.GetMsBuildProperty("MSBuildProjectDirectory");
            string decompilerPath = Path.Combine(projPath, "../Decompiler/cache/generated");

            context.AddSource("csharpdata.cs", SourceText.From($@"
using System.Collections.Generic;

namespace Generated.CSharpData
{{
    public static class NormalTextData
    {{
        public static IReadOnlyDictionary<string, string> English = new Dictionary<string, string>()
        {{
            {GetLanguageValues(
                @"(?<=Loads the string literal "")(?<desc>[^\t]*?)(?="" as a constant).*?$(\n?\r?).*?(?<=Loads the string literal "")(?<const>[^\t]*?)(?="" as a constant)",
                Path.Combine(decompilerPath, "types/csharpdata/method_dumps/normaltextdata_English_methods.txt")
            )}
        }};
    }}
}}

", Encoding.UTF8));
        }

        private static string GetLanguageValues(string regexp, string file)
        {
            Regex exp = new Regex(regexp, RegexOptions.Multiline);
            string fileContent = File.ReadAllText(file);

            MatchCollection matches = exp.Matches(fileContent);

            return matches.Cast<Match>()
                .Aggregate("", (current, match) => current + $@"
            {{
                ""{match.Groups["const"].Value}"",
                ""{match.Groups["desc"].Value}""
            }},");
        }
    }
}
