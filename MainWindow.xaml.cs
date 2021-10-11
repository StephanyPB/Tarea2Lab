using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tarea2Lab.UI;

namespace Tarea2Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RolesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles roles = new rRoles();
            roles.Show();
        }

        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuario usuario = new rUsuario();
            usuario.Show();

        }

        private void PermisoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPermisos permiso = new rPermisos();
            permiso.Show();
        }
    }
}
