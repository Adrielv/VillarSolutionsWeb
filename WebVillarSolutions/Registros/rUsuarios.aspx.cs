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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuarios.UsuarioId);
            NombresTextBox.Text = usuarios.Nombres;
            UsuarioTextBox.Text = usuarios.Usuario;
            ClaveTextBox.Text = usuarios.Clave;
            ConfirmarTextBox.Text = usuarios.Clave;
            EmailTextBox.Text = usuarios.Email;
            FechaTextBox.Text = Convert.ToString(usuarios.FechaCreacion);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (usuarios != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if ( string.IsNullOrWhiteSpace(NombresTextBox.Text) || string.IsNullOrWhiteSpace(UsuarioTextBox.Text) || string.IsNullOrWhiteSpace(ClaveTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || ConfirmarTextBox.Text != ClaveTextBox.Text)
            {
                  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
        }
        public static bool RepetirUser(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuarios.Any(p => p.Usuario.Equals(descripcion)))
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
                if (db.Usuarios.Any(p => p.Email.Equals(descripcion)))
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

            if (RepetirUser(UsuarioTextBox.Text))
            {
                   ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            if (RepetirEmail(EmailTextBox.Text))
            {
                  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            int.TryParse(UsuarioIdTextBox.Text, out int idx);
            usuarios.UsuarioId = idx;
            usuarios.Nombres = NombresTextBox.Text;
            usuarios.Usuario = UsuarioTextBox.Text;
            usuarios.Clave = ClaveTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.FechaCreacion = Convert.ToDateTime(FechaTextBox.Text);

            return usuarios;
        }




        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();

            bool paso = false;
            if (!Validar())
                return;

            usuarios = LlenaClase();
            int.TryParse(UsuarioIdTextBox.Text, out int idx);
            if (idx == 0)
            {
                if (!ValidarRepetir())
                    return;

                paso = Repositorio.Guardar(usuarios);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                       ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = Repositorio.Modificar(usuarios);
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
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            int idx;
            int.TryParse(UsuarioIdTextBox.Text, out idx);

            var usuario = Repositorio.Buscar(idx);
            if (usuario != null)
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

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            int.TryParse(UsuarioIdTextBox.Text, out int idx);

            usuarios = Repositorio.Buscar(idx);
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                   ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
                
        }

    
    }
}