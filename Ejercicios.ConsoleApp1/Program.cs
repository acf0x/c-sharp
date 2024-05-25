namespace Ejercicios.ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Ejercicio3();
    }

    // Pedir un número por consola y analizarlo para retorna uno de los dos mensajes:
    // -> El número introducido es [valor]
    // -> No se ha introducido un número o no se puede convertir
    static void Ejercicio1()
    {
        // MÍO

        int n = 0;
        Console.Write("Introduce un número: ");
        if (int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine($"El número es {n}");
        }
        else Console.WriteLine($"No se ha introducido un número o no se puede convertir");
        
        
        // Opcion A

        Console.Write("Introduce un número: ");
        string respuesta = Console.ReadLine();

        int numero = 0;
        bool resultado = int.TryParse(respuesta, out numero);

        if(resultado == true) Console.WriteLine($"El número es {numero}.");
        else Console.WriteLine($"{respuesta} no se puede convertir a número.");

    }


// Pedir un numero con parte decimal por consola y convertirlo a float con .Parse
// Controlar las excepciones FormatExcepcion y OverflowException
// Mostrar los mensajes en caso de error, de mal formato o numero demasiado grande

    static void Ejercicio2()
    {







    }

// Preguntar por consola una fecha
// Convertir a DateTime utilizando TryParse
// Si se puede convertir, mostrar la fecha que retorna la ejecución del método .ToLongDateString()

        // MIO
    static void Ejercicio3()
    {
        Console.Write("Introduce una fecha (dd/mm/yyyy): ");
        string input = Console.ReadLine();
        DateTime fecha;

        bool parse = DateTime.TryParse(input, out fecha);
        if(parse == true) Console.WriteLine($"La fecha es {fecha.ToLongDateString()}");
        else Console.WriteLine($"No es una fecha válida");

        // Opcion B
        Console.Write("Introduce una fecha: ");
        string respuesta2 = Console.ReadLine();

        DateTime fecha2;
        Console.WriteLine(DateTime.TryParse(respuesta2, out fecha2) ? fecha2.ToLongDateString() : $"{respuesta2} no se puede convertir en fecha.");
    }

// Repite el ejercicio anterior utilizando Convert
    static void Ejercicio4()
    {







    }

}