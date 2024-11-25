using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModLicitacao.Cadastro
{
    public partial class frmCadastrarJustificativasDeParticipacao : CustomForm
    {

        /** Instance **/
        int? saveMode; //0 == Adicionar / 1 == Editar 
        public frmCadastrarJustificativasDeParticipacao()
        {
            InitializeComponent();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();



            ConfigureFormEvents();

        }

        /** Async Tasks **/
        private async Task getJustifies()
        {
            dgvData.DataSource = await ProcessScheduleJustify.getAllToDataTableAsync();
        }
        private async Task saveAsync()
        {
            try
            {
                List<ProcessScheduleJustify> justifies = new List<ProcessScheduleJustify>();
                justifies.Add(new ProcessScheduleJustify()
                {
                    description = txtJustify.Text
                });

                await ProcessScheduleJustify.insertMultiUnityAsync(justifies, "UNI HOSPITALAR");
                await ProcessScheduleJustify.insertMultiUnityAsync(justifies, "UNI CEARÁ");
                await ProcessScheduleJustify.insertMultiUnityAsync(justifies, "SP HOSPITALAR");
                CustomNotification.defaultInformation();

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                btnEdit_Click(btnAdd, new EventArgs());
            }

        }
        private async Task editAsync()
        {
            try
            {
                var justify = (new ProcessScheduleJustify()
                {
                    id = txtId.Text,
                    description = txtJustify.Text
                });
                await ProcessScheduleJustify.updateAsync(justify, "UNI HOSPITALAR");
                await ProcessScheduleJustify.updateAsync(justify, "UNI CEARÁ");
                await ProcessScheduleJustify.updateAsync(justify, "SP HOSPITALAR");
                CustomNotification.defaultInformation();

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                btnEdit_Click(btnAdd, new EventArgs());
            }
        }
        private async Task deleteAsync()
        {
            try
            {
                if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
                {

                    var justify = (new ProcessScheduleJustify()
                    {
                        id = txtId.Text,
                        description = txtJustify.Text
                    });

                    await ProcessScheduleJustify.deleteAsync(justify, "UNI HOSPITALAR");
                    await ProcessScheduleJustify.deleteAsync(justify, "UNI CEARÁ");
                    await ProcessScheduleJustify.deleteAsync(justify, "SP HOSPITALAR");
                    CustomNotification.defaultInformation();
                }

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                btnEdit_Click(btnAdd, new EventArgs());
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastrarJustificativasDeParticipacao_Load;
        }
        private async void frmCadastrarJustificativasDeParticipacao_Load(object sender, EventArgs e)
        {
            await getJustifies();

            ConfigureTextBoxAttributes();






            ConfigureButtonEvents();
        }

        /** Configure TextBox **/

        private void ConfigureTextBoxProperties()
        {
            txtId.ReadOnly = true;
            txtId.TabStop = false;
            txtJustify.ReadOnly = true;
            txtJustify.TabStop = false;
        }
        private void ConfigureTextBoxAttributes()
        {

        }
        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
            btnRemove.Visible = false;
        }
        private void ConfigureButtonEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnRemove.Click += btnRemove_Click;
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await deleteAsync();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Editar")
            {
                if (dgvData.CurrentRow == null)
                {
                    CustomNotification.defaultAlert("Selecione algum registro para alterar");
                    return;
                }

                txtId.Text = dgvData.CurrentRow.Cells[0].Value.ToString();
                txtJustify.Text = dgvData.CurrentRow.Cells[1].Value.ToString();
                btnEdit.Text = "Cancelar";
                btnAdd.Text = "Salvar";
                saveMode = 1;
                btnRemove.Visible = true;
                txtJustify.ReadOnly = false;
                txtJustify.TabStop = true;
            }
            else if (btnEdit.Text == "Cancelar")
            {
                btnEdit.Text = "Editar";
                btnAdd.Text = "Adicionar";
                txtId.Text = string.Empty;
                txtJustify.Text = string.Empty;
                txtJustify.ReadOnly = !false;
                txtJustify.TabStop = !true;
                btnRemove.Visible = false;
                saveMode = null;
                await getJustifies();
                dgvData.AutoResizeColumns();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (btnAdd.Text == "Adicionar")
            {
                saveMode = 0;
                btnEdit.Text = "Cancelar";
                btnAdd.Text = "Salvar";
                txtId.Text = (await ProcessScheduleJustify.getNextCodeAsync()).ToString();
                txtJustify.ReadOnly = false;
                txtJustify.TabStop = true;
            }

            else if (btnAdd.Text == "Salvar")
            {
                if (saveMode.HasValue)
                {
                    if (string.IsNullOrEmpty(txtJustify.Text.Trim()))
                    {
                        CustomNotification.defaultAlert("A justificativa não pode estar vazia!");
                        return;
                    }

                    if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
                    {

                        if (saveMode == 0)
                            await saveAsync();
                        else
                            await editAsync();
                    }
                }
            }
        }

        /** Configure DataGridView **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
