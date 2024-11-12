using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestritoIqvia_Add : CustomForm
    {
        List<IqviaRestrictionItens> itens = new List<IqviaRestrictionItens>();
        public frmAcessoRestritoIqvia_Add()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();
            ConfigureButtonProperties();


            //Events
            ConfigureFormEvents();

        }

        /** Async Task **/
        private async Task saveAsync()
        {
            try
            {

                //inserindo cabeçalho da restrição
                await IqviaRestriction.insertAsync(new IqviaRestriction
                {
                    Description = txtDescription.Text,
                    Observation = txtObservation.Text,
                    Status = "1",
                    CreatedAt = DateTime.Now.ToString(),
                    lastUser = Section.idUsuario,
                    InitialDate = dtpInitialDate.Value.ToString(),
                    FinalDate = dtpFinalDate.Value.ToString()
                });

                Task.WaitAll();
                int lastRestriction = await IqviaRestriction.getLastCodeAsync();

                //Inserindo detalhamento da restrição
                int nextItemRestriction = await IqviaRestrictionItens.getNextCodeAsync();
                await IqviaRestrictionItens.insertAsync(itens);

                //Criando vínculo

                foreach (var item in itens)
                {
                    await IqviaRestriction_IqviaRestrictionItens.insertAsync(new IqviaRestriction_IqviaRestrictionItens
                    {
                        idIqviaRestriction = lastRestriction.ToString(),
                        idIqviaRestrictionItens = (nextItemRestriction++).ToString()
                    });

                }

                CustomNotification.defaultInformation();
                this.Close();
                    
            }
            catch (Exception ex) 
            {
                CustomNotification.defaultError(ex.Message);
            }


        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestritoIqvia_Add_Load;
        }
        private void frmAcessoRestritoIqvia_Add_Load(object sender, EventArgs e)
        {
            //Pré events
            ConfigureDateTimePickersAttributes();

            //Events
            ConfigureButtonEvents();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnAdicionar.Click += btnAdicionar_Click;
            btnRemover.Click += btnRemover_Click;
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Removerei " + itens[dgvData.CurrentRow.Index].KeyItem);
                itens.Remove(itens[dgvData.CurrentRow.Index]);
                dgvData.Rows.Remove(dgvData.CurrentRow);

            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAcessoRestritoIqvia_AddItens frmAcessoRestrito_AddItens = new frmAcessoRestritoIqvia_AddItens();
            frmAcessoRestrito_AddItens.ShowDialog();

            var item = frmAcessoRestrito_AddItens.item;
            itens.Add(item);

            if (item.Type == "Fabricante")
            {
                dgvData.Rows.Add("x", item.Type, (await FabricanteInnmed.getToClassAsync(item.KeyItem)).description);
            }
            else if (item.Type == "Fabricante + Esfera")
            {

                dgvData.Rows.Add("x", item.Type, (await FabricanteInnmed.getToClassAsync(item.KeyItem.Split(',')[0])).description + "," + item.KeyItem.Split(',')[1]);
            }
            else if (item.Type == "Produto")
            {
                dgvData.Rows.Add("x", item.Type, (await ProdutoInnmed.getToClassAsync(item.KeyItem)).description);
            }
            else if (item.Type == "Produto + Esfera")
            {
                dgvData.Rows.Add("x", item.Type, (await ProdutoInnmed.getToClassAsync(item.KeyItem.Split(',')[0])).description + "," + item.KeyItem.Split(',')[1]);
            }
            else if (item.Type == "Produto + Cliente")
            {
                dgvData.Rows.Add("x", item.Type, (await ProdutoInnmed.getToClassAsync(item.KeyItem.Split(',')[0])).description + "," + (await ClienteInnmed.getToClassAsync(item.KeyItem.Split(',')[1])).description);
            }
            else if (item.Type == "Cliente")
            {
                dgvData.Rows.Add("x", item.Type, (await ClienteInnmed.getToClassAsync(item.KeyItem)).description);
            }
            else if (item.Type == "Nota")
            {
                dgvData.Rows.Add("x", item.Type, (await NotaFiscalInnmed.getToClassAsync(item.KeyItem)).numero);
            }
            else if (item.Type == "Grupo de Cliente")
            {
                dgvData.Rows.Add("x", item.Type, (await GrupoClienteInnmed.getToClassAsync(item.KeyItem)).description);
            }
            else if (item.Type == "Grupo de Cliente + Esfera")
            {
                dgvData.Rows.Add("x", item.Type, (await GrupoClienteInnmed.getToClassAsync(item.KeyItem.Split(',')[0])).description + "," + item.KeyItem.Split(',')[1]);
            }
            else if (item.Type == "Esfera")
            {
                dgvData.Rows.Add("x", item.Type, item.KeyItem);
            }
            dgvData.AutoResizeColumns();

        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }


        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtDescription.MaxLength = 100;
            txtObservation.MaxLength = 500;
        }

        /** DateTimePicker Configuration **/
        private void ConfigureDateTimePickersAttributes()
        {
            dtpInitialDate.Value = DateTime.Now;
            dtpFinalDate.Value = DateTime.Now;
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Columns.Add("Id", "Id");
            dgvData.Columns.Add("Type", "Tipo");
            dgvData.Columns.Add("Descricao", "Descricao");
            dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
}
