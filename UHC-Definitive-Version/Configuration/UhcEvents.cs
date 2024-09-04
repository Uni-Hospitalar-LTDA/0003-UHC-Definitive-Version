using System;
using System.Diagnostics;

namespace UHC3_Definitive_Version.Configuration
{
    public static class UhcEvents
    {
        public static void glpi_Click(object sender, EventArgs e)
        {
            Process.Start("http://10.5.1.20/glpi");
        }
    }
}
