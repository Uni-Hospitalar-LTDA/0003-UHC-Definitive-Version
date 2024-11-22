using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using System.Windows.Forms;
using System.Drawing;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.App.ModCadastral.Cadastro;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Cadastral
{
    public partial class frmCadastroTransportador : CustomForm
    {
        /** Instance **/
        List<Contact> contacts = new List<Contact>();

        public frmCadastroTransportador()
        {
            InitializeComponent();

            //Events
            ConfigureFormProperties();
            ConfigureButtonsProperties();
            ConfigureTextBoxProperties();
            this.defaultMainMenu();
            //Properties
            ConfigureFormEvents();
        }

        /** Async Methods **/
        private async Task save()
        {
            try
            {
                List<Transporter_Contact> tc = new List<Transporter_Contact>();
                foreach (var contact in contacts)
                {
                    tc.Add(new Transporter_Contact
                    {
                        Cod_Transportador = txtTransprotador_Codigo.Text
                        ,
                        idContact = contact.idContact
                    });
                }
                await Transporter_Contact.deleteAsync(txtTransprotador_Codigo.Text);
                await Transporter_Contact.insertAsync(tc);

                CustomNotification.defaultInformation();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private async Task getContacts()
        {
            var str = txtTransprotador_Codigo.Text;
            if (!string.IsNullOrEmpty(str))
            {
                contacts = await Contact.getAllToListTransporterByCodeAsync(str);
            }
        }

        /** Sync methods **/
        private void listContacts()
        {
            try
            {
                lsbContatcs.Items.Clear();
                foreach (var cntc in contacts)
                    lsbContatcs.Items.Add($"{cntc.idContact} - {cntc.name}");
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }

        /** Configure Form **/

        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastroTransportador_Load;
        }
        private void frmCadastroTransportador_Load(object sender, EventArgs e)
        {
            ConfigureTextBoxEvents();
            ConfigureButtonsEvents();
        }

        /** Configure Buttons **/
        private void ConfigureButtonsProperties()
        {

            // btnAdd
            btnAdd.BackColor = Color.FromArgb(136, 201, 153); // Verde suave
            btnAdd.ForeColor = Color.White; // Texto branco            

            // btnRemove
            btnRemove.BackColor = Color.FromArgb(230, 135, 142); // Rosa suave
            btnRemove.ForeColor = Color.White; // Texto branco

            btnSave.Enabled = false;


            // btnFechar
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonsEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;
            btnConfigureContacts.Click += btnConfigureContacts_Click;
            btnSave.Click += btnSave_Click;

            btnConfigureStatePercents.Click += btnConfigureStatePercents_Click;
            btnConfigureCityPercents.Click += btnConfigureCityPercents_Click;
            btnMoreTransporter.Click += btnMoreTransporter_Click;

        }
        private void btnConfigureCityPercents_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTransportador_Descricao.Text))
            {
                frmCadastroTransportador_PrctFreteCidade frmCadastroTransportador_PrctFreteCidade = new frmCadastroTransportador_PrctFreteCidade();
                frmCadastroTransportador_PrctFreteCidade.transporterId = txtTransprotador_Codigo.Text;
                frmCadastroTransportador_PrctFreteCidade.transporderDescription = txtTransportador_Descricao.Text;
                frmCadastroTransportador_PrctFreteCidade.ShowDialog();
            }
            else
            {
                CustomNotification.defaultAlert("Selecione um Transportador!");
            }
        }
        private async void btnConfigureContacts_Click(object sender, EventArgs e)
        {
            frmContatos_Visualizar frmContatos_Visualizar = new frmContatos_Visualizar();
            frmContatos_Visualizar.linkedType = "Transporter";
            frmContatos_Visualizar.ShowDialog();
            lsbContatcs.Items.Clear();
            await getContacts();
            listContacts();

        }
        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransprotador_Codigo.Text = frmConsultarTransportador.extendedCode;
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao consultarContatos = new frmGeneric_ConsultaComSelecao();
            consultarContatos.consulta = await Contact.getAllToDataTableByTypeAsync("Transporter");
            consultarContatos.elemento = "Contato";
            consultarContatos.ShowDialog();
            var contact = await Contact.getToClassAsync(consultarContatos.extendedCode);
            if (!string.IsNullOrEmpty(contact.idContact))
            {
                lsbContatcs.Items.Add($"{contact.idContact} - {contact.name}");
                contacts.Add(contact);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
            {
                if (contacts.Count > 0 && lsbContatcs.SelectedItem != null)
                {
                    var contact = contacts.Find(x => x.idContact == lsbContatcs.SelectedItem.ToString().Split('-')[0].Trim().ToString());
                    contacts.Remove(contact);
                    lsbContatcs.Items.Remove(lsbContatcs.SelectedItem);
                }
            };

        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == System.Windows.Forms.DialogResult.Yes)
                await save();
        }
        private void btnConfigureStatePercents_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTransportador_Descricao.Text))
            {
                frmCadastroTransportador_PrctFreteEstado frmCadastroTransportador_PrctFreteEstado = new frmCadastroTransportador_PrctFreteEstado();
                frmCadastroTransportador_PrctFreteEstado.transporterId = txtTransprotador_Codigo.Text;
                frmCadastroTransportador_PrctFreteEstado.transporderDescription = txtTransportador_Descricao.Text;
                frmCadastroTransportador_PrctFreteEstado.ShowDialog();
            }
            else
            {
                CustomNotification.defaultAlert("Selecione um transportador.");
            }
        }

        /**  Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtTransportador_Descricao.ReadOnly = true;
            txtTransportador_Descricao.TabStop = false;
            txtTransprotador_Codigo.JustNumbers();
            txtTransprotador_Codigo.MaxLength = 10;
        }
        private void ConfigureTextBoxEvents()
        {
            txtTransprotador_Codigo.TextChanged += txtCodTransportador_TextChanged;
            txtTransportador_Descricao.DoubleClick += txtDescricaoTransportador_DoubleClick;
            txtTransportador_Descricao.TextChanged += txtDescricaoTransportador_TextChanged;
        }
        private async void txtCodTransportador_TextChanged(object sender, EventArgs e)
        {
            txtTransportador_Descricao.Text = await Transportadores_Externos.getDescriptionByCode(txtTransprotador_Codigo.Text);
        }
        private async void txtDescricaoTransportador_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (!string.IsNullOrEmpty(txt.Text.Trim()))
            {
                btnSave.Enabled = true;
                await getContacts();
                listContacts();
            }
            else
            {
                btnSave.Enabled = false;
                lsbContatcs.Items.Clear();
            }
        }
        private void txtDescricaoTransportador_DoubleClick(object sender, EventArgs e)
        {
            //frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            //frmConsultarTransportador.ShowDialog();
            //txtCodTransportador.Text = frmConsultarTransportador.extendedCode;
        }
    }
}
