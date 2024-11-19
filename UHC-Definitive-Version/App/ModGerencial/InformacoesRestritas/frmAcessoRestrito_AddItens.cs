using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestrito_AddItens : CustomForm
    {
        /** Instance **/
        public IqviaRestrictionItens item = new IqviaRestrictionItens();
        public DateTime dt1 { get; set; }
        public DateTime dt2 { get; set; }



        public frmAcessoRestrito_AddItens()
        {
            InitializeComponent();


            //Properties 
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureComboBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
        }


        private void getItem()
        {
            //Validação
            if (cbxEsfera.Enabled && cbxEsfera.SelectedItem is null)
            {
                CustomNotification.defaultAlert("Por favor, selecione a esfera.");
                return;
            }

            if (!txtItemId.ReadOnly && string.IsNullOrEmpty(txtItemDescription.Text))
            {
                CustomNotification.defaultAlert("Por favor, selecione o Item.");
                return;
            }

            if (txtCliente.Visible && string.IsNullOrEmpty(txtCliente.Text))
            {
                CustomNotification.defaultAlert("Por favor, selecione o Cliente.");
                return;
            }


            item.Type = cbxType.SelectedItem.ToString();
            
            item.KeyItem += txtItemId.Text;
            if (cbxType.SelectedItem?.ToString() == "Esfera")
                item.KeyItem += cbxEsfera.SelectedItem?.ToString();
            else if (cbxEsfera.Enabled)
                item.KeyItem += string.IsNullOrEmpty(cbxEsfera.SelectedItem?.ToString()) ? "" : $",{cbxEsfera.SelectedItem?.ToString()}";
            if (txtIdCliente.Visible)
                item.KeyItem += $",{txtIdCliente.Text.ToString()}";
            
            item.observation = txtObservation.Text;
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {

            //Load
            this.Load += frmAcessoRestrito_AddItens_Load;

        }
        private void frmAcessoRestrito_AddItens_Load(object sender, EventArgs e)
        {
            //Pré load 
            ConfigureComboBoxAttributes();
            


            //Events
            ConfigureComboBoxEvents();
            ConfigureTextBoxEvents();
            ConfigureButtonEvents();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtItemDescription.ReadOnly();
            txtItemId.ReadOnly();
            txtObservation.ReadOnly();
            txtCliente.ReadOnly();
        }
        private void ConfigureTextBoxEvents()
        {
            txtItemId.TextChanged += txtItemId_TextChanged;
            txtIdCliente.TextChanged += txtIdCliente_TextChanged;
        }

        private async void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            ClienteInnmed ci = await ClienteInnmed.getToClassAsync(txtIdCliente.Text);
            txtCliente.Text = !string.IsNullOrEmpty(ci?.description) ? $@"{ci?.description} ({ci.cnpj.ConvertToCNPJ()})" : string.Empty;
        }

        private async void txtItemId_TextChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedItem.ToString().Contains("Fabricante"))
            {
                FabricanteInnmed fi = await FabricanteInnmed.getToClassAsync(txtItemId.Text);
                txtItemDescription.Text = fi?.description;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Produto"))
            {
                ProdutoInnmed pi = await ProdutoInnmed.getToClassAsync(txtItemId.Text);

                txtItemDescription.Text = !string.IsNullOrEmpty(pi?.description) ? $@"{pi?.description} ({pi.ean})" : string.Empty;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Grupo de Cliente"))
            {
                GrupoClienteInnmed gci = await GrupoClienteInnmed.getToClassAsync(txtItemId.Text);
                txtItemDescription.Text = gci?.description;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Cliente"))
            {
                ClienteInnmed ci = await ClienteInnmed.getToClassAsync(txtItemId.Text);
                txtItemDescription.Text = !string.IsNullOrEmpty(ci?.description) ? $@"{ci?.description} ({ci.cnpj.ConvertToCNPJ()})" : string.Empty;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Nota"))
            {
                NotaFiscalInnmed nfi = await NotaFiscalInnmed.getToClassAsync(txtItemId.Text);
                ClienteInnmed nfci = await ClienteInnmed.getToClassAsync(nfi.idCliente);
                txtItemDescription.Text = !string.IsNullOrEmpty(nfci.description) ? $@"{nfci.description} ({nfci.cnpj.ConvertToCNPJ()})" : string.Empty;
            }           
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnMore.Click += btnMore_Click;
            btnCliente.Click += btnCliente_Click;
            btnSalvar.Click += btnSalvar_Click;
        }

        private async void btnCliente_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
            frmGeneric_ConsultaComSelecao.consulta = await ClienteInnmed.getAllToDataTableAsync();
            frmGeneric_ConsultaComSelecao.ShowDialog();
            txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            item = new IqviaRestrictionItens();
            getItem();
            Console.WriteLine("Type: "+item.Type);
            Console.WriteLine("KeyItem: " + item.KeyItem);
            Console.WriteLine("Observation: " + item.observation);
            this.Close();
        }

        private async void btnMore_Click(object sender, EventArgs e)
        {
            
            if (cbxType.SelectedItem.ToString().Contains("Fabricante"))
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await FabricanteInnmed.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Produto"))
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await ProdutoInnmed.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Grupo de Cliente"))
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await GrupoClienteInnmed.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Cliente"))
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await ClienteInnmed.getAllToDataTableAsync();
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Nota"))
            {
                frmGeneric_ConsultaComSelecao frmGeneric_ConsultaComSelecao = new frmGeneric_ConsultaComSelecao();
                frmGeneric_ConsultaComSelecao.consulta = await NotaFiscalInnmed.getAllToDataTableAsync(dt1,dt2);
                frmGeneric_ConsultaComSelecao.ShowDialog();
                txtItemId.Text = frmGeneric_ConsultaComSelecao.extendedCode;
            }
            

        }

        /** ComboBox Configuration **/
        private void ConfigureComboBoxAttributes()
        {
            cbxType.Items.AddRange(new object[] {"Fabricante","Fabricante + Esfera","Produto","Produto + Esfera","Produto + Cliente","Cliente","Nota","Grupo de Cliente", "Grupo de Cliente + Esfera", "Esfera" });
            cbxEsfera.Items.AddRange(new object[] { "Público", "Privado" });
        }
        private void ConfigureComboBoxProperties()
        {
            cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxEsfera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbxEsfera.Enabled = false;
        }
        private void ConfigureComboBoxEvents()
        {
            cbxType.SelectedIndexChanged += cbxType_SelectedIndexChanged;
        }
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObservation.ReadOnly(false);
            txtCliente.Visible = false;
            txtIdCliente.Visible = false;
            btnCliente.Visible = false;
            lblCliente.Visible = false;
            lblItem.Text = "Item Restringido*";
            txtItemId_TextChanged(null, null);
            if (cbxType.SelectedItem?.ToString() == "Produto + Cliente")
            {
                txtItemId.ReadOnly(false);
                cbxEsfera.Enabled = false;
                lblItem.Text = "Produto";
                txtCliente.Visible = true;
                txtIdCliente.Visible = true;
                btnCliente.Visible = true;
                lblCliente.Visible = true;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Esfera") && cbxType.SelectedItem.ToString() != "Esfera")
            {
                txtItemId.ReadOnly(false);                
                cbxEsfera.Enabled = true;
            }
            else if (cbxType.SelectedItem.ToString().Contains("Esfera"))
            {
                txtItemId.ReadOnly(true);                
                cbxEsfera.Enabled = true;
                txtItemId.Text = string.Empty;
            }
            else
            {
                txtItemId.ReadOnly(false);
                cbxEsfera.Enabled = false;
            }                       
        }
    }
}