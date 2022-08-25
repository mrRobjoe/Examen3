using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Examen3
{
    public class ClsUsuarios
    {
        private static int codigoUsuario { get; set; }
        private static string NomUsuario { get; set; }
        private static string ClavUsuario { get; set; }
        private static int TipoUser { get; set; }

        public ClsUsuarios(int codUser, string nomUser, string clavUser, int tipUser)
        {
            codigoUsuario = codUser;
            NomUsuario = nomUser;
            ClavUsuario = clavUser;
            TipoUser = tipUser;
        }

        public static int GetCodUser() { return codigoUsuario; }
        public static string GetNomUser() { return NomUsuario; }
        public static string GetClavUser() { return ClavUsuario; }
        public static int GetTipUser() { return TipoUser; }

        public static void SetCodUser(int codUser)
        {
            codigoUsuario = codUser;
        }
        public static void SetNomUser(string nomUser)
        {
            NomUsuario = nomUser;
        }
        public static void SetClavUser(string clavUser)
        {
            ClavUsuario = clavUser;
        }
        public static void SetTipUser(int tipUser)
        {
            TipoUser = tipUser;
        }

        public static int IngresarUser()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@nomUser", NomUsuario));
                    cmd.Parameters.Add(new SqlParameter("@clavUser", ClavUsuario));
                    cmd.Parameters.Add(new SqlParameter("@tipUser", TipoUser));

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

        public static int BorrarUsuario()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codUser", codigoUsuario));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                    }
                }

            }
            catch (SqlException)
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

        public static int ActualizarUsuario()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codUser", codigoUsuario));
                    cmd.Parameters.Add(new SqlParameter("@nomUser", NomUsuario));
                    cmd.Parameters.Add(new SqlParameter("@clavUser", ClavUsuario));
                    cmd.Parameters.Add(new SqlParameter("@tipUser", TipoUser));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                    }
                }

            }
            catch (SqlException)
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

        public static Boolean IniciarSesion()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["ControlInventarioConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("IniciarSesion", con);
                cmd.Parameters.Add(new SqlParameter("@username", NomUsuario));
                cmd.Parameters.Add(new SqlParameter("@claveUser", ClavUsuario));
                cmd.Parameters.Add(new SqlParameter("@tipoUser", TipoUser));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();

                existe = true;
            }
            catch (SqlException)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }
    }
}