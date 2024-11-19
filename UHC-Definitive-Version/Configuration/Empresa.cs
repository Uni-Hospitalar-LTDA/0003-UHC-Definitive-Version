using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Configuration
{
    public static class Empresa
    {
        public static List<string> empresas = new List<string>() { "UNI HOSPITALAR", "UNI HOSPITALAR CEARÁ","SP HOSPITALAR"};

        public static void toDefaultSeletorEmpresa(this ComboBox cbx)
        {
            cbx.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx.Items.AddRange(empresas.ToArray());
            cbx.SelectedItem = Section.Unidade;
        }        
    }
}
