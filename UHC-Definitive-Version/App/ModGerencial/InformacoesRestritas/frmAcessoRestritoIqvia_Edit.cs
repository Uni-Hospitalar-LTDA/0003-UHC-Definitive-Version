using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities.NewIqvia;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmAcessoRestritoIqvia_Edit : CustomForm
    {
        public IqviaRestriction iqviaRestriction { get; set; } = new IqviaRestriction();
        public List<IqviaRestrictionItens> iqviaRestrictionItens { get; set; } = new List<IqviaRestrictionItens>();

        public frmAcessoRestritoIqvia_Edit()
        {
            InitializeComponent();


            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureTextBoxProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();


        }

        /** Async Methods **/
        private async Task saveAsync()
        {
            try
            {

                //inserindo cabeçalho da restrição
                await IqviaRestriction.updateAsync(new IqviaRestriction
                {
                    Id = txtId.Text,
                    Description = txtDescription.Text,
                    Observation = txtObservation.Text,
                    Status = Convert.ToInt16(chkStatus.Checked).ToString(),
                    EditedAt = DateTime.Now.ToString(),
                    lastUser = Section.idUsuario,
                    InitialDate = dtpInitialDate.Value.ToString(),
                    FinalDate = dtpFinalDate.Value.ToString()
                });
                

                //Inserindo detalhamento da restrição
                await IqviaRestriction_IqviaRestrictionItens.deleteAsync("idIqviaRestriction", iqviaRestriction.Id);

                await IqviaRestrictionItens.deleteAsync(iqviaRestriction.Id);
                int nextItemRestriction = await IqviaRestrictionItens.getNextCodeAsync();
                await IqviaRestrictionItens.insertAsync(iqviaRestrictionItens);

                //Criando vínculo

                foreach (var item in iqviaRestrictionItens)
                {
                    await IqviaRestriction_IqviaRestrictionItens.insertAsync(new IqviaRestriction_IqviaRestrictionItens
                    {
                        idIqviaRestriction = iqviaRestriction.Id,
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
        /** Sync Methods **/
        private void getInitialAttributes()
        {
            txtId.Text = iqviaRestriction.Id;
            txtDescription.Text = iqviaRestriction.Description;
            dtpInitialDate.Value = Convert.ToDateTime(iqviaRestriction.InitialDate);
            dtpFinalDate.Value = Convert.ToDateTime(iqviaRestriction.FinalDate);
            chkStatus.Checked = Convert.ToBoolean(Convert.ToInt16(iqviaRestriction.Status));
            txtObservation.Text = iqviaRestriction.Observation;


            foreach (var item in iqviaRestrictionItens)
            {
                dgvData.Rows.Add(item.Id,item.Type,item.KeyItem);
            }
        }


        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();   
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmAcessoRestritoIqvia_Edit_Load;
        }
        private void frmAcessoRestritoIqvia_Edit_Load(object sender, EventArgs e)
        {
            //Attributes
            getInitialAttributes();

            //Events
            ConfigureButtonEvents();
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtId.ReadOnly();            
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSalvar.Click += btnSalvar_Click;
            btnAdicionar.Click += btnAdicionar_Click;
            btnRemover.Click += btnRemover_Click;
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Removerei " + iqviaRestrictionItens[dgvData.CurrentRow.Index].KeyItem);
                iqviaRestrictionItens.Remove(iqviaRestrictionItens[dgvData.CurrentRow.Index]);
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
            iqviaRestrictionItens.Add(item);

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
