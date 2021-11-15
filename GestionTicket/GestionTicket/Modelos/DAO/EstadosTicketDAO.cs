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
    public class EstadosTicketDAO: Conexion
    {
        SqlCommand comando = new SqlCommand(); 
        public bool GuardarEstado(EstadoTicket estadoTicket)
        {
            bool inserto = false; 
            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" UPDATE ESTADO_TICKET SET ESTADO = @Estado WHERE ID_TICKET = @IdTicket ; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                //comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();
                comando.Parameters.AddWithValue("@Estado", estadoTicket.Estado);
                comando.Parameters.AddWithValue("@IdTicket", estadoTicket.Id); 

                comando.ExecuteNonQuery();
                MiConexion.Close();
                inserto = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el nuevo estado");
                MessageBox.Show(ex.Message);
            }
            return inserto; 
        }

        public DataTable GetTicket()
        {
            DataTable tablaEstadoTicket = new DataTable();
            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" SELECT * FROM ESTADO_TICKET ; ");

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();

                SqlDataReader dataReader = comando.ExecuteReader();
                tablaEstadoTicket.Load(dataReader);
                comando.ExecuteNonQuery();
                MiConexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los estados de los ticket");
            }
            return tablaEstadoTicket;
        }
    }
}
