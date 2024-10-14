using System;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarCliente : CustomForm
    {
        /**Instance **/
        public string extendedCode { get; private set; }

        public frmConsultarCliente()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            //Events
            ConfigureFormEvents();
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmConsultarCliente_Load;
            this.KeyPreview = true; // Permitir que o formulário capture eventos de tecla globalmente
            this.KeyDown += frmConsultarCliente_KeyDown; // Evento de teclas no formulário
        }

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {
            //Pré load
            carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);

            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();
            ConfigureTextBoxEvents();
        }

        /** Função de carga **/
        private void carregarClientes(string text, DataGridView dataGridView)
        {
            try
            {
                dataGridView.DataSource = Clientes_Externos.getToDataTable(text);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dataGridView.toDefault();
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxEvents()
        {
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);
            }
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewEvents()
        {
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
        }

        // Função de redirecionamento de teclas para o DataGridView
        private void frmConsultarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se as teclas de seta para cima ou para baixo foram pressionadas
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Se o foco não está no DataGridView, redireciona para ele
                if (!dgvData.Focused)
                {
                    dgvData.Focus();
                    // Move a seleção dependendo da tecla
                    if (dgvData.Rows.Count > 0)
                    {
                        if (e.KeyCode == Keys.Up && dgvData.CurrentRow.Index > 0)
                        {
                            dgvData.CurrentCell = dgvData.Rows[dgvData.CurrentRow.Index - 1].Cells[0];
                        }
                        else if (e.KeyCode == Keys.Down && dgvData.CurrentRow.Index < dgvData.Rows.Count - 1)
                        {
                            dgvData.CurrentCell = dgvData.Rows[dgvData.CurrentRow.Index + 1].Cells[0];
                        }
                    }
                    e.Handled = true; // Prevenir comportamentos adicionais
                }
            }
        }

        // Atualizando o evento de duplo clique
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            SelecionarCliente();
        }

        // Atualizando o evento de KeyDown para incluir Enter
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelecionarCliente();
                e.Handled = true; // Para evitar comportamentos adicionais da tecla Enter
            }
        }

        // Função centralizada para seleção de cliente
        private void SelecionarCliente()
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
        }

        /** Button Configuration  **/
        private void ConfigureButtonProperties()
        {
            btnFechar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnPesquisar.Click += btnPesquisar_Click;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SelecionarCliente(); // Reaproveitando a lógica de seleção
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarClientes(txtPesquisar.Text.ToUpper(), dgvData);
        }
    }
}
