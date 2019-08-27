using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVillarSolutions.Registros
{
    public partial class rProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private void LlenaCampo(Proveedores i)
        {
            id.Text = Convert.ToString(i.ProveedorId);
            nombres.Text = i.Nombres;          
            direccion.Text = i.Direccion;
            email.Text = i.Email;
            telefono.Text = i.Telefono;
          
        }
        private Proveedores LlenaClase()
        {
            Proveedores i = new Proveedores();
            int.TryParse(id.Text, out int idx);
            i.ProveedorId = idx;
            i.Nombres = nombres.Text;          
            i.Direccion = direccion.Text;
            i.Email = email.Text;
            i.Telefono = telefono.Text;
           

            return i;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores i = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (i != null);
        }
        private void Limpiar()
        {
            id.Text = "0";
            nombres.Text = string.Empty;          
            direccion.Text = string.Empty;
            email.Text = string.Empty;
            telefono.Text = string.Empty;
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores i = new Proveedores();
            int.TryParse(id.Text, out int idx);

            i = Repositorio.Buscar(idx);
            if (i != null)
                LlenaCampo(i);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace(nombres.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(direccion.Text) || string.IsNullOrWhiteSpace(telefono.Text) || string.IsNullOrWhiteSpace(fecha.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }
        public static bool RepetirProveedor(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Nombres.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirEmail(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Email.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirTelefono(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Telefono.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirDireccion(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Direccion.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
       
        private bool ValidarRepetir()
        {
            bool paso = true;

            if (RepetirProveedor(nombres.Text) || RepetirEmail(email.Text) || RepetirTelefono(telefono.Text) || RepetirDireccion(direccion.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }
        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores i = new Proveedores();

            bool paso = false;
            if (!Validar())
                return;

            i = LlenaClase();
            int.TryParse(id.Text, out int idx);
            if (idx == 0)
            {
                if (!ValidarRepetir())
                    return;

                paso = Repositorio.Guardar(i);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = Repositorio.Modificar(i);
                Limpiar();
            }

            if (paso)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                return;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            int idx;
            int.TryParse(id.Text, out idx);

            var i = Repositorio.Buscar(idx);
            if (i != null)
            {
                if (Repositorio.Eliminar(idx))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                    Limpiar();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }
    }
}