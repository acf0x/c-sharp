﻿using ConsoleAppEF.Models;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //ConsultaConADONET();
            ConsultaConEF();
        }

        /// <summary>
        /// Ejecutamos una consulta de datos utilizando ADO.NET
        /// </summary>
        static void ConsultaConADONET()
        {
            // A Access
            // D Data
            // O Objects

            // SELECT * FROM dbo.Customers

            // Creamos un objeto para crear la cadena de conexión
            var csb = new SqlConnectionStringBuilder()
            {
                DataSource = "hostdb-eoi.database.windows.net",
                InitialCatalog = "Northwind",
                UserID = "Administrador",
                Password = "azurePa$$w0rd",
                IntegratedSecurity = false,
                ConnectTimeout = 60
            };

            // Mostramos la cadena de conexión resultante con los datos introducidos
            Console.WriteLine("Cadena de conexión: {0}", csb.ToString());

            // Creamos el objeto que representa la conexión con la base de datos 

            SqlConnection connection = new SqlConnection(csb.ToString());

//            SqlConnection connection = new SqlConnection()
//            {
//                ConnectionString = csb.ToString()
//            };

            Console.WriteLine($"Estado de la conexión: {connection.State}");

            // Abrimos la conexión con la base de datos 
            connection.Open();
            Console.WriteLine($"Estado de la conexión: {connection.State}");

            // Creamos un objeto que representa el comando que ejecutaremos en la base de datos
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            // --> Ejecución del comando 

            // Si el comando retorna datos tenemos que crear un cursor que
            // nos permita recorrer los datos recuperados (comandos SELECT)

            SqlDataReader cursor = command.ExecuteReader();

            // Recorremos los datos del cursor 
            if (!cursor.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                while (cursor.Read()) 
                {
                    Console.Write($"{cursor["CustomerID"].ToString().PadLeft(5, ' ')}#");    // Opción 1 (mejor)
                    Console.Write($"{cursor.GetValue(1).ToString().PadRight(20, ' ')}");     // Opción 2 (puede dar problema)
                    Console.WriteLine($"{cursor["Country"]}");                               // Opción 3  ""
                }

            }

            // Si el comando NO retorna datos, recogemos en una variable de tipo INT el número
            // de registros afectados por el comando (comandos INSERT, UPDATE y DELETE)

            //int rows = command.ExecuteNonQuery();


            // Cerramos conexiones y destruimos variables
            cursor.Close();
            command.Dispose();
            connection.Close(); 
            connection.Dispose();  


        }

        /// <summary>
        /// Ejecutamos consultas de datos con Entity Framework Core
        /// </summary>
        static void ConsultaConEF()
        {
            // SELECT * FROM dbo.Customers

            var context = new NorthwindContext();    // clase dentro de northwind context

            var clientes = context.Customers
                .Where(r=>r.Country == "Spain")
                .OrderBy(r=>r.City)
                .ToList();

            foreach(var cliente in clientes) 
            {
                Console.Write($"{cliente.CustomerID.PadLeft(5, ' ')}#");
                Console.Write($"{cliente.CompanyName.PadRight(20, ' ')}");
                Console.WriteLine($"{cliente.Country}");
            }
        }
    }
}
