using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Examen3
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoTipoArt();
            }
        }

        protected void ListadoTipoArt()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ControlInventarioConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ListadoTipoArt", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            if (tdescTipo.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Para agregar tipo artículo no puede quedar descripción tipo en blanco, verifíquelo de nuevo.');", true);
            }
            else
            {
                TipoArticulo.SetDescTipo(tdescTipo.Text);
                tdescTipo.Text = "";
                try
                {
                    if (TipoArticulo.IngresarTipoArt() > 0)
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
                    ListadoTipoArt();
                }
            }       
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            TipoArticulo.SetCodTipo(Convert.ToInt32(tcodTipo.Text));
            tcodTipo.Text = "";
            try
            {
                if (TipoArticulo.BorrarTipoArt() > 0)
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
                ListadoTipoArt();
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (tcodTipo.Text=="" || tdescTipo.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Para modificar no puede haber ningún campo en blanco');", true);
            }
            TipoArticulo.SetCodTipo(Convert.ToInt32(tcodTipo.Text));
            TipoArticulo.SetDescTipo(tdescTipo.Text);
            tcodTipo.Text = "";
            tdescTipo.Text = "";
            try
            {
                if (TipoArticulo.ActualizarTipoArt() > 0)
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
                ListadoTipoArt();
            }
        }
    }
}