using System.Data;
using System.Data.SqlClient;

namespace Examen3
{
    public class ClsArticulos
    {
        private static int codArticulo { get; set; }
        private static string descArticulo { set; get; }
        private static int codTipo { get; set; }
        private static float precioArticulo { get; set; }
        private static float costoArticulo { get; set; }
        private static int cant { get; set; }

        public ClsArticulos(int codArt, string descArt, int codTip, float precArt, float costArt, int cantidad)
        {
            codArticulo = codArt;
            descArticulo = descArt;
            codTipo = codTip;
            precioArticulo = precArt;
            costoArticulo = costArt;
            cant = cantidad;
        }

        public static void SetCodArticulo(int codArt)
        {
            codArticulo = codArt;
        }
        public static void SetDesArticulo(string descArt)
        {
            descArticulo = descArt;
        }
        public static void SetCodTipo(int codTip)
        {
            codTipo = codTip;
        }
        public static void SetPrecioArticulo(float precArt)
        {
            precioArticulo = precArt;
        }
        public static void SetCostoArticulo(float costArt)
        {
            costoArticulo = costArt;
        }
        public static void SetCantidad(int canti)
        {
            cant = canti;
        }

        public static int GetCodArticulo() { return codArticulo; }
        public static string GetDescArticulo() { return descArticulo; }
        public static int GetCodTipo() { return codTipo; }
        public static float GetPrecioArticulo() { return precioArticulo; }
        public static float GetCostoArticulo() { return costoArticulo; }
        public static int GetCantidad() { return cant; }

        public static int IngresarArticulo()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarArticulo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@descArticulo", descArticulo));
                    cmd.Parameters.Add(new SqlParameter("@codigTipo", codTipo));
                    cmd.Parameters.Add(new SqlParameter("@precArticulo", precioArticulo));
                    cmd.Parameters.Add(new SqlParameter("@costArticulo", costoArticulo));
                    cmd.Parameters.Add(new SqlParameter("@cant", cant));

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

        public static int BorrarArticulo()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarArticulo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codArticulo", codArticulo));

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

        public static int ActualizarArticulo()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarArticulo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Parameters.Add(new SqlParameter("@codArt", codArticulo));
                    cmd.Parameters.Add(new SqlParameter("@descArt", descArticulo));
                    cmd.Parameters.Add(new SqlParameter("@codTip", codTipo));
                    cmd.Parameters.Add(new SqlParameter("@precioArt", precioArticulo));
                    cmd.Parameters.Add(new SqlParameter("@costoArt", costoArticulo));
                    cmd.Parameters.Add(new SqlParameter("@canti", cant));

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
    }
}