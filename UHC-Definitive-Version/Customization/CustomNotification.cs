using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomNotification
    {
        public static DialogResult defaultQuestionAlert(string message = "Alerta, este é um evento que precisa da sua atenção, deseja prosseguir?", string caption = "Alerta")
        {
            /** Retorno DialogResult Yes/No **/
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static void defaultAlert(string message = "Alerta, este é um evento que precisa da sua atenção!", string caption = "Alerta")
        {
            /** Retorno DialogResult Yes/No **/
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void defaultError(string message = "Ocorreu um erro desconhecido!", string caption = "Erro")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void defaultInformation(string message = "Operação concluída com sucesso!", string caption = "Informação")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
