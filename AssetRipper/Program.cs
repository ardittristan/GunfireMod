// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using Microsoft.Win32;

namespace AssetRipper
{
    internal static class Program
    {
        private const string CommitUrl = "https://github.com/ds5678/AssetRipper/commits/master";

        private const string DownloadUrl =
            "https://nightly.link/ds5678/AssetRipper/workflows/publish/master/AssetRipperConsole_win64.zip";

        private static readonly Regex NumMatch = new Regex(@"[0-9]+");

        private static readonly string CachePath = Path.GetFullPath(
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                throw new InvalidOperationException(), @"..\..\", "cache")
        );

        private static string _checksum = string.Empty;

        private static string _gunfirePath;

        public static async Task<int> Main(string[] args)
        {
            GetGunfirePath();

            Directory.CreateDirectory(CachePath);

            if (File.Exists(Path.Combine(CachePath, "checksum.txt")))
                _checksum = File.ReadAllText(Path.Combine(CachePath, "checksum.txt"));

            string newChecksum = await GetChecksum(Path.Combine(_gunfirePath, "GameAssembly.dll"));

#if DEBUG
            Debug.WriteLine($"\nChecksum: {newChecksum}\n");
#else
            Console.WriteLine($"\nChecksum: {newChecksum}\n");
#endif

            if (_checksum == newChecksum) return 0;

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(DownloadUrl, Path.Combine(CachePath, "AssetRipper.zip"));
            }

            if (Directory.Exists(Path.Combine(CachePath, "AssetRipper")))
                Directory.Delete(Path.Combine(CachePath, "AssetRipper"), true);

            ZipFile.ExtractToDirectory(Path.Combine(CachePath, "AssetRipper.zip"),
                Path.Combine(CachePath, "AssetRipper"));

            using (Process cmdProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(CachePath, "AssetRipper", "AssetRipperConsole.exe"),
                    Arguments = $"-o \"{Path.Combine(CachePath, "Assets")}\" -q \"{_gunfirePath}\""
                }
            })
            {
                cmdProcess.Start();
                cmdProcess.WaitForExit();
            }

            File.WriteAllText(Path.Combine(CachePath, "checksum.txt"), newChecksum);

            return 0;
        }

        internal static void GetGunfirePath()
        {
            string steamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath", "");
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

        internal static string GetMd5Checksum(string filename)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }

        internal static async Task<string> GetAssetRipperVersion()
        {
            using (IBrowsingContext context = BrowsingContext.New(Configuration.Default.WithDefaultLoader()))
            {
                IDocument document = await context.OpenAsync(CommitUrl);

                string lastCommit = document
                    .QuerySelector(".js-navigation-container .Box-row .BtnGroup a.BtnGroup-item").TextContent;

                return lastCommit;
            }
        }

        internal static async Task<string> GetChecksum(string filename) =>
            GetMd5Checksum(filename) + (await GetAssetRipperVersion()).Trim();
    }
}
