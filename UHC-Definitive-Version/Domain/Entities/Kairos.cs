using UHC3_Definitive_Version.Customization;
using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace UHC3_Definitive_Version.Domain.Entities
{
    public class Kairos
    {
        private static async Task<bool> getKairosFromWebAsync(DateTime dt)
        {
            int mes = dt.Month;
            int ano = dt.Year;

            string[] mesvalores = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
            string mesvalor = mesvalores[mes - 1];

            string folderPath = @"C:\kairos";
            string caminhoDoArquivo = Path.Combine(folderPath, $"{mesvalor}{ano}.jar");
            string link = $"http://www.rgrpublicacoes.com.br/download/{mesvalor}{ano}x%20java.jar";

            // Crie a pasta se ela não existir
            Directory.CreateDirectory(folderPath);

            if (System.IO.File.Exists(caminhoDoArquivo))
            {
                CustomNotification.defaultAlert("O arquivo já está baixado em sua maquina");
                return false;
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(link, HttpCompletionOption.ResponseHeadersRead);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    //CustomMessage.Sucess("Ainda não há atualização do Kairos este mês.");
                    return false;
                }

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        byte[] downloadData = await response.Content.ReadAsByteArrayAsync();
                        await Task.Factory.StartNew(() => System.IO.File.WriteAllBytes(caminhoDoArquivo, downloadData));
                        return true;
                    }
                    catch (Exception err)
                    {
                        CustomNotification.defaultError(err.Message);
                        return false;
                    }
                }
                else
                {
                    CustomNotification.defaultError($"Erro ao baixar arquivo: {response.StatusCode}");
                    return false;
                }
            }
        }
        private static void attKairos(DateTime dt)
        {
            int mes = dt.Month;
            int ano = dt.Year;
            string[] mesvalores = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
            string mesvalor = mesvalores[mes - 1];

            string folderPath = @"C:\kairos";
            string caminhoDoArquivo = Path.Combine(folderPath, $"{mesvalor}{ano}.jar");

            // Crie a pasta se ela não existir
            Directory.CreateDirectory(folderPath);

            if (System.IO.File.Exists(caminhoDoArquivo))
            {
                try
                {
                    using (System.IO.Compression.ZipArchive archive = ZipFile.OpenRead(caminhoDoArquivo))
                    {
                        // O arquivo está ok, podemos executá-lo
                        Process process = new Process();
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.Arguments = $@"/k cd {folderPath} && java -jar {caminhoDoArquivo} -console";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardInput = true;
                        process.Start();

                        System.Threading.Thread.Sleep(3000);
                        process.StandardInput.WriteLine("1");
                        System.Threading.Thread.Sleep(3000);
                        process.StandardInput.WriteLine("Kairos");
                        System.Threading.Thread.Sleep(3000);
                        process.StandardInput.WriteLine("1");
                        System.Threading.Thread.Sleep(1000);
                        process.StandardInput.WriteLine("exit");

                        process.WaitForExit();
                        process.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"{caminhoDoArquivo} está inválido ou corrompido: {ex.Message}, tente baixa-lo novamente");
                }
            }
            else
            {
                CustomNotification.defaultAlert($"{caminhoDoArquivo} não existe.");
            }
        }
        public static void CreateShortcutOnDesktop()
        {
            // Caminho para o arquivo de destino (Informatico.jar)
            string jarPath = @"C:\kairos\Kairos\Informatico.jar";

            // Caminho para o ícone (Kairos.ico)
            string iconPath = @"C:\kairos\Kairos\Kairos.ico";

            // Caminho da Área de Trabalho do usuário
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Nome do atalho
            string shortcutName = "Kairos";

            try
            {
                // Criando um atalho
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(desktopPath, shortcutName + ".lnk"));

                // Definindo propriedades do atalho
                shortcut.Description = "Atalho para Informatico.jar";
                shortcut.TargetPath = jarPath; // Caminho do JAR
                shortcut.WorkingDirectory = Path.GetDirectoryName(jarPath); // Definir o diretório de trabalho para a pasta contendo o JAR
                shortcut.IconLocation = iconPath; // Definir o ícone do atalho
                shortcut.Save(); // Salva o atalho no desktop

                Console.WriteLine("Atalho criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar atalho: {ex.Message}");
            }
        }
        public static async Task<bool> ProcessAndDeleteKairosAsync(DateTime dt)
        {
            bool result = await getKairosFromWebAsync(dt);
            if (result)
            {
                attKairos(dt);

                // Deletar o arquivo após a instalação
                int mes = dt.Month;
                int ano = dt.Year;
                string[] mesvalores = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
                string mesvalor = mesvalores[mes - 1];
                string folderPath = @"C:\kairos";
                string caminhoDoArquivo = Path.Combine(folderPath, $"{mesvalor}{ano}.jar"); // Aqui estava o problema

                try
                {
                    CreateShortcutOnDesktop();
                    System.IO.File.Delete(caminhoDoArquivo);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao deletar {caminhoDoArquivo}: {ex.Message}");
                }
                finally
                {
                    CustomNotification.defaultInformation("Atualização concluída com sucesso, o kairos foi disponibilizado em sua área de trabhalho.");
                }
            }
            return result;
        }
        public static void StartShortcutFromDesktop(string shortcutName = "Kairos")
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutPath = Path.Combine(desktopPath, $"{shortcutName}.lnk");

            if (System.IO.File.Exists(shortcutPath))
            {
                try
                {
                    Process.Start(shortcutPath);
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError($"Erro ao tentar abrir o atalho: {ex.Message}");
                }
            }
            else
            {
                CustomNotification.defaultAlert($"Atalho {shortcutName} não encontrado na área de trabalho, por favor atualize a aplicação.");
            }
        }
        public static void DeleteKairosFolderAndShortcut()
        {
            string folderPath = @"C:\kairos";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutPath = Path.Combine(desktopPath, "Kairos.lnk");

            // Deleta o atalho da área de trabalho
            try
            {
                if (System.IO.File.Exists(shortcutPath))
                {
                    System.IO.File.Delete(shortcutPath);
                    Console.WriteLine($"Atalho {shortcutPath} foi deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Atalho {shortcutPath} não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar atalho {shortcutPath}: {ex.Message}");
            }

            // Deleta a pasta Kairos
            if (Directory.Exists(folderPath))
            {
                try
                {
                    Directory.Delete(folderPath, true); // O segundo parâmetro 'true' permite a remoção de subdiretórios e arquivos
                    Console.WriteLine($"Pasta {folderPath} foi deletada com sucesso.");
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Erro ao deletar pasta {folderPath}: {ioEx.Message}");
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    Console.WriteLine($"Erro de permissão ao deletar pasta {folderPath}: {uaEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao deletar pasta {folderPath}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"A pasta {folderPath} não foi encontrada.");
            }
        }
        public static async Task reinstallKairos(DateTime dt)
        {
            try
            {
                DeleteKairosFolderAndShortcut();
                if (await ProcessAndDeleteKairosAsync(dt))
                {
                    StartShortcutFromDesktop();
                    CustomNotification.defaultInformation("Kairos reparado com sucesso!");
                }
                else
                {
                    int x = 1;
                    bool t = true;
                    while (t)
                    {
                        t = !(await ProcessAndDeleteKairosAsync(dt.AddMonths(x--)));
                        if (!t)
                        {
                            CustomNotification.defaultInformation("Kairos reparado com sucesso!");
                            StartShortcutFromDesktop();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {

            }
        }

    }
}
