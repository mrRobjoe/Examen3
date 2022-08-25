using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Examen3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoUsuario();
            }
        }

        protected void ListadoUsuario()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ControlInventarioConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ListadoUsuarios", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            if (tnomUser.Text=="" || tclavUser.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Nombre usuario y clave no pueden ser campos en blanco, verifíquelo de nuevo.');", true);
            }
            else
            {
                ClsUsuarios.SetNomUser(tnomUser.Text);
                ClsUsuarios.SetClavUser(tclavUser.Text);
                ClsUsuarios.SetTipUser(Convert.ToInt32(dTipoUs.SelectedValue));
                tnomUser.Text = "";
                tclavUser.Text = "";
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
                finally
                {
                    ListadoUsuario();
                }
            }          
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetCodUser(Convert.ToInt32(tcodUser.Text));
            tcodUser.Text = "";
            try
            {
                if (ClsUsuarios.BorrarUsuario() > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Datos ingresados con éxito');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Error, los datos no han sido ingresados');", true);
            }
            finally
            {
                ListadoUsuario();
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (tcodUser.Text=="" || tnomUser.Text=="" || tclavUser.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Para modificar no pueden quedar campos en blanco, verifíquelo de nuevo.');", true);
            }
            else
            {
                ClsUsuarios.SetCodUser(Convert.ToInt32(tcodUser.Text));
                ClsUsuarios.SetNomUser(tnomUser.Text);
                ClsUsuarios.SetClavUser(tclavUser.Text);
                ClsUsuarios.SetTipUser(Convert.ToInt32(dTipoUs.SelectedValue));
                tcodUser.Text = "";
                tnomUser.Text = "";
                tclavUser.Text = "";
                try
                {
                    if (ClsUsuarios.ActualizarUsuario() > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Datos ingresados con éxito');", true);
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Error, los datos no han sido ingresados');", true);
                }
                finally
                {
                    ListadoUsuario();
                }
            }        
        }
    }
}