using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

//Espacios de nombre necesarios
using System.Drawing.Imaging;// para la clase imagen
using System.IO;



namespace _2021
{

    public partial class InDocente : Form
    {
        

        // Inicializar Interzas Docente
        public InDocente()
        {
            InitializeComponent();
        }
        conectar t = new conectar();
        private void button5_Click(object sender, EventArgs e)
        {
            // TablaListar.DataSource = t.ListarNombrados();
        }

        //  Cerrar ventana
        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Listado General
        private void ListarGeneral_Click(object sender, EventArgs e)
        {
            //TablaListar.DataSource = t.ListarContratado();
        }

        private void InDocente_Load(object sender, EventArgs e)
        {
            conectar t1 = new conectar();
            Listar.DataSource = t1.ListarDocentes();
        }

        // La funcion he hacer clik que nos permite seleccionar un dato en la tabla Grid View
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {

                CodigoNuevo.Text = Listar.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = Listar.CurrentRow.Cells[1].Value.ToString();
                Ap.Text = Listar.CurrentRow.Cells[2].Value.ToString();
                Am.Text = Listar.CurrentRow.Cells[3].Value.ToString();
                Tipo.Text = Listar.CurrentRow.Cells[4].Value.ToString();
                Direccion.Text = Listar.CurrentRow.Cells[5].Value.ToString();
                Email.Text = Listar.CurrentRow.Cells[6].Value.ToString();
                Telefono.Text = Listar.CurrentRow.Cells[7].Value.ToString();
                Sexo.Text = Listar.CurrentRow.Cells[8].Value.ToString();
                byte[] Foto = (byte[])(Listar.CurrentRow.Cells["Foto"].Value); // obtener los datos binarios de la imagen que se encuentra en la BD
                System.IO.MemoryStream m = new System.IO.MemoryStream(Foto); // convertir bytes en imagen
                imagen.Image = Image.FromStream(m); // mostrar la foto en el picturebox

            }
            catch
            {


            } 
        }

        // La funcion que nos permite hacer clik para mostrar la ultima actualizacion de docentes.
        private void Actualizar_Click(object sender, EventArgs e)
        {
            Listar.DataSource = t.ListarDocentes();

            CodigoNuevo.Text = "";
            Nombre.Text = "";
            Ap.Text = "";
            Am.Text = "";
            Tipo.Text = "";
            Direccion.Text = "";
            Email.Text = "";
            Telefono.Text = "";
            Sexo.Text = "";
            imagen.Image = null;
        }
        // La funcion que nos permite hacer clik para Agregar nuevos docentes.
        private void Agregar_Click(object sender, EventArgs e)
        {

            if ( Nombre.Text != "" && Ap.Text != "" && Am.Text != "" && Tipo.Text != "" && Direccion.Text != "" && Email.Text != "" && Telefono.Text != "" && Sexo.Text != "" && imagen.Image != null)
            {//Validamos Nombre.Txt

                if (validarstring() == true)
                {
                    //Creamos Clase Docente.
                    CDocente t = new CDocente();

                    //Creamos una memoria para guardar informacion
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    // guardamos el box imagen.umagen en ms de forma jpeg.
                    imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    t.Codigo = "";
                    t.Nombre = Nombre.Text;
                    t.Ap = Ap.Text;
                    t.Am = Am.Text;
                    t.Tipo = Tipo.Text;
                    t.Direccion = Direccion.Text;
                    t.Email = Email.Text;
                    t.Telefono = Telefono.Text;
                    t.Sexo = Sexo.Text;
                    t.foto = ms.GetBuffer();

                    MessageBox.Show("¿ESTA SEGURO QUE DESEA AGREGAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int resultado = conectar.Agregar(t);

                    if (resultado > 0)
                    {
                        MessageBox.Show("LOS DATOS HAN SIDO REGISTRADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR NO SE PUDO REGISTRAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("ERROR NO SE PUDO REGISTRAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("COMPLETE ESPACIOS EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private bool validarstring()
        {
            bool ok = true;
            // empesamos validar cada text box
            if(Nombre.Text == "" /*&& Ap.Text == ""  && Am.Text=="" && Tipo.Text=="" && Direccion.Text == "" && Email.Text=="" && Telefono.Text=="" && Sexo.Text=="" && CodigoNuevo.Text=="" */)
            {
                ok = false;
                errorProvider1.SetError(Nombre, "Nombre docente vacio");
                //errorProvider2.SetError(Ap, "Apellido paterno  vacio");
                /* errorProvider3.SetError(Am, "Apellido materno vacio");
                errorProvider4.SetError(Tipo, "Tipo Docente vacio");
                errorProvider5.SetError(Direccion, "Direccion docente vacio");
                errorProvider6.SetError(Email, "Email docente vacio");
                errorProvider7.SetError(Telefono, "Telefono vacio");
                errorProvider8.SetError(Sexo, "Sexo Docente vacio");
                errorProvider9.SetError(CodigoNuevo, "Codigo docente vacio"); */
                //errorProvider10.SetError(imagen, "Imagen docente vacio");
            }
            return ok;
        }
        private bool validarNombre()
        {
            bool ok = true;
            // empesamos validar cada text box
            if (Nombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(Nombre, "Ingrese su nombre");
            }

            return ok;
        }




        private void btnVerImagen_Click(object sender, EventArgs e)
        {
            CodigoNuevo.Text = "";
            Nombre.Text = "";
            Ap.Text = "";
            Am.Text = "";
            Tipo.Text = "";
            Direccion.Text = "";
            Email.Text = "";
            Telefono.Text = "";
            Sexo.Text = "";
        }

        private void modificar1()
        {
            int r;
            SqlConnection c = conexion.LeerCadena();
            SqlCommand t = new SqlCommand(string.Format("UPDATE Docentes set  Nombre = '" + this.Nombre.Text + "', ApellidoP = '" + this.Ap.Text + "', ApellidoM = '" + this.Am.Text + "', TipoDocentes = '" + this.Tipo.Text + "', Direccion = '" + this.Direccion.Text + "', Correo = '" + this.Email.Text + "', Celular = '" + this.Telefono.Text + "', Sexo = '" + this.Sexo.Text + "' where CodDocente = " + this.CodigoNuevo.Text + "", c));
            r = t.ExecuteNonQuery();

            if (r > 0)
            {
                MessageBox.Show("¡FELICIDADES MODIFICASTE TUS DATOS! ", "BASE DE DATOS UNSAAC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡ERROR NO SE MODIFICO!", "DATOS INCORRECTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }
        private bool Modificar = false;
        private bool validar = false;
        private void Editar_Click(object sender, EventArgs e)
        {
            

            //Creamos una memoria para guardar informacion
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            // guardamos el box imagen.umagen en ms de forma jpeg.
            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            CDocente d = new CDocente();

            d.Codigo = CodigoNuevo.Text;
            d.Nombre = Nombre.Text;
            d.Ap = Ap.Text;
            d.Am = Am.Text;
            d.Tipo = Tipo.Text;
            d.Direccion = Direccion.Text;
            d.Email = Email.Text;
            d.Telefono = Telefono.Text;
            d.Sexo = Sexo.Text;
            d.foto = ms.GetBuffer();

            MessageBox.Show("¿ESTA SEGURO QUE DESEA EDITAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = conectar.Editar(d);
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO MODIFICAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            //d.Codigo = 


        }

        // objetos necesarios para la importacion de datos al sql
        SqlConnection cn = new SqlConnection();


        // CLICK BUSCAR
        private void Buscar_Click(object sender, EventArgs e)
        {
           
            //Creamos una memoria para guardar informacion
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CDocente d = new CDocente();
            d.Codigo = CodigoNuevo.Text;

            if (CodigoNuevo.Text != "")
            {
                try
                {

                    DataTable n = conectar.BuscarDocente(d);
                    //CodigoNuevo.Text = validar.ToString();
                    Listar.DataSource = n;
                    Nombre.Text = Listar.CurrentRow.Cells["Nombres"].Value.ToString();
                    Ap.Text = Listar.CurrentRow.Cells["Apellido_Paterno"].Value.ToString();
                    Am.Text = Listar.CurrentRow.Cells["Apellido_Materno"].Value.ToString();
                    Tipo.Text = Listar.CurrentRow.Cells["TipoDocentes"].Value.ToString();
                    Direccion.Text = Listar.CurrentRow.Cells["Direccion"].Value.ToString();
                    Email.Text = Listar.CurrentRow.Cells["Correo"].Value.ToString();
                    Telefono.Text = Listar.CurrentRow.Cells["Celular"].Value.ToString();
                    Sexo.Text = Listar.CurrentRow.Cells["Sexo"].Value.ToString();
                    byte[] Foto = (byte[])(Listar.CurrentRow.Cells["Foto"].Value); // obtener los datos binarios de la imagen que se encuentra en la BD
                    System.IO.MemoryStream m = new System.IO.MemoryStream(Foto); // convertir bytes en imagen
                    imagen.Image = Image.FromStream(m); // mostrar la foto en el picturebox
                    MessageBox.Show("CODIGO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR DE BUSQUEDA DE CODIGO", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
            else
            {
                MessageBox.Show("CODIGO EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            

            /*
            // Llamamos la funcion busqueda en SQL SERVER.... 2019 -2021
            List<CDocente> lista1 = new List<CDocente>();
            using (SqlConnection c = conexion.LeerCadena())
            {
                SqlCommand t = new SqlCommand(string.Format("SELECT * FROM Docentes WHERE CodDocente like '%{0}%'", CodigoNuevo.Text), conexion.LeerCadena());
                SqlDataReader n = t.ExecuteReader();
                while (n.Read())
                {
                    CDocente A = new CDocente();
                    A.Codigo = n.GetString(0);
                    A.Nombre = n.GetString(1);
                    A.Ap = n.GetString(2);
                    A.Am = n.GetString(3);
                    A.Tipo = n.GetString(4);
                    A.Direccion = n.GetString(5);
                    A.Email = n.GetString(6);
                    A.Telefono = n.GetString(7);
                    A.Sexo = n.GetString(8);
                    
                    lista1.Add(A);

                    Nombre.Text = n.GetString(1);
                    Ap.Text = n.GetString(2);
                    Am.Text = n.GetString(3);
                    Tipo.Text = n.GetString(4);
                    Direccion.Text = n.GetString(5);
                    Email.Text = n.GetString(6);
                    Telefono.Text = n.GetString(7);
                    Sexo.Text = n.GetString(8);
                    byte[] Foto = (byte[])(Listar.CurrentRow.Cells["foto"].Value); // obtener los datos binarios de la imagen que se encuentra en la BD
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Foto); // convertir bytes en imagen
                    imagen.Image = Image.FromStream(ms); // mostrar la foto en el picturebox 

                }
                conexion.LeerCadena();
            }
            Listar.DataSource = lista1;
            */
        }


        // Hacer click y Eliminar por codigo.
        private void Eliminar_Click(object sender, EventArgs e)
        {
            CDocente e1 = new CDocente();
            e1.Codigo = CodigoNuevo.Text;
            e1.Nombre = Nombre.Text;
            e1.Ap = Ap.Text;
            e1.Am = Am.Text;
            e1.Tipo = Tipo.Text;
            e1.Direccion = Direccion.Text;
            e1.Email = Email.Text;
            e1.Telefono = Telefono.Text;
            e1.Sexo = Sexo.Text;
            MessageBox.Show("¿ESTA SEGURO QUE DESEA ELIMINAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = conectar.Eliminar(e1);
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS FUERON ELIMINADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO ELIMINAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                imagen.Image = Image.FromFile(dialogo.FileName);

                //Adecuamos la imagen al tamaño del cuadro.
                //imagen.SizeMode = PictureBoxSizeMode.StretchImage;

            }



        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
