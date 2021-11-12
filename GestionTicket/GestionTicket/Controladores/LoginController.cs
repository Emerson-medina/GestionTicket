using GestionTicket.Modelos.DAO;
using GestionTicket.Modelos.Entidades;
using GestionTicket.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Controladores
{
     public class LoginController
    {
        LoginView vista;
     
        public LoginController(LoginView view)
        {
            vista = view;
            vista.IngresarButton.Click += new EventHandler(ValidarUsuario); 
        }

        private void ValidarUsuario(object sender, EventArgs e)
        {
            if (vista.EmailTextBox.Text == "") {
                vista.errorProvider1.SetError(vista.EmailTextBox, "Debes ingresar un Email");
                vista.EmailTextBox.Focus();
                return; 
            }

            if (vista.ClaveTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ClaveTextBox, "Debes ingresar una Clave");
                vista.ClaveTextBox.Focus(); 
                return;
            }

            bool valido = false;

            UsuarioDAO userDAO = new UsuarioDAO();
            Usuario user = new Usuario();

            user.Email = vista.EmailTextBox.Text;
            user.Clave = vista.ClaveTextBox.Text; 

            valido = userDAO.ValidarUsuario(user);

            if (valido)
            {
                MessageBox.Show("Usuario valido");

                vista.Hide(); 
                MenuView menuView = new MenuView();
                menuView.ShowDialog();
                vista.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
            }
        }
    }
}
