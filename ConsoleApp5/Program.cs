using System.Globalization;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExtensionTipos();
        }
        /// <summary>
        /// La herencia nos permite crear nuevas clases que reutilizan, extienden y modifican el comportamiento definido en otras clases.
        /// Clase Padre -> Clase Hija
        /// Clase Base -> Clase Derivada
        /// </summary>
        static void Herencia()
        {
            var lista = new List<int>() { 1, 2, 3 };
            lista.Add(4);
            lista.Add(5);
            //listaEx.OutputAll();   <-- este método solo existiría en la clase que hemos creado "listaEx"

            // Mediante la herencia, el objeto tiene todos los métodos, propiedades... de
            // una LIST y además los métodos implementados como OUTPUTALL
            var listaEx = new ListExtend<int>() { 1, 2, 3 };
            listaEx.Add(4);
            listaEx.Add(5);
            listaEx.OutputAll();

            var Alumnos = new ListExtend<Alumno>
            {
                new Alumno() { Nombre = "Julia", Apellidos = "Fernandez", Edad = 24 },
                new Alumno() { Nombre = "Rosa", Apellidos = "Perez", Edad = 26 },
            };
            Alumnos.Add(new Alumno() { Nombre = "Ramón", Apellidos = "Sanz", Edad = 19 });
            Alumnos.OutputAll();

            Console.WriteLine($"Lista extendida {Alumnos.ToString()}\n");

        }

        static void Herencia2()
        {
            Animal anfibio = new Anfibio() { Nombre = "Rana" }; // Puede ser tanto clase Animal como Anfibio
            anfibio.MetodoA();
            anfibio.MetodoB();
            Console.WriteLine($"{anfibio.Especie}\n");

            Anfibio anfibio2 = new Anfibio() { Nombre = "Rana2" }; // Puede ser tanto clase Animal como Anfibio
            anfibio2.MetodoA();
            anfibio2.MetodoB();
            Console.WriteLine($"{anfibio2.Especie}\n");

            Reptil reptil = new Reptil() { Nombre = "Lagarto" }; // Este no puede ser clase abstracta Animal porque el MetodoC solo está dentro de Reptil
            reptil.MetodoA();
            reptil.MetodoB();
            reptil.MetodoC();
            Console.WriteLine($"{reptil.Especie}\n");

            Test(anfibio);
            Test(reptil);
        }

        static void Test(Animal animal) // este método permitiría instanciar cualquier tipo de animal con Test(anfibio), Test(reptil)...
        {
            animal.MetodoA();
            animal.MetodoB();
            Console.WriteLine($"{animal.Nombre} - {animal.Especie}");
            Console.WriteLine($"{animal.GetType().ToString()}\n");

            if (animal.GetType() == typeof(Reptil))
            {
                ((Reptil)animal).MetodoC(); // conversión de animal a Reptil y entonces invocar MetodoC
            }
        }

        static void Polimorfismo()
        {
            Coche coche = new Coche() { Nombre = "Hyundai Tucson", Ruedas = 4 };
            coche.Iniciar();
            coche.Parar();
            Console.WriteLine($"{coche.Nombre}\n");


            Avion avion = new Avion() { Nombre = "Airbus A320", Ruedas = 8, Potencia = 8000 };
            avion.Iniciar();
            avion.Parar();
            avion.Despegar();
            Console.WriteLine($"{avion.Nombre}\n");

            Test2(coche);
            Test2(avion);
        }

        static void Test2(IVehiculo vehiculo)
        {
            vehiculo.Iniciar();
            vehiculo.Parar();
            Console.WriteLine($"{vehiculo.Nombre}\n");

            if (vehiculo.GetType() == typeof(Avion)) ((Avion)vehiculo).Despegar();
        }

        static void ClasesGenericas()
        {
            DemoString demo1 = new DemoString("Hola Mundo!!");
            demo1.Metodo();
            Console.WriteLine("");

            DemoGenerica<string> demo1b = new DemoGenerica<string>("Hola Mundo!!");
            demo1b.Metodo();
            Console.WriteLine("");

            DemoInt demo2 = new DemoInt(33);
            demo2.Metodo();
            Console.WriteLine("");

            DemoGenerica<int> demo2b = new DemoGenerica<int>(33);
            demo2b.Metodo();
            Console.WriteLine("");

            DemoAlumno demo3 = new DemoAlumno(new Alumno() { Nombre = "Julia", Apellidos = "Sanz" });
            demo3.Metodo();
            Console.WriteLine();

            DemoGenerica<Alumno> demo3b = new DemoGenerica<Alumno>(new Alumno() { 
                Nombre = "Julia", 
                Apellidos = "Sanz" 
            });
            demo3b.Metodo();
            Console.WriteLine();
        }

        static void ExtensionTipos()
        {
            string texto = "En un lugar de la mancha de cuyo nombre...";
            Console.WriteLine($"Texto original: {texto}");
            Console.WriteLine($"Texto formato titulo: {ConvertToTitleCase(texto)}");
            Console.WriteLine($"Texto formato titulo: {texto.ToTitle()}"); // Esto gracias a la clase StringExtensions

            Console.WriteLine($"Caracteres: {texto.Length}");
            Console.WriteLine($"Palabras: {texto.WordCount()}"); // Esto gracias a la clase StringExtensions
        }

        static string ConvertToTitleCase(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            else return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto);
        }
    }
}
