using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using static UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros.frmMonitores_ExpXmlGnre_Obs;

namespace UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros
{
    public partial class frmMonitores_ExpXmlGnre : CustomForm
    {
        /** Instance  **/
        List<int> NFtoObsIndex = new List<int>();
        ObservableDictionary<int, string> NFtoExportDictionary = new ObservableDictionary<int, string>();
        internal class GNRE : Querys<GNRE>
        {
            public static async Task<System.Data.DataTable> getAllToDataTableAsync(DateTime inicialDate, DateTime finalDate, string NF,
                string cliente, string UF, string bloqueio, string exportacao)
            {
                // A var condition faz referência a condição selecionada do combo box
                int nfFilter = 0;
                if (!string.IsNullOrEmpty(NF))
                {
                    nfFilter = 1;
                }

                //Setado como -1 pela condicional ser booleana
                int blockFilter = -1;
                if (bloqueio == "Todos")
                    blockFilter = -1;
                else if (bloqueio == "Sim")
                    blockFilter = 1;
                else
                    blockFilter = 0;



                int exportFilter = -1;
                if (exportacao == "Todos")
                    exportFilter = -1;
                else if (exportacao == "Sim")
                    exportFilter = 1;
                else
                    exportFilter = 0;

                string query = $@"
        SELECT										
		  isnull(Monitor_GNRE.flg_BloqExport,0)	[Block]
		 ,NF_Saida.Num_Nota						[NF]       
		 ,Cliente.CODIGO						[Cod_Cliente] 
		 ,Cliente.Razao_Social					[Cliente] 
		 ,NF_Saida.Estado						[Estado] 
		 ,TBCFO.Descricao						[CFOP] 
		 ,Convert(Date, NF_Saida.Dat_Emissao)	[Dat_Emissao] 
		 ,isnull(NF_Saida.Vlr_TotalNota, 0)		[Vlr_Nota] 
		 ,isnull(NF_Saida.Vlr_IcmIntUfDes, 0)	[Vlr_GNRE] 
		 ,isnull(NF_Saida.Vlr_IcmFCPUfDes, 0)	[Vlr_FCP] 
		 ,Monitor_GNRE.Data_Bloqueio				[Dat_Bloqueio] 
		 ,Monitor_GNRE.Data_Exportacao			[Dat_Export] 
		 ,Monitor_GNRE.Observacao					[Observacao]		 
         ,Estado.Credenciamento [Credenciamento]
		 FROM       [{Connection.dbDMD}].dbo.[NFSCB] NF_Saida
		 INNER JOIN [{Connection.dbDMD}].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente 		 
		 INNER JOIN [{Connection.dbDMD}].dbo.[TBCFO] ON Cod_Cfo1 = TBCFO.Codigo 
         INNER JOIN [{Connection.dbDMD}].dbo.[ESTAD] Estado ON Estado.Codigo = NF_Saida.Estado
         LEFT JOIN [{Connection.dbBase}].dbo.[MonitorGnre] Monitor_GNRE ON Monitor_GNRE.NUM_NOTA = NF_Saida.NUM_NOTA 
		 WHERE (STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')
		 AND  (NF_Saida.Dat_Emissao BETWEEN '{inicialDate.ToString("yyyyMMdd")}' AND '{finalDate.ToString("yyyyMMdd")}') 
		 AND  (Cliente.Razao_Social LIKE '%{cliente}')            
         AND (Cliente.Cod_Estado LIKE '%{UF}')		 
         AND ( 1 = {nfFilter} AND NF_Saida.Num_Nota = '{NF}' OR 0={nfFilter})
         AND ( isnull(flg_BloqExport,0) = {blockFilter} OR -1 = {blockFilter})                  
         AND ((1 = {exportFilter} AND Data_Exportacao is not null) OR (0 = {exportFilter} AND Data_Exportacao is null) OR -1 = {exportFilter})       
         AND (Cliente.Cod_Estado NOT IN (SELECT Codigo FROM [{Connection.dbDMD}].dbo.[ESTAD] Estados 
                                         WHERE LEN(Credenciamento) > 4))
        AND NF_Saida.Vlr_IcmIntUfDes > 0

         ";
                Console.WriteLine(query);
                return await getAllToDataTable(query);
            }
            public static async Task<List<string>> getEstadosBloqueadosAsync()
            {

                List<string> EstadosBloqueados = new List<string>();
                using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT  DISTINCT [Bloqueados] = Codigo	
                                             FROM [{Connection.dbDMD}].dbo.[ESTAD] Estado
                                             WHERE Credenciamento LIKE '.' ";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Bloqueados"] != null)
                        {
                            EstadosBloqueados.Add(reader["Bloqueados"].ToString());
                        }
                    }
                }

                return EstadosBloqueados;
            }
            public static async Task<List<string>> getEstadosCredenciadosAsync()
            {
                List<string> EstadosCredenciados = new List<string>();
                using (SqlConnection conn = new Connection().getConnectionApp(Section.Unidade))
                {
                    await conn.OpenAsync();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = $@"SELECT  DISTINCT [Credenciados] = Codigo	
                                             FROM [{Connection.dbDMD}].dbo.[ESTAD] Estado
                                             WHERE LEN(Credenciamento) > 4";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Credenciados"] != null)
                        {
                            EstadosCredenciados.Add(reader["Credenciados"].ToString());
                        }
                    }
                }
                return EstadosCredenciados;
            }

        }

        public frmMonitores_ExpXmlGnre()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();

            //Events
            ConfigureFormEvents();
        }

        /** Async Tasks  **/
        private async Task getGnresAsync(DateTime dateInicial, DateTime dateFinal, string NF, string cliente, string UF, string bloqueio, string exportacao, DataGridView dataGridView)
        {

            try
            {
                limparDados();
                dataGridView.Rows.Clear();
                int somaBloqueadas = 0;
                int somaExportdadas = 0;
                int somaNaoExportadas = 0;
                System.Data.DataTable dt = await GNRE.getAllToDataTableAsync(dateInicial, dateFinal, NF, cliente, UF, bloqueio, exportacao);
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridView.Rows.Add(Convert.ToInt32(dr["Block"])
                                    , Convert.ToInt32(dr["NF"])
                                    , Convert.ToInt32(dr["Cod_Cliente"])
                                    , dr["Cliente"].ToString()
                                    , dr["Estado"].ToString()
                                    , dr["CFOP"].ToString()
                                    , Convert.ToDateTime(dr["Dat_Emissao"])
                                    , Convert.ToDouble(dr["Vlr_Nota"]).ToString("C")
                                    , Convert.ToDouble(dr["Vlr_GNRE"]).ToString("C")
                                    , Convert.ToDouble(dr["Vlr_FCP"]).ToString("C")
                                    , dr["Dat_Bloqueio"].ToString()
                                    , dr["Dat_Export"].ToString()
                                    , dr["Observacao"].ToString()
                                    );



                    bool condicionalBlock = (Convert.ToInt32(dr["Block"]) == 1 ? true : false);
                    bool condicionalExport = (!string.IsNullOrEmpty(dr["Dat_Export"].ToString()) ? true : false);
                    bool condicionalCredenciamento = (!string.IsNullOrEmpty(dr["Credenciamento"].ToString()) ? true : false);

                    if (condicionalBlock)
                        dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = pnlVermelho.BackColor;
                    if (condicionalExport)
                        dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = pnlCinza.BackColor;
                    if (condicionalCredenciamento)
                        dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = pnlVerde.BackColor;




                    if (condicionalBlock)
                    {
                        somaBloqueadas++;
                    }
                    else if (condicionalExport && !condicionalCredenciamento)
                    {
                        somaExportdadas++;
                    }
                    else if (!condicionalExport && !condicionalCredenciamento)
                    {
                        somaNaoExportadas++;
                    }



                }
                txtBloqueadas.Text = somaBloqueadas.ToString("N0");
                txtExportadas.Text = somaExportdadas.ToString("N0");
                txtNaoExportadas.Text = somaNaoExportadas.ToString("N0");
                dataGridView.AutoResizeColumns();

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }

        }

        /** Sync Tasks **/
        private void limparDados()
        {
            lsbExportar.Items.Clear();
            NFtoExportDictionary.Clear();
            NFtoObsIndex.Clear();
            txtGuias.Text = "0";
        }
        private void contarDadosAExportar(object sender, EventArgs e)
        {
            txtGuias.Text = NFtoExportDictionary.Count.ToString();
        }
        private void adicionarNF(DataGridViewRow row)
        {
            if (!NFtoExportDictionary.ContainsValue(row.Cells["Num_Nota"].Value.ToString()))
            {
                NFtoExportDictionary.Add(row.Index, row.Cells["Num_Nota"].Value.ToString());
                lsbExportar.Items.Add($"{row.Cells["num_Nota"].Value} - {row.Cells["Cod_Estado"].Value.ToString()}");
                row.DefaultCellStyle.BackColor = Color.Coral;
            }
            //row.Cells["NF_Block"].Value = 1;
        }
        private void removerNF()
        {
            string[] nfFirst = lsbExportar.SelectedItem.ToString().Trim().Split('-');
            string valor = nfFirst[0].Trim();
            int chave = NFtoExportDictionary.FirstOrDefault(entry => entry.Value == valor).Key;
            if (chave != -1)
            {
                lsbExportar.Items.Remove(lsbExportar.SelectedItem);
                NFtoExportDictionary.Remove(chave);
                dgvData.Rows[chave].DefaultCellStyle.BackColor = dgvData.AlternatingRowsDefaultCellStyle.BackColor;
                //dgvData.Rows[chave].Cells["NF_Block"].Value = 0;
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmMonitores_ExpXmlGnre_Load;
        }
        private async void frmMonitores_ExpXmlGnre_Load(object sender, EventArgs e)
        {
            //Properties Pos-Initialize
            dtpDtInicial.Text = Convert.ToString(DateTime.Today);
            dtpDtFinal.Text = Convert.ToString(DateTime.Today);
            ConfigureDataGridViewProperties();


            //Events
            ConfigureButtonEvents();
            ConfigureDataGridViewEvents();

            //Pos-Events
            btnPesquisar_Click(sender, e);

            // Cria o ContextMenuStrip
            ContextMenuStrip menu = new ContextMenuStrip();

            // Cria o item de menu "Copiar"
            ToolStripMenuItem item1 = new ToolStripMenuItem("Exportar itens selecionados");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Bloquear itens selecionados");
            ToolStripMenuItem item4 = new ToolStripMenuItem("Reiniciar itens selecionados");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Gerar manual itens selecionados");
            item1.Click += new EventHandler(itensExportar_Click); // define o evento de clique
            item4.Click += new EventHandler(itensReiniciar_Click);
            // Adiciona o item de menu ao ContextMenuStrip
            menu.Items.Add(item1);
            menu.Items.Add(item4);

            // Atribui o ContextMenuStrip ao DataGridView
            dgvData.ContextMenuStrip = menu;

            NFtoExportDictionary.CollectionChanged += contarDadosAExportar;

            SplitBase.Panel1MinSize = 500;
            SplitBase.Panel2MinSize = 50;
            splitFilter.Panel1MinSize = 220;
            splitOperation.Panel2MinSize = 150;
            splitOperation.Panel1MinSize = 1000;
            splitExportar.Panel1MinSize = 40;
            splitExportar.SplitterDistance = 40;

            foreach (var item in (await GNRE.getEstadosBloqueadosAsync()))
            {
                lsbBloqueados.Items.Add(item);
            }
            foreach (var item in (await GNRE.getEstadosCredenciadosAsync()))
            {
                lsbCredenciadas.Items.Add(item);
            }

            splitFilter.BorderStyle = BorderStyle.Fixed3D;
            splitOperation.BorderStyle = BorderStyle.Fixed3D;
            SplitBase.BorderStyle = BorderStyle.Fixed3D;
            splitExportar.BorderStyle = BorderStyle.Fixed3D;
            splitButtonsExport.BorderStyle = BorderStyle.Fixed3D;


            lsbBloqueados.TabStop = false;
            lsbCredenciadas.TabStop = false;


            cbxBloqueados.Items.Add("Todos");
            cbxBloqueados.Items.Add("Sim");
            cbxBloqueados.Items.Add("Não");
            cbxBloqueados.SelectedItem = "Todos";

            cbxExportados.Items.Add("Todos");
            cbxExportados.Items.Add("Sim");
            cbxExportados.Items.Add("Não");
            cbxExportados.SelectedItem = "Todos";

            txtCod_Cliente.KeyDown += pesquisarComEnter_KeyDown;
            
            txtUF.KeyDown += pesquisarComEnter_KeyDown;
            txtUF.TextChanged += txtUF_TextChanged;
            dtpDtInicial.KeyDown += pesquisarComEnter_KeyDown;
            dtpDtFinal.KeyDown += pesquisarComEnter_KeyDown;
            txtNF.KeyDown += pesquisarComEnter_KeyDown;
            
            lsbExportar.DoubleClick += lsbExportar_DoubleClick;


            ConfigureTextBoxEvents();

            ConfigureLinklabelEvents();
        }

        private async void itensReiniciar_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0)
            {
                if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
                {
                    //CustomNotification.defaultAlert(dgvData.SelectedCells.Count.ToString());
                    foreach (DataGridViewCell cell in dgvData.SelectedCells)
                    {
                        DataGridViewRow row = dgvData.Rows[cell.RowIndex];
                        await MonitorGnre.reiniciarAsync(row.Cells["Num_Nota"].Value.ToString());

                    }
                    btnPesquisar_Click(null, null);
                }
                
            }
            else
            {
                return;
            }

        }

        private async void txtUF_TextChanged(object sender, EventArgs e)
        {
            txtUFDesc.Text = await MonitorGnre.getEstadoAsync(txtUF.Text);
        }
        private void txtCustomerId_TextChanged(object sender, System.EventArgs e)
        {
            txtCliente.Text = Clientes_Externos.getDescripionByCode(txtCod_Cliente.Text);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            btnMoreCustomer_Click(sender, e);
        }
        private void btnMoreCustomer_Click(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCod_Cliente.Text = frmConsultarCliente.extendedCode;
        }
        private void lsbExportar_DoubleClick(object sender, EventArgs e)
        {
            if (lsbExportar.SelectedItem != null)
            {
                removerNF();
            }
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtBloqueadas.ReadOnly();
            txtExportadas.ReadOnly();
            txtNaoExportadas.ReadOnly();
            txtObservacao.ReadOnly();
        }
        private void ConfigureTextBoxEvents()
        {
            txtCod_Cliente.TextChanged += txtCustomerId_TextChanged;
            txtCliente.DoubleClick += txtCustomer_DoubleClick;
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            var col = new DataGridViewCheckBoxColumn();
            col.Name = "NF_Block";
            col.HeaderText = "B";
            col.FalseValue = "B0";
            col.TrueValue = "B1";
            col.CellTemplate.Value = true;
            col.CellTemplate.Style.NullValue = true;
            col.Width = 20;

            dgvData.Invoke((MethodInvoker)delegate
            {
                dgvData.Columns.Insert(0, col);
                dgvData.Columns["NF_Block"].Frozen = true;
                dgvData.Columns.Add("Num_Nota", "NF");
                dgvData.Columns.Add("Cod_Cliente", "Cód. Cliente");
                dgvData.Columns.Add("Desc_Cliente", "Cliente");
                dgvData.Columns.Add("Cod_Estado", "Estado");
                dgvData.Columns.Add("CFOP", "Desc. CFOP");
                dgvData.Columns.Add("Dat_Emissao", "Dat. Emissão");
                dgvData.Columns.Add("Vlr_NF", "Vlr. NF");
                dgvData.Columns.Add("Vlr_ICM", "Vlr. Difal");
                dgvData.Columns.Add("Vlr_FCP", "Vlr. FCP");
                dgvData.Columns.Add("Dat_Bloqueio", "Dat. Bloqueio");
                dgvData.Columns.Add("Dat_Exportacao", "Dat. Exportação");
                dgvData.Columns.Add("Obs_GNRE", "Observação");
                //dataGridView.Columns["Obs_GNRE"].Frozen = true;
                dgvData.toDefault();
                dgvData.MultiSelect = true;
                dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            });
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.RowEnter += dgvData_RowEnter;
            dgvData.CellClick += dgvData_CellClick;
            dgvData.DoubleClick += dgvData_DoubleClick;

        }
        private void dgvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                txtObservacao.Text = dgvData.Rows[e.RowIndex].Cells["Obs_GNRE"].Value.ToString();
            }
        }
        private void itensExportar_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedCells.Count > 0)
            {

                foreach (DataGridViewCell cell in dgvData.SelectedCells)
                {
                    DataGridViewRow row = dgvData.Rows[cell.RowIndex];
                    if (!NFtoExportDictionary.ContainsValue(row.Cells["Num_Nota"].Value.ToString())
                       && ((Convert.ToInt32(row.Cells["NF_Block"].Value) == 0) && string.IsNullOrEmpty(row.Cells["Dat_Exportacao"].Value?.ToString()))
                               && (row.DefaultCellStyle.BackColor != pnlVerde.BackColor && row.DefaultCellStyle.BackColor != pnlCinza.BackColor))
                    {
                        adicionarNF(row);
                    }

                }
            }
            else
            {
                return;
            }

            //// Obtém o texto da célula selecionada
            //string texto = dgvData.SelectedCells[0].Value.ToString();

            //// Copia o texto para a área de transferência
            //Clipboard.SetText(texto);
        }
        private async void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvData.CurrentRow.Cells["NF_Block"].Selected)
            {

                bool bloqueado = (int)dgvData.CurrentRow.Cells["NF_Block"].Value == 1 ? true : false;
                if (!bloqueado)
                {
                    dgvData.CurrentRow.Cells["NF_Block"].Value = 1;
                    NFtoObsIndex.Add(dgvData.CurrentRow.Index);
                }
                else if (bloqueado && NFtoObsIndex.Contains(dgvData.CurrentRow.Index))
                {
                    dgvData.CurrentRow.Cells["NF_Block"].Value = 0;
                    NFtoObsIndex.Remove(dgvData.CurrentRow.Index);
                }
                else
                {
                    if (DialogResult.Yes == CustomNotification.defaultQuestionAlert())
                    {
                        try
                        {
                            await MonitorGnre.desbloquearAsync(dgvData.CurrentRow.Cells["num_nota"].Value.ToString());
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {
                            dgvData.CurrentRow.Cells["NF_Block"].Value = 0;
                            dgvData.CurrentRow.DefaultCellStyle.BackColor = Color.LightBlue;
                        }
                    }
                }
            }

        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {

            if (dgvData.CurrentRow != null)
            {
                DataGridViewRow row = dgvData.CurrentRow;
                if (!NFtoExportDictionary.ContainsValue(row.Cells["Num_Nota"].Value.ToString()))
                {
                    //MessageBox.Show(pnlCinza.BackColor.ToString());
                    if (dgvData.CurrentRow.DefaultCellStyle.BackColor == pnlCinza.BackColor)
                    {
                        if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("NF já exportada anteriormente, deseja prosseguir?"))
                        {
                            adicionarNF(row);
                        }
                    }
                    else if (dgvData.CurrentRow.DefaultCellStyle.BackColor == pnlVerde.BackColor)
                    {
                        if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("Estado cadastrado como não comtemplado, deseja prosseguir?"))
                        {
                            adicionarNF(row);
                        }
                    }
                    else if (dgvData.CurrentRow.DefaultCellStyle.BackColor == pnlVermelho.BackColor)
                    {
                        CustomNotification.defaultAlert("NF bloqueada! Para o processo de exportação é necessário que seja desbloqueada.");
                        return;
                    }
                    else
                    {
                        adicionarNF(row);
                    }

                }

            }
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            btnExportarTodos.Click += btnExportarTodos_Click;
            btnRemoverTodos.Click += btnRemoverTodos_Click;
            btnGerarManual.Click += btnGerarManual_Click;
            btnBloquear.Click += btnBloquear_Click;
            btnFecharConfirmar.Click += btnExportar_Click;
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            string UF = null;
            if (!string.IsNullOrEmpty(txtUFDesc.Text))
                UF = txtUF.Text;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnPesquisar.Enabled = false;
                await getGnresAsync(dtpDtInicial.Value, dtpDtFinal.Value, txtNF.Text, txtCliente.Text, txtUF.Text, cbxBloqueados.Text, cbxExportados.Text, dgvData);
                btnPesquisar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }
        private void pesquisarComEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnPesquisar_Click(sender, e);
            }
        }
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (NFtoObsIndex.Count > 0)
            {
                frmMonitores_ExpXmlGnre_Obs frmMonitores_ExpXmlGnre_Obs = new frmMonitores_ExpXmlGnre_Obs();
                for (int contaNFtoBlock = 0; contaNFtoBlock < NFtoObsIndex.Count; contaNFtoBlock++)
                {
                    frmMonitores_ExpXmlGnre_Obs.nfsObservation.Add(
                        new GNRE_Observation
                        {
                            NF = dgvData.Rows[NFtoObsIndex[contaNFtoBlock]].Cells["Num_Nota"].Value.ToString()
                        ,
                            UF = dgvData.Rows[NFtoObsIndex[contaNFtoBlock]].Cells["Cod_Estado"].Value.ToString()
                        });
                }
                frmMonitores_ExpXmlGnre_Obs.tipo = "B";
                frmMonitores_ExpXmlGnre_Obs.ShowDialog();
                if (frmMonitores_ExpXmlGnre_Obs.Controle)
                {
                    btnPesquisar_Click(sender, e);
                    limparDados();
                }
            }
        }
        private void btnGerarManual_Click(object sender, EventArgs e)
        {
            if (NFtoObsIndex.Count > 0)
            {
                frmMonitores_ExpXmlGnre_Obs frmMonitores_ExpXmlGnre_Obs = new frmMonitores_ExpXmlGnre_Obs();
                for (int contaNFtoBlock = 0; contaNFtoBlock < NFtoObsIndex.Count; contaNFtoBlock++)
                {
                    frmMonitores_ExpXmlGnre_Obs.nfsObservation.Add(
                            new GNRE_Observation
                            {
                                NF = dgvData.Rows[NFtoObsIndex[contaNFtoBlock]].Cells["Num_Nota"].Value.ToString()
                            ,
                                UF = dgvData.Rows[NFtoObsIndex[contaNFtoBlock]].Cells["Cod_Estado"].Value.ToString()
                            });
                }
                frmMonitores_ExpXmlGnre_Obs.tipo = "M";
                frmMonitores_ExpXmlGnre_Obs.ShowDialog();
                if (frmMonitores_ExpXmlGnre_Obs.Controle)
                {
                    btnPesquisar_Click(sender, e);
                    limparDados();
                }
            }
        }
        private void btnExportarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!NFtoExportDictionary.ContainsValue(row.Cells["Num_Nota"].Value.ToString())
                        && (
                            (Convert.ToInt32(row.Cells["NF_Block"].Value) == 0)
                            && string.IsNullOrEmpty(row.Cells["Dat_Exportacao"].Value?.ToString())
                         && (row.DefaultCellStyle.BackColor != pnlVerde.BackColor && row.DefaultCellStyle.BackColor != pnlCinza.BackColor)))
                {
                    adicionarNF(row);
                }
            }
        }
        private void btnRemoverTodos_Click(object sender, EventArgs e)
        {
            lsbExportar.Items.Clear();
            NFtoExportDictionary.Clear();
            txtGuias.Text = "0";
            btnPesquisar_Click(sender, e);
        }
        private async void btnExportar_Click(object sender, EventArgs e)
        {

            if (lsbExportar.Items.Count > 0)
            {
                try
                {
                    List<string> nfs = new List<string>();
                    foreach (var item in NFtoExportDictionary)
                    {
                        //MessageBox.Show(item.Value);
                        nfs.Add(item.Value.Trim());

                        List<GNRE_Observation> obs = new List<GNRE_Observation>();
                        foreach (var nf in nfs)
                        {
                            obs.Add(new GNRE_Observation { NF = nf });
                        }
                        await GNRE_Observation.manualAsync(obs, null);
                    }
                    GNRE_Lote.exportar(@"c:\XML_lote\", nfs);
                }
                catch
                {

                }
                finally
                {
                    btnPesquisar_Click(sender, e);
                    limparDados();
                    CustomNotification.defaultInformation();
                }
            }
            else
            {
                CustomNotification.defaultAlert("Selecione alguma nota.");
            }
        }


        /** Links externos **/
        private void ConfigureLinklabelEvents()
        {
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.gnre.pe.gov.br:444/gnre/portal/GNRE_DisponibilidadeUF.jsp");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.gnre.pe.gov.br:444/gnre/v/lote/gerar");
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string folderPath = @"C:\XML_Lote";

            // Verifica se a pasta existe
            if (!Directory.Exists(folderPath))
            {
                // Cria a pasta se ela não existir
                Directory.CreateDirectory(folderPath);
            }

            // Abre a pasta
            Process.Start("explorer.exe", folderPath);
        }
    }
}
