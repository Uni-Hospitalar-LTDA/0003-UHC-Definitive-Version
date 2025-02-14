using Screen = UHC3_Definitive_Version.Domain.Permissionamento.Screen;
using Action = UHC3_Definitive_Version.Domain.Permissionamento.Action;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Permissionamento;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.Opcoes.OpcoesDeDesenvolvedor
{
    public partial class frmPermissoes_Add : CustomForm
    {
        /** Instance **/
        internal string type { get; set; }
        public frmPermissoes_Add()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private async Task saveAsync(string type)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                CustomNotification.defaultAlert("O campo de descrição não pode estar vazio.");
                return;
            }


            if (type == "Module")
            {
                List<Module> module = new List<Module>
                                    {
                                        new Module
                                        {
                                            Name = txtDescricao.Text,
                                            Description = txtObservacao.Text
                                        }
                                    };
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await Module.insertAsync(module);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }

            }
            else if (type == "SubModule")
            {
                if (string.IsNullOrEmpty(txtDescricaoMae.Text))
                {
                    CustomNotification.defaultAlert($"O campo de {"Módulo"} não pode estar vazio.");
                    return;
                }
                List<SubModule> submodule = new List<SubModule>
                                    {
                                        new SubModule
                                        {
                                            Name = txtDescricao.Text,
                                            Description = txtObservacao.Text,
                                            idModule = txtIdMae.Text
                                        }
                                    };
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await SubModule.insertAsync(submodule);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }

            }
            else if (type == "Screen")
            {
                if (string.IsNullOrEmpty(txtDescricaoMae.Text))
                {
                    CustomNotification.defaultAlert($"O campo de {"SubModulo"} não pode estar vazio.");
                    return;
                }
                List<Screen> screen = new List<Screen>
                                    {
                                        new Screen
                                        {
                                            Name = txtDescricao.Text,
                                            Description = txtObservacao.Text,
                                            idSubModule = txtIdMae.Text
                                        }
                                    };
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await Screen.insertAsync(screen);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtDescricaoMae.Text))
                {
                    CustomNotification.defaultAlert($"O campo de {"tela"} não pode estar vazio.");
                    return;
                }
                List<Action> action = new List<Action>
                                    {
                                        new Action
                                        {
                                            Name = txtDescricao.Text,
                                            Description = txtObservacao.Text,
                                            idScreen = txtIdMae.Text
                                        }
                                    };
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await Action.insertAsync(action);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    CustomNotification.defaultError(ex.Message);
                }
            }


            CustomNotification.defaultInformation($"O registro de permissão ({type}) foi inserido com sucesso!");

            if (CustomNotification.defaultQuestionAlert($"Deseja inserir outro {type}?") == DialogResult.No)
                this.Close();
        }

        /** Sync Methods **/
        private void PropriedadesIniciaisTela(string type)
        {
            switch (type)
            {
                case "Module":
                    lblFilhoDe.Visible = false;
                    txtDescricaoMae.Visible = false;
                    txtIdMae.Visible = false;
                    btnMaisMae.Visible = false;
                    btnMaisMae.Visible = false;
                    break;
                case "SubModule":
                    lblFilhoDe.Text = "Filho de: " + "(Modulo)";
                    break;
                case "Screen":
                    lblFilhoDe.Text = "Filho de: " + "(SubModulo)";
                    break;
                case "Action":
                    lblFilhoDe.Text = "Filho de: " + "(Tela)";
                    break;
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmPermissoes_Add_Load;
        }
        private void frmPermissoes_Add_Load(object sender, EventArgs e)
        {
            //Attributes


            //Properties
            PropriedadesIniciaisTela(type);

            //Events
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
        }


        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtIdMae.JustNumbers();
            txtIdMae.MaxLength = 6;
            txtDescricaoMae.ReadOnly();
        }
        private void ConfigureTextBoxEvents()
        {
            txtIdMae.TextChanged += txtIdMae_TextChanged;
        }

        private async void txtIdMae_TextChanged(object sender, EventArgs e)
        {
            if (type == "SubModule")
            {
                txtDescricaoMae.Text = (await Module.getToClassAsync(txtIdMae.Text)).Name;
            }
            else if (type == "Screen")
            {
                txtDescricaoMae.Text = (await SubModule.getToClassAsync(txtIdMae.Text)).Name;
            }
            else if (type == "Action")
            {
                txtDescricaoMae.Text = (await Screen.getToClassAsync(txtIdMae.Text)).Name;
            }
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnMaisMae.Click += btnMaisMae_Click;
            btnSalvar.Click += btnSalvar_Click;
        }
        private async void btnMaisMae_Click(object sender, EventArgs e)
        {
            if (type == "SubModule")
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await Module.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.elemento = "Módulo";
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtIdMae.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (type == "Screen")
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await SubModule.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.elemento = "SubMódulo";
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtIdMae.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (type == "Action")
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await Screen.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.elemento = "Tela";
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtIdMae.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync(type);
        }


    }
}
