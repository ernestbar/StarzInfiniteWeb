using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class soporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("ingreso.aspx");
                }
                else
                {
                    odsVideos.FilterExpression = "codigo in (1,2)";
                    lblUsuario.Text = Session["usuario"].ToString();
                    //MultiView1.ActiveViewIndex = 0;
                }
            }

        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Response.Redirect("videos_todos.aspx");
        }
    }
}