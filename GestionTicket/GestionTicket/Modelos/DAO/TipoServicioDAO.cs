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
    public class TipoServicioDAO:Conexion   
    {
        SqlCommand comando = new SqlCommand(); 
        public bool AddTipoServicio(TipoServicio tipoServicio)
        {
            
            bool inserto = false;
            if (VerificarDuplicados(tipoServicio))
            {
                MessageBox.Show("Estas intentando guardar un tipo servicio ya existente");
            } else
            {
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append("INSERT INTO TIPO_SERVICIO VALUES (@Nombre, @Descripcion)");

                    comando.Connection = MiConexion;
                    MiConexion.Open();
                    comando.Parameters.Clear(); 

                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta.ToString();
                    comando.Parameters.AddWithValue("@Nombre", tipoServicio.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", tipoServicio.Descripcion);

                    comando.ExecuteNonQuery();
                    MiConexion.Close();
                    inserto = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar registrar el tipo de servicio");
                    MessageBox.Show(ex.Message);
                }
            }
            
            return inserto; 
        }

        public DataTable GetTipoServicio()
        {
            DataTable tablaTipoServicio = new DataTable(); 
            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT * FROM TIPO_SERVICIO");

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();

                SqlDataReader dataReader = comando.ExecuteReader();
                tablaTipoServicio.Load(dataReader); 
                comando.ExecuteNonQuery();
                MiConexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los tipos de servicio"); 
            }
            return tablaTipoServicio; 
        }

        public bool ModificarTipoServicio(TipoServicio tipoServicio)
        {
            SqlCommand comando2 = new SqlCommand(); 
            bool modifico = false;
            if (VerificarDuplicados(tipoServicio))
            {
                MessageBox.Show("Estas intentando guardar un tipo servicio ya existente");
            }
            else
            {
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append("UPDATE TIPO_SERVICIO SET NOMBRE = @Nombre, DESCRIPCION = @Descripcion");
                    consulta.Append(" WHERE ID = @Id"); 

                    comando2.Connection = MiConexion;
                    MiConexion.Open();

                    comando2.CommandType = System.Data.CommandType.Text;
                    comando2.CommandText = consulta.ToString();
                    comando2.Parameters.AddWithValue("@Nombre", tipoServicio.Nombre);
                    comando2.Parameters.AddWithValue("@Descripcion", tipoServicio.Descripcion);
                    comando2.Parameters.AddWithValue("@Id", tipoServicio.Id);

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

        public bool EliminarTipoServicio(int id)
        {
            bool elimino = false;

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("DELETE FROM TIPO_SERVICIO WHERE ID = @Id");

                comando.Connection = MiConexion;
                MiConexion.Open();

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

        public bool VerificarDuplicados(TipoServicio tipoServicio)
        {
            bool duplicado = false;

            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append("SELECT 1  FROM TIPO_SERVICIO WHERE NOMBRE = @Nombre AND DESCRIPCION = @Descripcion");

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();
                comando.Parameters.AddWithValue("@Nombre", tipoServicio.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", tipoServicio.Descripcion);

                duplicado = Convert.ToBoolean(comando.ExecuteScalar());
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
