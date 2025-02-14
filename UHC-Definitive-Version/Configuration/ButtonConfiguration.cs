using Krypton.Toolkit;
using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public static class ButtonConfiguration
    {
        public static void toDefaultQuestionCloseButton(this Button button)
        {
            button.Click += questionClose_Click;
        }
        public static void toDefaultCloseButton(this Button button)
        {
            button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button.Click += close_Click;
        }
        public static void toDefaultExitButton(this KryptonButton button)
        {
            button.Click += questionExit_Click;
        }
        public static void toDefaultExitButton(this Button button)
        {
            button.Click += questionExit_Click;
        }
        public static void toDefaultRestartButton(this Button button)
        {
            button.Click += questionRestart_Click;
        }
        private static void close_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
        public static void questionClose_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja fechar a tela?") == DialogResult.Yes)
                Form.ActiveForm.Close();
        }
        public static void questionExit_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja fechar a aplicação?") == DialogResult.Yes)
                Application.Exit();
        }
        public static void questionRestart_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja reiniciar a aplicação?") == DialogResult.Yes)
                Application.Restart();
        }
    }
}
