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
    public class TipoServicioController
    {
        TipoServicioView vista;
        string operacion = ""; 
        public TipoServicioController(TipoServicioView view)
        {
            vista = view;
            vista.AgregarButton.Click += new EventHandler(AgregarTipoServicio);
            vista.ModificarButton.Click += new EventHandler(ModificarTipoServicio);
            vista.EliminarButton.Click += new EventHandler(EliminarTipoServicio);
            vista.CancelarButton.Click += new EventHandler(CancelarOperacion); 
            vista.Load += Vista_Load;
        }

        private void CancelarOperacion(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void EliminarTipoServicio(object sender, EventArgs e)
        {
            if (vista.TipoServicioDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = false;

                TipoServicioDAO tipoServicioDAO = new TipoServicioDAO();

                elimino = tipoServicioDAO.EliminarTipoServicio(Convert.ToInt32(vista.TipoServicioDataGridView.CurrentRow.Cells["ID"].Value));

                if (elimino)
                {
                    MessageBox.Show("Tipo de servicio eliminado exitosamente");
                    LimpiarControles();
                    ListarTipoServicio();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar el tipo de servicio");
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void ModificarTipoServicio(object sender, EventArgs e)
        {
           if (vista.TipoServicioDataGridView.SelectedRows.Count>0)
           {
                vista.NombreTextBox.Text = vista.TipoServicioDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.DescripcionTextBox.Text = vista.TipoServicioDataGridView.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                vista.IdTextBox.Text = vista.TipoServicioDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                operacion = "Modificar"; 

            }
           else
           {
                MessageBox.Show("Debes seleccionar un registro");
           }
        }

        private void Vista_Load(object sender, EventArgs e)
        {
            vista.WindowState = FormWindowState.Maximized; 
            ListarTipoServicio(); 
        }

        private void AgregarTipoServicio(object sender, EventArgs e)
        {
            if (RevisarContenidoControles())
            {
                if (operacion == "Modificar")
                {
                    
                    bool modifico = false;

                    TipoServicioDAO tipoServicioDAO = new TipoServicioDAO();
                    TipoServicio tipoServicio = new TipoServicio();

                    tipoServicio.Nombre = vista.NombreTextBox.Text;
                    tipoServicio.Descripcion = vista.DescripcionTextBox.Text;
                    tipoServicio.Id = Convert.ToInt32(vista.IdTextBox.Text); 

                    modifico = tipoServicioDAO.ModificarTipoServicio(tipoServicio);

                    if (modifico)
                    {
                        MessageBox.Show("Tipo de servicio Modificado exitosamente");
                        LimpiarControles();
                        ListarTipoServicio();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar modificar el tipo de servicio");
                        LimpiarControles();
                        tipoServicio = null;
                    }
                } 
                else 
                {
                    bool agrego = false;

                    TipoServicioDAO tipoServicioDAO = new TipoServicioDAO();
                    TipoServicio tipoServicio = new TipoServicio();

                    tipoServicio.Nombre = vista.NombreTextBox.Text;
                    tipoServicio.Descripcion = vista.DescripcionTextBox.Text;

                    agrego = tipoServicioDAO.AddTipoServicio(tipoServicio);

                    if (agrego)
                    {
                        MessageBox.Show("Tipo de servicio agregado exitosamente");
                        LimpiarControles();
                        ListarTipoServicio();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar agregar el tipo de servicio");
                    }
                }
                operacion = ""; 
            } else
            {
                return; 
            }
           /* if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Debes ingresar un Nombre");
                vista.NombreTextBox.Focus();
                return;
            }

            if (vista.DescripcionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripcionTextBox, "Debes ingresar una Descripcion");
                vista.DescripcionTextBox.Focus();
                return;
            }*/

          
        }

        private void LimpiarControles()
        {
            vista.NombreTextBox.Clear();
            vista.DescripcionTextBox.Clear();
            vista.IdTextBox.Clear(); 
        }

        private bool RevisarContenidoControles()
        {
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Debes ingresar un Nombre");
                vista.NombreTextBox.Focus();
                return false;
            }

            if (vista.DescripcionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripcionTextBox, "Debes ingresar una Descripcion");
                vista.DescripcionTextBox.Focus();
                return false;
            }
            return true; 
        }

        private void ListarTipoServicio()
        {
            TipoServicioDAO tipoServicioDAO = new TipoServicioDAO(); 
            vista.TipoServicioDataGridView.DataSource = tipoServicioDAO.GetTipoServicio();
        }
    }
}
