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
    public class TodosDetallesTicketDAO: Conexion
    {
        SqlCommand comando = new SqlCommand(); 

        public DataTable GetTodosDetallesTicket()
        {
            DataTable tablaTodosDetallesTicket = new DataTable();
            try
            {
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" SELECT T.ID AS TICKET, T.ID_CLIENTE, C.NOMBRE,TS.NOMBRE AS TIPO_SERVICIO, DT.DESCRIPCION, DT.COSTO, E.ESTADO ");
                consulta.Append(" FROM TICKET T, DETALLE_TICKET DT, ESTADO_TICKET E, CLIENTE C, TIPO_SERVICIO TS ");
                consulta.Append(" WHERE T.ID = DT.ID_TICKET AND T.ID = E.ID_TICKET AND T.ID_CLIENTE = C.ID AND T.ID_TIPO_SERVICIO = TS.ID ;"); 

                comando.Connection = MiConexion;
                MiConexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();

                SqlDataReader dataReader = comando.ExecuteReader();
                tablaTodosDetallesTicket.Load(dataReader);
                comando.ExecuteNonQuery();
                MiConexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar obtener los clientes");
            }
            return tablaTodosDetallesTicket;
        }

        public bool EliminarTicket(Ticket ticket)
        {
            MiConexion.Open();
            comando.Connection = MiConexion; 
            SqlTransaction transaccion = MiConexion.BeginTransaction();
            comando.Transaction = transaccion;

            bool elimino = false; 
            try
            {               
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" DELETE FROM TICKET WHERE ID = @IdTicket; "); 

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta.ToString();

                comando.Parameters.AddWithValue("@IdTicket", ticket.IdTicket);

                comando.ExecuteNonQuery();

                transaccion.Commit();
                
                MiConexion.Close();

                elimino = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar el Ticket");
                transaccion.Rollback();
                MessageBox.Show(ex.Message);
            }
            return elimino; 
        }

    }
}
