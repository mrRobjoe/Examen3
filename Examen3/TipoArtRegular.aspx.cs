using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Examen3
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoArticuloReg();
            }
        }

        protected void TipoArticuloReg()
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
    }
}