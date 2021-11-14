using GestionTicket.Modelos.DAO;
using GestionTicket.Modelos.Entidades;
using GestionTicket.Vistas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTicket.Controladores
{
    public class ClienteController
    {
        ClienteView vista;
        TicketView vistaTicket; 
        string operacion = "";
        public ClienteController(ClienteView view, TicketView ticketView)
        {
            vistaTicket = ticketView; 
            vista = view;
            vista.GuardarButton.Click += new EventHandler(GuardarCliente);
            vista.ModificarButton.Click += new EventHandler(ModificarCliente);
            vista.EliminarButton.Click += new EventHandler(EliminarCliente);
            vista.CancelarButton.Click += new EventHandler(CancelarOperacion);
            vista.ImageButton.Click += new EventHandler(SeleccionarImagen);
            vista.SeleccionarButton.Click += new EventHandler(SeleccionarCliente); 
            vista.Load += Vista_Load;
        }

        private void SeleccionarCliente(object sender, EventArgs e)
        {
            vistaTicket.IdCliente = Convert.ToInt32(vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value);
            vistaTicket.ClienteTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
            MessageBox.Show($"El valor de idCliente es: {vistaTicket.IdCliente} "); 
            vista.Close();

        }

        private void SeleccionarImagen(object sender, EventArgs e)
        {
            OpenFileDialog ventana = new OpenFileDialog();
            //ventana.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG(*.png)|*.png";
            if (ventana.ShowDialog() == DialogResult.OK)
            {
                vista.ImagePictureBox.ImageLocation = ventana.FileName;
                vista.ImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void CancelarOperacion(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void EliminarCliente(object sender, EventArgs e)
        {
            if (vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = false;

                ClienteDAO clienteDAO = new ClienteDAO();

                elimino = clienteDAO.EliminarCliente(Convert.ToInt32(vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value));

                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado exitosamente");
                    LimpiarControles();
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar el cliente");
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un registro");
            }
        }

        private void ModificarCliente(object sender, EventArgs e)
        {
            if (vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                if (vista.ClientesDataGridView.CurrentRow.Cells["FOTO"].Value != DBNull.Value )
                {
                    vista.ImagePictureBox.Image = ByteArrayToImage((Byte[])vista.ClientesDataGridView.CurrentRow.Cells["FOTO"].Value); 
                } else
                {
                    vista.ImagePictureBox.Image = null; 
                }
                vista.IdTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.IdentidadMaskedTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["NRO_IDENTIDAD"].Value.ToString();
                vista.NombreTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.EmailTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                vista.TelefonoTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();
                vista.DireccionTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
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
            ListarClientes();
        }

        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private Image ByteArrayToImage(byte[] image)
        { 
            MemoryStream ms = new MemoryStream(image);
            Image i = Image.FromStream(ms);
            return i; 
        }

        private void GuardarCliente(object sender, EventArgs e)
        {
            if (RevisarContenidoControles())
            {
                if (operacion == "Modificar")
                {

                    bool modifico = false;

                    ClienteDAO clienteDAO = new ClienteDAO();
                    Cliente cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(vista.IdTextBox.Text); 
                    cliente.NroIdentidad = vista.IdentidadMaskedTextBox.Text;
                    cliente.Nombre = vista.NombreTextBox.Text;
                    cliente.Email = vista.EmailTextBox.Text;
                    cliente.Telefono = vista.TelefonoTextBox.Text;
                    cliente.Direccion = vista.DireccionTextBox.Text;
                    if (vista.ImagePictureBox.Image != null)
                    {
                        cliente.Foto = ImageToByteArray(vista.ImagePictureBox.Image); 
                    }


                    modifico = clienteDAO.ModificarCliente(cliente);

                    if (modifico)
                    {
                        MessageBox.Show("Cliente Modificado exitosamente");
                        LimpiarControles();
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar modificar el cliente");
                        LimpiarControles();
                        //tipoServicio = null
                    }
                }
                else
                {
                    bool agrego = false;

                    ClienteDAO clienteDAO = new ClienteDAO();
                    Cliente cliente = new Cliente();

                    cliente.NroIdentidad = vista.IdentidadMaskedTextBox.Text;
                    cliente.Nombre = vista.NombreTextBox.Text;
                    cliente.Email = vista.EmailTextBox.Text;
                    cliente.Telefono = vista.TelefonoTextBox.Text;
                    cliente.Direccion = vista.DireccionTextBox.Text;
                    if (vista.ImagePictureBox.Image != null)
                    {
                        cliente.Foto = ImageToByteArray(vista.ImagePictureBox.Image);
                    }

                    agrego = clienteDAO.AddCliente(cliente);

                    if (agrego)
                    {
                        MessageBox.Show("Cliente agregado exitosamente");
                        LimpiarControles();
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar agregar el cliente");
                    }
                }
                operacion = "";
            }
            else
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
            vista.IdTextBox.Clear();
            vista.IdentidadMaskedTextBox.Clear(); 
            vista.NombreTextBox.Clear();
            vista.EmailTextBox.Clear();
            vista.TelefonoTextBox.Clear(); 
            vista.DireccionTextBox.Clear();
            vista.ImagePictureBox.Image = null; 
        }

        private bool RevisarContenidoControles()
        {
            if (vista.IdentidadMaskedTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadMaskedTextBox, "Debes ingresar un Número de Identidad");
                vista.IdentidadMaskedTextBox.Focus();
                return false;
            }

            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Debes ingresar un Nombre");
                vista.NombreTextBox.Focus();
                return false;
            }

            if (vista.EmailTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EmailTextBox, "Debes ingresar un Email");
                vista.EmailTextBox.Focus();
                return false;
            }

            if (vista.TelefonoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TelefonoTextBox, "Debes ingresar un Telefono");
                vista.TelefonoTextBox.Focus();
                return false;
            }

            if (vista.DireccionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DireccionTextBox, "Debes ingresar una Direccion");
                vista.DireccionTextBox.Focus();
                return false;
            }
            return true;
        }

        private void ListarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            vista.ClientesDataGridView.DataSource = clienteDAO.GetCliente();
        }
    }
}

