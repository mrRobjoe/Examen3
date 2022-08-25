using System;
using System.Web.UI;

namespace Examen3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bIniciarSesion_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetNomUser(tUser.Text);
            ClsUsuarios.SetClavUser(tClave.Text);
            ClsUsuarios.SetTipUser(Convert.ToInt32(dTipoUser.SelectedValue));
            if (ClsUsuarios.IniciarSesion())
            {
                if (ClsUsuarios.GetTipUser() == 1)
                {
                    Response.Redirect("InicioRegular.aspx");
                }
                else if (ClsUsuarios.GetTipUser() == 2)
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Error, usuario no es válido');", true);
            }
        }

        protected void bRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void dTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}