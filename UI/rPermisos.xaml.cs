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
using System.Windows.Shapes;
using Tarea2Lab.BLL;
using Tarea2Lab.Entidades;

namespace Tarea2Lab.UI
{
    /// <summary>
    /// Interaction logic for Permisos.xaml
    /// </summary>
    public partial class rPermisos : Window
    {
        private Permisos permiso;
        public rPermisos()
        {
            InitializeComponent();
            this.permiso = new Permisos();
            this.DataContext = this.permiso;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void Limpiar()
        {
            this.permiso = new Permisos();
            DataContext = new Permisos();
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Permisos existe = PermisosBLL.Buscar(this.permiso.PermisoId);

            if (PermisosBLL.Eliminar(this.permiso.PermisoId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PermisosBLL.Guardar(this.permiso);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(PermisoIDTextBox.Text, out int PermisoId);
            var permiso = PermisosBLL.Buscar(PermisoId);

            if (permiso != null)
                this.permiso = permiso;
            else{
                    this.permiso = new Permisos();
                    MessageBox.Show("Este Permiso no existe.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.permiso;

        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
