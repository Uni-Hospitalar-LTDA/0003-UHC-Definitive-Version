using Krypton.Toolkit;
using System.Windows.Forms;
using System;

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
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja fechar a tela?") == DialogResult.Yes)
                Application.Exit();
        }
    }
}
