using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;


namespace _2021
{
    public partial class FormMantenimientoEstudiante : Form
    {





        private bool Modificar = false;
        private bool validar = false;
        NEstudiante obj = new NEstudiante();
        EEstudiante obje = new EEstudiante();
        

        public FormMantenimientoEstudiante()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void cerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void cerrar_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void MostrarListaEstudiantes()
        {
            btnGuardarCambios.Visible = false;
            dataGridViewEstudiantes.DataSource = obj.Mostrar_Estudiante();
            dataGridViewEstudiantes.Columns[9].Visible = false;
        }
        public void limpiar()
        {
            txtCodigo.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtNombres.Clear();
            txtDocumento.Clear();
            cbxSexo.Text = "";
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            btnGuardarCambios.Visible = false;
            Cargar_Imagen_default();

        }
        private void Cargar_Imagen_default()
        {
            try
            {

                string Ruta = Directory.GetCurrentDirectory();            // recuperar la direccion actual del directorio
                int Indice = Ruta.IndexOf(@"Mantenimiento_Estudiantes\"); // recuperar el indice de directorio "Mantenimiento_Estudiantes" en ruta
                Ruta = Ruta.Substring(0, Indice - 1) + @"\Mantenimiento_Estudiantes\Imagenes\283234.png"; // establecer direccion del nuevo directorio                
                pbxFoto.Image.Dispose();                                  // limpiar imagen y colocar imagen por defecto del directorio de la aplicacion
                pbxFoto.Image = System.Drawing.Image.FromFile(Ruta);
            }
            catch (Exception)
            {
                MessageBox.Show("Imagen por defecto no encontrada", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnFoto.Visible = true;
            validar = true;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            NEstudiante obj = new NEstudiante();
            EEstudiante OEstudiante = new EEstudiante();
            btnGuardarCambios.Visible = false;
            if (Modificar == false)
            {
                try
                {
                    if (txtApellidoPaterno.Text != "")
                    {
                        if (txtApellidoMaterno.Text != "")
                        {
                            if (txtNombres.Text != "")
                            {
                                if (txtDocumento.Text != "" && txtDocumento.Text.Length == 8)
                                {
                                    if (cbxSexo.Text != "")
                                    {
                                        if (txtDireccion.Text != "")
                                        {
                                            if (txtTelefono.Text != "" && txtTelefono.Text.Length == 9 && pbxFoto.Image != null)
                                            {
                                                pbxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                                OEstudiante.CODIGO = "";
                                                OEstudiante.APELLIDO_PATERNO = txtApellidoPaterno.Text;
                                                OEstudiante.APELLIDO_MATERNO = txtApellidoMaterno.Text;
                                                OEstudiante.NOMBRES = txtNombres.Text;
                                                OEstudiante.DOCUMENTO = txtDocumento.Text;
                                                OEstudiante.SEXO = cbxSexo.Text;
                                                OEstudiante.DIRECCION = txtDireccion.Text;
                                                OEstudiante.TELEFONO = txtTelefono.Text;
                                                OEstudiante.EMAIL = txtEmail.Text;
                                                OEstudiante.FOTO = ms.GetBuffer();
                                                obj.Agregar_Estudiante(OEstudiante);
                                                MessageBox.Show("Los datos se agregaron correctamente");
                                                MostrarListaEstudiantes();
                                                limpiar();
                                            }
                                            else
                                                MessageBox.Show("Ingrese numero telefónico");
                                        }
                                        else
                                            MessageBox.Show("Ingrese la direccion");
                                    }
                                    else
                                        MessageBox.Show("Indique el sexo");
                                }
                                else
                                    MessageBox.Show("Ingrese correctamente el documento de identidad");
                            }
                            else
                                MessageBox.Show("Ingrese el nombre");
                        }
                        else
                            MessageBox.Show("Ingrese el apellido materno");
                    }
                    else
                        MessageBox.Show("Ingrese el apellido paterno");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo agregar");
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnGuardarCambios.Visible = true;
            validar = false;
            if (dataGridViewEstudiantes.SelectedRows.Count > 0)
            {
                Modificar = true;
                txtApellidoPaterno.Text = dataGridViewEstudiantes.CurrentRow.Cells["Apellido_Paterno"].Value.ToString();
                txtApellidoMaterno.Text = dataGridViewEstudiantes.CurrentRow.Cells["Apellido_Materno"].Value.ToString();
                txtNombres.Text = dataGridViewEstudiantes.CurrentRow.Cells["Nombres"].Value.ToString();
                txtDocumento.Text = dataGridViewEstudiantes.CurrentRow.Cells["DNI"].Value.ToString();
                cbxSexo.Text = dataGridViewEstudiantes.CurrentRow.Cells["Sexo"].Value.ToString();
                txtDireccion.Text = dataGridViewEstudiantes.CurrentRow.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dataGridViewEstudiantes.CurrentRow.Cells["Telefono"].Value.ToString();
                txtEmail.Text = dataGridViewEstudiantes.CurrentRow.Cells["Email"].Value.ToString();
                txtCodigo.Text = dataGridViewEstudiantes.CurrentRow.Cells["Codigo_Estudiante"].Value.ToString();
                // Recuperar la imagen de la BD
                byte[] Foto = (byte[])(dataGridViewEstudiantes.CurrentRow.Cells["Foto"].Value); // obtener los datos binarios de la imagen que se encuentra en la BD
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Foto); // convertir bytes en imagen
                pbxFoto.Image = Image.FromStream(ms); // mostrar la foto en el picturebox 
            }
            else
                MessageBox.Show("Seleccione una fila por favor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnFoto.Visible = false;
            EEstudiante objE = new EEstudiante();
            if (dataGridViewEstudiantes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    objE.CODIGO = dataGridViewEstudiantes.CurrentRow.Cells["Codigo_Estudiante"].Value.ToString();
                    obj.EliminarRegistro(objE);
                    MessageBox.Show("Eliminado correctamente");
                    MostrarListaEstudiantes();
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            if (Modificar == true)
            {
                if (MessageBox.Show("¿Desea modificar el registro actual?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pbxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        NEstudiante obj = new NEstudiante();
                        EEstudiante OEstudiante = new EEstudiante();

                        if (txtApellidoPaterno.Text != "")
                        {
                            if (txtApellidoMaterno.Text != "")
                            {
                                if (txtNombres.Text != "")
                                {
                                    if (txtDocumento.Text != "" && txtDocumento.Text.Length == 8)
                                    {
                                        if (cbxSexo.Text != "")
                                        {
                                            if (txtDireccion.Text != "")
                                            {
                                                if (txtTelefono.Text != "" && txtTelefono.Text.Length == 9)
                                                {
                                                    OEstudiante.CODIGO = txtCodigo.Text;
                                                    OEstudiante.APELLIDO_PATERNO = txtApellidoPaterno.Text;
                                                    OEstudiante.APELLIDO_MATERNO = txtApellidoMaterno.Text;
                                                    OEstudiante.NOMBRES = txtNombres.Text;
                                                    OEstudiante.DOCUMENTO = txtDocumento.Text;
                                                    OEstudiante.SEXO = cbxSexo.Text;
                                                    OEstudiante.DIRECCION = txtDireccion.Text;
                                                    OEstudiante.TELEFONO = txtTelefono.Text;
                                                    OEstudiante.EMAIL = txtEmail.Text;
                                                    OEstudiante.FOTO = ms.GetBuffer();
                                                    obj.Modificar_Estudiante(OEstudiante);
                                                    MessageBox.Show("El registro se modificó correctamente");
                                                    MostrarListaEstudiantes();
                                                    Modificar = false;
                                                }
                                                else
                                                    MessageBox.Show("Ingrese numero telefónico");
                                            }
                                            else
                                                MessageBox.Show("Ingrese la direccion");
                                        }
                                        else
                                            MessageBox.Show("Indique el sexo");
                                    }
                                    else
                                        MessageBox.Show("Ingrese correctamente el documento de identidad");
                                }
                                else
                                    MessageBox.Show("Ingrese el nombre");
                            }
                            else
                                MessageBox.Show("Ingrese el apellido materno");
                        }
                        else
                            MessageBox.Show("Ingrese el apellido paterno");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo editar los datos");
                    }
                }

            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                obje.CODIGO = txtCodigo.Text;
                DataTable dt = new DataTable();
                dt = obj.Buscar_Estudiante(obje);
                dataGridViewEstudiantes.DataSource = dt;
            }
            else
            {
                //MessageBox.Show("Registro no encontrado","Notificacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridViewEstudiantes.DataSource = obj.Mostrar_Estudiante();
            }

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto = new OpenFileDialog();
            DialogResult resultado = foto.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pbxFoto.Image = Image.FromFile(foto.FileName);
            }

        }










        

        
        // =============================================================================
        private void FormMantenimientoEstudiante_Load(object sender, EventArgs e)
        {
            btnGuardarCambios.Visible = false;

            MostrarListaEstudiantes();
        }
        
        // =============================================================================
        //                      CONFIGURACION DE LOS BOTONES
        // =============================================================================
        
        
        
        
        
        

        // =============================================================================
        //                      VALIDAR EL INGRESO DE SOLO LETRAS
        // =============================================================================
        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        // =============================================================================
        //                      VALIDAR EL INGRESO DE SOLO NUMEROS
        // =============================================================================
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo Números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingrese solo Números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        // ==================== VALIDACIONES ADICIONALES ===============================
        private void txtApellidoPaterno_Validated(object sender, EventArgs e)
        {
            if (validar == true)
            {
                if (txtApellidoPaterno.Text.Trim() == "")
                {
                    epError.SetError(txtApellidoPaterno, "Ingresa el Apellido Paterno");
                    txtApellidoPaterno.Focus();
                }
                else
                {
                    epError.Clear();
                }
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (validarEmail(txtEmail.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion de correo no valido, el correo debe tener el formato: nombre@ejemplo.com," + "por favor ingrese un correo valido", "validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.SelectAll();
                //txtEmail.Focus();
            }
        }
        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }
        
        
        
        // =============================================================================
        private void dataGridViewEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // =============================================================================
        //                      CONFIGURACION DE LOS TEXT BOX
        // =============================================================================
        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pbxFoto_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEstudiantes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormMantenimientoEstudiante_Load_1(object sender, EventArgs e)
        {
            btnGuardarCambios.Visible = false;

            MostrarListaEstudiantes();
        }
    }
}
