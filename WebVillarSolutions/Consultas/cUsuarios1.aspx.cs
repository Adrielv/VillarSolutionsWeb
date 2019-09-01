using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebVillarSolutions.Utilitarios;

namespace WebVillarSolutions.Consultas
{
    public partial class cUsuarios1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtros = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();

            DateTime Desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime Hasta = Utils.ToDateTime(HastaTextBox.Text);

            int id;
            id = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    break;
                case 1: //ID                  
                    filtros = c => c.UsuarioId == id && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 2: //Email
                    filtros = c => c.Email.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 3: //Usuario
                    filtros = c => c.Usuario.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 4: //Nombres
                    filtros = c => c.Nombres.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
              
              
            }
            UsuarioGrid.DataSource = repositorio.GetList(filtros);
            UsuarioGrid.DataBind();
        }
    }
}
