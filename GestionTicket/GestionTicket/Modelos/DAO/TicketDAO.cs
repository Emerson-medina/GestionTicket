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
    public class TicketDAO:Conexion
    {
        SqlCommand comando = new SqlCommand(); 
        public bool AddTicket(Ticket ticket)
        {
            comando.Connection = MiConexion;
            MiConexion.Open();
            SqlTransaction transaccion = MiConexion.BeginTransaction();
            bool inserto = false;
          /*  if (VerificarDuplicados(cliente))
            {
                MessageBox.Show("Estas intentando guardar un cliente ya existente");
            }
            else
            {*/
                try
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append(" INSERT INTO TICKET VALUES (@IdCliente, @IdTipoServicio, @IdEquipo, @Total); ");
                    consulta.Append(" SELECT SCOPE_IDENTITY(); ");
                    
                    
                    comando.Parameters.Clear();

                    comando.Transaction = transaccion; 
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta.ToString();
                    comando.Parameters.AddWithValue("@IdCliente", ticket.IdCliente);
                    comando.Parameters.AddWithValue("@IdTipoServicio", ticket.IdTipoServicio);
                    comando.Parameters.Add("@IdEquipo", SqlDbType.Int).Value = DBNull.Value;
                    comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = DBNull.Value;

                    int idTicket = Convert.ToInt32(comando.ExecuteScalar()); 
                    
                 
                    StringBuilder consulta2 = new StringBuilder();
                    consulta2.Append(" INSERT INTO DETALLE_TICKET VALUES (@IdTicket, @Detalle, @Costo);");

                    comando.Parameters.Clear(); 
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta2.ToString();
                    comando.Parameters.Add("@IdTicket", SqlDbType.Int).Value = idTicket;
                    comando.Parameters.AddWithValue("@Detalle", ticket.Detalle);
                    comando.Parameters.AddWithValue("@Costo", ticket.Costo);
                  
                    comando.ExecuteNonQuery();

                    StringBuilder consulta3 = new StringBuilder();
                    consulta3.Append(" INSERT INTO ESTADO_TICKET VALUES ('Sin resolver', @IdTicket); ");

                    comando.Parameters.Clear(); 
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = consulta3.ToString();

                    comando.Parameters.Add("@IdTicket", SqlDbType.Int).Value = idTicket;

                    comando.ExecuteNonQuery();

                    transaccion.Commit(); 
                    
                    MiConexion.Close();

                    inserto = true;

                    
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Ocurrió un error al intentar insertar el Ticket");
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                }
            //}

            return inserto;
        }


    }
}
