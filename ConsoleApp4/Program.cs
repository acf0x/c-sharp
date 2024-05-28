using System.Diagnostics.Contracts;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime fecha = DateTime.Now;
            DateTime fecha2 = new DateTime(1990, 5, 27);               // 27-05-1990  0:00:00
            DateTime fecha3 = new DateTime(1990, 5, 27, 10, 10, 0);    // 27-05-1990 10:10:00

            fecha2.AddDays(-4);   // 23-05-1990  0:00:00
            var resta = fecha - fecha2;
            var resta2 = fecha.Subtract(fecha2);

            Console.WriteLine(fecha2.ToString());
            Console.WriteLine(fecha2);
            Console.WriteLine(fecha.ToLongDateString);
            Console.Clear();
            Ejercicio6();



        }

        static void ConsultasBasicas()
        {
            // Transat-SQL -> SELECT * FROM ListaProductos
            // Listado de Productos completo

            // Métodos de LINQ
            var productos1a = DataLists.ListaProductos
                .ToList();

            // Expresiones de LINQ
            var productos1b = from r in DataLists.ListaProductos
                              select r;

///////////////////////////////////////////////////////////////////
            
            // Transat-SQL -> SELECT * FROM ListaProductos WHERE precio > 2
            // Listado de Productos con precio mayor de 2

            // Métodos de LINQ
            var productos2a = DataLists.ListaProductos
                .Where(r => r.Precio > 2)
                .ToList();

            // Expresiones de LINQ
            var productos2b = from r in DataLists.ListaProductos
                              where r.Precio > 2
                              select r;

///////////////////////////////////////////////////////////////////
///
            // Transat-SQL -> SELECT * FROM ListaProductos WHERE precio > 2 ORDER BY descripcion DESC
            // Listado de Productos con precio mayor de 2 ordenados por descripción DESC

            // Métodos de LINQ
            var productos3a = DataLists.ListaProductos
                .Where(r => r.Precio > 2)
                .OrderByDescending(r => r.Descripcion)
                .ToList();

            // Expresiones de LINQ
            var productos3b = from r in DataLists.ListaProductos
                              where r.Precio > 2
                              orderby r.Descripcion descending
                              select r;

///////////////////////////////////////////////////////////////////
            
            // Transat-SQL -> SELECT Descripcion, Precio  FROM ListaProductos WHERE precio > 2.5 ORDER BY precio ASC
            // Listado de Descripcion y Precio para productos con precio mayor de 2.5 ordenados por precio ASC

            // Métodos de LINQ
            var productos4a = DataLists.ListaProductos
                .Where(r => r.Precio > 2.5)
                .OrderBy(r => r.Precio)
                .Select(r => new { r.Descripcion, r.Precio })
                .ToList();

            // Expresiones de LINQ
            var productos4b = from r in DataLists.ListaProductos
                              where r.Precio > 2.5
                              orderby r.Precio
                              select new {r.Descripcion, r.Precio};


///////////////////////////////////////////////////////////////////
        
        // Transat-SQL -> SELECT id AS Code FROM ListaProductos
        // Listado de Id y Descripción de Producots

            // Métodos de LINQ
        var productos5a = DataLists.ListaProductos
            .Select(r=>new {Code = r.Id, r.Descripcion})
            .ToList();

            // Expresiones de LINQ
            var productos5b = from r in DataLists.ListaProductos
                              select new { Code = r.Id, r.Descripcion };

///////////////////////////////////////////////////////////////////

        // Transat-SQL -> SELECT descripcion FROM ListaProductos
        // Listado de Descripción de Producots

        // Métodos de LINQ
        var productos6a = DataLists.ListaProductos
            .Select(r => r.Descripcion )
            .ToList();

            // Expresiones de LINQ
            var productos6b = from r in DataLists.ListaProductos
                              select r.Descripcion;


///////////////////////////////////////////////////////////////////
    
        // Ordena en la base de datos
        var order1a = DataLists.ListaProductos
            .Where(r => r.Precio > 0.9 && r.Precio <2)
            .OrderBy(r => r.Descripcion)
            .Select(r => r.Descripcion);

        var order1b = from r in DataLists.ListaProductos
            where r.Precio > 0.90 && r.Precio < 2
            orderby r.Descripcion
            select r.Descripcion;


        // Ordena en el ordenador, puede ofrecer menos rendimiento
        var order2a = DataLists.ListaProductos
            .Where(r => r.Precio > 0.90 && r.Precio < 2)
            .Select(r => r.Descripcion)
            .OrderBy(r => r);

        // Ordena en el ordenador, puede ofrecer menos rendimiento
        var order2b = (from r in DataLists.ListaProductos
                        where r.Precio > 0.90 && r.Precio < 2
                        select r.Descripcion).ToList().OrderBy(r => r);

        ////////////////////////////////////////////////////////////////////////////////////////

        // Contains -> Contiene; 
        // Transat-SQL -> SELECT * FROM ListaProductos  WHERE descripcion LIKE '%es%'

        var w1a = DataLists.ListaProductos
            .Where(r => r.Descripcion.Contains("es"))
            .Select(r => r)
            .ToList();

        var w1b = from r in DataLists.ListaProductos
                    where r.Descripcion.Contains("es")
                    select r.Descripcion;


        // StartsWith-> Comienza; 
        // Transat-SQL -> SELECT * FROM ListaProductos  WHERE descripcion LIKE 'es%'

        var w2a = DataLists.ListaProductos
            .Where(r => r.Descripcion.StartsWith("es"))
            .Select(r => r)
            .ToList();

        var w2b = from r in DataLists.ListaProductos
                    where r.Descripcion.StartsWith("es")
                    select r.Descripcion;


        // EndsWith-> Finaliza
        // Transat-SQL -> SELECT * FROM ListaProductos  WHERE descripcion LIKE '%es'

        var w3a = DataLists.ListaProductos
            .Where(r => r.Descripcion.EndsWith("es"))
            .Select(r => r)
            .ToList();

        var w3b = from r in DataLists.ListaProductos
                    where r.Descripcion.EndsWith("es")
                    select r.Descripcion;



        foreach (var producto in productos4a)
            Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio.ToString("N2")}");
        }

        /// <summary>
        /// Clientes mayores de 40 años
        /// </summary>
        static void Ejercicio1()
        {
            DateTime fecha = DateTime.Now;
            var clientes = DataLists.ListaClientes
                .Where(r => (fecha.Year - r.FechaNac.Year) > 40)
                .ToList();

            Console.WriteLine($"Clientes mayores de 40 años:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nombre} - Edad: {(fecha.Year - cliente.FechaNac.Year)} años");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Productos que comiencen por C ordenados por precio
        /// </summary>
        static void Ejercicio2()
        {
            var productos = DataLists.ListaProductos
                .Where(r => r.Descripcion.StartsWith("C"))
                .OrderBy(r=> r.Precio)
                .ToList();

            Console.WriteLine($"Productos que comienzan por C ordenados por precio:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"{producto.Descripcion} - Precio: {producto.Precio} euros");
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Listar un detalle de todos los pedidos (Id, Descripción, Cantidad y Precio de cada producto del pedido)
        /// </summary>
        static void Ejercicio3()
        {
            // Id, Descripción, Cantidad y el precio de cada producto del pedido

            var pedidos = DataLists.ListaPedidos
                .ToList();

            foreach (var pedido in pedidos)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("Pedido numero: {0}", pedido.Id);
                Console.WriteLine("=======================================================");

                var lineas = DataLists.ListaLineasPedido
                    .Where(r => r.IdPedido == pedido.Id)
                    .Select(r=> new { r.IdProducto, r.Cantidad})
                    .ToList();

                float total = 0;

                foreach (var linea in lineas)
                {
                    var producto = DataLists.ListaProductos
                        .Where(r => r.Id == linea.IdProducto)
                        
                        .FirstOrDefault();

                    Console.WriteLine($"{producto.Id} - {producto.Descripcion} -  Cant. {linea.Cantidad} - Precio {producto.Precio.ToString("N2")}");

                    total = total + (linea.Cantidad * producto.Precio);
                }

                Console.WriteLine("=======================================================");
                Console.WriteLine($"TOTAL PEDIDO: {total.ToString("N2")}");
                Console.WriteLine("=======================================================\n\n");
            }

        }


        static void Ejercicio3B()
        {
            // Subconsultas o SubSelects
            Console.Clear();
            Console.Write("Número de Pedido: ");
            int numPedido = Convert.ToInt32(Console.ReadLine());

            var lineas = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == numPedido)
                .Select(r => new {
                    r.IdProducto,
                    Descripcion = DataLists.ListaProductos
                        .Where(s => s.Id == r.IdProducto)
                        .Select(r => r.Descripcion)
                        .FirstOrDefault(),
                    Precio = DataLists.ListaProductos
                        .Where(s => s.Id == r.IdProducto)
                        .Select(r => r.Precio)
                        .FirstOrDefault(),
                    r.Cantidad
                })
                .ToList();

            //CON LINQ

            var lineas2 = from r in DataLists.ListaLineasPedido
                          where r.IdPedido == numPedido
                          select new
                          {
                              r.IdProducto,
                              Descripcion = (from s in DataLists.ListaProductos
                                            where s.Id == r.IdProducto
                                            select s.Descripcion).FirstOrDefault(),
                              Precio = (from s in DataLists.ListaProductos
                                       where s.Id == r.IdProducto
                                       select s.Precio).FirstOrDefault(),
                              r.Cantidad
                          };


            foreach (var linea in lineas)
                Console.WriteLine($"{linea.IdProducto} - {linea.Descripcion} -  Cant. {linea.Cantidad} - Precio {linea.Precio.ToString("N2")}");
        }


        /// <summary>
        /// Mostrar el importe total de un pedido
        /// </summary>
        static void Ejercicio4a()
        {
            Console.Clear();
            Console.Write("Número de Pedido: ");
            int numPedido = Convert.ToInt32(Console.ReadLine());

            var lineas = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == numPedido)
                .Select(r => new { r.IdProducto, r.Cantidad })
                .ToList();

            float total = 0;


            foreach (var linea in lineas)
            {
                var precio = DataLists.ListaProductos
                    .Where(r => r.Id == linea.IdProducto)
                    .Select(r => r.Precio)
                    .FirstOrDefault();

                total += (linea.Cantidad * precio);
            }
            Console.WriteLine("===============================================");
            Console.WriteLine("TOTAL".PadLeft(39, ' ') + $"   {total.ToString("N2").PadLeft(5, ' ')}");
            Console.WriteLine("===============================================");
        }

        /// <summary>
        /// Mostrar el importe total de un pedido, calculado con LINQ
        /// </summary>
        static void Ejercicio4B()
        {
            Console.Clear();
            Console.Write("Número de Pedido: ");
            int numPedido = Convert.ToInt32(Console.ReadLine());

            var total = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == numPedido)
                .Select(r => r.Cantidad * DataLists.ListaProductos
                        .Where(s => s.Id == r.IdProducto)
                        .Select(s => s.Precio)
                        .FirstOrDefault()).Sum();

            Console.WriteLine(total);

            //TODO CON LINQ

            var total2 = (from r in DataLists.ListaLineasPedido
                         where r.IdPedido == numPedido
                         select r.Cantidad * (from s in DataLists.ListaProductos
                                              where s.Id == r.IdProducto
                                              select s.Precio).FirstOrDefault()).Sum();

            Console.WriteLine(total2);
        }

        /// <summary>
        /// Mostrar los pedidos con lapiceros
        /// </summary>
        static void Ejercicio5a()
        {
            var lapiceroID = (from r in DataLists.ListaProductos
                              where r.Descripcion == "Lapicero"
                              select r.Id).FirstOrDefault();

            var pedidos_con_lapiceros = from r in DataLists.ListaLineasPedido
                            where r.IdProducto == lapiceroID
                            select r.Id;
        }


        static void Ejercicio5b()
        {
            var ids = DataLists.ListaProductos
                      .Where(r=> r.Descripcion.ToLower().Contains("Lapicero"))
                      .Select(r=>r.Id)
                      .ToList();

            var pedidos = DataLists.ListaLineasPedido
                .Where(r=> ids.Contains(r.IdProducto))
                .Select(r=>r.IdPedido)
                .Distinct()
                .ToList();

            foreach(var pedido in pedidos)
                Console.WriteLine($"ID Pedido: {pedido.ToString().PadLeft(4, ' ')}");


            // CON LINQ

            var ids2 = (from r in DataLists.ListaProductos
                        where r.Descripcion.ToLower().Contains("lapicero")
                        select r.Id).ToList();

            var pedidos2 = (from r in DataLists.ListaLineasPedido
                           where ids2.Contains(r.IdProducto)
                           select r.IdPedido).Distinct();


        }

        /// <summary>
        /// Número de pedidos con cuaderno grande
        /// </summary>

        // MIO
        static void Ejercicio6()
        {
            var Lpedidos = DataLists.ListaLineasPedido
                .Where(r => r.IdProducto == 2)
                .Select(r => new {r.Id, r.Cantidad})
                .ToList();

            Console.WriteLine($"Pedidos con cuaderno grande:");
            Console.WriteLine($"==========================================");
            short contador = 0;

            foreach (var pedido in Lpedidos)
            {
                contador += 1;
                Console.WriteLine($"{contador}# ID: {pedido.Id}, {pedido.Cantidad} cuadernos");
            }
            Console.WriteLine($"==========================================");
            Console.WriteLine($"Número de pedidos con cuaderno grande: {contador}");
            Console.WriteLine($"Número de pedidos con cuaderno grande: {Lpedidos.Count}"); // lo mismo y no haría falta contador
            Console.WriteLine();
        }


        static void Ejercicio6b()
        {
            var pedidos = DataLists.ListaLineasPedido
                .Where(r => r.IdProducto == 2)
                .Count();

            var pedidos2 = DataLists.ListaLineasPedido
                .Count(r => r.IdProducto == 2);

            var pedidos3 = DataLists.ListaLineasPedido
                .Where(r => r.IdProducto == 2)
                .Select(r => r.IdPedido)
                .Distinct()
                .Count();

            var pedidos4 = (from r in DataLists.ListaLineasPedido
                            where r.IdProducto == 2
                            select r.Id).Count();


            Console.Clear();
            Console.WriteLine($"{pedidos} pedidos con cuadernos grandes.");

        }

        /// <summary>
        /// Unidades vendidas de cuaderno pequeño
        /// </summary>
        static void Ejercicio7()
        {
            var unidades = DataLists.ListaLineasPedido
                .Where(r => r.IdProducto == 3)
                .Sum(r => r.Cantidad);

            var unidades2 = DataLists.ListaLineasPedido
                .Where(r => r.IdProducto == DataLists.ListaProductos
                                            .Where(s => s.Descripcion.ToLower().Contains("cuaderno pequeño"))
                                            .Select(s => s.Id)
                                            .FirstOrDefault())
                .Sum(r => r.Cantidad);

            var unidades3 = (from r in DataLists.ListaLineasPedido
                where r.IdProducto == 3
                select r.Cantidad).Sum();

            var lista = from r in DataLists.ListaLineasPedido
                             where r.IdProducto == 3
                             select new { r.IdPedido, r.Cantidad};

            var unid = lista.Sum(r => r.Cantidad);


        }
        

        /// <summary>
        /// Consultas avanzadas de LINQ con DataLists
        /// </summary>
        static void ConsultasAvanzadas()
        {
            ////////////////
            // AGREGACIÓN //
            ////////////////

            // Count()      -> Cuenta el numero de elementos
            // Distinct()   -> Retorna valores distintos, eliminando los repetidos de la colección
            // Max()        -> Valor maximo, se aplica también a los alfanumúricos
            // Min()        -> Valor minimo, se aplica también a los alfanumericos
            // Sum()        -> Suma valores numericos
            // Average()    -> Calcula la media de valores numéricos
            // Aggregate()  -> Aplica una fórmula o método de agregación

            var demo1 = DataLists.ListaProductos
                .Where(r => r.Precio > 0.90)
                .Count();

            var demo2 = DataLists.ListaProductos
                .Count(r => r.Precio > 0.90);

            var demo3 = (from r in DataLists.ListaProductos
                         where r.Precio > 0.90
                         select r).Count();


             ////////////////
            // PAGINACIÓN //      En paginación, MUY importante ORDENAR
           ////////////////
           
            // Ordenación en la base de datos
            var pag2a = DataLists.ListaProductos
                .OrderBy(r=>r.Descripcion)
                .Skip(5)
                .Take(5)
                .Select(r=>r)
                .ToList();

            // Ordenación en el PC 
            var data = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Select(r => r)
                .ToList()
                .Skip(5)
                .Take(5);

            var data = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Select(r => r)
                .ToList();
            var p1 = data.Skip(0).Take(5);
            var p2 = data.Skip(5).Take(5);
            var p3 = data.Skip(10).Take(5);






        }



    }
}
