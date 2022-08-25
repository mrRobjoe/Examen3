using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Examen3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoArticulos();
            }
        }

        protected void ListadoArticulos()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["ControlInventarioConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ListadoArticulos", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            if (tdescArt.Text=="" || tcodTipo.Text=="" || tPrecArt.Text=="" || tcostArt.Text=="" || tCant.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Para agregar artículos los campos no pueden quedar vacíos a excepción del código de artículo, verifíquelo de nuevo.');", true);
            }
            else
            {
                ClsArticulos.SetDesArticulo(tdescArt.Text);
                ClsArticulos.SetCodTipo(Convert.ToInt32(tcodTipo.Text));
                ClsArticulos.SetPrecioArticulo(float.Parse(tPrecArt.Text));
                ClsArticulos.SetCostoArticulo(float.Parse(tcostArt.Text));
                ClsArticulos.SetCantidad(Convert.ToInt32(tCant.Text));
                tdescArt.Text = "";
                tcodTipo.Text = "";
                tPrecArt.Text = "";
                tcostArt.Text = "";
                tCant.Text = "";
                try
                {
                    if (ClsArticulos.IngresarArticulo() > 0)
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
                    ListadoArticulos();
                }
            }       
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsArticulos.SetCodArticulo(Convert.ToInt32(tcodArt.Text));
            tcostArt.Text = "";
            try
            {
                if (ClsArticulos.BorrarArticulo() > 0)
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
                ListadoArticulos();
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (tcodArt.Text=="" || tdescArt.Text == "" || tcodTipo.Text == "" || tPrecArt.Text == "" || tcostArt.Text == "" || tCant.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Para modificar los campos no pueden quedar en blanco, verifíquelo de nuevo.');", true);
            }
            else
            {
                ClsArticulos.SetCodArticulo(Convert.ToInt32(tcodArt.Text));
                ClsArticulos.SetDesArticulo(tdescArt.Text);
                ClsArticulos.SetCodTipo(Convert.ToInt32(tcodTipo.Text));
                ClsArticulos.SetPrecioArticulo(float.Parse(tPrecArt.Text));
                ClsArticulos.SetCostoArticulo(float.Parse(tcostArt.Text));
                ClsArticulos.SetCantidad(Convert.ToInt32(tCant.Text));
                tcodArt.Text = "";
                tcostArt.Text = "";
                tdescArt.Text = "";
                tcodTipo.Text = "";
                tPrecArt.Text = "";
                tcostArt.Text = "";
                tCant.Text = "";
                try
                {
                    if (ClsArticulos.ActualizarArticulo() > 0)
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
                    ListadoArticulos();
                }
            }       
        }
    }
}