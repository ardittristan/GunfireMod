﻿using Microsoft.CodeAnalysis;
using System.Linq;

namespace TranslationGenerator
{
    internal static class SourceGeneratorContextExtensions
    {
        private const string SourceItemGroupMetadata = "build_metadata.AdditionalFiles.SourceItemGroup";

        public static string GetMsBuildProperty(
            this GeneratorExecutionContext context,
            string name,
            string defaultValue = "")
        {
            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.{name}", out var value);
            return value ?? defaultValue;
        }

        public static string[] GetMsBuildItems(this GeneratorExecutionContext context, string name)
            => context
                .AdditionalFiles
                .Where(f => context.AnalyzerConfigOptions
                                .GetOptions(f)
                                .TryGetValue(SourceItemGroupMetadata, out var sourceItemGroup)
                            && sourceItemGroup == name)
                .Select(f => f.Path)
                .ToArray();
    }
}
