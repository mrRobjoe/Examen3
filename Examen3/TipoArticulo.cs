using System.Data;
using System.Data.SqlClient;

namespace Examen3
{
    public class TipoArticulo
    {
        private static int codTipo { get; set; }
        private static string descTipo { get; set; }

        public TipoArticulo(int codigoTipo, string descripcionTip)
        {
            codTipo = codigoTipo;
            descTipo = descripcionTip;
        }

        public static int GetCodTipo() { return codTipo; }
        public static string GetDescTipo() { return descTipo; }

        public static void SetCodTipo(int codigoTip)
        {
            codTipo = codigoTip;
        }
        public static void SetDescTipo(string descripcionTipo)
        {
            descTipo = descripcionTipo;
        }

        public static int IngresarTipoArt()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarTipoArt", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@descTipo", descTipo));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return retorno;
        }

        public static int BorrarTipoArt()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarTipoArt", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codTipo", codTipo));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return retorno;
        }

        public static int ActualizarTipoArt()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarTipoArt", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codTipo", codTipo));
                    cmd.Parameters.Add(new SqlParameter("@descTipo", descTipo));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return retorno;
        }
    }
}