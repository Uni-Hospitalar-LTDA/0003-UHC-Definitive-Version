using System.Windows.Forms;
using System;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities.InnmedEntities;
using UHC3_Definitive_Version.Domain.Entities;
using System.Threading.Tasks;
using System.Data;
using UHC3_Definitive_Version.App.Telas_Genericas;

namespace UHC3_Definitive_Version.App.ModAdmistrativo.Canhotos
{
    public partial class frmFretes_Conferencia_Ajuste : CustomForm
    {
        public frmFretes_Conferencia_Ajuste()
        {
            InitializeComponent();
            
            //Properties
            ConfigureFormProperties();
            ConfigureTextBoxProperties();
            ConfigureTextBoxProperties();
            ConfigureGroupBoxProperties();
            ConfiguraDataGridViewProperties();
            ConfigureButtonProperties();


            //Events
            ConfigureFormEvents();
        }
        /** Async Tasks **/
        private async Task getConferenceListAsync()
        {

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            string transporter = null;
            string nf = null;
            string cte = null;

            dtpInitialDate.Invoke((Action)delegate { dt1 = dtpInitialDate.Value; });
            dtpFinalDate.Invoke((Action)delegate { dt2 = dtpFinalDate.Value; });
            txtTransporterDescription.Invoke((Action)delegate
            {
                transporter = !string.IsNullOrEmpty(txtTransporterDescription.Text) ? txtTransporterId.Text : null;
            });
            txtNF.Invoke((Action)delegate
            {
                nf = txtNF.Text;
            });
            txtCTE.Invoke((Action)delegate
            {
                cte = txtCTE.Text;
            });

            DataTable dt = await ShippingConference.getShippingConferenceToUpdateAsync(dt1, dt2, transporter, nf, cte);

            dgvData.Invoke((Action)delegate
            {
                dgvData.DataSource = dt;
                dgvData.AutoResizeColumns();
            });

            btnClean.Invoke((Action)delegate
            {
                btnClean_Click(btnClean, new EventArgs());
            });

        }
        private async Task saveAsync()
        {
            if (string.IsNullOrEmpty(txtEditCTE.Text) ||
                string.IsNullOrEmpty(txtEditRealValue.Text) ||
                string.IsNullOrEmpty(txtEditObservation.Text)
                )
            {
                CustomNotification.defaultAlert("Alteração inválida, por favor revise os campos.");
            }
            try
            {
                await ShippingConference.updateAsync
                    (
                         gpbEdit.Text.Split(':')[1].Trim()
                        , txtEditCTE.Text
                        , txtEditRealValue.Text
                        , txtEditObservation.Text
                    );
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                await getConferenceListAsync();
            }

        }
        /** Generic Event **/
        private void GenericSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSearch_Click(sender, new EventArgs());
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultMaximableForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmFretes_Conferencia_Ajuste_Load;
        }
        private async void frmFretes_Conferencia_Ajuste_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerAttributes();


            //getting initial data
            await Task.Factory.StartNew(() => getConferenceListAsync());

            //The DataGridView properties should be after get the system data from initial query

            ConfigureDataGridViewCollumnsProperties();


            // ** Events ** //
            ConfigureButtonEvents();
            ConfigureTextBoxEvents();
            ConfigureDataGridViewEvents();
        }

        /** GroupBox Configuration **/
        private void ConfigureGroupBoxProperties()
        {
            gpbEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        /** DataGridView Configuration **/
        private void ConfiguraDataGridViewProperties()
        {
            dgvData.toDefault();
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ReadOnly = true;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;




        }
        private void ConfigureDataGridViewCollumnsProperties()
        {
            dgvData.Columns[0].ValueType = typeof(int);
            dgvData.Columns[1].ValueType = typeof(int);
            dgvData.Columns[2].ValueType = typeof(int);
            dgvData.Columns[6].ValueType = typeof(double);
            dgvData.Columns[6].DefaultCellStyle.Format = "C2";
            dgvData.Columns[7].ValueType = typeof(double);
            dgvData.Columns[7].DefaultCellStyle.Format = "C2";
            dgvData.Columns[8].ValueType = typeof(double);
            dgvData.Columns[8].DefaultCellStyle.Format = "C2";
            dgvData.Columns[9].ValueType = typeof(double);
            dgvData.Columns[9].DefaultCellStyle.Format = "C2";
            dgvData.Columns[10].ValueType = typeof(DateTime);
            dgvData.Columns[10].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void ConfigureDataGridViewEvents()
        {
            dgvData.CellEnter += dgvData_CellEnter;
        }
        private void dgvData_CellEnter(object sender, EventArgs e)
        {
            var row = dgvData.CurrentRow;
            if (dgvData.CurrentRow != null)
            {
                gpbEdit.Text = "NF:" + row.Cells[0].Value.ToString();
                txtEditCTE.Text = row.Cells[1].Value.ToString();
                txtEditRealValue.Text = row.Cells[8].Value.ToString();
                txtEditObservation.Text = row.Cells[11].Value as string;
            }
            else
            {
                btnClean_Click(sender, e);
            }
        }

        /** DateTimePicker configuration **/
        private void ConfigureDateTimePickerAttributes()
        {
            dtpInitialDate.Value = DateTime.Now.AddDays(-30);
            dtpFinalDate.Value = DateTime.Now;
        }

        /** TextBox Configuration **/
        private void ConfigureTextBoxProperties()
        {
            txtTransporterDescription.ReadOnly = true;
            txtTransporterDescription.TabStop = false;

            txtTransporterId.JustNumbers();
            txtNF.JustNumbers();
            txtCTE.JustNumbers();

            txtEditCTE.JustNumbers();
            txtEditRealValue.justDecimalNumbers();


            txtEditObservation.ScrollBars = ScrollBars.Vertical;
        }
        private void ConfigureTextBoxEvents()
        {
            txtTransporterId.TextChanged += txtCodTransportador_TextChanged;


            txtTransporterId.KeyDown += GenericSearch_KeyDown;
            dtpInitialDate.KeyDown += GenericSearch_KeyDown;
            dtpFinalDate.KeyDown += GenericSearch_KeyDown;
            txtNF.KeyDown += GenericSearch_KeyDown;
            txtCTE.KeyDown += GenericSearch_KeyDown;
        }
        private async void txtCodTransportador_TextChanged(object sender, EventArgs e)
        {
            txtTransporterDescription.Text = await Transportadores_Externos.getDescriptionByCode(txtTransporterId.Text);
        }
        private async void txtDescricaoTransportador_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (!string.IsNullOrEmpty(txt.Text.Trim()))
            {
                await getConferenceListAsync();
            }
        }

        /** Button Configuration**/
        private void ConfigureButtonProperties()
        {
            btnClose.toDefaultCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnClean.Click += btnClean_Click;
            btnSearch.Click += btnSearch_Click;
            btnSave.Click += btnSave_Click;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await getConferenceListAsync();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
                await saveAsync();
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            txtEditCTE.Text = string.Empty;
            txtEditRealValue.Text = string.Empty;
            txtEditObservation.Text = string.Empty;
            gpbEdit.Text = "Campos Editáveis";
        }

        private void btnMoreTransporter_Click(object sender, EventArgs e)
        {
            frmConsultarTransportador frmConsultarTransportador = new frmConsultarTransportador();
            frmConsultarTransportador.ShowDialog();
            txtTransporterId.Text = frmConsultarTransportador.extendedCode;
        }

    }
}
