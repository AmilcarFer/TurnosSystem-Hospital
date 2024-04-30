using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class DoctoresDatos
    {

        public List<DoctoresModel> ListarD() { 
        
            var oLista = new List<DoctoresModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarD", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new DoctoresModel() {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Especialidad = dr["Especialidad"].ToString(),
                            DNI = dr["DNI"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }

        public DoctoresModel ObtenerD(int Id)
        {

            var oDoctores = new DoctoresModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerD", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oDoctores.Id = Convert.ToInt32(dr["Id"]);
                        oDoctores.Nombre = dr["Nombre"].ToString();
                        oDoctores.Apellido = dr["Apellido"].ToString();
                        oDoctores.Telefono = dr["Telefono"].ToString();
                        oDoctores.Especialidad = dr["Especialidad"].ToString();
                        oDoctores.DNI = dr["DNI"].ToString();
                    }
                }
            }

            return oDoctores;
        }

        public bool GuardarD(DoctoresModel odoctores) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarD", conexion);
                    cmd.Parameters.AddWithValue("Nombre", odoctores.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", odoctores.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", odoctores.Telefono);
                    cmd.Parameters.AddWithValue("Especialidad", odoctores.Especialidad);
                    cmd.Parameters.AddWithValue("DNI", odoctores.DNI);
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


        public bool EditarD(DoctoresModel oDoctores)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarD", conexion);
                    cmd.Parameters.AddWithValue("Id", oDoctores.Id);
                    cmd.Parameters.AddWithValue("Nombre", oDoctores.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oDoctores.Apellido);
                    cmd.Parameters.AddWithValue("Telefono", oDoctores.Telefono);
                    cmd.Parameters.AddWithValue("ObraSocial", oDoctores.Especialidad);
                    cmd.Parameters.AddWithValue("DNI", oDoctores.DNI);
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

        public bool EliminarD(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarD", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
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
