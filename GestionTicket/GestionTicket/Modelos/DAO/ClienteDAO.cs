using GestionTicket.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Modelos.DAO
{
    public class ClienteDAO:Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool AddCliente(Cliente cliente)
        {

            bool inserto = false;
            if (VerificarDuplicados(cliente))
            {
                MessageBox.Show("Estas intentando guardar un cliente ya existente");
            }
            else
            {
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append("INSERT INTO CLIENTE VALUES (@NroIdentidad, @Nombre, @Email, @Telefono, @Direccion, @Foto )");

                    comando.Connection = MiConexion;
                    MiConexion.Open();
                    //comando.Parameters.Clear();

                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta.ToString();
                    comando.Parameters.AddWithValue("@NroIdentidad", cliente.NroIdentidad);
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Email", cliente.Email);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    if (cliente.Foto == null)
                    {
                        comando.Parameters.Add("@Foto", SqlDbType.Image).Value = DBNull.Value;
                        //comando.Parameters.AddWithValue("@Foto", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.Add("@Foto", System.Data.SqlDbType.Image).Value = cliente.Foto;
                        //comando.Parameters.AddWithValue("@Foto", cliente.Foto);
                    }

                    comando.ExecuteNonQuery();
                    MiConexion.Close();
                    inserto = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar insertar el cliente");
                    MessageBox.Show(ex.Message);
                }
            }

            return inserto;
        }

        public bool ModificarCliente(Cliente cliente)
        {
            SqlCommand comando2 = new SqlCommand();
            bool modifico = false;
            if (VerificarDuplicados(cliente))
            {
                MessageBox.Show("Estas intentando guardar un cliente ya existente");
            }
            else
            {
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append("UPDATE CLIENTE SET NRO_IDENTIDAD = @NroIdentidad, NOMBRE = @Nombre, EMAIL = @Email, TELEFONO = @Telefono, " +
                                    " DIRECCION = @Direccion, FOTO = @Foto");
                    consulta.Append(" WHERE ID = @Id");

                    comando2.Connection = MiConexion;
                    MiConexion.Open();

                    comando2.CommandType = System.Data.CommandType.Text;
                    comando2.CommandText = consulta.ToString();

                    comando2.Parameters.AddWithValue("@Id", cliente.Id); 
                    comando2.Parameters.AddWithValue("@NroIdentidad", cliente.NroIdentidad);
                    comando2.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando2.Parameters.AddWithValue("@Email", cliente.Email);
                    comando2.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando2.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    if (cliente.Foto == null)
                    {
                        comando2.Parameters.Add("@Foto", SqlDbType.Image).Value = DBNull.Value;

                        //comando.Parameters.AddWithValue("@Foto", DBNull.Value);
                    }
                    else
                    {
                        comando2.Parameters.Add("@Foto", SqlDbType.Image).Value = cliente.Foto;

                        //comando.Parameters.AddWithValue("@Foto", cliente.Foto);
                    }

                    comando2.ExecuteNonQuery();
                    MiConexion.Close();
                    modifico = true;
                }
                catch (Exception ex)
                {
                    modifico = false;
                    MessageBox.Show(ex.Message);
                }

            }
            return modifico;
        }

        public DataTable GetCliente()
        {
            DataTable tablaCliente = new DataTable();
            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT * FROM CLIENTE");

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();

                SqlDataReader dataReader = comando.ExecuteReader();
                tablaCliente.Load(dataReader);
                comando.ExecuteNonQuery();
                MiConexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los clientes");
            }
            return tablaCliente;
        }

        public bool EliminarCliente(int id)
        {
            bool elimino = false;

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("DELETE FROM CLIENTE WHERE ID = @Id");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear(); 

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();
                comando.Parameters.AddWithValue("@Id", id);

                comando.ExecuteNonQuery();
                MiConexion.Close();
                elimino = true;
            }
            catch (Exception ex)
            {
                elimino = false;
                MessageBox.Show(ex.Message);
            }
            return elimino;
        }
        public bool VerificarDuplicados(Cliente cliente)
        {
            SqlCommand comando2 = new SqlCommand(); 
            bool duplicado = false;

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT 1  FROM CLIENTE WHERE NRO_IDENTIDAD = @NroIdentidad AND EMAIL = @Email AND ID <> @Id"); 

                comando2.Connection = MiConexion;
                MiConexion.Open();
                //comando.Parameters.Clear(); 

                comando2.CommandType = System.Data.CommandType.Text;
                comando2.CommandText = consulta.ToString();
                comando2.Parameters.AddWithValue("@Id", cliente.Id); 
                comando2.Parameters.AddWithValue("@NroIdentidad", cliente.NroIdentidad);
                comando2.Parameters.AddWithValue("@Email", cliente.Email);

                duplicado = Convert.ToBoolean(comando2.ExecuteScalar());
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                duplicado = false;
                MessageBox.Show(ex.Message);
            }
            return duplicado;
        }
    }
}
