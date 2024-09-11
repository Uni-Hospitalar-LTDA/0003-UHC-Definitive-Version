using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarNF : CustomForm
    {
        internal string nf;

        public frmConsultarNF()
        {
            InitializeComponent();
            this.defaultFixedForm();
            this.Load += frmConsultarNF_Load;
        }


        private async Task carregarCabeçalhoNF(string nf)
        {
            if (!nf.Trim().Equals(string.Empty))
            {
                ExternalNF eNF = await ExternalNF.getToClassAsync(nf);
                txtEmissao.Text = Convert.ToDateTime(eNF?.DataEmissao).ToString("dd/MM/yyyy");
                txtCodCFOP.Text = eNF?.Cfop;
                txtCFOP.Text = eNF?.DescricaoCfop;
                txtCodTipo.Text = eNF?.Tipo;
                txtTipo.Text = eNF?.DescricaoTipo;
                txtValorNota.Text = Convert.ToDouble(eNF?.valorNota).ToString("C");
                Clientes_Externos cliente = Clientes_Externos.clientes?.Where(c => c.codigo.Equals(eNF?.Cod_Cliente)).FirstOrDefault();
                txtCodCliente.Text = cliente?.codigo;
                txtCliente.Text = cliente?.razao_social;
                txtCNPJ.Text = cliente?.cgc_cpf.ConvertToCNPJ();
                txtEsferaCliente.Text = cliente?.esfera_Cliente;
                dgvData.DataSource = await ExternalNF.getProductsToDataTableAsync(nf);
                dgvData.toDefault();
                dgvData.Columns[0].ValueType = typeof(int);
                dgvData.Columns[dgvData.ColumnCount - 1].ValueType = typeof(double);
                dgvData.Columns[dgvData.ColumnCount - 1].DefaultCellStyle.Format = "R$ #,##0.00";
                dgvData.Columns[dgvData.ColumnCount - 2].ValueType = typeof(double);
                dgvData.Columns[dgvData.ColumnCount - 2].DefaultCellStyle.Format = "R$ #,##0.00";
            }
            else
            {
                txtCodCFOP.Text = string.Empty;
                txtEmissao.Text = string.Empty;
                txtValorNota.Text = string.Empty;
                txtCFOP.Text = string.Empty;
                txtCodTipo.Text = string.Empty;
                txtTipo.Text = string.Empty;
                txtCodCliente.Text = string.Empty;
                txtCliente.Text = string.Empty;
                txtCNPJ.Text = string.Empty;
                txtEsferaCliente.Text = string.Empty;
                dgvData.DataSource = null;
            }
        }

        private void frmConsultarNF_Load(object sender, EventArgs e)
        {
            /** Configurações Iniciais dos Campos **/
            txtNF.Text = nf;
            txtEmissao.ReadOnly = true;
            txtCodCFOP.ReadOnly = true;
            txtCFOP.ReadOnly = true;
            txtCodTipo.ReadOnly = true;
            txtTipo.ReadOnly = true;
            txtValorNota.ReadOnly = true;
            txtCodCliente.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtCNPJ.ReadOnly = true;
            txtEsferaCliente.ReadOnly = true;

            txtEmissao.TabStop = false;
            txtCodCFOP.TabStop = false;
            txtCFOP.TabStop = false;
            txtCodTipo.TabStop = false;
            txtTipo.TabStop = false;
            txtValorNota.TabStop = false;
            txtCodCliente.TabStop = false;
            txtCliente.TabStop = false;
            txtCNPJ.TabStop = false;
            txtEsferaCliente.TabStop = false;

            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }

        /** Configure TextBox**/
        private void ConfigureTextBoxEvents()
        {
            txtNF.TextChanged += txtNF_TextChanged;
        }

        private async void txtNF_TextChanged(object sender, EventArgs e)
        {
            await carregarCabeçalhoNF(txtNF.Text);
        }


        /** Configure Button **/
        private void ConfigureButtonEvents()
        {
            btnFechar.Click += btnFechar_Click;
            btnSalvar.Click += btnSalvar_Click;
        }
        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            nf = string.Empty;
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            nf = txtNF.Text;
            this.Close();
        }
    }
}
