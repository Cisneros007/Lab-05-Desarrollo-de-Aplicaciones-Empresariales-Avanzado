using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;
using static Semana05.Clase1;



namespace Semana05
{
    public partial class MainWindow : Window
    {
        // Cadena de conexión correcta
        private string connectionString = "Data Source=LAB1507-18\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=sebas;Password=123456;";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Listar empleados
        private void BtnListarEmpleados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

        // Crear empleado
        private void BtnCrearEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_CrearEmpleado01", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                       
                        cmd.Parameters.AddWithValue("@IdEmpleado", Convert.ToInt32(txtIdEmpleado.Text));
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                        cmd.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dpFechaNacimiento.SelectedDate);
                        cmd.Parameters.AddWithValue("@FechaContratacion", dpFechaContratacion.SelectedDate);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                        cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                        cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                        cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                        cmd.Parameters.AddWithValue("@TelDomicilio", txtTelDomicilio.Text);
                        cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                        cmd.Parameters.AddWithValue("@Notas", txtNotas.Text);
                        cmd.Parameters.AddWithValue("@Jefe", Convert.ToInt32(txtJefe.Text));
                        cmd.Parameters.AddWithValue("@SueldoBasico", Convert.ToDecimal(txtSueldoBasico.Text));

                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado creado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al crear el empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        // Actualizar empleado
        private void BtnActualizarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_ActualizarEmpleado01", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        cmd.Parameters.AddWithValue("@IdEmpleado", Convert.ToInt32(txtIdEmpleado.Text));
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                        cmd.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dpFechaNacimiento.SelectedDate);
                        cmd.Parameters.AddWithValue("@FechaContratacion", dpFechaContratacion.SelectedDate);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                        cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                        cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                        cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                        cmd.Parameters.AddWithValue("@TelDomicilio", txtTelDomicilio.Text);
                        cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                        cmd.Parameters.AddWithValue("@Notas", txtNotas.Text);
                        cmd.Parameters.AddWithValue("@Jefe", Convert.ToInt32(txtJefe.Text));
                        cmd.Parameters.AddWithValue("@SueldoBasico", Convert.ToDecimal(txtSueldoBasico.Text));

                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado actualizado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        // Eliminar empleado
        private void BtnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_EliminarEmpleado01", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        cmd.Parameters.AddWithValue("@IdEmpleado", Convert.ToInt32(txtIdEmpleado.Text));

                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado eliminado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        // Evento de selección del DataGrid (puede usarse para obtener detalles de un empleado seleccionado)
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Datagrid.SelectedItem != null)
            {
                Empleado empleadoSeleccionado = (Empleado)Datagrid.SelectedItem;

                
                txtIdEmpleado.Text = empleadoSeleccionado.IdEmpleado.ToString();
                txtNombre.Text = empleadoSeleccionado.Nombre;
                txtApellidos.Text = empleadoSeleccionado.Apellidos;
                txtCargo.Text = empleadoSeleccionado.Cargo;
                txtTratamiento.Text = empleadoSeleccionado.Tratamiento;
                dpFechaNacimiento.SelectedDate = empleadoSeleccionado.FechaNacimiento;
                dpFechaContratacion.SelectedDate = empleadoSeleccionado.FechaContratacion;
                txtDireccion.Text = empleadoSeleccionado.Direccion;
                txtCiudad.Text = empleadoSeleccionado.Ciudad;
                txtRegion.Text = empleadoSeleccionado.Region;
                txtCodPostal.Text = empleadoSeleccionado.CodPostal;
                txtPais.Text = empleadoSeleccionado.Pais;
                txtTelDomicilio.Text = empleadoSeleccionado.TelDomicilio;
                txtExtension.Text = empleadoSeleccionado.Extension;
                txtNotas.Text = empleadoSeleccionado.Notas;
                txtJefe.Text = empleadoSeleccionado.Jefe.ToString();
                txtSueldoBasico.Text = empleadoSeleccionado.SueldoBasico.ToString();
            }
        }
    }
}
