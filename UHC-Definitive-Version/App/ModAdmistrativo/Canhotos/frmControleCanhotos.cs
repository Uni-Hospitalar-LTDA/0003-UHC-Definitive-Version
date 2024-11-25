using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Canhotos
{
    public partial class frmControleCanhotos : CustomForm
    {

        public frmControleCanhotos()
        {
            InitializeComponent();

            //Properties 
            ConfigureCheckedListBoxProperties();
            ConfigureFormProperties();
            ConfigureTextBoxProperties();

            //Events 
            ConfigureFormEvents();
        }


        /** Instance **/
        List<NF_Canhotos> Canhotos = new List<NF_Canhotos>();

        internal class Information : Querys<Information>
        {
            public string Num_Nota { get; set; }
            public string Dat_Emissao { get; set; }
            public string Status { get; set; }
            public string Estado { get; set; }
            public string CFOP { get; set; }
            public string Dat_Coleta { get; set; }
            public string Cod_Cliente { get; set; }
            public string Cliente { get; set; }
            public string Cod_Transportadora { get; set; }
            public string Transportadora { get; set; }


            public static async Task<Information> getToClassAsync(string NF)
            {
                string query = $@"SELECT NF_Saida.Num_Nota
	  ,NF_Saida.Dat_Emissao
	  ,NF_Saida.Status
	  ,NF_Saida.Estado
	  ,CFOP.Descricao [CFOP]
	  ,Data_Coleta [Dat_Coleta]
	  ,Cliente.Codigo [Cod_Cliente]
	  ,Cliente.Razao_Social [Cliente]
	  ,Transportadora.Codigo [Cod_Transportadora]
	  ,Transportadora.Fantasia [Transportadora]	  	  
FROM [DMD].dbo.[NFSCB] NF_Saida
LEFT JOIN [DMD].dbo.[RMNIT] Romaneio_Itens ON Romaneio_Itens.Num_Nota = NF_Saida.Num_Nota
LEFT JOIN [DMD].dbo.[RMNCB] Romaneio ON Romaneio.Numero = Romaneio_Itens.Num_Romaneio
LEFT JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.CODIGO = NF_Saida.Cod_Cliente
LEFT JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.CODIGO = NF_Saida.Cod_Cfo1
LEFT JOIN [DMD].dbo.[TRANS] Transportadora ON Transportadora.Codigo = NF_Saida.Cod_Transportadora

WHERE NF_Saida.Num_Nota = {NF}
UNION ALL
SELECT 
                                                NF_Entrada.Numero as [Num_Nota]
                                               ,NF_Entrada.Dat_emissao                                                
                                               ,NF_Entrada.Status                                                
                                               ,Cliente.Cod_Estado as [UF]                                                
                                               ,CFOP.Descricao as [Desc_CFOP] 
											   ,Romaneio.Data_Coleta as [Dat_Coleta]  
											   ,Cliente.Codigo as [Cod_Cliente] 
                                               ,Cliente.Razao_Social as [Desc_Clien] 
                                               ,Transportadora.Codigo as [Cod_Transp] 
                                               ,Transportadora.Fantasia as [Transp]                                                                                                                                             
                                               FROM [DMD].dbo.[NFECB] NF_Entrada                                                
                                               LEFT OUTER JOIN [DMD].dbo.[RMNIT] Romaneio_Itens ON Romaneio_Itens.Num_Nota = NF_Entrada.Numero 
                                               LEFT OUTER JOIN [DMD].dbo.[RMNCB] Romaneio ON Romaneio.Numero = Romaneio_Itens.Num_Romaneio 
                                               LEFT OUTER JOIN [DMD].dbo.[CLIEN] Cliente ON Cliente.CODIGO = NF_Entrada.Cod_EmiCliente 
                                               LEFT OUTER JOIN [DMD].dbo.[TBCFO] CFOP ON CFOP.CODIGO = NF_Entrada.Cod_Cfo 
                                               LEFT OUTER JOIN [DMD].dbo.[TRANS] Transportadora ON CFOP.Codigo = NF_Entrada.Cod_Transp                                                                                       
WHERE NF_Entrada.Numero = {NF}";

                return await getToClass(query);
            }
        }

     
        /** Async Tasks**/
        private async Task getCanhotosFromDB(DateTime dt1, DateTime dt2, string codCliente = null, string codTransportador = null)
        {
            Canhotos.Clear();
            Canhotos = await NF_Canhotos.getAllToCheckToListAsync(dt1, dt2, codCliente, codTransportador);
        }
        private async Task getCanhotosFromDB(string nf)
        {
            Canhotos.Clear();
            Canhotos = await NF_Canhotos.getAllToCheckToListAsync(nf);
        }
        private async Task filterNFOnCheckedListBox()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(txtNF.Text.Trim()))
                {
                    string codTransprotador = (!string.IsNullOrEmpty(txtTransportador_Descricao.Text.Trim()) ? txtTransportador_Codigo.Text : null);
                    string codCliente = (!string.IsNullOrEmpty(txtCliente_Descricao.Text.Trim()) ? txtCliente_Codigo.Text : null);

                    await getCanhotosFromDB(dtpDtInicial.Value, dtpDtFinal.Value, codCliente, codTransprotador);
                }
                else
                {

                    await getCanhotosFromDB(txtNF.Text);
                }

                putNFsOnCheckedListBox(clbNotas);
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {

            }

        }

        /** Sync Methods **/
        private async Task save()
        {
            try
            {
                var import = Canhotos.Where(i => clbNotas.CheckedItems.Cast<string>().Any(item => i.Num_Nota == item)).ToList();
                foreach (var i in import)
                {
                    i.Dat_Entrada = DateTime.Now.ToString();
                    i.Dat_Canhoto = DateTime.Today.ToString();
                    i.idUsers = Section.idUsuario;
                }
                await NF_Canhotos.insertAsync(import);
                CustomNotification.defaultInformation($"Você inseriu {import.Count()} registro(s)!");
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                return;
            }
        }

        /** Configure Form **/
        private void ConfigureFormEvents()
        {
            this.Load += frmControleCanhotos_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
            
        }
        private async void frmControleCanhotos_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();
            await getCanhotosFromDB(dtpDtInicial.Value, dtpDtFinal.Value);
            putNFsOnCheckedListBox(clbNotas);

            //Buttons Configure
            ConfigureButtonsEvents();
            ConfigureCheckedListBoxEvents();
            ConfigureTextBoxEvents();
        }

        /**Configure DateTimePicker**/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpDtInicial.Value = DateTime.Now.AddDays(-7);
            dtpDtFinal.Value = DateTime.Now;
        }

        /** Configure CheckedListBox **/
        private void ConfigureCheckedListBoxEvents()
        {
            clbNotas.SelectedIndexChanged += clbNotas_SelectedIndexChanged;
            clbNotas.ItemCheck += clbNotas_ItemCheck;
        }
        private void ConfigureCheckedListBoxProperties()
        {
            clbNotas.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        }
        private void putNFsOnCheckedListBox(CheckedListBox clb)
        {
            clb.Items.Clear();
            foreach (var canhoto in Canhotos)
            {
                clb.Items.Add(canhoto.Num_Nota);
            }
            clbNotas_ItemCheck(btnPesquisar, new EventArgs());

        }
        private async void clbNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Info = await Information.getToClassAsync(clbNotas.SelectedItem.ToString());
            txtDatEmissaoInfo.Text = Info.Dat_Emissao;
            txtStatusInfo.Text = Info.Status;
            txtUfInfo.Text = Info.Estado;
            txtCfopInfo.Text = Info.CFOP;
            txtDatColetaInfo.Text = Info.Dat_Coleta != null ? Convert.ToDateTime(Info.Dat_Coleta).ToShortDateString() : "Não há data de coleta";
            txtClienteInfo_Codigo.Text = Info.Cod_Cliente;
            txtClienteInfo_Descricao.Text = Info.Cliente;
            txtTransportadorInfo_Codigo.Text = Info.Cod_Transportadora;
            txtTransportadorInfo_Descricao.Text = Info.Transportadora;
        }
        private void clbNotas_ItemCheck(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                if (clbNotas.CheckedItems.Count > 0)
                {
                    btnConfirmar.BackColor = Color.DarkOliveGreen;
                    btnConfirmar.Text = "Salvar";
                }
                else
                {
                    btnConfirmar.BackColor = Color.Silver;
                    btnConfirmar.Text = "Fechar";
                }
            });
        }

        /** Configure Buttons **/
        private void ConfigureButtonsEvents()
        {
            btnPesquisar.Click += btnPesquisar_Click;
            btnConfirmar.Click += btnConfirmar_Click;

            // Transportador e Clientes buttons
            btnMoreCustomers.Click += btnMoreCustomersQuery;
            btnMoreTransporters.Click += btnMoreTransportersQuery;
        }
        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await filterNFOnCheckedListBox();
        }
        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (clbNotas.CheckedItems.Count > 0)
            {
                if (DialogResult.Yes == CustomNotification.defaultQuestionAlert($"Você deseja confirmar os {clbNotas.CheckedItems.Count} registro(s)?"))
                {
                    await save();
                    await filterNFOnCheckedListBox();
                    clbNotas_ItemCheck(sender, e);
                }
            }
            else
            {
                if (clbNotas.CheckedItems.Count > 0)
                {
                    if (DialogResult.OK == CustomNotification.defaultQuestionAlert("Deseja fechar a tela?")) this.Close();

                }
                else
                    this.Close();
            }

        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {

            txtDatEmissaoInfo.ReadOnly();
            txtStatusInfo.ReadOnly();
            txtUfInfo.ReadOnly();
            txtCfopInfo.ReadOnly();
            txtDatColetaInfo.ReadOnly();
            txtClienteInfo_Codigo.ReadOnly();
            txtClienteInfo_Descricao.ReadOnly();
            txtTransportadorInfo_Codigo.ReadOnly();
            txtTransportadorInfo_Descricao.ReadOnly();
            txtCliente_Descricao.ReadOnly();
            txtTransportador_Descricao.ReadOnly();
            

            txtCliente_Codigo.JustNumbers();
            txtTransportadorInfo_Codigo.JustNumbers();
            txtNF.JustNumbers();

            txtCliente_Codigo.MaxLength = 10;
            txtTransportador_Codigo.MaxLength = 10;
            txtNF.MaxLength = 10;
        }
        private void ConfigureTextBoxEvents()
        {
            txtNF.KeyDown += txt_KeyDown;
            txtCliente_Codigo.KeyDown += txt_KeyDown;
            txtTransportador_Codigo.KeyDown += txt_KeyDown;
            txtCliente_Descricao.DoubleClick += txtDescricaoCliente_DoubleClick;
            txtTransportador_Descricao.DoubleClick += txtDescricaoTransportador_DoubleClick;

            txtCliente_Codigo.TextChanged += txtCodCliente_TextChanged;
            txtTransportador_Codigo.TextChanged += txtCodTransportador_TextChanged;
        }
        private async void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await filterNFOnCheckedListBox();
            }
        }
        private void txtDescricaoCliente_DoubleClick(object sender, EventArgs e)
        {
            // Criar e exibir o formulário "frmConsultarProduto"
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            // Atualizar o texto do controle "txtCodProduto" com o código do produto selecionado
            txtCliente_Codigo.Text = frmConsultarCliente.extendedCode;
        }
        private async void txtCodTransportador_TextChanged(object sender, EventArgs e)
        {
            // Atualizar o texto do controle "txtDescricaoFabricante" com a descrição do fabricante correspondente ao código digitado
            txtTransportador_Descricao.Text = await Transportadores_Externos.getDescriptionByCode(txtTransportador_Codigo.Text);
        }
        private void txtDescricaoTransportador_DoubleClick(object sender, EventArgs e)
        {
            // Criar e exibir o formulário "frmConsultarFabricante"
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            // Atualizar o texto do controle "txtCodFabricante" com o código do fabricante selecionado
            txtTransportador_Codigo.Text = frmConsultarTransportador.extendedCode;
        }
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            // Atualizar o texto do controle "txtDescricaoProduto" com a descrição do produto correspondente ao código digitado
            txtCliente_Descricao.Text = Clientes_Externos.getDescripionByCode(txtCliente_Codigo.Text);
        }

        private void chkMarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            bool marcar = chkMarcarTodos.Checked;

            for (int i = 0; i < clbNotas.Items.Count; i++)
            {
                clbNotas.SetItemChecked(i, marcar);
            }
        }


   


        private void btnMoreTransportersQuery(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransportador_Codigo.Text = frmConsultarTransportador.extendedCode;
        }

        private void btnMoreCustomersQuery(object sender, EventArgs e)
        {
            frmConsultarCliente frmConsultarCliente = new frmConsultarCliente();
            frmConsultarCliente.ShowDialog();
            txtCliente_Codigo.Text = frmConsultarCliente.extendedCode;
        }

      
    }
}
