using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using static Semana05.Clase1;

namespace Semana05
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LAB1507-23\\SQLEXPRESS02;Initial Catalog=NeptunoB;User ID=usuario01;Password=123456;"
;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnListarEmpleados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Usar la cadena de conexión actualizada
                string cadena = "Data Source=LAB1507-23\\SQLEXPRESS02;Initial Catalog=NeptunoB;User ID=usuario01;Password=123456;";

                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_ListarEmpleados01", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    List<Empleado> listaEmpleados = new List<Empleado>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado
                        {
                            IdEmpleado = reader["IdEmpleado"] != DBNull.Value ? Convert.ToInt32(reader["IdEmpleado"]) : 0,
                            Apellidos = reader["Apellidos"] != DBNull.Value ? reader["Apellidos"].ToString() : string.Empty,
                            Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                            Cargo = reader["Cargo"] != DBNull.Value ? reader["Cargo"].ToString() : string.Empty,
                            Tratamiento = reader["Tratamiento"] != DBNull.Value ? reader["Tratamiento"].ToString() : string.Empty,
                            FechaNacimiento = reader["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimiento"]) : DateTime.MinValue,
                            FechaContratacion = reader["FechaContratacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaContratacion"]) : DateTime.MinValue,
                            Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : string.Empty,
                            Ciudad = reader["Ciudad"] != DBNull.Value ? reader["Ciudad"].ToString() : string.Empty,
                            Region = reader["Region"] != DBNull.Value ? reader["Region"].ToString() : string.Empty,
                            CodPostal = reader["CodPostal"] != DBNull.Value ? reader["CodPostal"].ToString() : string.Empty,
                            Pais = reader["Pais"] != DBNull.Value ? reader["Pais"].ToString() : string.Empty,
                            TelDomicilio = reader["TelDomicilio"] != DBNull.Value ? reader["TelDomicilio"].ToString() : string.Empty,
                            Extension = reader["Extension"] != DBNull.Value ? reader["Extension"].ToString() : string.Empty,
                            Notas = reader["Notas"] != DBNull.Value ? reader["Notas"].ToString() : string.Empty,
                            Jefe = reader["Jefe"] != DBNull.Value ? Convert.ToInt32(reader["Jefe"]) : 0,
                            SueldoBasico = reader["SueldoBasico"] != DBNull.Value ? Convert.ToDecimal(reader["SueldoBasico"]) : 0
                        };
                        listaEmpleados.Add(empleado);
                    }

                    
                    connection.Close();

                    Datagrid.ItemsSource = listaEmpleados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnCrearEmpleado_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnActualizarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
