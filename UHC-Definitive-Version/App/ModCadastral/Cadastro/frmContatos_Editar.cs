using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModCadastral.Cadastro
{
    public partial class frmContatos_Editar : CustomForm
    {

        /** Instance  **/
        CustomMenuStrip menuStrip = new CustomMenuStrip();

        /** Instance **/
        List<Contact_Mail> mails = new List<Contact_Mail>();
        List<Contact_Person> people = new List<Contact_Person>();
        List<Contact_Phone> phones = new List<Contact_Phone>();
        Contact contact = new Contact();


        public string contactId { get; set; }

        public frmContatos_Editar()
        {
            InitializeComponent();
            
            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureListBoxProperties();

            //Events
            ConfigureFormEvents();
        }


        /** Async Task **/

        private async Task save()
        {
            if (contact == null)
            {
                contact = new Contact
                {
                    idContact = txtIdContact.Text,
                    name = txtContactName.Text,
                    description = txtContactDescription.Text,
                    linkedAt = "Transporter"
                };
            }
            else
            {
                contact = new Contact
                {
                    idContact = txtIdContact.Text,
                    name = txtContactName.Text,
                    description = txtContactDescription.Text
                };
            }
            await Contact.updateAsync(contact);
        }
        private async Task getContact()
        {
            contact = await Contact.getToClassAsync(contactId);
            txtIdContact.Text = contact.idContact;
            txtContactName.Text = contact.name;
            txtContactDescription.Text = contact.description;
        }

        public async Task getContact_Phones()
        {
            phones = await Contact_Phone.getAllToListByIdAsync(contact.idContact);
            lsbPhoneList.Items.Clear();
            lsbPhoneList.Items.AddRange(phones.Where(p => p.idContact == contact.idContact).Select(p => p.phone).ToArray());

        }

        public async Task getContact_Mail()
        {
            mails = await Contact_Mail.getAllToListByIdAsync(contact.idContact);
            lsbMailList.Items.Clear();
            lsbMailList.Items.AddRange(mails.Where(m => m.idContact == contact.idContact).Select(m => m.mail).ToArray());
        }

        public async Task getContact_People()
        {
            people = await Contact_Person.getAllToListByIdAsync(contact.idContact);
            lsbContactNameList.Items.Clear();
            lsbContactNameList.Items.AddRange(people.Where(p => p.idContact == contact.idContact).Select(p => p.name).ToArray());
        }


        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmContatos_Editar_Load;
        }
        private async void frmContatos_Editar_Load(object sender, EventArgs e)
        {
            await getContact();
            await getContact_Phones();
            await getContact_Mail();
            await getContact_People();

            ConfigureButtonEvents();
            ConfigureListBoxEvents();
        }

        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
            btnAddOnMailList.Click += btnAddOnMailList_Click;
            btnRemOnMailList.Click += btnRemOnMailList_Click;
            btnAddOnPhoneList.Click += btnAddOnPhoneList_Click;
            btnRemOnPhoneList.Click += btnRemOnPhoneList_Click;
            btnAddOnNameList.Click += btnAddOnNameList_Click;
            btnRemOnNameList.Click += btnRemOnNameList_Click;
        }
        private void btnAddOnMailList_Click(object sender, EventArgs e)
        {
            menuStrip_AddMail_Click(sender, e);
        }

        private async Task delete(object obj)
        {
            try
            {
                if (obj.GetType() == typeof(Contact_Mail))
                {
                    await Contact_Mail.deleteAsync((Contact_Mail)obj);
                    await getContact_Mail();
                }
                else if (obj.GetType() == typeof(Contact_Phone))
                {
                    await Contact_Phone.deleteAsync((Contact_Phone)obj);
                    await getContact_Phones();
                }
                else
                {
                    await Contact_Person.deleteAsync((Contact_Person)obj);
                    await getContact_People();
                }
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }

        private async void btnRemOnMailList_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja excluir o registro?")
                == DialogResult.Yes)
            {
                if (lsbMailList.SelectedItem != null)
                {
                    var mail = mails?.Where(m => m.mail == lsbMailList.SelectedItem.ToString()).FirstOrDefault();
                    await delete(mail);
                }
            };

        }

        private void btnAddOnPhoneList_Click(object sender, EventArgs e)
        {
            menuStrip_AddPhone_Click(sender, e);
        }
        private async void btnRemOnPhoneList_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja excluir o registro?")
                == DialogResult.Yes)
            {
                if (lsbPhoneList.SelectedItem != null)
                {
                    var phone = phones?.Where(p => p.phone == lsbPhoneList.SelectedItem.ToString()).FirstOrDefault();
                    await delete(phone);
                }
            };

        }
        private void btnAddOnNameList_Click(object sender, EventArgs e)
        {
            menuStrip_AddPerson_Click(sender, e);
        }
        private async void btnRemOnNameList_Click(object sender, EventArgs e)
        {
            if (lsbContactNameList.SelectedItem != null)
            {
                if (CustomNotification.defaultQuestionAlert("Tem certeza que deseja excluir o registro?")
                    == DialogResult.Yes)
                {
                    var person = people?.Where(p => p.name == lsbContactNameList.SelectedItem.ToString()).FirstOrDefault();
                    await delete(person);
                };
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtContactName.Text))
            {
                CustomNotification.defaultAlert("O nome do contato não pode estar vazio.");
                return;
            }
            try
            {
                await save();
                this.Close();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }



        /** Configure TextBox**/
        private void ConfigureTextBoxProperties()
        {
            txtIdContact.TabStop = false;
            txtIdContact.ReadOnly = true;

            // btnAdd
            btnAddOnMailList.BackColor = Color.FromArgb(136, 201, 153); // Verde suave
            btnAddOnMailList.ForeColor = Color.White; // Texto branco            

            // btnRemove
            btnRemOnMailList.BackColor = Color.FromArgb(230, 135, 142); // Rosa suave
            btnRemOnMailList.ForeColor = Color.White; // Texto branco

            // btnAdd
            btnAddOnPhoneList.BackColor = Color.FromArgb(136, 201, 153); // Verde suave
            btnAddOnPhoneList.ForeColor = Color.White; // Texto branco            

            // btnRemove
            btnRemOnPhoneList.BackColor = Color.FromArgb(230, 135, 142); // Rosa suave
            btnRemOnPhoneList.ForeColor = Color.White; // Texto branco

            // btnAdd
            btnAddOnNameList.BackColor = Color.FromArgb(136, 201, 153); // Verde suave
            btnAddOnNameList.ForeColor = Color.White; // Texto branco            

            // btnRemove
            btnRemOnNameList.BackColor = Color.FromArgb(230, 135, 142); // Rosa suave
            btnRemOnNameList.ForeColor = Color.White; // Texto branco1

        }


        /** Configure ListBox **/
        private void ConfigureListBoxProperties()
        {
            lsbContactNameList.TabStop = false;
            lsbMailList.TabStop = false;
            lsbPhoneList.TabStop = false;
        }
        private void ConfigureListBoxEvents()
        {
            lsbMailList.DoubleClick += lsb_DoubleClick;
            lsbContactNameList.DoubleClick += lsb_DoubleClick;
            lsbPhoneList.DoubleClick += lsb_DoubleClick;

            lsbMailList.GotFocus += lsbMailList_GotFocus;
            lsbContactNameList.GotFocus += lsbContactNameList_GotFocus;
            lsbPhoneList.GotFocus += lsbPhoneList_GotFocus;

        }

        private void lsb_DoubleClick(object sender, EventArgs e)
        {
            ListBox _lsb = (ListBox)sender;
            if (_lsb.SelectedItem != null)
            {
                if (_lsb.Name.Contains("Phone"))
                {
                    frmContatos_DetalhesEditar frmContatos_DetalhesEditar = new frmContatos_DetalhesEditar();
                    frmContatos_DetalhesEditar.inheritedItem = phones?.Where(p => p.phone == lsbPhoneList.SelectedItem.ToString()).FirstOrDefault();
                    frmContatos_DetalhesEditar.ShowDialog();
                }
                else if (_lsb.Name.Contains("Mail"))
                {
                    frmContatos_DetalhesEditar frmContatos_DetalhesEditar = new frmContatos_DetalhesEditar();
                    frmContatos_DetalhesEditar.inheritedItem = mails?.Where(m => m.mail == lsbMailList.SelectedItem.ToString()).FirstOrDefault();
                    frmContatos_DetalhesEditar.ShowDialog();
                }
                else
                {
                    frmContatos_DetalhesEditar frmContatos_DetalhesEditar = new frmContatos_DetalhesEditar();
                    frmContatos_DetalhesEditar.inheritedItem = people?.Where(p => p.name == lsbContactNameList.SelectedItem.ToString()).FirstOrDefault();
                    frmContatos_DetalhesEditar.ShowDialog();
                }
            }
        }

        private void lsbPhoneList_GotFocus(object sender, EventArgs e)
        {
            lsbContactNameList.SelectedItem = null;
            lsbMailList.SelectedItem = null;
        }
        private void lsbMailList_GotFocus(object sender, EventArgs e)
        {
            lsbContactNameList.SelectedItem = null;
            lsbPhoneList.SelectedItem = null;
        }
        private void lsbContactNameList_GotFocus(object sender, EventArgs e)
        {
            lsbPhoneList.SelectedItem = null;
            lsbMailList.SelectedItem = null;
        }

        /** Configure Menu Strip **/
        private void ConfigureMenuStrip()
        {
            menuStrip_AddMail.Click += menuStrip_AddMail_Click;
            menuStrip_AddPhone.Click += menuStrip_AddPhone_Click; ;
            menuStrip_AddPerson.Click += menuStrip_AddPerson_Click; ;
        }
        private async void menuStrip_AddPerson_Click(object sender, EventArgs e)
        {
            frmContatos_Detalhes frmConfigurarContatos_Detalhes = new frmContatos_Detalhes();
            frmConfigurarContatos_Detalhes.typeOperation = "Person";
            frmConfigurarContatos_Detalhes.idContact = Convert.ToInt32(contact.idContact);
            frmConfigurarContatos_Detalhes.ShowDialog();
            await getContact_People();
        }
        private async void menuStrip_AddPhone_Click(object sender, EventArgs e)
        {
            frmContatos_Detalhes frmConfigurarContatos_Detalhes = new frmContatos_Detalhes();
            frmConfigurarContatos_Detalhes.typeOperation = "Phone";
            frmConfigurarContatos_Detalhes.idContact = Convert.ToInt32(contact.idContact);
            frmConfigurarContatos_Detalhes.ShowDialog();
            await getContact_Phones();
        }
        private async void menuStrip_AddMail_Click(object sender, EventArgs e)
        {
            frmContatos_Detalhes frmConfigurarContatos_Detalhes = new frmContatos_Detalhes();
            frmConfigurarContatos_Detalhes.typeOperation = "Mail";
            frmConfigurarContatos_Detalhes.idContact = Convert.ToInt32(contact.idContact);
            frmConfigurarContatos_Detalhes.ShowDialog();
            await getContact_Mail();
        }
        /** Menu Strip Configuration **/
        private void ConfigureMenuStripProperties()
        {
            CustomToolStripMenuItem menuArquivo = new CustomToolStripMenuItem("Arquivo");
            CustomToolStripMenuItem itemArquivoAbrir = new CustomToolStripMenuItem("Abrir");
            CustomToolStripMenuItem itemArquivoAbrirExcel = new CustomToolStripMenuItem("Excel");
            CustomToolStripMenuItem itemArquivoExportar = new CustomToolStripMenuItem("Exportar");
            CustomToolStripMenuItem itemArquivoExportarExcel = new CustomToolStripMenuItem("Excel");

            itemArquivoAbrirExcel.Click += ItemArquivoAbrirExcel_Click;
            itemArquivoExportarExcel.Click += ItemArquivoExportarExcel_Click;

            menuArquivo.DropDownItems.Add(itemArquivoAbrir);
            menuArquivo.DropDownItems.Add(itemArquivoExportar);
            itemArquivoAbrir.DropDownItems.Add(itemArquivoAbrirExcel);
            itemArquivoExportar.DropDownItems.Add(itemArquivoExportarExcel);

            menuStrip.Items.Add(menuArquivo);
            this.Controls.Add(menuStrip);
        }
       
    }
}
