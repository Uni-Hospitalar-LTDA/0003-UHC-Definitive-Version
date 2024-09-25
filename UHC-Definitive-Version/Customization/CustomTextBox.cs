using System;
using System.Linq;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public static class CustomTextBox
    {
        public static void blockBackSpace(this TextBox textBox)
        {
            textBox.KeyDown += blockBackSpace_KeyDown;
        }
        public static void ReadOnly(this TextBox textBox)
        {
            textBox.ReadOnly = true;
            textBox.TabStop = false;
        }
        public static void JustNumbers(this TextBox textBox)
        {
            textBox.KeyPress += justNumbers;
        }
        public static void justDecimalNumbers(this TextBox textBox)
        {
            textBox.KeyPress += justDecimalNumbers;
        }
        public static void JustAllowedChars(this TextBox textBox)
        {
            textBox.KeyPress += justAllowedChars;
        }
        public static void MaskCNPJ(this MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Mask = "00.000.000/0000-00";
        }
        public static void MaskCPF(this MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Mask = "000.000.000-00";
        }
        private static void justNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private static void justDecimalNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // permitir apenas um ponto decimal na entrada
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
        private static void justAllowedChars(object sender, KeyPressEventArgs e)
        {
            // Lista de caracteres permitidos (números, letras e controle como backspace)
            char[] allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._".ToCharArray();

            // Verifica se o caractere digitado não está na lista de permitidos
            if (!allowedChars.Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Impede a inserção do caractere
                e.Handled = true;
            }
        }
        private static void blockBackSpace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
        }


        //UHC 3 methods
        public static void readOnlyAll(Form form, bool condition)
        {
            foreach (var control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.ReadOnly = condition;
                }
            }
        }
        public static void clearAll()
        {
            try
            {
                foreach (var control in Form.ActiveForm.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txt = (TextBox)control;
                        txt.Text = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError("Function CustomTextBox.clearAll() " + ex.Message);
            }
        }
    }
}
