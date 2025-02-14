using System.Drawing;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public static class CustomDataGridView
    {
        public static void toDefault(this DataGridView dataGridView, bool Multiselect = true)
        {
            //Grid            
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = Multiselect;
            dataGridView.ReadOnly = true;

            //Layout
            // Estilização dos Cabeçalhos
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.AutoResizeColumns();

        }
    }
}
