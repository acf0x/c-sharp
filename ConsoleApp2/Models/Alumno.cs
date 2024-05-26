using System.Configuration.Assemblies;
using System.Security.Cryptography;

namespace ConsoleApp2.Models;


public class Alumno
{
    // Miembro: Variables (suelen ser siempre privadas)
    private string nombre;
    private int edad;


    // Miembro: Propiedad que se comporta como una variable pública
    // esto se puede hacer así cuando en la propiedad no hay ninguna validación, lo que mandan es lo que coge
    // si es el caso, no hace falta crear la variable "private string apellido"
    public string Apellidos {get; set;}

    // Miembro: Propiedades (suelen y deberían de ser públicas)
    public string Nombre
    {
        // retornar la información después de transformarla
        get 
        { 
            return nombre.Trim().ToLower(); 
        }
        set 
        { 
            if(value.Length < 2) nombre = "";
            else nombre = value; 
        }
    }

    public int Edad
    {
        get { return edad; }
        set 
        {
            if(value < 1 || value > 120) edad = 0;
            else edad = value;
        }

    }


    // Miembro: Propiedad de solo lectura, no asociada a una variable
    public string NombreCompleto
    {
        get
        {
            return $"{this.nombre} {this.Apellidos}";
        }

    }

    // Miembro: Propiedad de solo escritura
    public int CambiaEdad
    {
        set 
        {
            if(value < 1 || value > 120) edad = 0;
            else edad = value;
        }

    }


    // Miembro: Métodos con tipo de dato void, que no retorna nada
    public void MetodoUno()
    {
        
    // Miembro: Métodos con tipo de datos (Ejemplo: bool) que siempre retorna ese tipo de dato
    }
    public bool MetodoDos()
    {
        return true;
    }

    // Requiere indicar param1 y 2 para su ejecución. 3 y 4 son opcionales, para ello, se les añade un valor por defecto
    public bool MetodoTres(int param1, string param2, float param3 = 0, string param4 = "valor por defecto")
    {
        return true;
    }



    // Miembro: Método constructor, se ejecuta cuando se instancia el objeto
    // Es público, no tiene tipo (no retorna nada y no es void) y se llama igual que la clase
    public Alumno()
    {

    }

    // Sobrecarga del método constructor
    public Alumno(string nombre, string apellidos)
    {
        this.nombre = nombre;
        this.Apellidos = apellidos;

    }

    // Sobrecarga del método constructor
    public Alumno(string nombre, int edad)
    {
        this.nombre = nombre;
        this.Edad = edad;

    }
}