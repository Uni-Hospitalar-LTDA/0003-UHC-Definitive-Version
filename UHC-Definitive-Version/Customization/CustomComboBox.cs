using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public static  class CustomComboBox
    {
        public static void toDefaultStatus(this ComboBox comboBox)
        {
            string[] status = { "Inativo", "Ativo" };
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.AddRange(status);
        }
    }
}
