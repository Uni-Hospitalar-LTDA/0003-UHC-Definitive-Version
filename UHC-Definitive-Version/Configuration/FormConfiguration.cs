﻿using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public static class FormConfiguration
    {
        private static Bitmap cachedBackgroundImage = null;  // Armazena a imagem de fundo para reutilização

        public static void defaultFixedForm(this Form form)
        {
            form.MaximumSize = new Size(form.Width, form.Height);
            form.MinimumSize = new Size(form.Width, form.Height);            
            form.Text = $"{Section.Unidade}: " + form.Text;
            form.MaximizeBox = false;

        }
        public static void defaultMaximableForm(this Form form)
        {
            form.MinimumSize = new Size(form.Width, form.Height);
            form.Text = $"{Section.Unidade}: " + form.Text;
            form.WindowState = FormWindowState.Maximized;
        }
        public static void defaultMainMenu(this Form form)
        {
            form.MinimumSize = new Size(form.Width, form.Height);
            form.Text = $"UHC: " + form.Text;
        }
        public static void defaultModuleScreen(this Form form)
        {
            form.MinimumSize = new Size(form.Width, form.Height);
            form.Text = $"{Section.Unidade}: " + form.Text;

            // Carregar a imagem de fundo apenas uma vez
            if (cachedBackgroundImage == null)
            {
                cachedBackgroundImage = new Bitmap(Properties.Resources.Background_Office_Gray);  // Carrega a imagem de fundo apenas uma vez
            }

            form.BackgroundImage = cachedBackgroundImage;  // Reutiliza a imagem carregada
            form.BackgroundImageLayout = ImageLayout.Stretch;
            form.KeyPreview = true;
        }

        public static void ShowOrActivateFormInPanel<T>(Panel panel, string formName = "SubModule") where T : Form, new()
        {
            
            SuspendDrawing(panel);  // Suspend drawing
            panel.SuspendLayout();


            if (panel.Controls.ContainsKey(formName))
            {
                // O formulário já existe no painel, traga-o para frente
                panel.Controls[formName].BringToFront();

                // Se for o primeiro formulário, altere o plano de fundo para a cor padrão
                if (panel.Controls.Count == 1)
                {
                    Form frm = panel.Controls[formName] as Form;
                    frm.BackgroundImage = Properties.Resources.Background_Office_Gray;
                    frm.BackgroundImageLayout = ImageLayout.Stretch;
                    //frm.BackColor = SystemColors.Control; // Ou qualquer outra cor padrão
                }
            }
            else
            {
                // Crie uma nova instância do formulário e adicione-o ao painel
                T frm = new T();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Name = formName;
                panel.Controls.Add(frm);

                // Se for o primeiro formulário, use a imagem de fundo
                if (panel.Controls.Count != 1)
                {
                    // Carregar imagem de fundo de forma assíncrona (se necessário)
                    Task.Run(() =>
                    {
                        frm.BeginInvoke((MethodInvoker)delegate
                        {
                            frm.BackgroundImage = Properties.Resources.Background_Office_Gray;
                            frm.BackgroundImageLayout = ImageLayout.Stretch;

                        });
                    });
                }
                frm.BringToFront();
                frm.Show();


            }

            panel.ResumeLayout();
            ResumeDrawing(panel);  // Resume drawing

        }

        public static void ShowOrActivateForm<T>() where T : Form, new()
        {
            if (Application.OpenForms.OfType<T>().Count() > 0)
            {
                if (Application.OpenForms.OfType<T>().First().WindowState == FormWindowState.Minimized)
                {
                    Application.OpenForms.OfType<T>().First().WindowState = FormWindowState.Normal;
                    Application.OpenForms.OfType<T>().First().Focus();
                }
                else
                {
                    Application.OpenForms.OfType<T>().First().Focus();
                }
            }
            else
            {
                T frm = new T();
                frm.Show();
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        public static void SuspendDrawing(System.Windows.Forms.Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Invalidate();
        }
        public static void ResumeDrawing(System.Windows.Forms.Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private static Bitmap backgroundImage = new Bitmap(Properties.Resources.Background_Office_Gray);

        public static bool requiredInformationValidation(this Form form)
        {
            bool isValid = true;
            try
            {
                
                StringBuilder errorMessages = new StringBuilder();

                void ValidateControl(Control control)
                {
                    // Verifica se o controle é um contêiner que pode conter outros controles
                    if (control is Panel || control is GroupBox || control is TabPage || control is TableLayoutPanel || control is FlowLayoutPanel || control is SplitContainer)
                    {
                        // Caso seja um SplitContainer, verificamos os controles nos dois painéis
                        if (control is SplitContainer splitContainer)
                        {
                            ValidateControl(splitContainer.Panel1);
                            ValidateControl(splitContainer.Panel2);
                        }
                        else
                        {
                            // Itera sobre os controles filhos do contêiner
                            foreach (Control subControl in control.Controls)
                            {
                                ValidateControl(subControl);
                            }
                        }
                    }
                    else
                    {
                        // Verifica se o controle atual é um Label obrigatório
                        if (control is Label label && label.Name.StartsWith("lbl") && label.Text.EndsWith("*"))
                        {
                            string baseName = label.Name.Substring(3); // Remove o prefixo "lbl"
                            Control parent = label.Parent;

                            if (parent != null)
                            {
                                // Encontra o TextBox correspondente com o prefixo "txt"
                                Control correspondingTextBox = parent.Controls.Find("txt" + baseName, false).FirstOrDefault();

                                if (correspondingTextBox is TextBox textBox)
                                {
                                    // Verifica se o TextBox está vazio
                                    if (string.IsNullOrEmpty(textBox.Text))
                                    {
                                        isValid = false;
                                        errorMessages.AppendLine($"- O campo '{label.Text.TrimEnd('*')}' é obrigatório.");
                                    }
                                }
                            }
                        }
                    }
                }

                // Inicia a validação a partir dos controles do formulário principal
                foreach (Control control in form.Controls)
                {
                    ValidateControl(control);
                }

                if (!isValid)
                {
                    CustomNotification.defaultAlert(errorMessages.ToString(), "Validação");
                }
                return isValid;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError("Sem parâmetros definidos para validação: " + ex.Message);
                return isValid;
            }
            
        }

        public static void atribuirAtributosAosLabels(this Form form)
        {
            foreach (var obj in form.Controls)
            {
                if (obj is GroupBox)
                {
                    GroupBox gpb = (GroupBox)obj;
                    foreach (var obj_gpb in gpb.Controls)
                    {
                        if (obj_gpb is Label)
                        {
                            Label label = (Label)obj_gpb;
                            label.MouseHover += defaultMouseHover;
                            label.MouseLeave += defaultMouseLeave;
                        }
                    }
                }
            }
        }
        private static void defaultMouseHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            if (Form.ActiveForm != null)
                Form.ActiveForm.Cursor = Cursors.Hand;
        }
        private static void defaultMouseLeave(object sender, EventArgs e)
        {

            Label label = (Label)sender;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            if (Form.ActiveForm != null)
                Form.ActiveForm.Cursor = Cursors.Default;
        }
    }
}
