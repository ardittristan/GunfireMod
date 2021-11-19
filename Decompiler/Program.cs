// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
#if !NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endif
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Cpp2IL;
using Cpp2IL.Core;
using Cpp2IL.Core.Exceptions;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using LibCpp2IL;
using Microsoft.Win32;
using Mono.Cecil;

namespace Decompiler
{
    internal static class Program
    {
        private static readonly Regex NumMatch = new Regex(@"[0-9]+");

        private static readonly string CachePath = Path.GetFullPath(
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), @"..\..\", "cache")
        );

        // ReSharper disable once InconsistentNaming
        private static readonly Stopwatch stopwatch = new Stopwatch();

        private static readonly string[] AssembliesToCheck = { "Assembly-CSharp", "Assembly-CSharp-firstpass", "csharpdata" };

        private static Cpp2IlRuntimeArgs _args;

#if !DEBUG
        private static string _checksum = string.Empty;
#endif

        private static string _gunfirePath = null!;

        public static void Log(string txt)
        {
#if DEBUG
            Debug.WriteLine(txt);
#else
            Console.WriteLine(txt);
#endif
        }

        public static int Main(string[] args)
        {
            stopwatch.Start();

            Log("Starting Decompiler");

            GetGunfirePath();

            Directory.CreateDirectory(CachePath);

#if !DEBUG
            if (File.Exists(Path.Combine(CachePath, "checksum.txt")))
                _checksum = File.ReadAllText(Path.Combine(CachePath, "checksum.txt"));

            string newChecksum = GetChecksum(Path.Combine(_gunfirePath, "GameAssembly.dll"));
            
            Log($"\nChecksum: {newChecksum}\n");

            if (_checksum == newChecksum) return 0;
#endif

            Log("===Cpp2IL by Samboy063===");
            Log("A Tool to Reverse Unity's \"il2cpp\" Build Process.\n");

            ConsoleLogger.Initialize();
            try
            {
                RunCpp2Il();
            }
#region catch
            catch (DllSaveException e)
            {
                Logger.ErrorNewline(e.ToString());
                Console.WriteLine();
                Console.WriteLine();
                Logger.ErrorNewline("Waiting for you to press enter - feel free to copy the error...");
                Console.ReadLine();

                return -1;
            }
            catch (LibCpp2ILInitializationException e)
            {
                Logger.ErrorNewline($"\n\n{e}\n\nWaiting for you to press enter - feel free to copy the error...");
                Console.ReadLine();
                return -1;
            }
#endregion

#if !DEBUG
            File.WriteAllText(Path.Combine(CachePath, "checksum.txt"), newChecksum);
#endif

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Log($"Decompiler Duration: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}");

            return 0;
        }

        internal static void GetGunfirePath()
        {
            string steamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath", "")!;
            VProperty vdf = VdfConvert.Deserialize(File.ReadAllText(Path.Combine(steamPath, "steamapps", "libraryfolders.vdf")));
            
            foreach (VToken vToken in vdf.Value.Children())
            {
                VProperty value = (VProperty)vToken;
                if (!NumMatch.IsMatch(value.Key)) continue;
                bool isRightLibrary = value.Value["apps"]?["1217060"] != null;
                if (isRightLibrary)
                {
                    _gunfirePath = Path.Combine(value.Value["path"]?.ToString() ?? @"C:\Program Files (x86)\Steam",
                        @"steamapps\common\Gunfire Reborn");
                }
            }
        }

        private static void RunCpp2Il()
        {
            if (Directory.Exists(Path.Combine(CachePath, "generated")))
                Directory.Delete(Path.Combine(CachePath, "generated"), true);

            _args.PathToAssembly = Path.Combine(_gunfirePath, "GameAssembly.dll");
            _args.PathToMetadata =
                Path.Combine(_gunfirePath, @"Gunfire Reborn_Data\il2cpp_data\Metadata\global-metadata.dat");
            _args.UnityVersion = Cpp2IlApi.DetermineUnityVersion(Path.Combine(_gunfirePath, "Gunfire Reborn.exe"),
                Path.Combine(_gunfirePath, "Gunfire Reborn_Data"));
            _args.OutputRootDirectory = Path.Combine(CachePath, "generated");

            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

            Cpp2IlApi.InitializeLibCpp2Il(_args.PathToAssembly, _args.PathToMetadata, _args.UnityVersion, false);

            Cpp2IlApi.MakeDummyDLLs();

            Cpp2IlApi.GenerateMetadataForAllAssemblies(_args.OutputRootDirectory);

            BaseKeyFunctionAddresses keyFunctionAddresses = null!;

            if (LibCpp2IlMain.Binary?.InstructionSet != InstructionSet.ARM32)
            {
                Logger.InfoNewline("Running Scan for Known Functions...");
                keyFunctionAddresses = Cpp2IlApi.ScanForKeyFunctionAddresses();
            }

            Cpp2IlApi.RunAttributeRestorationForAllAssemblies(keyFunctionAddresses,
                LibCpp2IlMain.MetadataVersion >= 29 ||
                (LibCpp2IlMain.Binary?.InstructionSet == InstructionSet.X86_32 ||
                 LibCpp2IlMain.Binary?.InstructionSet == InstructionSet.X86_64));

            Cpp2IlApi.PopulateConcreteImplementations();

            Cpp2IlApi.HarmonyPatchCecilForBetterExceptions();

            Cpp2IlApi.SaveAssemblies(_args.OutputRootDirectory);

            foreach (string assembly in AssembliesToCheck)
            {
                DoAssemblyCSharpAnalysis(assembly, _args.OutputRootDirectory, keyFunctionAddresses);
            }
        }

        private static void DoAssemblyCSharpAnalysis(string assemblyName, string rootDir, BaseKeyFunctionAddresses keyFunctionAddresses)
        {
#pragma warning disable CS8600
            AssemblyDefinition assemblyCsharp = Cpp2IlApi.GetAssemblyByName(assemblyName);
#pragma warning restore CS8600

            if (assemblyCsharp == null)
                return;

            Cpp2IlApi.AnalyseAssembly(AnalysisLevel.PRINT_ALL, assemblyCsharp, keyFunctionAddresses, Path.Combine(rootDir, "types"), true, true);

            Cpp2IlApi.SaveAssemblies(rootDir, new List<AssemblyDefinition> { assemblyCsharp });
        }

#if NET6_0_OR_GREATER
        internal static string GetMd5Checksum(string filename)
        {
            using MD5 md5 = MD5.Create();
            using FileStream stream = File.OpenRead(filename);
            byte[] hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "");
        }
#else
        internal static string GetMd5Checksum(string filename)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }
#endif
        
        internal static string GetCpp2IlVersion()
        {
            string output = "";

            Assembly assembly = Assembly.GetExecutingAssembly();

            string ilRepackName = assembly.GetManifestResourceNames().First(s => s.Contains("ILRepack.List"));

#pragma warning disable CS8600
            // ReSharper disable once AssignNullToNotNullAttribute
            Stream stream = assembly.GetManifestResourceStream(ilRepackName);
#pragma warning restore CS8600

            if (stream == null) return output;

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            string binaryText = Encoding.ASCII.GetString(buffer);
            string text = Regex.Replace(binaryText, @"[^0-9a-zA-Z.,= ]+", "|");
            foreach (string entry in text.Split('|'))
            {
                string[] values = entry.Split(',');
                if (values[0].Trim().Length == 0) continue;
                // ReSharper disable twice ReplaceSubstringWithRangeIndexer
                if (values[0].Substring(1) == "Cpp2IL.Core") output = values[1].Substring(9);
            }

            return output;
        }

        internal static string GetChecksum(string filename) => GetMd5Checksum(filename) + GetCpp2IlVersion();
    }
}
