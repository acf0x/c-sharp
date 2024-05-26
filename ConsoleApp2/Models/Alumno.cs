namespace ConsoleApp2.Models;


public class Alumno
{
    // Miembro: Variables (suelen ser siempre privadas)
    private string nombre;
    private int edad;

    // Miembro: Propiedades (suelen y deberían de ser públicas)
    public string Nombre
    {
        // retornar la información después de transformarla
        get 
        { 
            return nombre.Trim().ToLower(); 
            }
        set { nombre = value; }


    }

}