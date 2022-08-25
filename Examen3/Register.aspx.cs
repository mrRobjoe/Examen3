using System;
using System.Web.UI;

namespace Examen3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegistrar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetNomUser(tUserr.Text);
            ClsUsuarios.SetClavUser(tClav.Text);
            ClsUsuarios.SetTipUser(Convert.ToInt32(dTipoUser.SelectedValue));
            tUserr.Text = "";
            tClav.Text = "";
            try
            {
                if (ClsUsuarios.IngresarUser() > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Datos ingresados con éxito');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Error, los datos no han sido ingresados');", true);
            }
        }
    }
}