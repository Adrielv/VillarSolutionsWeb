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
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LlenaCampo(Productos i)
        {
            id.Text = Convert.ToString(i.ProductoId);
            descripcion.Text = i.Descripcion;
            cantidad.Text = Convert.ToString(i.Cantidad);          
            precio.Text = Convert.ToString(i.Precio);
            costo.Text = Convert.ToString(i.Ganancia);
            ganancia.Text = Convert.ToString(i.Ganancia);
            itbis.Text = Convert.ToString(i.ITBIS);
           
        }
        private Productos LlenaClase()
        {
            Productos i = new Productos();
            int.TryParse(id.Text, out int idx);
            i.ProductoId = idx;
         
            i.Descripcion = descripcion.Text;
         
            i.Precio = Convert.ToDecimal(precio.Text);
            i.Costo = Convert.ToDecimal(costo.Text);
            i.Ganancia = Convert.ToDecimal(ganancia.Text);
            i.ITBIS = Convert.ToDecimal(itbis.Text);
          

            return i;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos i = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (i != null);
        }
        private void Limpiar()
        {
            id.Text = "0";         
            descripcion.Text = string.Empty;
            cantidad.Text = string.Empty;         
            precio.Text = string.Empty;
            costo.Text = string.Empty;
            ganancia.Text = string.Empty;
            itbis.Text = string.Empty;
        }
        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos i = new Productos();
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

            if ( string.IsNullOrWhiteSpace(descripcion.Text) || string.IsNullOrWhiteSpace(precio.Text) || string.IsNullOrWhiteSpace(costo.Text) || Convert.ToDecimal(costo.Text) > Convert.ToDecimal(precio.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }
        public static bool RepetirProducto(string descrip)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Productos.Any(p => p.Descripcion.Equals(descrip)))
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

            if (RepetirProducto(descripcion.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }
        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos i = new Productos();

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
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
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

        protected void precio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(costo.Text))
                ganancia.Text = "0";

            itbis.Text = Convert.ToString(Convert.ToDecimal(precio.Text) * 0.18m);

            if (costo.Text != "")
                ganancia.Text = Convert.ToString(Convert.ToDecimal(precio.Text) - Convert.ToDecimal(costo.Text));
        }

        protected void costo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(precio.Text))
                ganancia.Text = "0";

            if (precio.Text != "")
                ganancia.Text = Convert.ToString(Convert.ToDecimal(precio.Text) - Convert.ToDecimal(costo.Text));
        }
    }
}