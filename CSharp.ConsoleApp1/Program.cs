using System.Security.Cryptography;
using CSharp.ConsoleApp1.Models;

namespace CSharp.ConsoleApp1;

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
        DeclaracionVariables();
        ConversionVariables();
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

    }


}