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

namespace _2021
{
    public partial class InTipoMatricula : Form
    {
        public InTipoMatricula()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            txtCodMatricula.Text = " ";
            txtDescripcion.Text = " ";
            txtActivo.Text = " ";
            txtConvenio.Text = " ";
            txtBuscarCodigo.Text = " ";
            txtBuscarDescripcion.Text = " ";
        }

        private void Listar1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtCodMatricula.Text = Listar1.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = Listar1.CurrentRow.Cells[1].Value.ToString();
                txtActivo.Text = Listar1.CurrentRow.Cells[2].Value.ToString();
                txtConvenio.Text = Listar1.CurrentRow.Cells[3].Value.ToString();
                txtBuscarCodigo.Text = Listar1.CurrentRow.Cells[0].Value.ToString();
                txtBuscarDescripcion.Text = Listar1.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            {


            }
        }
        private void Listar2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtAño.Text = Listar2.CurrentRow.Cells[0].Value.ToString();
                txtPeriodo.Text = Listar2.CurrentRow.Cells[1].Value.ToString();
                txtDocumento.Text = Listar2.CurrentRow.Cells[2].Value.ToString();
                txtObservaciones.Text = Listar2.CurrentRow.Cells[3].Value.ToString();

            }
            catch
            {


            }
        }

        private void InTipoMatricula_Load(object sender, EventArgs e)
        {
            CModulos t1 = new CModulos();
            Listar1.DataSource = t1.Mostrar1();
            Listar2.DataSource = t1.Mostrar2();
        }
        private bool validarstring()
        {
            bool ok = true;
            // empesamos validar cada text box
            if (txtCodMatricula.Text == "" /*&& Ap.Text == ""  && Am.Text=="" && Tipo.Text=="" && Direccion.Text == "" && Email.Text=="" && Telefono.Text=="" && Sexo.Text=="" && CodigoNuevo.Text=="" */)
            {
                ok = false;
                errorProvider1.SetError(txtCodMatricula, "Codigo vacio");
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
        private void BGuardar_Click(object sender, EventArgs e)
        {

            if (txtDescripcion.Text != "" && txtActivo.Text != "" && txtConvenio.Text != "")
            {//Validamos Nombre.Txt

                if (validarstring() == true)
                {
                    //Creamos Clase Docente.
                    CTipoMatricula t = new CTipoMatricula();

                    

                    t.CodigoMatricula = txtCodMatricula.Text;
                    t.Descripcion = txtDescripcion.Text;
                    t.Activo = txtActivo.Text;
                    t.Convenio = txtConvenio.Text;

                    MessageBox.Show("¿ESTA SEGURO QUE DESEA AGREGAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int resultado = CModulos.Agregar(t);
                    SqlConnection c = conexion.LeerCadena();
                    SqlCommand cm = new SqlCommand("select * from TMantenimientoMatricula",c);
                    SqlDataReader dr = cm.ExecuteReader();
                    while(dr.Read())
                    {
                        //txtBuscarCodigo.Items.Add(dr.GetString(0));
                        //txtBuscarDescripcion.Items.Add(dr.GetString(1));
                    }


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

        private void BModificar_Click(object sender, EventArgs e)
        {

            

            CTipoMatricula d = new CTipoMatricula();

            d.CodigoMatricula = txtCodMatricula.Text;
            d.Descripcion = txtDescripcion.Text;
            d.Activo = txtActivo.Text;
            d.Convenio = txtConvenio.Text;

            MessageBox.Show("¿ESTA SEGURO QUE DESEA EDITAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = CModulos.Editar(d);
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO MODIFICAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            CTipoMatricula e1 = new CTipoMatricula();
            e1.CodigoMatricula = txtCodMatricula.Text;
            
            MessageBox.Show("¿ESTA SEGURO QUE DESEA ELIMINAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = CModulos.Eliminar(e1);
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS FUERON ELIMINADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO ELIMINAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BActualizar_Click(object sender, EventArgs e)
        {
            CModulos t1 = new CModulos();
            Listar1.DataSource = t1.Mostrar1();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscarCodigo.Text == "")
            {
                if(txtDescripcion.Text != "")
                {
                    CTipoMatricula d = new CTipoMatricula();
                    d.Descripcion = txtDescripcion.Text;
                    DataTable n = CModulos.BuscarDescripcion(d);
                    //CodigoNuevo.Text = validar.ToString();
                    Listar1.DataSource = n;
                    txtCodMatricula.Text = Listar1.CurrentRow.Cells["CodMatricula"].Value.ToString();
                    txtDescripcion.Text = Listar1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtActivo.Text = Listar1.CurrentRow.Cells["Activo"].Value.ToString();
                    txtConvenio.Text = Listar1.CurrentRow.Cells["Convenio"].Value.ToString();
                    MessageBox.Show("CODIGO ENCONTRADO ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    MessageBox.Show("COMPLETE LA CASILLA DE BUSCAR POR DESCRIPCION ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            else
            {
                if (txtBuscarCodigo.Text != "")
                {
                    CTipoMatricula d = new CTipoMatricula();
                    d.CodigoMatricula = txtCodMatricula.Text;
                    DataTable n = CModulos.BuscarCodigo(d);
                    //CodigoNuevo.Text = validar.ToString();
                    Listar1.DataSource = n;
                    txtCodMatricula.Text = Listar1.CurrentRow.Cells["CodMatricula"].Value.ToString();
                    txtDescripcion.Text = Listar1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtActivo.Text = Listar1.CurrentRow.Cells["Activo"].Value.ToString();
                    txtConvenio.Text = Listar1.CurrentRow.Cells["Convenio"].Value.ToString();
                    MessageBox.Show("CODIGO ENCONTRADO ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    MessageBox.Show("COMPLETE LA CASILLA DE BUSCAR POR CODIGO ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            
        }

        private void B2Limpiar_Click(object sender, EventArgs e)
        {
            txtAño.Text = " ";
            txtPeriodo.Text = " ";
            txtDocumento.Text = " ";
            txtObservaciones.Text = " ";
            CModulos t1 = new CModulos();
            Listar2.DataSource = t1.Mostrar2();
        }

        private void B2Modificar_Click(object sender, EventArgs e)
        {



            CDetalles d = new CDetalles();

            d.Año = txtAño.Text;
            d.Periodo = txtPeriodo.Text;
            d.Documento = txtDocumento.Text;
            d.Observaciones = txtObservaciones.Text;

            MessageBox.Show("¿ESTA SEGURO QUE DESEA EDITAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = CModulos.EditarDetalles(d);
            CModulos t1 = new CModulos();
            Listar2.DataSource = t1.Mostrar2();
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO MODIFICAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void B2Guardar_Click(object sender, EventArgs e)
        {

            if (txtAño.Text != "" && txtPeriodo.Text != "" && txtDocumento.Text != "" && txtObservaciones.Text !="")
            {//Validamos Nombre.Txt
                //Creamos Clase Docente.
                CDetalles t = new CDetalles();
                t.Año = txtAño.Text;
                t.Periodo = txtPeriodo.Text;
                t.Documento = txtDocumento.Text;
                t.Observaciones = txtObservaciones.Text;
                MessageBox.Show("¿ESTA SEGURO QUE DESEA AGREGAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int resultado = CModulos.AgregarDetalles(t);
                CModulos t1 = new CModulos();
                Listar2.DataSource = t1.Mostrar2();

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
                MessageBox.Show("COMPLETE ESPACIOS EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void B2Eliminar_Click(object sender, EventArgs e)
        {
            CDetalles e1 = new CDetalles();
            e1.Documento = txtDocumento.Text;

            MessageBox.Show("¿ESTA SEGURO QUE DESEA ELIMINAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = CModulos.EliminarDocumento(e1);
            CModulos t1 = new CModulos();
            Listar2.DataSource = t1.Mostrar2();
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS FUERON ELIMINADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO ELIMINAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
