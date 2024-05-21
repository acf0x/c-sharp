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
    }

/// <summary>
/// Declaracción de variables
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
        var alumno2 = 10;
        Console.WriteLine(alumno2.GetType());
    }





}