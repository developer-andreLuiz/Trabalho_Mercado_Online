using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Views.Principal;

namespace Trabalho_Mercado_Online
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


          
            GlobalHelper.Listas = new ListasBancoHelper();
            Application.Run(new FrmPrincipal());
        }
    }
}
