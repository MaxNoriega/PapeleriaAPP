using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private string connectionString;

    // Constructor que recibe la cadena de conexión
    public DatabaseHelper(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Método para ejecutar una consulta SELECT y devolver un DataTable
    public DataTable ExecuteQuery(string query)
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader()) // Declaración de 'reader'
                    {
                        dataTable.Load(reader); // Uso de 'reader' dentro del bloque
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error de base de datos: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error general: " + ex.Message);
        }
        return dataTable;
    }

    // Método para ejecutar una consulta INSERT, UPDATE o DELETE
    public int ExecuteNonQuery(string query)
    {
        int rowsAffected = 0;
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error de base de datos: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error general: " + ex.Message);
        }
        return rowsAffected;
    }

    // Método para ejecutar una consulta con parámetros (INSERT, UPDATE, DELETE)
    public int ExecuteNonQueryWithParameters(string query, SqlParameter[] parameters)
    {
        int rowsAffected = 0;
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error de base de datos: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error general: " + ex.Message);
        }
        return rowsAffected;
    }

    // Método para ejecutar una consulta SELECT con parámetros
    public DataTable ExecuteQueryWithParameters(string query, SqlParameter[] parameters)
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = command.ExecuteReader()) // Declaración de 'reader'
                    {
                        dataTable.Load(reader); // Uso de 'reader' dentro del bloque
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error de base de datos: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error general: " + ex.Message);
        }
        return dataTable;
    }
}