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
    public partial class rCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }
        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        private void LlenaCampo(Clientes cliente)
        {
            id.Text = Convert.ToString(cliente.ClienteId);
            nombres.Text = cliente.Nombres;
            cedula.Text = cliente.Cedula;
            telefono.Text = cliente.Telefono;
            direccion.Text = cliente.Direccion;
            fecha.Text = cliente.FechaCreacion.ToString("yyyy-MM-dd");
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            int.TryParse(id.Text, out int idx);

            cliente = Repositorio.Buscar(idx);
            if (cliente != null)
                LlenaCampo(cliente);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (cliente != null);
        }
        private Clientes LlenaClase()
        {
            Clientes c = new Clientes();
            int.TryParse(id.Text, out int idx);
            c.ClienteId = idx;
            c.Nombres = nombres.Text;
            c.Cedula = cedula.Text;
            c.Telefono = telefono.Text;
            c.Direccion = direccion.Text;
            c.FechaCreacion = Convert.ToDateTime(fecha.Text);

            return c;
        }
        private void Limpiar()
        {

            id.Text = "0";
            nombres.Text = string.Empty;
            cedula.Text = string.Empty;
            telefono.Text = string.Empty;
            direccion.Text = string.Empty;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace(nombres.Text) || string.IsNullOrWhiteSpace(cedula.Text) || string.IsNullOrWhiteSpace(telefono.Text) || string.IsNullOrWhiteSpace(direccion.Text) || string.IsNullOrWhiteSpace(fecha.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }
        public static bool RepetirNombre(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Nombres.Equals(descripcion)))
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
        public static bool RepetirCedula(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Cedula.Equals(descripcion)))
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
                if (db.Clientes.Any(p => p.Telefono.Equals(descripcion)))
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

            if (RepetirNombre(nombres.Text) || RepetirCedula(cedula.Text) || RepetirTelefono(telefono.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }
        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();

            bool paso = false;
            if (!Validar())
                return;

            cliente = LlenaClase();
            int.TryParse(id.Text, out int idx);
            if (idx == 0)
            {
                if (!ValidarRepetir())
                    return;

                paso = Repositorio.Guardar(cliente);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = Repositorio.Modificar(cliente);
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
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            int idx;
            int.TryParse(id.Text, out idx);

            var cliente = Repositorio.Buscar(idx);
            if (cliente != null)
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