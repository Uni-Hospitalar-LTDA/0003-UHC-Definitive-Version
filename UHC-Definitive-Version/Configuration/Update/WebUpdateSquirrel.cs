﻿using Squirrel;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration.Update
{
    public class WebUpdateSquirrel
    {
        public static string _updateUrlWeb = @"https://github.com/Uni-Hospitalar-LTDA/0003-UHC-Definitive-Version-Publisher";


        
        public async static Task rollbackAsync(string rollbackTag = "1.0.0")
        {
            CustomNotification.defaultAlert("Rollback detectado! A aplicação passará por reparos automáticos. Aguarde a tela de login.");
            string url = _updateUrlWeb + $@"/releases/download/{rollbackTag}/Setup.exe";
            string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyApp", "Setup.exe");         

            try
            {
                // Verifica e cria a pasta de destino
                string folderPath = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Baixa o arquivo
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode();
                        byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();

                        // Escreve o arquivo na pasta de destino
                        File.WriteAllBytes(outputPath, fileBytes);
                        Console.WriteLine(outputPath);                        

                        // Executa o arquivo baixado
                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = outputPath,
                                UseShellExecute = true, // Necessário para garantir a execução correta
                                Verb = "runas" // Solicita privilégios elevados para instalar o arquivo
                            }
                        };
                        process.Start();
                        Environment.Exit(0);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Erro ao baixar o arquivo: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }
        public static async Task<string> CheckForUpdatesAsync()
        {
            try
            {
                using (var gitHubManager = await UpdateManager.GitHubUpdateManager(_updateUrlWeb))
                {
                    var releaseEntry = await gitHubManager.CheckForUpdate();
                    if (releaseEntry != null)
                    {
                        return $"{releaseEntry.FutureReleaseEntry.Version} detected. Updating version: {Application.ProductVersion}";

                        //else return $"Without new versions";
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return "Doesn't exists any updates." + ex.Message;
            }
        }
        public static async Task<string> UpdateAppAsync()
        {
            try
            {
                using (var gitHubManager = await UpdateManager.GitHubUpdateManager(_updateUrlWeb))
                {
                    var releaseEntry = await gitHubManager.UpdateApp();
                    return $"Actualized to v{releaseEntry.Version}";
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static void RestartApplication()
        {
            UpdateManager.RestartApp();
        }
        public static int CompareVersion(string version1, string version2)
        {
            string[] parts1 = version1.Split('.');
            string[] parts2 = version2.Split('.');

            for (int i = 0; i < 3; i++) // Assuming x.x.x
            {
                int num1 = int.Parse(parts1[i]);
                int num2 = int.Parse(parts2[i]);

                /** The method works, but for some reason when checking the version present on GitHub, 
                 * when the version is lower, it returns in "FutureReleaseEntry.Version" the version 
                 * equal to the program, that is, if on Github it is 1.0.1 and in your machine 1.0.6, 
                 * it will return as if 1.0.6 was on github. So for now I'm disregarding rollback, 
                 * if you want to work with Rollback I will provide a manual way to do it.  **/

                if (num1 < num2)
                    return -1;

                if (num1 > num2)
                    return 1;
            }

            return 0; // If versions are equal
        }
        public static async Task<string> CheckVersionAsync()
        {
            try
            {
                using (var gitHubManager = await UpdateManager.GitHubUpdateManager(_updateUrlWeb))
                {
                    var releaseEntry = await gitHubManager.CheckForUpdate();
                    
                    if (releaseEntry != null)
                    {                                             
                        return releaseEntry.FutureReleaseEntry.Version.ToString();
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                return "Version not identified";
            }

        }
    }
}
