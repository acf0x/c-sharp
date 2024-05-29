using ConsoleAppEF.Models;
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
            //ConsultaConEF();
            //InsertarDatosEF();
            //ActualizarDatosEF();
            //EliminarDatosEF();
        }

        ////////////////////////////////////////////////////////////
        /// Ejecutamos una consulta de datos utilizando ADO.NET   //
        ////////////////////////////////////////////////////////////
        
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

        ///////////////////////////////////////////////////////////////
        /// Ejecutamos consultas de datos con Entity Framework Core  //
        ///////////////////////////////////////////////////////////////
        
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


        static void InsertarDatosEF()
        {
            var context = new NorthwindContext();
            var cliente = new Customer()
            {
                CustomerID = "FAD01",
                CompanyName = "Empresa Uno, SL",
                ContactName = "Fernando Alonso Diaz",
                ContactTitle = "Padre",
                Address = "Avenida paraiso, 33",
                Region = "Madrid",
                City = "Madrid",
                Country = "España",
                Phone = "900 900 900",
                Fax = "900 900 900"
            };

            context.Customers.Add(cliente);
            context.SaveChanges();
            Console.WriteLine("Registro Actualizado");
        }



        static void ActualizarDatosEF()
        {
            var context = new NorthwindContext();

            // OPCION A
            // Recuperamos el cliente de lpa base de datos, modificamos valores de las propiedades
            // y guardamos los cambios

            var cliente = context.Customers
                .Where(r => r.CustomerID == "ACF01")
                .FirstOrDefault();

            if (cliente == null) Console.WriteLine("NO existe el cliente");
            else 
            {
                cliente.ContactName = "Elon Musgo";
                cliente.PostalCode = "99999";

                context.SaveChanges();

                Console.WriteLine("Cliente actualizado correctamente");
            }

            // OPCION B
            // Instanciamos un objeto que representa un registro existente en la base de datos, pero
            // con valores diferentes y lo utilizamos para actualizar.

            var cliente2 = new Customer()
            {
                CustomerID = "FAD01",
                CompanyName = "Empresa 33, SL",
                ContactName = "Fernando Alonso Díaz",
                ContactTitle = "Padre",
                Address = "Avenida paraiso, 33",
                Region = "Madrid",
                City = "Madrid",
                Country = "España",
                Phone = "933 933 933",
                Fax = "933 933 933"
            };

         
            // Método 1
            context.Entry(cliente2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            // Método 2
            context.Customers.Update(cliente2);
            context.SaveChanges();

        }
        static void EliminarDatosEF()
        {
            var context = new NorthwindContext();
           
            
            // Método 1
            var cliente = new Customer() { CustomerID = "ACF01" };
            context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Console.WriteLine("Cliente eliminado correctamente");

            // Método 2
            var cliente2 = context.Customers
                .Where(r => r.CustomerID == "ACF01")
                .FirstOrDefault();

            if (cliente2 == null) Console.WriteLine("NO existe el cliente");
            else
            {
                context.Customers.Remove(cliente2);

                context.SaveChanges();

                Console.WriteLine("Cliente eliminado correctamente");
            }
        }





    }
}
