using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.Telas_Genericas
{
    public partial class frmConsultarProduto : CustomForm
    {
        public frmConsultarProduto()
        {
            InitializeComponent();
            this.defaultFixedForm();
            //txtPesquisar.TextChanged += btnPesquisar_Click;
            ConfigureFormEvents();

        }

        /** Instance **/

        public string extendedCode;
        //private CancellationTokenSource cancellationTokenSource;


        /** Load do form **/

        private void ConfigureFormEvents()
        {
            this.Load += frmConsultarProduto_Load;
            
        }
        private void frmConsultarProduto_Load(object sender, EventArgs e)
        {

            carregarProdutos(txtPesquisar.Text.ToUpper(), dgvData);


            ConfigureButtonEvents();

        }        

        /** Funçoes de carga **/
        private void configurarGrid(DataGridView dataGridView)
        {
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("codProduto", "Cód. Produto");
                dataGridView.Columns.Add("descProduto", "Produto");
                dataGridView.Columns.Add("codEAN", "EAN");
                dataGridView.Columns.Add("codFabricante", "Cód. Fabricante");
                dataGridView.Columns.Add("descFabricante", "Fabricante");
                dataGridView.toDefault();
            }
        }
        private void carregarProdutos(string text, DataGridView dataGridView)
        {
            configurarGrid(dataGridView);
            dataGridView.SuspendLayout();
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Rows.Clear();
            }
            var select = from produto in Produtos_Externos.getToListByFilter(text)
                         join fabricante in Fabricantes_Externos.fabricantes on produto.Cod_Fabricante equals fabricante.codigo
                         where produto.descricao.Contains(text)
                         select new { produto, fabricante };

            foreach (var linha in select)
            {
                dataGridView.Rows.Add(linha.produto.codigo, linha.produto.descricao, linha.produto.cod_EAN, linha.fabricante.codigo, linha.fabricante.Fantasia);
            }

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoResizeColumns();
            dataGridView.ResumeLayout();
        }

        /** Funções dos componentes internos **/
        private void DataGridViewEvents()
        {
            dgvData.KeyDown += dgvData_KeyDown;
            dgvData.DoubleClick += dgvData_DoubleClick;
            txtPesquisar.KeyDown += txtPesquisar_KeyDown;
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
        }
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                }
            }
        }
        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                carregarProdutos(txtPesquisar.Text.ToUpper(), dgvData);
            }
        }

        /** Buttons **/
        private void ConfigureButtonEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            btnSalvar.Click += btnSalvar_Click;
            btnFechar.Click += btnFechar_Click;
        }

        

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarProdutos(txtPesquisar.Text.ToUpper(), dgvData);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                extendedCode = dgvData.CurrentRow.Cells[0].Value.ToString();
            }
            this.Close();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            extendedCode = "0";
            this.Close();
        }


    }
}
