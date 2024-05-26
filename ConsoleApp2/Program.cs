using ConsoleApp2.Models;
namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        var alumno = new Alumno();
        alumno.Nombre = " Alvaro     ";
        alumno.Edad = -30;
        Console.WriteLine($"Nombre: {alumno.Nombre}");
        Console.WriteLine($"Nombre: {alumno.Edad}");
    }




}
