using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trabalho_Mercado_Online.Dao;

namespace Trabalho_Mercado_Online.Views
{
    /// <summary>
    /// Lógica interna para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbContextDao db = new DbContextDao();

            var a = db.TbEstados.ToList();
        }
    }
}
