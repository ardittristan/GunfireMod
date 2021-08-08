﻿// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Cpp2IL.Core;
using Cpp2IL.Core.Exceptions;
using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using LibCpp2IL;
using LibCpp2IL.PE;
using Microsoft.Win32;
using Mono.Cecil;
using Newtonsoft.Json.Linq;

namespace Decompiler
{
    internal class Program
    {
        private static readonly Regex NumMatch = new Regex(@"[0-9]+");

        private static readonly string CachePath = Path.GetFullPath(
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), @"..\..\", "cache")
        );

        private static readonly string[] AssembliesToCheck = { "Assembly-CSharp", "Assembly-CSharp-firstpass", /*"csharpdata"*/ };

        private static Cpp2IlRuntimeArgs _args;

        private static string _checksum = string.Empty;

        private static string _gunfirePath;

        public static int Main(string[] args)
        {
            GetGunfirePath();

            Directory.CreateDirectory(CachePath);

            if (File.Exists(Path.Combine(CachePath, "checksum.txt")))
                _checksum = File.ReadAllText(Path.Combine(CachePath, "checksum.txt"));

            var newChecksum = GetMd5Checksum(Path.Combine(_gunfirePath, "GameAssembly.dll"));

            if (_checksum == newChecksum) return 0;
            Console.WriteLine("===Cpp2IL by Samboy063===");
            Console.WriteLine("A Tool to Reverse Unity's \"il2cpp\" Build Process.\n");

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

            File.WriteAllText(Path.Combine(CachePath, "checksum.txt"), newChecksum);

            return 0;
        }

        internal static void GetGunfirePath()
        {
            var steamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath", "");
            var vdf = VdfConvert.Deserialize(File.ReadAllText(Path.Combine(steamPath, "steamapps", "libraryfolders.vdf"))).ToJson();

            foreach (var jToken in vdf.Values())
            {
                var value = (JProperty)jToken;
                if (!NumMatch.IsMatch(value.Name)) continue;
                var isRightLibrary = value.First?["apps"]?["1217060"] != null;
                if (isRightLibrary)
                {
                    _gunfirePath = Path.Combine((string)value.First["path"] ?? @"C:\Program Files (x86)\Steam",
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

            Cpp2IlApi.InitializeLibCpp2Il(_args.PathToAssembly, _args.PathToMetadata, _args.UnityVersion, false);

            Cpp2IlApi.MakeDummyDLLs();

            KeyFunctionAddresses keyFunctionAddresses = null;

            if (LibCpp2IlMain.Binary?.InstructionSet == InstructionSet.X86_32 ||
                LibCpp2IlMain.Binary?.InstructionSet == InstructionSet.X86_64 && LibCpp2IlMain.Binary is PE)
            {
                Logger.InfoNewline("Running Scan for Known Functions...");
                keyFunctionAddresses = Cpp2IlApi.ScanForKeyFunctionAddresses();
            }

            Cpp2IlApi.RunAttributeRestorationForAllAssemblies(keyFunctionAddresses);

            Cpp2IlApi.PopulateConcreteImplementations();

            Cpp2IlApi.SaveAssemblies(_args.OutputRootDirectory);

            foreach (var assembly in AssembliesToCheck)
            {
                DoAssemblyCSharpAnalysis(assembly, _args.OutputRootDirectory, keyFunctionAddresses);
            }
        }

        private static void DoAssemblyCSharpAnalysis(string assemblyName, string rootDir, KeyFunctionAddresses keyFunctionAddresses)
        {
            var assemblyCsharp = Cpp2IlApi.GetAssemblyByName(assemblyName);

            if (assemblyCsharp == null)
                return;

            Cpp2IlApi.AnalyseAssembly(AnalysisLevel.PRINT_ALL, assemblyCsharp, keyFunctionAddresses, Path.Combine(rootDir, "types"), true);

            Cpp2IlApi.SaveAssemblies(rootDir, new List<AssemblyDefinition> { assemblyCsharp });
        }

        internal static string GetMd5Checksum(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }
    }
}
