using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.ModGerencial.Controladoria;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmControladoria_Arquivos_IQVIA : CustomForm
    {
        /** Screen Permissions **/
        public frmControladoria_Arquivos_IQVIA()
        {
            InitializeComponent();
            this.defaultMaximableForm();
        }
        Iqvia_Control persistent = new Iqvia_Control();

        /** Event Load **/
        private async void frmControladoria_ArquivosIMS_Load(object sender, EventArgs e)
        {
            dtpDataBase.Value = DateTime.Now;
            dtpDataInicial.Value = DateTime.Now.AddDays(-7);
            dtpDataFinal.Value = DateTime.Now.AddDays(7);

            persistent = await Iqvia_Control.getToClassAsync();
            chkClientes.Checked = Convert.ToBoolean(Convert.ToInt16(persistent.Layout_Clientes));
            chkProdutos.Checked = Convert.ToBoolean(Convert.ToInt16(persistent.Layout_Produtos));
            chkVendas.Checked = Convert.ToBoolean(Convert.ToInt16(persistent.Layout_Vendas));
            txtNArquivos.Text = "0";

            //Carregar informações do grid            
            await carregarPanel(dtpDataInicial.Value, dtpDataFinal.Value);
        }

        /** Tasks **/
        private async Task carregarPanel(DateTime dateInicial, DateTime dateFinal)
        {
            dgvData.toDefault();
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = true;
            dgvData.DataSource = await Iqvia_Panel.getAllExternalToDataTableAsync(dateInicial, dateFinal);

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[4].Value.ToString().Equals("Sim"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                else if (row.Cells[3].Value.ToString().Equals("Sim"))
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }
        private async Task save_IqviaControl()
        {
            List<Iqvia_Control> iqvia_Controls = new List<Iqvia_Control>();
            iqvia_Controls.Add(new Iqvia_Control
            {
                Layout_Clientes = Convert.ToInt16(chkClientes.CheckState).ToString()
                ,
                Layout_Produtos = Convert.ToInt16(chkProdutos.CheckState).ToString()
                ,
                Layout_Vendas = Convert.ToInt16(chkVendas.CheckState).ToString()
            });
            try
            {
                await Iqvia_Control.deleteAsync();
                await Iqvia_Control.insertAsync(iqvia_Controls);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
        }
        private async Task gerarArquivosAsync()
        {
            try
            {
                List<Iqvia_Panel> panelItens = new List<Iqvia_Panel>();
                for (int x = 0; x < Convert.ToInt32(txtNArquivos.Text); x++)
                {
                    DateTime date = dtpDataBase.Value.AddDays(x);
                    if (date.DayOfWeek.ToString() != "Sunday" && date.DayOfWeek.ToString() != "Saturday")
                    {
                        if (!await Iqvia_Panel.exists(date.AddDays(x)))
                        {
                            panelItens.Add(new Iqvia_Panel
                            {
                                description = $"C{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}"
                                ,
                                day = date.ToString()
                            }); ;
                            panelItens.Add(new Iqvia_Panel
                            {
                                description = $"P{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}"
                                ,
                                day = date.ToString()
                            });
                            panelItens.Add(new Iqvia_Panel
                            {
                                description = $"V{Section.CodIqvia}M{date.ToString("MM")}.D{date.ToString("dd")}"
                                ,
                                day = date.ToString()
                            });
                        }
                    }
                }
                await Iqvia_Panel.insertAsync(panelItens);
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
            }
            finally
            {
                await carregarPanel(dtpDataInicial.Value, dtpDataFinal.Value);
            }


        }

        /** Components Functions **/
        private void txtNArquivos_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Trim().Equals(String.Empty))
            {
                txt.Text = "0";
            }
        }
        private void dgvData_DoubleClick(object sender, EventArgs e)
        {
            btnVerificarArquivo_Click(sender, e);
        }
        private async void dtp_ValueChanged(object sender, EventArgs e)
        {
            await carregarPanel(dtpDataInicial.Value, dtpDataFinal.Value);
        }

        /** System Buttons **/
        private void btnVerificarArquivo_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                frmVisualizarLayout_IQVIA frmVisualizarLayoutIqvia = new frmVisualizarLayout_IQVIA();
                frmVisualizarLayoutIqvia.id = dgvData.CurrentRow.Cells[0].Value.ToString();
                frmVisualizarLayoutIqvia.date = Convert.ToDateTime(dgvData.CurrentRow.Cells[2].Value);
                frmVisualizarLayoutIqvia.tipo = dgvData.CurrentRow.Cells[1].Value.ToString().Substring(0, 1);
                frmVisualizarLayoutIqvia.Show();
            }
            else if (dgvData.SelectedRows.Count > 1)
            {
                CustomNotification.defaultAlert("Selecione apenas um registro.");
            }
            else
            {
                CustomNotification.defaultAlert("Selecione algum registro.");
            }


        }
        private void btnBloqueioDetalhado_Click(object sender, EventArgs e)
        {

            if (dgvData.CurrentRow != null)
            {
                frmBloqueioDetalhado_IQVIA frmBloqueioDetalhado = new frmBloqueioDetalhado_IQVIA();
                foreach (DataGridViewRow row in dgvData.SelectedRows)
                {
                    frmBloqueioDetalhado.panel.Add(new Iqvia_Panel
                    {
                        id = row.Cells[0].Value.ToString()
                        ,
                        description = row.Cells[1].Value.ToString()
                        ,
                        day = Convert.ToDateTime(row.Cells[2].Value).ToString("dd/MM/yyyy")

                    });
                }
                frmBloqueioDetalhado.Show();

            }
            else
            {
                CustomNotification.defaultAlert("Selecione algum registro.");
            }

        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {


                await carregarPanel(dtpDataInicial.Value, dtpDataFinal.Value);
            }
            catch
            {

            }
            finally
            {
                CustomNotification.defaultInformation();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnGerarArquivosEnvio_Click(object sender, EventArgs e)
        {
            await gerarArquivosAsync();
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await save_IqviaControl();
        }
        private async void btnRemoverBloqueios_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                if (CustomNotification.defaultQuestionAlert() == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvData.SelectedRows)
                        {
                            await Iqvia_DetailedBlocks.deleteAsync(row.Cells[0].Value.ToString());
                            await Iqvia_Panel.updateHasBlock(row.Cells[0].Value.ToString());
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        await carregarPanel(dtpDataInicial.Value, dtpDataFinal.Value);
                    }
                };
            }
            else
            {
                CustomNotification.defaultAlert("Selecione algum registro.");
            }

        }
      
    }
}
