using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVillarSolutions.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
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
            int id = ToInt(CriterioTextBox.Text);
            int index = ToInt(UsuarioGridView.SelectedIndex);
       //     DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
        //    DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
         //   UsuarioGridView.DataSource = BLL.Metodos.Buscar(id, index, CriterioTextBox.Text, desde, hasta);
            UsuarioGridView.DataBind();
        }
    }
}
   