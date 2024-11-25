using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarFabricante : CustomForm
    {
        public frmConsultarFabricante()
        {
            InitializeComponent();
            this.defaultFixedForm();

            // Configurações de eventos
            this.Load += frmConsultarFabricante_Load;
            this.KeyPreview = true; // Permitir que o formulário capture eventos de tecla globalmente
            this.KeyDown += frmConsultarFabricante_KeyDown; // Evento de teclas global

            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
            dgvData.DoubleClick += dgvData_DoubleClick;
            dgvData.KeyDown += dgvData_KeyDown;
            btnPesquisar.Click += btnPesquisar_Click;
            btnFechar.Click += btnFechar_Click;
            btnSalvar.Click += btnSalvar_Click;
        }

        /** Instance **/
        public string extendedCode;

        /** Load do form **/
        private void frmConsultarFabricante_Load(object sender, EventArgs e)
        {
            carregarFabricantes(txtPesquisar.Text.ToUpper());
        }

        /** Função de carga **/
        private void carregarFabricantes(string text)
        {
            try
            {
                if (Fabricantes_Externos.fabricantes.Count == 0)
                {
                    dgvData.DataSource = Fabricantes_Externos.getToDataTable(text);
                }
                else
                {
                    dgvData.DataSource = Fabricantes_Externos.getToDataTable(text);
                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                dgvData.toDefault();
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        /** Redirecionar teclas de navegação e Enter para o DataGridView **/
        private void frmConsultarFabricante_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Enter)
            {
                // Se o Enter for pressionado fora do DataGridView, redireciona para selecionar o item
                if (!dgvData.Focused && dgvData.CurrentRow != null)
                {
                    SelecionarFabricante();
                    e.Handled = true;
                }
            }
        }

        /** Funções dos componentes internos **/
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                carregarFabricantes(txtPesquisar.Text.ToUpper());
            }
        }

        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            SelecionarFabricante();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvData.CurrentRow != null)
            {
                SelecionarFabricante();
                e.Handled = true; // Prevenir comportamentos adicionais
            }
        }

        /** Função de seleção de fabricante **/
        private void SelecionarFabricante()
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
        }

        /** Buttons **/
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarFabricantes(txtPesquisar.Text.ToUpper());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            extendedCode = "0";
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SelecionarFabricante();
        }
    }
}
