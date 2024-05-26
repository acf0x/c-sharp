using System.Security.Cryptography;
using ConsoleApp1.Models;

namespace ConsoleApp1;

/// <summary>
/// La clase Program ocntiene el método Main, donde inicia la ejecucción del programa
/// </summary>

class Program

{
    /// <summary>
    /// Método Main, inicio del programa
    /// </summary>
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Hello, Todos!");
        Console.Clear();
        // DeclaracionVariables();
        // ConversionVariables();
        // SentenciasDeControl();
        SentenciasDeRepeticion();
    }

/// <summary>
/// Declaración de variables
/// </summary>
    static void DeclaracionVariables()
    {
        string texto = "Hola Mundo !!";
        string otroTexto;
        System.String texto2 = "Mi nombre es Borja";

        int numero = 10;
        int otroNumero;
        System.Int32 numero2 = 0;

        decimal a, b, c;
    

    // Instanciamos un objeto Alumno y modificamos sus propiedades o variables
        Alumno alumno = new Alumno();
        alumno.Nombre = "Borja";
        alumno.Apellidos = "Sanz";
        alumno.Edad = 33;

    // Instanciamos un objeto Alumno y asignamos valores a sus propiedades o variables
        Alumno alumno1 = new Alumno()
        {
            Nombre = "Julian",
            Apellidos = "Sánchez",
            Edad = 25
        };

        // Instanciamos un objeto Alumno usando VAR, OBJECT, DYNAMIC
        // Las variables con tipo implícito (var) se deben inicializar (dar valor)
        var alumno2 = new Alumno();
        alumno2.Nombre = "maría josé";

        Console.WriteLine($"Tipo2: {alumno2.GetType()}");
        Console.WriteLine($"Nombre2: {alumno2.Nombre}" +Environment.NewLine);
        

    // Object tiene la capacidad de contener cualquier tipo de dato, se aplica en diseño
    // No permite acceder a los miembros (args) del objeto, para acceder se debe aplicar la conversión
        Object alumno3 = new Alumno();
        ((Alumno)alumno3).Nombre = "Isabel";
        // alumno3.Nombre = "Isabel"; <- no funciona por ser un object

        Console.WriteLine($"Tipo3: {alumno3.GetType()}");
        Console.WriteLine($"Nombre3: {((Alumno)alumno3).Nombre}");
        // Console.WriteLine($"Nombre3: {alumno3.Nombre}"); <- no funciona por ser un object

    // dynamic tiene la capacidad de contener cualquier tipo de dato, se aplica en ejecución.
    // si ponemos p.e. "miNombre" u otro arg no contemplado, solo da errores en el run, pero en el build no los da
        dynamic alumno4 = new Alumno();
        alumno4.Nombre = "antonio josé";
        alumno4.Edad = 30;

        Console.WriteLine($"Tipo4: {alumno4.GetType()}");
        Console.WriteLine($"Nombre4: {alumno4.Nombre}" +Environment.NewLine);
    
    // Formula C# versiones más actuales
        Alumno alumno5 = new();
        alumno5.Nombre = "Borja";
    
        Console.WriteLine($"Tipo5: {alumno5.GetType()}");
        Console.WriteLine($"Nombre5: {alumno5.Nombre}" +Environment.NewLine);
    
    }

/// <summary>
/// Conversión de variables
/// </summary>
    static void ConversionVariables()
    {
        byte num1 = 10;         // 8bits
        int num2 = 30;          // 32bits
        string num3 = "42";     // bits variable según contenido

        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}");

        // Conversión implícita, posible si el receptor es de mayor tamaño en bits
        num2 = num1;

        Console.WriteLine($"Después de la conversión implícita");
        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}");

        // num1 = num2 <- no sería posible, la opción es hacer una conversión EXPLÍCITA, indicada por el programador 
        // será válida si el valor está comprendido entre los valores de la variable receptora
        num2 = 14500032;
        num1 = (byte)num2; // <- lo va a truncar. Coge de los 32 bits (32 num binarios) 8 y los transforma al valor decimal correspondiente

        Console.WriteLine($"Después de la conversión explícita");
        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}");

        // Conversión explícita, utilizando los métodos del objeto CONVERT
        // aquí cuando no se puede convertir, no lo trunca como antes, sino que da una excepción.
        // lo máximo sería 255
        num2 = 255;
        num1 = Convert.ToByte(num2);
        Console.WriteLine($"Después de la conversión explícita2");
        Console.WriteLine($"Num1 (byte): {num1} - Num2 (int): {num2} - Num3 (string): {num3}");


        ///////////////////////////////////////////////////////////////                
        // Transformaciones de STRING a cualquier tipo de dato númerico
        ///////////////////////////////////////////////////////////////     
        num1 = Convert.ToByte(num3);
        num2 = Convert.ToInt32(num3);
    
        // Conversión explícita, utilizando el método Parse
        num1 = byte.Parse(num3);
    
        // Conversión explícita, utilizando el método TryParse
        byte.TryParse(num3, out num1);

        num3 = "102";
        int num4;
        bool result = int.TryParse(num3, out num4);
        Console.WriteLine($"Resultado: {result} - Valor Num 4: {num4}");
        
        // En este ejemplo solo comprobamos si la transformación es posible.
        // Mediante [out _] indicamos que no queremos el resultado de la transformación  
        var esEntero = int.TryParse(num3, out _);

        Console.WriteLine($"Resultado: {result} - Valor Num 4: {num4}");
        Console.WriteLine($"Resultado Num 5: {esEntero}");
    }


    static void SentenciasDeControl()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        // Uso de IF/ELSE
        Reserva reserva = new Reserva();
        
        Console.Write("ID de la Reserva: ");
        reserva.id = Console.ReadLine();

        Console.Write("Nombre del Cliente: ");
        reserva.cliente = Console.ReadLine();

        Console.Write("Tipo de Reserva: (100, 200, 300 o 400) ");
        // Opcion A
        string respuesta = Console.ReadLine();
        int.TryParse(respuesta, out reserva.tipo);

        // Opcion B
        //int.TryParse(Console.ReadLine(), out reserva.tipo);

        Console.Write("Es Fumador ? (Sí o No) ");
        string fumador = Console.ReadLine();

        // Opción 1, utilizando IF/ELSE
        if (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí")
        {
            reserva.fumador = true;
        }
        else
        {
            reserva.fumador = false;
        }

        // Opción 2, utilizando IF/ELSE IF/ELSE
        if (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí")
        {
            reserva.fumador = true;
        }
        else if (fumador.ToLower().Trim() == "no")
        {
            reserva.fumador = false;
        }
        else 
        {
            reserva.fumador = false;
            Console.WriteLine($"El valor {fumador} no es valido, pero se asigna habitación de no fumador.");
        }

        // Opción 3, utilizando IF/ELSE (sin bloques)
        if (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí") reserva.fumador = true;        
        else reserva.fumador = false;

        // Opción 4a, asignación condicional con ? :
        // Siempre un IF/ELSE y asignación de un valor (no ejecutan sentencias)
        reserva.fumador = (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí") ? true : false;

        // Opción 4b, asignación condicional con ? :
        // Siempre un IF/ELSE y asignación de un valor (no ejecutan sentencias)
        reserva.fumador = (fumador.ToLower().Trim() == "si" || fumador.ToLower().Trim() == "sí");

        // Opción 5, utilizando SWITCH
        switch(fumador.ToLower().Trim())
        {
            case "si":
                reserva.fumador = true;
                break;
            case "sí":
                reserva.fumador = true;
                break;
            case "no":
                reserva.fumador = false;
                break;
            default:
                reserva.fumador = false;
                Console.WriteLine($"El valor {fumador} no es valido, pero se asigna habitación de no fumador.");
                break;
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("ID Reserva: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{reserva.id}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Cliente: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(reserva.cliente);

        // Pintar el tipo de habitación
        // 100 -> Habitación individual
        // 200 -> Habitación doble
        // 300 -> Habitación Junior Suite
        // 400 -> Habitación Suite (cyan)
        // xxx -> xxx, tipo de habitación desconocido (rojo)


        // IF/ELSEIF/ELSE
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Tipo: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (reserva.tipo == 100) {
            Console.WriteLine($"Habitación individual");}
        else if (reserva.tipo == 200) {
            Console.WriteLine($"Habitación doble");}
        else if (reserva.tipo == 300) {
            Console.WriteLine($"Habitación Junior Suite");}
        else if (reserva.tipo == 400) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Habitación Suite");}
        else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{reserva.tipo}, tipo de habitación desconocido");}

        // SWITCH


        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Tipo: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        switch(reserva.tipo)
        {
            case 100:
                Console.WriteLine($"Habitación individual");
                break;
            case 200:
                Console.WriteLine($"Habitación doble");
                break;
            case 300:
                Console.WriteLine($"Habitación Junior Suite");
                break;
            case 400:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Habitación Suite");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{reserva.tipo}, tipo de habitación desconocido");
                break;
        }

        // Pintar si es fumador
        // true -> Sí (rojo)
        // false -> No (verde)

        // Asignador condicional (condición) ? "Sí" : "No"

        // Opción A
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Fumador: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.ForegroundColor = reserva.fumador ? ConsoleColor.Red : ConsoleColor.Green;   
        Console.WriteLine((reserva.fumador) ? "Sí" : "No");

        // Opción B
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Fumador: ".PadLeft(15, ' '));
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.ForegroundColor = reserva.fumador ? ConsoleColor.Red : ConsoleColor.Green;  
        string esFumador = reserva.fumador ? "Sí" : "No";  
        Console.WriteLine(esFumador);

}


    static void SentenciasDeRepeticion()
    {
        string[] frutas = {"naranja", "limón", "pomelo", "líma"};
        object[] objetos = {"naranja", 10, new Alumno(), new Reserva()};

        // Recorremos una colección con un contador FOR
        // Mostramos el contenido de Array utilizando la posición de los elementos
        // Python: for i in range(0, i < len(frutas), i += 1)

        // Opción 1a
        for(int i = 0; i < frutas.Length; i += 1)
        {
            Console.WriteLine($"Posición {i} -> {frutas[i]}");
        }
        Console.WriteLine("");

        // Opcion 1b
        for (int i = 0; i < frutas.Length; i += 1) Console.WriteLine($"Posición {i} -> {frutas[i]}");
        Console.WriteLine("");

        // Recorremos una colección utilizando un FOREACH
        // Mostramos el contenido de Array utilizando los valores elementos
        // Python: for fruta in frutas
        foreach (string fruta in frutas)
        {
            Console.WriteLine($" -> {fruta}");
        }
        Console.WriteLine("");

        // Recorremos una colección utilizando un WHILE
        int contador = 0;
        while (contador < frutas.Length)
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
        }
        Console.WriteLine("");

        contador = 0;
        while (true)
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
            if (contador >= frutas.Length) break;
        }
        Console.WriteLine("");

        // Recorremos una colección utilizando un DO/WHILE
        // Usado principalmente cuando queremos que se ejecute AL MENOS 1 vez (ej, comprobar conex.)
        contador = 0;
        do
        {
            Console.WriteLine($"Posición {contador} -> {frutas[contador]}");
            contador++;
        } while (contador < frutas.Length);
        Console.WriteLine("");
    

        //////////////////////////////////////////////////////////////////////////////////

        decimal[] numeros = {10, 5, 345, 52, 13, 1000, 83};

        decimal suma = 0;
        decimal suma2 = 0;
        decimal suma3 = 0;
        decimal max = numeros[0];
        decimal min = numeros[0];
        decimal max2 = numeros[0];
        decimal min2 = numeros[0];
        decimal max3 = numeros[0];
        decimal min3 = numeros[0];

        contador = 0;

        // Mostramos la suma y la media, el número mayor y el menor

        // FOR

        for (int i = 0; i < numeros.Length; i += 1)
        {
            suma += numeros[i];
            if (numeros[i] > max)
            {
                max = numeros[i];
            }
            if (numeros[i] < min)
            {
                min = numeros[i];
            }
        }
        decimal media = suma/numeros.Length;
        Console.WriteLine($"SUMA FOR: {suma}");
        Console.WriteLine($"MEDIA FOR: {media.ToString("N2")}");
        Console.WriteLine($"MAX FOR: {max}");
        Console.WriteLine($"MIN FOR: {min}");
        Console.WriteLine();

        // FOREACH

        foreach (int numero in numeros)
        {
            suma2 += numero;
            if (numero > max2) max2 = numero;
            if (numero < min2) min2 = numero;
        }
        decimal media2 = suma/numeros.Length;
        Console.WriteLine($"SUMA FOREACH: {suma2}");
        Console.WriteLine($"MEDIA FOREACH: {media2.ToString("N2")}");
        Console.WriteLine($"MAX FOREACH: {max2}");
        Console.WriteLine($"MIN FOREACH: {min2}");
        Console.WriteLine();

        // WHILE
        while (contador < numeros.Length)
        {
            if (numeros[contador] > max3)
            {
                max3 = numeros[contador];
            }
            if (numeros[contador] < min3)
            {
                min3 = numeros[contador];
            }
            suma3 += numeros[contador];
            contador += 1;
        }
        decimal media3 = suma/numeros.Length;
        Console.WriteLine($"SUMA WHILE: {suma3}");
        Console.WriteLine($"MEDIA WHILE: {media3.ToString("N2")}");
        Console.WriteLine($"MAX WHILE: {max3}");
        Console.WriteLine($"MIN WHILE: {min3}");
        Console.WriteLine();

        // Ejemplo de obtener información con métedos de LINQ

        Console.WriteLine($"Suma total: {numeros.Sum()}");
        Console.WriteLine($"Media: {numeros.Average().ToString("N2")}");
        Console.WriteLine($"Número mayor: {numeros.Max()}");
        Console.WriteLine($"Número menor: {numeros.Min()}");

    static void ControlDeExcepciones()
    {

        // EJEMPLO EN PYTHON
        // numero1 = 5
        // numero2 = 100

        // try:    
        //     numero3 = numero2 / numero1
        //     print(f"Valor de número 3: {numero3}")

        //     f = open("miFichero.txt")
        // except ZeroDivisionError as err:
        //     print(f"-> {err}")
        //     print(f"-> {type(err)}")
        // except FileNotFoundError as err:
        //     print(f"-> {err}")
        //     print(f"-> {type(err)}")
        // except Exception as err:
        //     print(f"{err}")
        //     print(f"{type(err)}")
        // finally:
        //     print(f"F I N")


        int numero1 = 5;
        int numero2 = 100;

        try
        {
            int numero3 = numero2 / numero1;
            Console.WriteLine($"El valor de número 3 es {numero3}");
        }
        catch (DivideByZeroException err)
        {
            Console.WriteLine("Excepción específica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
        }
        catch (FileNotFoundException err)
        {
            Console.WriteLine("Excepción específica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
        }
        catch (Exception err)
        {   
            Console.WriteLine("Excepción genérica");
            Console.WriteLine($"Mensaje: {err.Message}");
            Console.WriteLine($"Tipo: {err.GetType()}");
        }
        finally
        {
            Console.WriteLine("FIN");
        }
        Console.WriteLine("");

        /*
        try:
            print("Nivel 1")

            print("Inicio Nivel 2")

            try:
                print("Nivel 2")
                print(100/0)
            except Exception as err:
                raise
                print(f"Nivel 2: {err}")
            finally:
                print("Fin Nivel 2")
        except Exception as err:
            print(f"Nivel 1: {err}")
        */
        try
        {
            Console.WriteLine("NIVEL 1");

            Console.WriteLine(" -> Inicio Nivel 2");
            try
            {
                Console.WriteLine("NIVEL 2");
                int n1 = 0;
                int n2 = 100;
                int n3 = n2 / n1;
            }
            catch (Exception e)
            {                
                Console.WriteLine($"Error 2: {e.Message}");
                throw new Exception("No se puede dividir por cero");
            }
            finally
            {
                Console.WriteLine(" -> Fin Nivel 2");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error 1: {e.Message}");
            throw;
        }
    }
}
}

