using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class PacientesDatos
    {

        public List<PacientesModel> Listar() { 
        
            var oLista = new List<PacientesModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new PacientesModel() {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            ObraSocial = dr["ObraSocial"].ToString(),
                            DNI = dr["DNI"].ToString(),
                            Area = dr["Area"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public PacientesModel Obtener(int IdContacto)
        {

            var oContacto = new PacientesModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Apellido = dr["Apellido"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.ObraSocial = dr["ObraSocial"].ToString();
                        oContacto.DNI = dr["DNI"].ToString();
                        oContacto.Area = dr["Area"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(PacientesModel ocontacto) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ocontacto.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("ObraSocial", ocontacto.ObraSocial);
                    cmd.Parameters.AddWithValue("DNI", ocontacto.DNI);
                    cmd.Parameters.AddWithValue("Area", ocontacto.Area);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e) {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(PacientesModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ocontacto.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("ObraSocial", ocontacto.ObraSocial);
                    cmd.Parameters.AddWithValue("DNI", ocontacto.DNI);
                    cmd.Parameters.AddWithValue("Area", ocontacto.Area);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
