using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UHC3_Definitive_Version.Configuration;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Domain.Entities.InnmedEntities
{
    public class Fabricantes_Externos : Querys<Fabricantes_Externos>
    {
        public string codigo { get; set; }
        public string Fantasia { get; set; }

        public static List<Fabricantes_Externos> fabricantes = new List<Fabricantes_Externos>();

        public static DataTable getToDataTable(string description)
        {
            DataTable dt = new DataTable();
            dt = fabricantes.Where(f => f.Fantasia.ToUpper().Contains(description)).ToList().AsDataTable();
            dt.Columns[0].ColumnName = "Código";
            dt.Columns[1].ColumnName = "Fabricante";

            return dt;
        }



        public static Fabricantes_Externos getDescriptionByCode(string code)
        {
            return fabricantes.Where(f => f.codigo == code).First();
        }

        public static string getDescripionByCode(string code)
        {
            string description = null;
            try
            {
                if (fabricantes.Count > 0 ? (!string.IsNullOrEmpty(code)) : false)
                    description = fabricantes.Where(p => p.codigo == code).FirstOrDefault()?.Fantasia;
            }
            catch (Exception ex)
            {
                CustomNotification.defaultError(ex.Message);
                description = null;
            }
            return description;
        }


        public async static Task carregarAsync()
        {
            fabricantes.Clear();
            string query = $@"SELECT Fabricante.codigo
                                    ,Fabricante.Fantasia
                              FROM [DMD].dbo.[FABRI] Fabricante";
            fabricantes = await getAllToList(query);
        }
    }
}
