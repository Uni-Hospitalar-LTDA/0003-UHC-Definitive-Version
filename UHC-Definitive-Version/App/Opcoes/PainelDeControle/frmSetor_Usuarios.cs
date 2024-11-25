using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.Users;

namespace UHC3_Definitive_Version.App.Opcoes.PainelDeControle
{
    public partial class frmSetor_Usuarios : CustomForm
    {
        /** Instance **/
        internal Sector  selectedSector {get;set; }
        List<Users> initialUsers = new List<Users>();
        List<Users> finalUsers = new List<Users>();
        List<Sector> sectors = new List<Sector>();

        
        /** async Methods **/
        private async Task getInitialAttributesAsync()
        {
            txtCodSetor.Text = selectedSector.Id;
            txtSetor.Text = selectedSector.Description;


            initialUsers = await Users.getAllToListBySectorAsync(selectedSector.Id);
            finalUsers = await Users.getAllToListBySectorAsync(selectedSector.Id);
            sectors = await Sector.getAllToListAsync();

            foreach (var user in initialUsers)
            {
                lsbUsuarios.Items.Add($"{user.id} - {user.login} - {user.name}");
            }
            
            foreach (var sector in sectors)
            {
                cbxSetor.Items.Add(sector.Description);
            }            
            
        }
        private async Task saveAsync()
        {            
            foreach (var user in initialUsers)
            {                
                string nextidSector = sectors.First(s => s.Description.Equals(cbxSetor.SelectedItem.ToString())).Id;                
                user.idSector = nextidSector;
                Task t1 = (Users.updateSectorAsync(user));
                await Task.WhenAll(t1);
            }

            foreach (var user in finalUsers)
            {                
                user.idSector = txtCodSetor.Text;
                Task t2 = (Users.updateSectorAsync(user));
                await Task.WhenAll(t2);
            }
        }

        /** Sync Methods **/
        private void limparDados()
        {
            lsbUsuarios.Items.Clear();
            finalUsers.Clear();
        }


        public frmSetor_Usuarios()
        {
            InitializeComponent();

            //Properties            
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureListBoxProperties();
            ConfigureButtonProperties();            
            //Events
            ConfigureFormEvents();


            
        }



        /** Configure Form **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();

            
        }
        private void ConfigureFormEvents()
        {
            this.KeyDown += frmSetor_Usuarios_KeyDown;
            this.Load += frmSetor_Usuarios_Load;
        }
        private async void frmSetor_Usuarios_Load(object sender, EventArgs e)
        {
            //Attributes
            await getInitialAttributesAsync();



            ConfigureButtonEvents();

            cbxSetor.SelectedIndex = 0;
        }
        private void frmSetor_Usuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btnRemover_Click(sender, e);
            }
        }
        /** Configure TextBox **/
        private void ConfigureTextBoxProperties()
        {
            txtCodSetor.ReadOnly();            
            txtSetor.ReadOnly();            
        }

        /** Configure ListBox **/
        private void ConfigureListBoxProperties()
        {            
            cbxSetor.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        /**Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnRemover.Click += btnRemover_Click;
            btnSalvar.Click += btnSalvar_Click;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSelecionarUsuario frmSelecionarUsuarios = new frmSelecionarUsuario();
            foreach (var user in lsbUsuarios.Items)
            {
                string[] id = user.ToString().Split('-');
                frmSelecionarUsuarios.markedUsers.Add(initialUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault());
            }
            frmSelecionarUsuarios.ShowDialog();

            limparDados();
            if (frmSelecionarUsuarios.markedUsers.Count > 0)
            {

                foreach (var markedUser in frmSelecionarUsuarios.markedUsers)
                {
                    finalUsers.Add(markedUser);
                    lsbUsuarios.Items.Add($"{markedUser.id} - {markedUser.login} - {markedUser.name}");
                }
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lsbUsuarios.SelectedItem != null)
            {
                string[] id = lsbUsuarios.SelectedItem.ToString().Split('-');
                if (finalUsers.Contains(finalUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault()))
                {
                    finalUsers.Remove(finalUsers.Where(u => u.id.Equals(id[0].Trim())).FirstOrDefault());
                    lsbUsuarios.Items.Remove(lsbUsuarios.SelectedItem);
                }
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {

            if (cbxSetor.SelectedText == txtSetor.Text)
            {
                CustomNotification.defaultAlert("O setor de redirecionamento não pode ser o mesmo que está sendo modificado.");
                return;
            }
            try
            {
                await saveAsync();
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                CustomNotification.defaultInformation("Modificações salvas!");
                this.Close();
            }
        }


    }
}
