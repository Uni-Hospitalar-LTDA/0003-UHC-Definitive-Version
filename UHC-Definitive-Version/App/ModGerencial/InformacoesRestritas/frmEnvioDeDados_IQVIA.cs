using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;
using UHC3_Definitive_Version.Configuration;

namespace UHC3_Definitive_Version.App.ModGerencial.InformacoesRestritas
{
    public partial class frmEnvioDeDados_IQVIA : CustomForm
    {
        public frmEnvioDeDados_IQVIA()
        {
            InitializeComponent();
            this.defaultFixedForm();
            progressBar1.Visible = false;
        }

        /** System Lists **/
        List<FTP> FTPlist = new List<FTP>();
        Iqvia_Control iControl = new Iqvia_Control();
        List<Iqvia_Panel> iPanel = new List<Iqvia_Panel>();

        /** Tasks **/
        private async Task carregarFTPs()
        {
            FTPlist = (await FTP.getAllToListAsync()).Where(x => x.enabled.Equals("1")).ToList();
            foreach (var ftp in FTPlist)
            {
                chkFTPList.Items.Add(ftp.description, true);
            }

        }
        private async Task carregarArchivePermition()
        {
            iControl = await Iqvia_Control.getToClassAsync();
            chkArchiveList.Items.Add("Produtos", Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Produtos)));
            chkArchiveList.Items.Add("Clientes", Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Clientes)));
            chkArchiveList.Items.Add("Vendas", Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Vendas)));
        }
        private async Task carregarArchives(DateTime dateInicial, DateTime dateFinal)
        {
            iPanel = await Iqvia_Panel.getAllToListAsync(dateInicial, dateFinal);
        }


        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            List<string> idSent = new List<string>();
            progressBar1.Visible = true;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                TimeSpan span = dtpFinal.Value - dtpInicial.Value;

                int travel = (100 / (span.Days + 1) / 3);
                for (int x = 0; x <= span.Days; x++)
                {
                    foreach (var ftp in chkFTPList.CheckedItems)
                    {
                        if (await Iqvia_Panel.exists(dtpInicial.Value.AddDays(x)))
                        {
                            if (Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Clientes)))
                            {
                                try
                                {


                                    Iqvia_Panel ip = iPanel?.Where(i => (Convert.ToDateTime(i.day).ToShortDateString().Equals(dtpInicial.Value.AddDays(x).ToShortDateString())
                                                                       && (i.description.Contains("C"))
                                        )).FirstOrDefault();

                                    string result = await IMSCliente.writeIMSCliente(dtpInicial.Value.AddDays(x), ip.id);


                                    if (result != null && ip != null)
                                    {
                                        await FTP.sendAsync(FTPlist[chkFTPList.Items.IndexOf(ftp)], result, ip.description);
                                        idSent.Add(ip.id);
                                    }


                                }
                                catch (Exception)
                                {
                                    break;
                                }
                                finally
                                {
                                    if ((progressBar1.Value + travel) < 100)
                                        progressBar1.Value += travel;
                                }
                            }
                            if (Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Produtos)))
                            {
                                try
                                {
                                    Iqvia_Panel ip = iPanel?.Where(i => (Convert.ToDateTime(i.day).ToShortDateString().Equals(dtpInicial.Value.AddDays(x).ToShortDateString())
                                                                       && (i.description.Contains("P"))
                                        )).FirstOrDefault();

                                    string result = await IMSProduto.writeIMSProduto(dtpInicial.Value.AddDays(x), ip.id);
                                    if (result != null && ip != null)
                                    {
                                        await FTP.sendAsync(FTPlist[chkFTPList.Items.IndexOf(ftp)], result, ip.description);
                                        idSent.Add(ip.id);
                                    }


                                }
                                catch (Exception ex)
                                {
                                    CustomMessage.Error("Enviar FTP - Produtos: " + ex.Message);
                                    break;
                                }
                                finally
                                {
                                    if ((progressBar1.Value + travel) < 100)
                                        progressBar1.Value += travel;
                                }
                            }
                            if (Convert.ToBoolean(Convert.ToInt16(iControl.Layout_Vendas)))
                            {
                                try
                                {
                                    Iqvia_Panel ip = iPanel?.Where(i => (Convert.ToDateTime(i.day).ToShortDateString().Equals(dtpInicial.Value.AddDays(x).ToShortDateString())
                                                                       && (i.description.Contains("V"))
                                        )).FirstOrDefault();

                                    string result = await IMSVendas.writeIMSVendas(dtpInicial.Value.AddDays(x), ip.id);

                                    if (result != null && ip != null)
                                    {
                                        await FTP.sendAsync(FTPlist[chkFTPList.Items.IndexOf(ftp)], result, ip.description);
                                        idSent.Add(ip.id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    CustomMessage.Error("Enviar FTP - Vendas: " + ex.Message);
                                    break;
                                }
                                finally
                                {
                                    if ((progressBar1.Value + travel) < 100)
                                        progressBar1.Value += travel;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Error("Enviar FTP: " + ex.Message);
            }
            finally
            {
                progressBar1.Value = 100;
                CustomMessage.Sucess();
                foreach (var id in idSent)
                {
                    try
                    {
                        await Iqvia_Panel.updateHasSent(id);
                    }
                    catch (Exception ex)
                    {
                        CustomMessage.Error("Atualizar status de envio: " + ex.Message);
                    }
                }
                this.Cursor = Cursors.Default;
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
        }

        private async void frmEnvioDeDados_IMS_Load(object sender, EventArgs e)
        {
            await carregarFTPs();
            await carregarArchivePermition();
            await carregarArchives(dtpInicial.Value, dtpFinal.Value);

            chkArchiveList.Enabled = false;
        }
        private async void dtp_ValueChanged(object sender, EventArgs e)
        {
            await carregarArchives(dtpInicial.Value, dtpFinal.Value);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CustomApplication.closeForm();
        }
    }
}
