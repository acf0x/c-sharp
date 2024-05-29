using Ejercicios.ConsoleAppEF.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ejercicios.ConsoleAppEF
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Consulta1();
            Consulta2();
            Consulta3();
            Consulta4();
            Consulta5();
            Consulta6();
            //Consulta7();
            Consulta8();
            Consulta9();
            Consulta10();
            Consulta11();
            Consulta12();
            Consulta13();
            Consulta14();
            Consulta15();
            //Consulta16();
            //Consulta17();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que residen en USA
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Country = 'USA'

            static void Consulta1()
            {
                var context = new NorthwindContext();

                var clientes = context.Customers
                    .Where(r => r.Country == "USA")
                    .ToList();

                Console.WriteLine("\nConsulta 1: Clientes que residen en USA:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.CustomerID} - {cliente.ContactName}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Proveedores (Suppliers) de Berlin
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Suppliers WHERE City = 'Berlin'

            static void Consulta2()
            {
                var context = new NorthwindContext();

                var proveedores = context.Suppliers
                    .Where(r => r.City == "Berlin")
                    .ToList();

                Console.WriteLine("\nConsulta 2: Proveedores de Berlín:");
                foreach (var proveedor in proveedores)
                {
                    Console.WriteLine($"{proveedor.SupplierID}# {proveedor.ContactName} - {proveedor.CompanyName}");
                }
            }


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Empleados con identificadores 3, 5 y 8
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Employees WHERE EmployeeID IN (3, 5, 8)

            static void Consulta3()
            {
                var context = new NorthwindContext();

                var empleados = context.Employees
                    .Where(r => new int[] { 3, 5, 8 }.Contains(r.EmployeeID))
                    .ToList();

                Console.WriteLine("\nConsulta 3: Empleados con identificadores 3, 5 y 8:");
                foreach (var empleado in empleados)
                {
                    Console.WriteLine($"{empleado.FirstName} {empleado.LastName}");
                }
            }


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitsInStock > 0

            static void Consulta4()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .Where(r => r.UnitsInStock > 0)
                    .ToList();

                Console.WriteLine("\nConsulta 4: Productos con stock mayor de cero:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.ProductID}# {producto.ProductName}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero de los proveedores con identificadores 1, 3 y 5
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE SupplierID IN (1, 3, 5) 

            static void Consulta5()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .Where(r => (r.SupplierID == 1 || r.SupplierID == 3 || r.SupplierID == 5) && r.UnitsInStock > 0)
                    .ToList();

                Console.WriteLine("\nConsulta 5: Productos con stock mayor de cero de proveedores con ID 1, 3 y 5:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.ProductID}# {producto.ProductName}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con precio mayor de 20 y menor 90
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitPrice > 20 AND UnitPrice < 90

            static void Consulta6()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .Where(r => r.UnitPrice > 20 && r.UnitPrice < 90)
                    .ToList();

                Console.WriteLine("\nConsulta 6: Productos con precio mayor de 20 y menor 90:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.ProductID}# {producto.ProductName} - Precio: {producto.UnitPrice.Value.ToString("N2")}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos entre 01/01/1997 y 15/07/1997
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE OrderDate >= '1997/01/01' AND OrderDate <= '1997/09/15'

            static void Consulta7()
            {
                var context = new NorthwindContext();

                var pedidos = context.Orders
                    //       .Where(r => r.OrderDate.Value >= 1997/01/01 && r.OrderDate.Value <= 1997/09/15)
                    .ToList();

                Console.WriteLine("\nConsulta 7: Pedidos entre 01/01/1997 y 15/07/1997:");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.OrderID}# {pedido.OrderDate}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1997 AND EmployeeID IN (1, 3, 4, 8)

            static void Consulta8()
            {
                var context = new NorthwindContext();

                var pedidos = context.Orders

                    .Where(r => r.OrderDate.Value.Year == 1997 && (r.EmployeeID == 1 || r.EmployeeID == 3 || r.EmployeeID == 4 || r.EmployeeID == 8))
                    .ToList();

                Console.WriteLine("\nConsulta 8: Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997:");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.OrderID}#");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de octubre de 1996
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1996 AND MONTH(OrderDate) = 10

            static void Consulta9()
            {
                var context = new NorthwindContext();

                var pedidos = context.Orders

                    .Where(r => r.OrderDate.Value.Year == 1996 && r.OrderDate.Value.Month == 10)
                    .ToList();

                Console.WriteLine("\nConsulta 9: Pedidos de octubre de 1996:");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.OrderID}#");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos realizados los dia uno de cada mes del año 1998
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1998 AND DAY(OrderDate) = 1

            static void Consulta10()
            {
                var context = new NorthwindContext();

                var pedidos = context.Orders

                    .Where(r => r.OrderDate.Value.Year == 1998 && r.OrderDate.Value.Day == 1)
                    .ToList();

                Console.WriteLine("\nConsulta 10: Pedidos realizados los dia uno de cada mes del año 1998:");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.OrderID}#");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que no tiene fax
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Fax = NULL

            static void Consulta11()
            {
                var context = new NorthwindContext();

                var clientes = context.Customers
                    .Where(r => r.Fax == null)
                    .ToList();

                Console.WriteLine("\nConsulta 11: Clientes que no tienen fax:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.CustomerID} - {cliente.ContactName}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más baratos
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice

            static void Consulta12()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .OrderBy(r => r.UnitPrice)
                    .Take(10)
                    .ToList();

                Console.WriteLine("\nConsulta 12: Productos con stock mayor de cero:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.ProductID}# {producto.ProductName} - Stock: {producto.UnitsInStock}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más caros con stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice DESC

            static void Consulta13()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .OrderByDescending(r => r.UnitPrice)
                    .Take(10)
                    .ToList();

                Console.WriteLine("\nConsulta 13: Listado de los 10 productos más caros con stock:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.ProductID}# {producto.ProductName} - Precio: {producto.UnitPrice}");
                }
            }
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Cliente de UK y nombre de empresa que comienza por B
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE CompanyName LIKE 'B%' AND Country = 'Uk'

            static void Consulta14()
            {
                var context = new NorthwindContext();

                var clientes = context.Customers
                    .Where(r => r.CompanyName.StartsWith("B") && r.Country == "UK")
                    .ToList();

                Console.WriteLine("\nConsulta 14: Clientes de UK y nombre de empresa que comienza por B:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.CustomerID}# {cliente.ContactName} - {cliente.CompanyName}");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos de identificador de categoria 3 y 5
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products WHERE CategoryID IN (3, 5)

            static void Consulta15()
            {
                var context = new NorthwindContext();

                var productos = context.Products
                    .Where(r => (r.CategoryID == 3 || r.CategoryID == 5))
                    .OrderByDescending(r => r.CategoryID)
                    .Take(10)
                    .Select(r => r)
                    .ToList();

                Console.WriteLine("\nConsulta 15: Productos de identificador de categoria 3 y 5:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"Categoría: {producto.CategoryID} | {producto.ProductID}# {producto.ProductName}");
                }
            }
            /////////////////////////////////////////////////////////////////////////////////
            // Importe total del stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT SUM(UnitInStock * UnitPrice) FROM Products

            static void Consulta16()
            {
                var context = new NorthwindContext();

                var lista = context.Products
                    .ToList();

                var productos = context.Products
                    .Sum(r => r.UnitsInStock);

                var precios = context.Products
                    .Sum(r => r.UnitPrice);

                Console.WriteLine("\nConsulta 16: Importe total del stock:");
                foreach (var item in lista)
                {
                    Console.WriteLine($"{productos * precios}");
                }
            }
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de los clientes de Argentina
            /////////////////////////////////////////////////////////////////////////////////            

            // SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina'
            // SELECT * FROM dbo.Orders WHERE CustomerID IN ('CACTU', 'OCEAN', 'RANCH')

            //           static void Consulta17()
            //           {
            //               var context = new NorthwindContext();
            //
            //            var clientes = context.Customers
            //                    .Where(r => r.Country == "Argentina")
            //                    .Select (r => r.CustomerID)
            //                    .ToList();
            //
            //            var pedidos = context.Orders
            //                    .Where(s => s.CustomerID == "CACTU" || s.CustomerID == "OCEAN" || s.CustomerID == "RANCH" ||))
            //                    .ToList;
            //
            //            Console.WriteLine("\nPedidos de los clientes de Argentina:");
            //            foreach (var cliente in clientes)
            //            {
            //            Console.WriteLine($"{cliente.CustomerID}");
            //        }
            //        }
            //
            //           // SELECT * FROM dbo.Orders WHERE CustomerID IN (SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina')
            //

        }
    }
}