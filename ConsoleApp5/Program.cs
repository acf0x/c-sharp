namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Herencia();
            Herencia2();
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

            if(animal.GetType() == typeof(Reptil))
            {
                ((Reptil)animal).MetodoC(); // conversión de animal a Reptil y entonces invocar MetodoC
            }
        }
    
    }
}
