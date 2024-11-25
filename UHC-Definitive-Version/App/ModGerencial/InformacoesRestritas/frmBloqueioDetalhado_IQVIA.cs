using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.App.Telas_Genericas;


namespace UHC3_Definitive_Version.ModGerencial.Controladoria
{
    public partial class frmBloqueioDetalhado_IQVIA : CustomForm
    {
        /** Screen Permissions **/
        public frmBloqueioDetalhado_IQVIA()
        {
            InitializeComponent();
            this.defaultFixedForm();

            //dgvProduto.CellValidating += dataGridView_CellValidating;
            //dgvNF.CellValidating += dataGridView_CellValidating;
            //dgvFabricante.CellValidating += dataGridView_CellValidating;
            //dgvCliente.CellValidating += dataGridView_CellValidating;
        }


        /** Internal Instance **/
        List<Iqvia_DetailedBlocks> blocks = new List<Iqvia_DetailedBlocks>();
        internal List<Iqvia_Panel> panel = new List<Iqvia_Panel>();


        /** Load Event **/
        private async void frmBloqueioDetalhado_Load(object sender, EventArgs e)
        {
            btnConsultar.Visible = true;
            await carregarBlocks(panel[0].id);
            lblTitle.Text = $"Bloqueios baseados no layout {panel[0].id} - {panel[0].description} - {panel[0].day}";
            foreach (var item in panel)
            {
                lsbLayousAssociados.Items.Add($"{item.id} - {item.description} - {item.day}");
            }


        }


        /** Tasks **/
        private async Task carregarBlocks(string id)
        {
            blocks = await Iqvia_DetailedBlocks.getAllToListAsync(id);
            dgvCliente.toDefault();

            dataGridView_configurationDefault(dgvCliente);
            dgvCliente.Columns.Add("id", "Código");
            dgvCliente.Columns.Add("cnpj", "CNPJ");
            dgvCliente.Columns.Add("descricao", "Descrição");
            dgvCliente.Columns["descricao"].ReadOnly = true;
            dgvCliente.Columns["cnpj"].ReadOnly = true;

            var select_Cliente = from cBlock in blocks
                                 where cBlock.TypeBlock.Equals("C")
                                 select new { cBlock };
            foreach (var block in select_Cliente)
            {
                dgvCliente.Rows.Add(
                     block.cBlock.external_Code
                    , Clientes_Externos.clientes.Find(c => c.codigo == block.cBlock.external_Code).cgc_cpf
                    , Clientes_Externos.clientes.Find(c => c.codigo == block.cBlock.external_Code).razao_social
                    );
            }


            dataGridView_configurationDefault(dgvProduto);
            dgvProduto.Columns.Add("id", "Código");
            dgvProduto.Columns.Add("cod_EAN", "EAN");
            dgvProduto.Columns.Add("descricao", "Descrição");
            dgvProduto.Columns["cod_EAN"].ReadOnly = true;
            dgvProduto.Columns["descricao"].ReadOnly = true;

            var select_Produto = from cBlock in blocks
                                 where cBlock.TypeBlock.Equals("P")
                                 select new { cBlock };
            foreach (var block in select_Produto)
            {
                dgvProduto.Rows.Add(
                     block.cBlock.external_Code
                    , Produtos_Externos.produtos.Find(p => p.codigo == block.cBlock.external_Code).cod_EAN
                    , Produtos_Externos.produtos.Find(p => p.codigo == block.cBlock.external_Code).descricao
                    );
            }

            dataGridView_configurationDefault(dgvFabricante);
            dgvFabricante.Columns.Add("id", "Código");
            dgvFabricante.Columns.Add("descricao", "Descrição");
            dgvFabricante.Columns["descricao"].ReadOnly = true;

            var select_Fabricante = from cBlock in blocks
                                    where cBlock.TypeBlock.Equals("F")
                                    select new { cBlock };
            foreach (var block in select_Fabricante)
            {
                dgvFabricante.Rows.Add(
                     block.cBlock.external_Code
                    , Fabricantes_Externos.fabricantes.Find(f => f.codigo == block.cBlock.external_Code).Fantasia
                    );
            }

            dataGridView_configurationDefault(dgvNF);
            dgvNF.Columns.Add("id", "Nota Fiscal");
            dgvNF.Columns.Add("cod_cliente", "Código Cliente");
            dgvNF.Columns.Add("descricao", "Descrição");
            dgvNF.Columns["cod_cliente"].ReadOnly = true;
            dgvNF.Columns["descricao"].ReadOnly = true;

            var select_NF = from cBlock in blocks
                            where cBlock.TypeBlock.Equals("N")
                            select new { cBlock };
            foreach (var block in select_NF)
            {
                ExternalNF nf = await ExternalNF.getToClassAsync(block.cBlock.external_Code);
                Clientes_Externos cliente = Clientes_Externos.clientes?.Where(c => c.codigo.Equals(nf?.Cod_Cliente)).FirstOrDefault();
                dgvNF.Rows.Add(block.cBlock.external_Code, cliente.codigo, cliente.razao_social);
            }


        }
        private async Task salvarBloqueio()
        {
            List<Iqvia_DetailedBlocks> detailedBlocks = new List<Iqvia_DetailedBlocks>();


            foreach (var item in panel)
            {
                await Iqvia_DetailedBlocks.deleteAsync(item.id);
                foreach (DataGridViewRow row in dgvCliente.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != null)
                    {
                        detailedBlocks.Add(new Iqvia_DetailedBlocks { id_Panel = item.id, TypeBlock = "C", external_Code = row.Cells[0].Value.ToString() });
                    }
                }
                foreach (DataGridViewRow row in dgvProduto.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != null)
                    {
                        detailedBlocks.Add(new Iqvia_DetailedBlocks { id_Panel = item.id, TypeBlock = "P", external_Code = row.Cells[0].Value.ToString() });
                    }
                }
                foreach (DataGridViewRow row in dgvFabricante.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != null)
                    {
                        detailedBlocks.Add(new Iqvia_DetailedBlocks { id_Panel = item.id, TypeBlock = "F", external_Code = row.Cells[0].Value.ToString() });
                    }
                }
                foreach (DataGridViewRow row in dgvNF.Rows)
                {
                    if (row.Cells[0].Value?.ToString() != null)
                    {
                        detailedBlocks.Add(new Iqvia_DetailedBlocks { id_Panel = item.id, TypeBlock = "N", external_Code = row.Cells[0].Value.ToString() });
                    }
                }
            }

            await Iqvia_DetailedBlocks.insertAsync(detailedBlocks);

            foreach (var item in panel)
            {
                await Iqvia_Panel.updateHasBlock(item.id);
            }

        }


        /** Configurations Components **/       
        private void dataGridView_configurationDefault(DataGridView _dgv)
        {
            _dgv.toDefault();
            _dgv.AllowUserToAddRows = true;
            _dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            _dgv.ReadOnly = false;
            _dgv.Rows.Clear();
            _dgv.Columns.Clear();            
            dataGridView_getResults(_dgv);
        }
        private void dataGridView_getResults(DataGridView _dgv)
        {
            _dgv.CellEndEdit += dataGridView_CellEndOfEdit;
            _dgv.KeyDown += dataGridView_delete;
        }
        private void dataGridView_delete(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {                
                DataGridView _dgv = (DataGridView)sender;                
                _dgv.Rows.Remove(_dgv.CurrentRow);
            }
        }
        private async void dataGridView_CellEndOfEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView _dgv = (DataGridView)sender;
            try
            {
                if (_dgv.CurrentRow.Cells[0].Selected)
                {
                    if (tabBloqueios.SelectedTab.Text.Equals("Cliente"))
                    {
                        Clientes_Externos cliente = Clientes_Externos.clientes.Find(c => c.codigo.Equals(_dgv.CurrentRow.Cells["id"].Value?.ToString()));
                        if (cliente != null)
                        {
                            _dgv.CurrentRow.Cells["CNPJ"].Value = cliente.cgc_cpf.ConvertToCNPJ();
                            _dgv.CurrentRow.Cells["descricao"].Value = cliente.razao_social;
                        }
                        else
                        {
                            _dgv.Rows.Remove(_dgv.CurrentRow);
                        }
                    }
                    else if (tabBloqueios.SelectedTab.Text.Equals("Produto"))
                    {
                        Produtos_Externos produto = Produtos_Externos.produtos.Find(p => p.codigo.Equals(_dgv.CurrentRow.Cells["id"].Value?.ToString()));
                        if (produto != null)
                        {
                            _dgv.CurrentRow.Cells["cod_EAN"].Value = produto.cod_EAN;
                            _dgv.CurrentRow.Cells["descricao"].Value = produto.descricao;
                        }
                        else
                        {
                            _dgv.Rows.Remove(_dgv.CurrentRow);
                        }
                    }
                    else if (tabBloqueios.SelectedTab.Text.Equals("Fabricante"))
                    {
                        Fabricantes_Externos fabricante = Fabricantes_Externos.fabricantes.Find(f => f.codigo.Equals(_dgv.CurrentRow.Cells["id"].Value?.ToString()));
                        if (fabricante != null)
                        {
                            _dgv.CurrentRow.Cells["descricao"].Value = fabricante.Fantasia;
                        }
                        else
                        {
                            _dgv.Rows.Remove(_dgv.CurrentRow);
                        }

                    }
                    else if (tabBloqueios.SelectedTab.Text.Equals("NF"))
                    {
                        ExternalNF nf = await ExternalNF.getToClassAsync(_dgv.CurrentRow.Cells[0].Value?.ToString());
                        if (nf != null)
                        {

                            Clientes_Externos cliente = Clientes_Externos.clientes?.Where(c => c.codigo.Equals(nf?.Cod_Cliente)).FirstOrDefault();
                            _dgv.CurrentRow.Cells["cod_cliente"].Value = cliente?.codigo;
                            _dgv.CurrentRow.Cells["descricao"].Value = cliente?.razao_social;
                        }
                        else
                        {
                            _dgv.Rows.Remove(_dgv.CurrentRow);
                        }

                    }
                }
            }
            catch
            {
                _dgv.CurrentRow.Cells[0].Value = null;
            }
            finally
            {
                _dgv.AutoResizeColumns();
            }
        }
        private async void lsbLayousAssociados_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lsb = (ListBox)sender;
            if (lsb.SelectedItem != null)
            {
                await carregarBlocks(panel[lsb.SelectedIndex].id);
                lblTitle.Text = $"Bloqueios baseados no layout {panel[lsb.SelectedIndex].id} - {panel[lsb.SelectedIndex].description} - {panel[lsb.SelectedIndex].day}";
            }
        }
        private void tabBloqueios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBloqueios.SelectedTab.Text.Equals("Fabricante"))
            {
                //btnConsultar.Visible = true;
            }           

            else if (tabBloqueios.SelectedTab.Text.Equals("NF"))
            {
                //btnConsultar.Visible = true;
            }
            else
            {
                //btnConsultar.Visible = false;
            }
        }
        private void dgvNF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabBloqueios.SelectedTab.Text.Equals("NF"))
            {
                int nfInt;
                if (int.TryParse(dgvNF.CurrentRow.Cells[0].Value?.ToString(), out nfInt))
                {
                    // o valor é um número inteiro, a saída será "V"
                    //Console.WriteLine("V");
                    frmConsultarNF frmConsultarNF = new frmConsultarNF();
                    frmConsultarNF.nf = dgvNF.CurrentRow.Cells[0].Value?.ToString();
                    frmConsultarNF.ShowDialog();
                }
                else
                {
                    // o valor não é um número inteiro, a saída será ignorada
                    Console.WriteLine("Valor não é um número de NF válido.");
                }


                

            }

        }


        //** System Buttons **//
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                await salvarBloqueio();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                CustomNotification.defaultInformation();
            }
        }                
        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {


                if (tabBloqueios.SelectedTab.Text == "Fabricante")
                {
                    frmConsultarFabricante frmConsultarFabricante = new frmConsultarFabricante();
                    frmConsultarFabricante.ShowDialog();
                    Fabricantes_Externos fabricante = Fabricantes_Externos.getDescriptionByCode(frmConsultarFabricante.extendedCode);
                    dgvFabricante.Rows.Add(fabricante.codigo, fabricante.Fantasia);
                }
                else if (tabBloqueios.SelectedTab.Text == "Produto")
                {
                    frmConsultarProduto frmConsultarProduto = new frmConsultarProduto();
                    frmConsultarProduto.ShowDialog();
                    Produtos_Externos produto = Produtos_Externos.getProductByCode(frmConsultarProduto.extendedCode);
                    dgvProduto.Rows.Add(produto.codigo, produto.descricao);
                }
                else if (tabBloqueios.SelectedTab.Text == "Cliente")
                {
                    frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
                    frmConsultarCliente.ShowDialog();
                    Clientes_Externos cliente = Clientes_Externos.getClienteByCode(frmConsultarCliente.extendedCode);
                    dgvCliente.Rows.Add(cliente.codigo, cliente.razao_social);
                }
                else if (tabBloqueios.SelectedTab.Text == "NF")
                {
                    frmConsultarNF frmConsultarNF = new frmConsultarNF();
                    frmConsultarNF.ShowDialog();
                    if (frmConsultarNF.nf != null)
                    {
                        ExternalNF nf = await ExternalNF.getToClassAsync(frmConsultarNF.nf);
                        Clientes_Externos cliente = Clientes_Externos.clientes?.Where(c => c.codigo.Equals(nf?.Cod_Cliente)).FirstOrDefault();
                        dgvNF.Rows.Add(frmConsultarNF.nf, cliente.codigo, cliente.razao_social);
                    }

                }
            }
            catch (Exception)
            {

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes) this.Close();
        }
      
    }
}


