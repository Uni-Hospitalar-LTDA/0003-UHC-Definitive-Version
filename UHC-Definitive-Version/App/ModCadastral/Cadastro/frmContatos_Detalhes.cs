using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using System.Threading.Tasks;

namespace UHC3_Definitive_Version.App.ModCadastral.Cadastro
{
    public partial class frmContatos_Detalhes : CustomForm
    {
        /** Instance **/
        public string typeOperation { get; set; } = "Mail";
        public int idContact { get; set; }


        public frmContatos_Detalhes()
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
                List<Contact_Phone> phone = new List<Contact_Phone>();

                phone.Add(new Contact_Phone
                {
                    idContact = idContact.ToString()
                     ,
                    phone = mtxtInformation.Text
                     ,
                    observation = txtObservation.Text
                });

                await Contact_Phone.insertAsync(phone);
            }
            else if (type == "Mail")
            {
                List<Contact_Mail> mail = new List<Contact_Mail>();
                mail.Add(new Contact_Mail
                {
                    idContact = idContact.ToString()
                   ,
                    mail = mtxtInformation.Text
                   ,
                    observation = txtObservation.Text
                });
                await Contact_Mail.insertAsync(mail);
            }
            else
            {
                List<Contact_Person> person = new List<Contact_Person>();
                person.Add(new Contact_Person
                {
                    idContact = idContact.ToString()
                   ,
                    name = mtxtInformation.Text
                   ,
                    observation = txtObservation.Text
                });
                await Contact_Person.insertAsync(person);
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
                    mtxtInformation.Text = "(00) 00000-0000";
                    lblInformation.Text = "Telefone:";
                    break;

                case "Person":
                    // Remover a máscara e definir o comprimento máximo
                    mtxtInformation.Mask = string.Empty;
                    mtxtInformation.MaxLength = 255;
                    //mtxtInformation.Text = "Cadastrar Pessoa";
                    lblInformation.Text = "Nome:";
                    break;

                case "Mail":
                    // Remover a máscara e definir o validador
                    mtxtInformation.Mask = string.Empty;
                    mtxtInformation.Text = "contato@email.com";
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
        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmCadastrarContatos_Detalhes_Load;
        }
        private void frmCadastrarContatos_Detalhes_Load(object sender, EventArgs e)
        {
            UpdateMaskedTextBox(typeOperation);
            ConfigureMaskedTextBoxEvents();
            ConfigureButtonEvents();
        }


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
            try
            {
                if (string.IsNullOrEmpty(mtxtInformation.Text.Trim()) || (!mtxtInformation.MaskFull && mtxtInformation.Mask != string.Empty))
                {
                    CustomNotification.defaultAlert($"Preencha a informação {lblInformation.Text}!");
                    return;
                }


                await save(typeOperation);
                CustomNotification.defaultInformation();
                if (DialogResult.Yes == CustomNotification.defaultQuestionAlert("Deseja adicionar outro registro?"))
                {
                    txtObservation.Text = string.Empty;
                    _temp = string.Empty;
                    mtxtInformation.Text = string.Empty;
                    mtxtInformation.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {

            }
        }


    }
}
