using System.Drawing;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomToolStripMenuItem : ToolStripMenuItem
    {
        public CustomToolStripMenuItem(string text)
        {
            this.ForeColor = Color.WhiteSmoke;
            this.Text = text;
        }
    }
}
