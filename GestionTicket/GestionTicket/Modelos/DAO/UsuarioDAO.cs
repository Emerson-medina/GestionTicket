using GestionTicket.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Modelos.DAO
{
    public class UsuarioDAO:Conexion
    {
        SqlCommand comando = new SqlCommand(); 
        public bool ValidarUsuario( Usuario user)
        {
            bool valido = false;

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT 1 FROM USUARIO WHERE EMAIL = @Email and CLAVE  = @Clave");

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();
                comando.Parameters.AddWithValue("@Email", user.Email);
                comando.Parameters.AddWithValue("@Clave", user.Clave);

                valido = Convert.ToBoolean(comando.ExecuteScalar());
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hemos tenido un problema al intentar validar el usuario");
                MessageBox.Show(ex.Message); 
            }

            return valido; 
        }

    }
}
