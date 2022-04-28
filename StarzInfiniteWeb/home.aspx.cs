using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void ddlOrigen_DataBound(object sender, EventArgs e)
        {
            ddlOrigen.Items.Insert(0, "ORIGEN");
        }

        protected void ddlDestino_DataBound(object sender, EventArgs e)
        {
            ddlDestino.Items.Insert(0, "DESTINO");
        }

        protected void ddlLineArea_DataBound(object sender, EventArgs e)
        {
            ddlLineArea.Items.Insert(0, "TODAS");
        }

        protected void btnVuelos_Click(object sender, EventArgs e)
        {

        }
    }
}