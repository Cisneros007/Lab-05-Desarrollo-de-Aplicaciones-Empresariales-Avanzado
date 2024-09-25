using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05
{
    internal class EmpleadoCreate
    {
        private string connectionString = "Data Source=LAB1507-23\\SQLEXPRESS02;Initial Catalog=NeptunoB;User ID=usuario01;Password=123456;";

        public void InsertarEmpleado(
            int idEmpleado, string apellidos, string nombre, string cargo, string tratamiento, DateTime fechaNacimiento,
            DateTime fechaContratacion, string direccion, string ciudad, string region, string codPostal, string pais,
            string telDomicilio, string extension, string notas, int jefe, decimal sueldoBasico)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_CrearEmpleado01", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Añadir parámetros
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Cargo", cargo);
                    command.Parameters.AddWithValue("@Tratamiento", tratamiento);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@FechaContratacion", fechaContratacion);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Ciudad", ciudad);
                    command.Parameters.AddWithValue("@Region", region);
                    command.Parameters.AddWithValue("@CodPostal", codPostal);
                    command.Parameters.AddWithValue("@Pais", pais);
                    command.Parameters.AddWithValue("@TelDomicilio", telDomicilio);
                    command.Parameters.AddWithValue("@Extension", extension);
                    command.Parameters.AddWithValue("@Notas", notas);
                    command.Parameters.AddWithValue("@Jefe", jefe);
                    command.Parameters.AddWithValue("@SueldoBasico", sueldoBasico);

                    // Ejecutar el comando
                    command.ExecuteNonQuery();

                    Console.WriteLine("Empleado insertado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar empleado: " + ex.Message);
            }
        }
    }
}
