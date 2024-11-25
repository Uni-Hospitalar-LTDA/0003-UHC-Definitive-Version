using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;
using UHC3_Definitive_Version.Domain.Entities;

namespace UHC3_Definitive_Version.App.ModFinanceiro.MonitoresFinanceiros
{
    public partial class frmMonitores_ExpXmlGnre_Obs : CustomForm
    {

        /** Instância **/
        internal List<GNRE_Observation> nfsObservation = new List<GNRE_Observation>();
        internal string tipo;
        internal bool Controle = false;
        internal class GNRE_Observation
        {
            public string NF { get; set; }
            public string UF { get; set; }
            public static async Task bloquearAsync(List<GNRE_Observation> nfs, string observation)
            {
                foreach (var nf in nfs)
                {
                    //Checar se existe
                    var monitor = await MonitorGnre.getToClassAsync(nf.NF);
                    if (!string.IsNullOrEmpty(monitor.num_Nota))
                    {
                        MonitorGnre updateGnre = new MonitorGnre
                        {
                            num_Nota = nf.NF,
                            Observacao = observation,
                            flg_BloqExport = "1",
                            idUsers = Section.idUsuario

                        };

                        await MonitorGnre.updateBloqueioAsync(updateGnre);
                    }
                    else
                    {
                        List<MonitorGnre> monitorGnres = new List<MonitorGnre>();

                        monitorGnres.Add(new MonitorGnre
                        {
                            num_Nota = nf.NF,
                            Data_Bloqueio = DateTime.Now.ToShortDateString(),
                            Observacao = observation,
                            flg_BloqExport = "1",
                            idUsers = Section.idUsuario

                        });

                        await MonitorGnre.insertAsync(monitorGnres);
                    }


                }
            }
            public static async Task manualAsync(List<GNRE_Observation> nfs, string observation)
            {
                foreach (var nf in nfs)
                {
                    //Checar se existe
                    var monitor = await MonitorGnre.getToClassAsync(nf.NF);
                    if (!string.IsNullOrEmpty(monitor.num_Nota))
                    {
                        MonitorGnre updateGnre = new MonitorGnre
                        {
                            num_Nota = nf.NF,
                            Observacao = observation
                        };

                        await MonitorGnre.updateManualAsync(updateGnre);
                    }
                    else
                    {
                        List<MonitorGnre> monitorGnres = new List<MonitorGnre>();

                        monitorGnres.Add(new MonitorGnre
                        {
                            num_Nota = nf.NF,
                            Data_Exportacao = DateTime.Now.ToShortDateString(),
                            Observacao = observation
                        });

                        await MonitorGnre.insertAsync(monitorGnres);
                    }


                }
            }
        }



        public frmMonitores_ExpXmlGnre_Obs()
        {
            InitializeComponent();

            //Properties
            ConfigureFormProperties();
            ConfigureButtonProperties();

            //Events
            ConfigureFormEvents();


        }

        /** Sync methods **/
        private void configuracaoInicial()
        {
            if (tipo == "B")
            {
                this.Text = $"{Application.ProductName}: Observação de Bloqueio";
            }
            else if (tipo == "M")
            {
                this.Text = $"{Application.ProductName}: Observação";
            }

            foreach (var item in nfsObservation)
            {
                lsbNfs.Items.Add($"{item.NF} - {item.UF}");
            }
        }

        /** Form Configuration **/
        private void ConfigureFormProperties()
        {
            this.defaultFixedForm();
        }
        private void ConfigureFormEvents()
        {
            this.Load += frmMonitores_ExpXmlGnre_Obs_Load;
        }
        private void frmMonitores_ExpXmlGnre_Obs_Load(object sender, System.EventArgs e)
        {
            //Pós-Intialize Properties
            configuracaoInicial();

            //Events
            ConfigureButtonEvents();
        }




        /** Configure Button **/
        private void ConfigureButtonProperties()
        {
            btnCancelar.toDefaultQuestionCloseButton();
        }
        private void ConfigureButtonEvents()
        {
            btnConfirmar.Click += btnConfirmar_Click;
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == CustomNotification.defaultQuestionAlert())
                return;

            if (tipo == "B")
            {
                await GNRE_Observation.bloquearAsync(nfsObservation, txtObs.Text);
            }
            else if (tipo == "M")
            {
                await GNRE_Observation.manualAsync(nfsObservation, txtObs.Text);
            }
            CustomNotification.defaultInformation();
            Controle = true;
            this.Close();
        }
    }
}
