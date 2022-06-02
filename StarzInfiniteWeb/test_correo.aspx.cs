using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarzInfiniteWeb
{
    public partial class test_correo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            enviar_correo objC = new enviar_correo();
            string resp_email = objC.enviar(txtEmail.Text, txtSubject.Text, hfDiv.Value, "");
            lblAviso.Text = resp_email;
        }
    }
}