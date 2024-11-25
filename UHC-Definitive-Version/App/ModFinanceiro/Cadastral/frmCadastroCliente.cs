using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using System;
using UHC3_Definitive_Version.App.Telas_Genericas;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.App.ModCadastral.Cadastro;
using System.Drawing;

namespace UHC3_Definitive_Version.App.ModFinanceiro.Cadastral
{
    public partial class frmCadastroCliente : CustomForm
    {
        /** Instance **/
        internal string customerId { get; set; }
        Clientes_Externos customer = new Clientes_Externos();
        List<Contact> contacts = new List<Contact>();

        internal class ExternalContact
        {
            public static Task<Contact_Mail> getMailToClassAsync(string idCliente)
            {
                string query = $@"SELECT     
    NULL[idMail],
    NULL[idContact],
    Mail = CASE 
               WHEN ISNULL(Cliente.Email, '') LIKE 'xml@unihospitalar.com.br' OR LEN(ISNULL(Cliente.Email, '')) < 5
               THEN ISNULL(NULLIF(Cliente.Email_Cob, ''), Cliente.Email)
               ELSE Cliente.Email
           END,
    observation = 'Customer'
FROM 
    [DMD].dbo.[CLIEN] Cliente 
WHERE 
    (
        (ISNULL(Cliente.Email, '') NOT LIKE 'xml@unihospitalar.com.br' AND ISNULL(Cliente.Email_Cob, '') NOT LIKE 'xml@unihospitalar.com.br')
        OR
        (
            (ISNULL(Cliente.Email, '') <> '' AND NOT LEN(Cliente.Email) < 5 AND Cliente.Email NOT LIKE '% %')
            AND
            (ISNULL(Cliente.Email_Cob, '') <> '' AND NOT LEN(Cliente.Email_Cob) < 5 AND Cliente.Email_Cob NOT LIKE '% %')
        )
    )
    AND ISNULL(Cliente.Email, '') IS NOT NULL AND ISNULL(Cliente.Email_Cob, '') NOT LIKE 'xml@unihospitalar.com.br'
    AND ISNULL(Cliente.Email, '') NOT LIKE 'xml@unihospitalar.com.br' AND ISNULL(Cliente.Email_Cob, '') IS NOT NULL
    AND NOT (LEN(ISNULL(Cliente.Email, '')) = 0 AND LEN(ISNULL(Cliente.Email_Cob, '')) = 0)
    AND Cliente.Codigo = {idCliente}
";
                return Contact_Mail.getToClass(query);
            }
            public static Task<Contact> getContactToClassAsync(string idCliente)
            {
                string query = $@"SELECT 
    NULL [idContact],
    name = 'Padrão - [' + COALESCE(Cliente.Razao_Social, '') + '] - ' + COALESCE(NULLIF(Cliente.Contato, ''), ''),
    description = 'Cadastro importado do sistema Innmed',
    linkedAt = 'Customer'
FROM [DMD].dbo.[CLIEN] Cliente 
WHERE 
    (
        (ISNULL(Cliente.Email, '') NOT LIKE 'xml@unihospitalar.com.br' AND ISNULL(Cliente.Email_Cob, '') NOT LIKE 'xml@unihospitalar.com.br')
        OR
        (
            (ISNULL(Cliente.Email, '') <> '' AND NOT LEN(Cliente.Email) < 5 AND Cliente.Email NOT LIKE '% %')
            AND
            (ISNULL(Cliente.Email_Cob, '') <> '' AND NOT LEN(Cliente.Email_Cob) < 5 AND Cliente.Email_Cob NOT LIKE '% %')
        )
    )
    AND ISNULL(Cliente.Email, '') IS NOT NULL AND ISNULL(Cliente.Email_Cob, '') NOT LIKE 'xml@unihospitalar.com.br'
    AND ISNULL(Cliente.Email, '') NOT LIKE 'xml@unihospitalar.com.br' AND ISNULL(Cliente.Email_Cob, '') IS NOT NULL
    AND NOT (LEN(ISNULL(Cliente.Email, '')) = 0 AND LEN(ISNULL(Cliente.Email_Cob, '')) = 0)
    AND Cliente.Codigo = {idCliente}
";
                return Contact.getToClass(query);
            }
        }

        Contact _tempContact = new Contact();
        Contact_Mail _tempMail = new Contact_Mail();

        public frmCadastroCliente()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonsProperties();
            
            //Events 
            ConfigureFormEvents();
        }

        /** Async Tasks **/
        private void getCustomerData()
        {
            customer = Clientes_Externos.getClienteByCode(customerId);
        }
        private async Task save()
        {

            try
            {
                await Customer_Contact.deleteAsync(customerId);
                List<Customer_Contact> customer_contacts = new List<Customer_Contact>();
                foreach (var item in contacts)
                {
                    customer_contacts.Add(new Customer_Contact
                    {
                        Cod_Cliente = txtCustomerId.Text
                        ,
                        idContact = item.idContact
                    });
                }

                await Customer_Contact.insertAsync(customer_contacts);
                CustomNotification.defaultInformation();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private async Task getCustomerContactsFromExternalDB(string idCustomer)
        {
            _tempContact = await ExternalContact.getContactToClassAsync(idCustomer);
            _tempMail = await ExternalContact.getMailToClassAsync(idCustomer);
        }
        private async Task getContacts(string idCustomer)
        {
            var cc = await Contact.getAllToListCustomerByCodeAsync(idCustomer);
            if (cc != null)
                contacts = cc;
        }

        /** Configure Form **/
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastroCliente_Load;
        }
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private async void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            getCustomerData();

            ConfigureTextBoxAttributes();
            await getCustomerContactsFromExternalDB(txtCustomerId.Text);
            await getContacts(txtCustomerId.Text);
            ConfigureListBoxAttributes();

            ConfigureButtonEvents();
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCustomerId.ReadOnly = true;
            txtCustomerDescription.ReadOnly = true;

            txtCustomerId.TabStop = false;
            txtCustomerDescription.TabStop = false;
        }
        private void ConfigureTextBoxAttributes()
        {
            txtCustomerId.Text = customer.codigo;
            txtCustomerDescription.Text = customer.razao_social;
        }


        /** Configure Button **/
        private void ConfigureButtonsProperties()
        {
            // btnAdd
            btnAdd.BackColor = Color.FromArgb(136, 201, 153); // Verde suave
            btnAdd.ForeColor = Color.White; // Texto branco            

            // btnRemove
            btnRemove.BackColor = Color.FromArgb(230, 135, 142); // Rosa suave
            btnRemove.ForeColor = Color.White; // Texto branco

            // btnFechar
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnContacts.Click += btnContacts_Click;
            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;
            btnSave.Click += btnSave_Click;
        }
        private async void btnContacts_Click(object sender, EventArgs e)
        {
            frmContatos_Visualizar frmContatos_Visualizar = new frmContatos_Visualizar();
            frmContatos_Visualizar.linkedType = "Customer";
            frmContatos_Visualizar.ShowDialog();
            lsbContatcs.Items.Clear();
            await getContacts(customerId);
            ConfigureListBoxAttributes();


        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmGeneric_ConsultaComSelecao consultarContatos = new frmGeneric_ConsultaComSelecao();
            consultarContatos.consulta = await Contact.getAllToDataTableByTypeAsync("Customer");
            consultarContatos.elemento = "Contato";
            consultarContatos.ShowDialog();
            var contact = await Contact.getToClassAsync(consultarContatos.extendedCode);
            lsbContatcs.Items.Add($"{contact.idContact} - {contact.name}");
            contacts.Add(contact);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
            {
                if (!lsbContatcs.SelectedItem.ToString().Contains("Padrão"))
                {
                    var contact = contacts.Find(x => x.idContact == lsbContatcs.SelectedItem.ToString().Split('-')[0].Trim().ToString());
                    contacts.Remove(contact);
                    lsbContatcs.Items.Remove(lsbContatcs.SelectedItem);
                }
                else if (lsbContatcs.SelectedItem.ToString().Contains("Padrão"))
                {
                    CustomNotification.defaultAlert($"Informação Herdada ({_tempMail.mail}), acesse o sistema Innmed para visualizar o [Contato de Cobrança] .");
                }
            };

        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await save();
        }

        /** Configure ListBox Attributes**/
        private void ConfigureListBoxAttributes()
        {
            if (_tempContact.description != null && _tempMail.mail != null)
            {
                lsbContatcs.Items.Add($"Padrão - {_tempMail.mail} **Herdado do Innmed**");
            }

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    lsbContatcs.Items.Add($"{contact.idContact} - {contact.name}");
                }
            }

        }
    }
}
