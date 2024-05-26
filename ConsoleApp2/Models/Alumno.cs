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
        set 
        { 
            if(value.Length < 2) nombre = "";
            else nombre = value; 
        }

    public int edad
    {
        get { return edad; }
        set 
        {
            if(value < 1 || value > 120) edad = 0;
            else edad = value;
        }

    }

    }

}