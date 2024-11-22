using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain;

namespace UHC3_Definitive_Version.App.ModContabilFiscal.Configuracoes
{
    public partial class frmParametrizacaoFiscalPorUf : CustomForm
    {
        /** Instance **/
        private List<FiscalParametersByState> persistent = new List<FiscalParametersByState>();

        public frmParametrizacaoFiscalPorUf()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();
            ConfigureDataGridViewProperties();

            //Events
            ConfigureFormEvents();
        }

        /** async Tasks **/
        private async Task getUFsWithFiscalParametersAsync()
        {
            dgvData.DataSource = await FiscalParametersByState.getAllToDataTableAsync();
            persistent = await FiscalParametersByState.getAllToListAsync();
            dgvData.Columns[0].ReadOnly = true;
            dgvData.Columns[1].ReadOnly = true;
            dgvData.Columns[2].ReadOnly = true;
            dgvData.Columns[3].ReadOnly = true;
            dgvData.Columns[4].ReadOnly = false;
            dgvData.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvData.Columns[4].DefaultCellStyle.Format = "N2";
            dgvData.Columns[4].ValueType = typeof(double);
        }
        private async Task saveAsync()
        {
            try
            {

                List<FiscalParametersByState> listToInsert = new List<FiscalParametersByState>();
                foreach (DataGridViewRow _row in dgvData.Rows)
                {
                    bool insert = (Convert.ToDouble(_row.Cells[4].Value)
                        != Convert.ToDouble(persistent.Where(x => x.idIBGE_State.Equals(_row.Cells[0].Value))?.FirstOrDefault().diferencialICMS));
                    if (insert)
                    {
                        await FiscalParametersByState.deleteAllAsync(_row.Cells[0].Value.ToString());
                        listToInsert.Add(new FiscalParametersByState
                        {
                            idIBGE_State = _row.Cells[0].Value.ToString(),
                            diferencialICMS = _row.Cells[4].Value.ToString(),
                            idUser = Section.idUsuario,
                        });
                    }
                }
                await FiscalParametersByState.insertAsync(listToInsert);
                CustomNotification.defaultInformation();
            }
            catch
            {

            }

        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmParametrizacaoFiscalPorUF_Load;
        }
        private async void frmParametrizacaoFiscalPorUF_Load(object sender, EventArgs e)
        {
            await getUFsWithFiscalParametersAsync();
            ConfigureDataGridViewEvents();
            ConfigureButtonEvents();
        }

        /** Button Configuration **/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnSave.Click += btnSave_Click;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await saveAsync();
        }

        /** DataGridView Configuration **/
        private void ConfigureDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.ReadOnly = false;
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.CellValidating += dgvData_CellValidating;
        }
        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int columnIndex = 4;

            if (e.ColumnIndex == columnIndex)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal _))
                {
                    e.Cancel = true;
                    CustomNotification.defaultAlert("Por favor, insira um número decimal.");
                }
            }
        }

    }
}
