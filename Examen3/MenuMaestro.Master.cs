using System;

namespace Examen3
{
    public partial class MenuMaestro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lUser.Text = ClsUsuarios.GetNomUser();
        }

        protected void bLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.RedirectPermanent("Login.aspx");
        }
    }
}