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
using Tarea2Lab.BLL;
using Tarea2Lab.Entidades;

namespace Tarea2Lab.UI
{
 
    public partial class rRoles : Window
    {
        private Roles Rol = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = this.Rol;
        }
        private bool Validar()
        {
            bool esValido = true;

            if(DescripcionTextBox.Text.Length==0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void Limpiar()
        {
            RolIDTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;

            DataContext = new Roles();
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(RolIDTextBox.Text,out int RolId);
            var Rol = RolesBLL.Buscar(RolId);

            if (Rol != null)
                this.Rol = Rol;
            else
                this.Rol = new Roles();

            this.DataContext = this.Rol;
        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(this.Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Roles existe = RolesBLL.Buscar(this.Rol.RolId);

            if (RolesBLL.Eliminar(this.Rol.RolId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
