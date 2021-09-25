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
    /// Interaction logic for rUsuario.xaml
    /// </summary>
    public partial class rUsuario : Window
    {
        private Usuario Usuario = new Usuario();
        public rUsuario()
        {
            InitializeComponent();
            Usuario = new Usuario();
            this.DataContext = this.Usuario;
            LlenarCombo();

        }
        private void LlenarCombo()
        {
            this.RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            this.RolIdComboBox.SelectedValuePath = "RolId";
            this.RolIdComboBox.DisplayMemberPath = "Descripcion";

            if (RolIdComboBox.Items.Count > 0)
                RolIdComboBox.SelectedIndex = 0;
        }
        private bool Validar()
        {
            bool esValido = true;
           
            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ConfirmarClaveTextBox.Text != null && !ClaveTextBox.Text.Equals(ConfirmarClaveTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Las contraseñas deben ser iguales!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (RolIdComboBox.Items.Count <= 0)
            {
                esValido = false;
                MessageBox.Show("Debes agregar un Rol", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void Limpiar()
        {

            UsuarioIDTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            AliasTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ConfirmarClaveTextBox.Text = string.Empty;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            EmailTextBox.Text = string.Empty;
            RolIdComboBox.SelectedItem = null;


            DataContext = new Usuario();
            LlenarCombo();
        }


        private void BuscarId_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(UsuarioIDTextBox.Text, out int RolId);
            var Usuario = UsuarioBLL.Buscar(RolId);

            if (Usuario != null)
                this.Usuario = Usuario;
            else
                this.Usuario = new Usuario();

            this.DataContext = this.Usuario;

        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuarioBLL.Guardar(this.Usuario);

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
            Usuario existe = UsuarioBLL.Buscar(this.Usuario.UsuarioId);

            if (UsuarioBLL.Eliminar(this.Usuario.UsuarioId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
