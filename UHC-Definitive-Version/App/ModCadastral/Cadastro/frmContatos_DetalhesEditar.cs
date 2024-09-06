using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Configuration;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.App.ModCadastral.Cadastro
{
    public partial class frmContatos_DetalhesEditar : CustomForm
    {
        /** Instance **/
        Contact_Mail mail = new Contact_Mail();
        Contact_Phone phone = new Contact_Phone();
        Contact_Person person = new Contact_Person();
        string typeOperation;
        internal object inheritedItem { get; set; } = new object();

        public frmContatos_DetalhesEditar()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();
        }

        /**async methods **/
        private async Task save(string type)
        {

            if (type == "Phone")
            {
                phone.observation = txtObservation.Text;
                phone.phone = mtxtInformation.Text;

                await Contact_Phone.updateAsync(phone);
            }
            else if (type == "Mail")
            {                
                mail.mail = mtxtInformation.Text;
                mail.observation = txtObservation.Text;
                await Contact_Mail.updateAsync(mail);
            }
            else
            {
                person.name = mtxtInformation.Text;
                person.observation = txtObservation.Text;
                await Contact_Person.updateAsync(person);
            }
        }

        /** Sync Methods **/
        public void UpdateMaskedTextBox(string inputType)
        {
            // Limpar o MaskedTextBox
            mtxtInformation.Mask = string.Empty;
            mtxtInformation.MaxLength = Int32.MaxValue;
            mtxtInformation.Width = 200; // Largura padrão para Mail e Person

            // Remover manipuladores de eventos anteriores
            mtxtInformation.Validating -= HandleValidation;
            mtxtInformation.Leave -= HandleMaskChange;
            mtxtInformation.Enter -= HandleMaskSet;

            switch (inputType)
            {
                case "Phone":
                    // Configura a máscara para o formato inicial do telefone
                    mtxtInformation.Mask = "(00) 00000-0000";
                    mtxtInformation.Width = 160; // Estimativa baseada no tamanho da fonte e número de caracteres
                    mtxtInformation.Text = phone.phone;
                    lblInformation.Text = "Telefone:";
                    break;

                case "Person":
                    // Remover a máscara e definir o comprimento máximo
                    mtxtInformation.Mask = string.Empty;
                    mtxtInformation.MaxLength = 255;
                    mtxtInformation.Text = person.name;
                    lblInformation.Text = "Nome:";
                    break;

                case "Mail":
                    // Remover a máscara e definir o validador
                    mtxtInformation.Mask = string.Empty;
                    mtxtInformation.Text = mail.mail;
                    lblInformation.Text = "E-mail:";
                    break;
            }

            // Adicionar manipuladores de eventos de validação e mudança de máscara
            mtxtInformation.Validating += HandleValidation;
            mtxtInformation.Leave += HandleMaskChange;
            mtxtInformation.Enter += HandleMaskSet;
        }
        private void HandleMaskSet(object sender, EventArgs e)
        {
            if (mtxtInformation.Mask != string.Empty)
            {
                // Ao ganhar o foco, ajuste a máscara para o formato de telefone de 11 dígitos
                mtxtInformation.Mask = "(00) 00000-0000";
            }
        }
        private void HandleMaskChange(object sender, EventArgs e)
        {
            var digitCount = mtxtInformation.Text.Count(char.IsDigit);

            // Ao perder o foco, ajuste a máscara com base no número de dígitos
            if (mtxtInformation.Mask != string.Empty)
            {
                mtxtInformation.Mask = digitCount == 10 ? "(00) 0000-0000" : "(00) 00000-0000";
            }
        }
        private void HandleValidation(object sender, CancelEventArgs e)
        {
            string input = mtxtInformation.Text;
            var digitCount = mtxtInformation.Text.Count(char.IsDigit);

            if (digitCount == 10)
            {
                // Validação para telefone de 10 dígitos
                if (!Regex.IsMatch(input, @"^\(\d{2}\) \d{4}-\d{4}$"))
                {
                    CustomNotification.defaultAlert("O número de telefone inserido é inválido!");
                    e.Cancel = true;
                }
            }
            else if (digitCount == 11)
            {
                // Validação para telefone de 11 dígitos
                if (!Regex.IsMatch(input, @"^\(\d{2}\) \d{5}-\d{4}$"))
                {
                    CustomNotification.defaultAlert("O número de telefone inserido é inválido!");
                    e.Cancel = true;
                }
            }
            else if (mtxtInformation.Mask == string.Empty && typeOperation != "Mail")
            {
                // Validação para pessoa
                if (Regex.IsMatch(input, @"[;,\.]"))
                {
                    CustomNotification.defaultAlert("O nome da pessoa não deve conter caracteres especiais como vírgulas, pontos ou ponto e vírgulas!");
                    e.Cancel = true;
                }
            }
            else if (mtxtInformation.Mask == string.Empty)
            {
                // Validação para e-mail
                try
                {
                    var addr = new System.Net.Mail.MailAddress(input);
                    if (addr.Address != input)
                    {
                        CustomNotification.defaultAlert("O e-mail inserido é inválido!");
                        e.Cancel = true;
                    }
                }
                catch
                {
                    CustomNotification.defaultAlert("O e-mail inserido é inválido!");
                    e.Cancel = true;
                }
            }
        }
        private void getInitialParameters()
        {
            if (inheritedItem.GetType() == typeof(Contact_Mail))
            {
                mail = (Contact_Mail)inheritedItem;
                mtxtInformation.Text = mail.mail;
                txtObservation.Text = mail.observation;
                typeOperation = "Mail";
                UpdateMaskedTextBox(typeOperation);
            }
            else if (inheritedItem.GetType() == typeof(Contact_Phone))
            {
                phone = (Contact_Phone)inheritedItem;
                mtxtInformation.Text = phone.phone;
                txtObservation.Text = phone.observation;
                typeOperation = "Phone";
                UpdateMaskedTextBox(typeOperation);
            }
            else
            {
                person = (Contact_Person)inheritedItem;
                mtxtInformation.Text = person.name;
                txtObservation.Text = person.observation;
                typeOperation = "Person";
                UpdateMaskedTextBox(typeOperation);
            }
        }

        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastrarContatos_Load;
        }
        private void frmCadastrarContatos_Load(object sender, EventArgs e)
        {
            ConfigureMaskedTextBoxEvents();
            ConfigureButtonEvents();

            getInitialParameters();
        }

        /** Configure Masked TextBox**/

        private void ConfigureMaskedTextBoxEvents()
        {
            mtxtInformation.Enter += mtxt_Enter;
            mtxtInformation.Leave += mtxt_Leave;
        }
        string _temp;
        private void mtxt_Enter(object sender, EventArgs e)
        {
            switch (typeOperation)
            {
                case "Phone":
                    if (mtxtInformation.Text == "(00) 0000-0000" || mtxtInformation.Text == "(00) 00000-0000")
                    {
                        _temp = mtxtInformation.Text;
                        mtxtInformation.Text = string.Empty;
                    }
                    break;
                case "Mail":
                    if (mtxtInformation.Text == "contato@email.com")
                    {
                        _temp = mtxtInformation.Text;
                        mtxtInformation.Text = string.Empty;
                    }
                    break;
            }
        }
        private void mtxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtInformation.Text))
                mtxtInformation.Text = _temp;
        }

        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtObservation.ScrollBars = ScrollBars.Vertical;
        }
        /**Configure Buttons **/
        /** Button Configuration**/
        private void ConfigureButtonProperties()
        {
            btnCancel.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(mtxtInformation.Text.Trim()) || (!mtxtInformation.MaskFull && mtxtInformation.Mask != string.Empty))
            {
                CustomNotification.defaultAlert($"Preencha a informação {lblInformation.Text}!");
                return;
            }
            try
            {


                await save(typeOperation);
                CustomNotification.defaultInformation();
                this.Close();
            }
            catch
            {

            }
        }
    }
}
