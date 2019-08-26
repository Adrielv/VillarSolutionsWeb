using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace VillarSolutionsWeb
{
    public partial class rrUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            id.Text = Convert.ToString(usuarios.UsuarioId);
            nombres.Text = usuarios.Nombres;
            usuario.Text = usuarios.Usuario;
            clave.Text = usuarios.Clave;
            confirmar.Text = usuarios.Clave;
            email.Text = usuarios.Email;
            fecha.Text = Convert.ToString(usuarios.FechaCreacion);
        }
      
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (usuarios != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace(nombres.Text) || string.IsNullOrWhiteSpace(usuario.Text) || string.IsNullOrWhiteSpace(clave.Text) || string.IsNullOrWhiteSpace(email.Text) || confirmar.Text != clave.Text)
            {
              //  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }
      
        private void Limpiar()
        {
            id.Text = "0";
            nombres.Text = string.Empty;
            usuario.Text = string.Empty;
            clave.Text = string.Empty;
            confirmar.Text = string.Empty;
            email.Text = string.Empty;
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

            if (RepetirUser(usuario.Text))
            {
             //   ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            if (RepetirEmail(email.Text))
            {
              //  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            int.TryParse(id.Text, out int idx);
            usuarios.UsuarioId = idx;
            usuarios.Nombres = nombres.Text;
            usuarios.Usuario = usuario.Text;
            usuarios.Clave = clave.Text;
            usuarios.Email = email.Text;
            usuarios.FechaCreacion = Convert.ToDateTime(fecha.Text);

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
            int.TryParse(id.Text, out int idx);
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

               //     ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = Repositorio.Modificar(usuarios);
                Limpiar();
            }

            if (paso)
            {
                //   ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                return;
            }
            else
                //    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
                ;

        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            int idx;
            int.TryParse(id.Text, out idx);

            var usuario = Repositorio.Buscar(idx);
            if (usuario != null)
            {
                if (Repositorio.Eliminar(idx))
                {
                    //     ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                    Limpiar();
                }
                else
                    //    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    ;
            }
            else
                //  ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
                ;
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            int.TryParse(id.Text, out int idx);

            usuarios = Repositorio.Buscar(idx);
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                //   ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
                ;
        }
    }
}
