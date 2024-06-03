using Newtonsoft.Json;
using System.Dynamic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace ConsoleAppHTTP
{
    internal class Program
    {
        private static HttpClient http = new HttpClient();          // cada vez que se instancia, bloquea un puerto para él

        static void Main(string[] args)
        {
            // Opcionalmente especificamos la dirección base para las URLs de consulta

            http.BaseAddress = new Uri("https://postman-echo.com/");

            // Headers opcionales del objeto HttpClient
            // Se envían en todas las peticiones lanzadas con este objeto
            // Son útiles para especificar token o claves (APIKey) de acceso

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("User-Agent", "HttpCliente .NET Core Demo");
            http.DefaultRequestHeaders.Add("X-Data-1", "Demo");
            http.DefaultRequestHeaders.Add("X-Data-2", "1234567890");
            //http.DefaultRequestHeaders.Add("Accept", "application/json");
            //http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            Get();
            Get2();
        }

        /// <summary>
        /// Si solo hay que invocar a la url y obtener resultado:
        /// </summary>
        static void Get()
        {
            // get
            HttpResponseMessage response = http.GetAsync("get?param1=hola").Result;    //sería lo mismo que http.GetAsync("https://postman-echo.com/get?param1=hola").Result, si no hubiesemos añadido BaseAdress
            
            // Opción 1, preguntamos por un código de estado concreto (ok = 200, notfound = 404...)
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Lectura del cuerpo del mensaje de respuesta como STRING
                // El texto obtenido normalmente estará en JSON
                string responseBodyText = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("");
                Console.WriteLine("Body:");
                Console.WriteLine("==============================================");
                Console.WriteLine($"{responseBodyText}");
                
                // Convertir el JSON en Objeto
                // Utilizamos DYNAMIC cuando no tenemos una clase que represente el objeto retornado
                var obj = JsonConvert.DeserializeObject<dynamic>(responseBodyText);  //<-- en los < > se pone el tipo de obj (string) o la CLASE (Customer / dynamic...)

                Console.WriteLine("");
                Console.WriteLine("Datos del Body:");
                Console.WriteLine("==============================================");
                Console.WriteLine($"URL: {obj["url"]}");
                Console.WriteLine($"Param 1: {obj["args"]["param1"]}");
                Console.WriteLine($"Data 1: {obj["headers"]["x-data-1"]}");

                Console.WriteLine($"URL: {obj.url}");
                Console.WriteLine($"Param 1: {obj.args.param1}");
                // Console.WriteLine($"Data 1: {obj.headers.x-data-1}"); <-- no es posible al llevar -

                Console.WriteLine("");
                Console.WriteLine("Headers:");
                Console.WriteLine("==============================================");


                // También tenemos acceso a las cabeceras del mensaje de respuesta
                foreach(var header in response.Headers)
                {
                    Console.WriteLine($"{header.Key}: {header.Value.FirstOrDefault()}");
                }

                Console.WriteLine($"Date: {response.Headers.GetValues("Date").FirstOrDefault()}");

                IEnumerable<string> valor;
                response.Headers.TryGetValues("Content-Type", out valor);
                Console.WriteLine($"Content-Type: {(valor == null ? "" : valor.FirstOrDefault())}");

                var responseHeaders = response.Headers;
            }
            else Console.WriteLine($"Error: {response.StatusCode}");

            // Opción 2, preguntamos si finaliza con cualquier código 2XX

            if (response.IsSuccessStatusCode) 
            {
                // aquí iría el mismo código que la opción 1
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        /// <summary>
        /// Este si hay que añadir contenido o cabeceras específicas:
        /// </summary>
        static void Get2()
        {
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "get?param1=hola");

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("https://postman-echo.com/get?param1=hola"); // por alguna razón, aquí no vale poner get, tiene que ser entera´, arriba sí deja


            // Opcionalmente definimos cabeceras del mensaje
            // Las cabeceras se anexan a las cabeceras por defecto del objeto HttpClient
            request.Headers.Add("X-Data-3", "ABC");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Opcionalmente definimos el cuerpo del mensaje

            //Opción 1
            //request.Content = new StringContent(JsonConvert.SerializeObject(obj2), Encoding.UTF8, "application/json");

            // Opción 2
            var obj2 = new { Nombre = "Borja", Apellido1 = "Cabeza", Apellido2 = "Rozas" };
            string obj2JSON = JsonConvert.SerializeObject(obj2);
            StringContent contenido = new StringContent(obj2JSON, Encoding.UTF8, "application/json");

            request.Content = contenido;

            // Enviamos la petición y obtenemos la respuesta

            HttpResponseMessage response = http.SendAsync(request).Result;
        }

        /// <summary>
        /// Muy simple, del msj de respuesta solo quiero el contenido(Body) del resultado, ni siquiera las headers
        /// </summary>
        //static void Get3()
        //{
        //    try
        //    {
        //        var obj3 = http.GetFromJsonAsync<ExpandoObject>("get?param1=hola").Result;
        //        //if(obj3 != null) 
        //        //{
        //        //    Console.WriteLine("");
        //        //    Console.WriteLine("Datos del Body:");
        //        //    Console.WriteLine("==============================================");
        //        //    Console.WriteLine($"URL: {obj3["url"]}");
        //        //    Console.WriteLine($"Param 1: {obj3["args"]["param1"]}");
        //        //    Console.WriteLine($"Data 1: {obj3["headers"]["x-data-1"]}");

        //        //    Console.WriteLine($"URL: {obj3.url}");
        //        //    Console.WriteLine($"Param 1: {obj3.args.param1}");
        //        }
        //        else 
        //        {
        //            Console.WriteLine($"No se puede acceder a la información"); 
        //        }
        //    }
        //    catch (Exception e) 
        //    {
        //        Console.WriteLine($"Error: {e.Message}");
        //    }
        //}

    }
}
