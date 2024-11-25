using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHC3_Definitive_Version.Customization
{
    public class CustomMenuStrip : MenuStrip
    {
        public CustomMenuStrip()
        {
            // Personalização das cores
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.ForeColor = Color.WhiteSmoke;

            // Configurações adicionais do MenuStrip
            this.RenderMode = ToolStripRenderMode.Professional;
            this.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
        }



        private class CustomProfessionalColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color MenuBorder => Color.FromArgb(80, 80, 80);
            public override Color MenuItemBorder => Color.FromArgb(100, 100, 100);
            public override Color MenuItemSelected => Color.FromArgb(120, 120, 120);
            public override Color MenuStripGradientBegin => Color.FromArgb(64, 64, 64);
            public override Color MenuStripGradientEnd => Color.FromArgb(64, 64, 64);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(120, 120, 120);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(120, 120, 120);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(120, 120, 120);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(120, 120, 120);
        }
    }
}
