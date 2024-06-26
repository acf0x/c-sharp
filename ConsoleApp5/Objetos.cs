﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// Creamos una clase que hereda de LIST y añadimos funcionalidad extra
    /// Los objetos de ListExtend tienen la misma funcionalidad que los objetos creados a partir de LIST y además la funcionalidad extra que incorporamos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListExtend<T> : List<T>
    {
        public void OutputAll()
        {
            foreach (var item in this) Console.WriteLine($"{item.ToString()}");
        }

        public override string ToString()
        {
            return $"Colección con {this.Count} elementos.";
        }
    }

    public abstract class Animal
    {
        /// <summary>
        /// Propiedad que se hereda por las clases derivadas o hijas
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Propiedad abstracta que necesita obligatoriamente ser implementada en clases derivadas o hijas
        /// </summary>
        public abstract string Especie { get; set; }

        /// <summary>
        /// Método que se hereda por las clases derivadas o hijas
        /// </summary>
        public void MetodoA() => Console.WriteLine("Método A, clase Animal");

        /// <summary>
        /// Método abstracto que necesita obligatoriamente ser implementado en clases derivadas o hijas
        /// </summary>
        public abstract void MetodoB();
    }

    public class Anfibio : Animal
    {
        protected string especie = "Anfibio";
        public override string Especie { get => especie; set => especie = value; }
        //public override string Especie
        //{
        //    get { return especie; }
        //    set { especie = value; }
        //}

        public override void MetodoB()
        {
            Console.WriteLine("Método B, clase Anfibio");
        }
    }

    public class Reptil : Animal
    {
        protected string especie = "Reptil";
        public override string Especie { get => especie; set => especie = value; }
        //public override string Especie
        //{
        //    get { return especie; }
        //    set { especie = value; }
        //}

        public override void MetodoB() => Console.WriteLine("Método B, clase Reptil");
        public void MetodoC() => Console.WriteLine("Método C, clase Reptil");
    }

    public interface IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public void Iniciar();
        public void Parar();
    }

    public class Coche : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public void Iniciar() => Console.WriteLine("Coche, Iniciar");
        public void Parar() => Console.WriteLine("Coche, Parar");
        void IVehiculo.Iniciar() => Console.WriteLine("Coche como Vehículo, Iniciar"); // esto afectaría al método Test2 en el program
        void IVehiculo.Parar() => Console.WriteLine("Coche como Vehículo, Parar");
    }

    public class Avion : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public int Potencia { get; set; }
        public void Iniciar() => Console.WriteLine($"Avion, Iniciar Potencia {Potencia}");
        void IVehiculo.Iniciar() => Console.WriteLine($"Avion, Iniciar");
        public void Parar() => Console.WriteLine("Avion, Parar");
        public void Despegar() => Console.WriteLine("Avion, Despegar");
    }

    public sealed class Persona
    {
        public string Nombre { set; get; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public void MetodoA() => Console.WriteLine("Método A, clase Persona");
    }

    //No se puede heredar de Persona porque es una clase SEALED (sellada)
    //public class Medico : Persona

    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellidos}";  // <- gracias a esto, el OutputAll no retornará el nombre del objeto, sino Nombre y Apellidos
        }
    }

    public class DemoString
    {
        public string Data { get; set; }
        public void Metodo() => Console.WriteLine($"Texto: {Data}");
        public DemoString() { }
        public DemoString(string data)
        {
            this.Data = data;
        }
    }
    public class DemoInt
    {
        public int Data { get; set; }
        public void Metodo() => Console.WriteLine($"Número: {Data.ToString()}");
        public DemoInt() { }
        public DemoInt(int data)
        {
            this.Data = data;
        }
    }
    public class DemoAlumno
    {
        public Alumno Data { get; set; }
        public void Metodo() => Console.WriteLine($"Alumno: {Data.Nombre} {Data.Apellidos}");
        public DemoAlumno() { }
        public DemoAlumno(Alumno data)
        {
            this.Data = data;
        }
    }

    public class DemoGenerica<T> // Sustituye a todas las DemoX anteriores, para no tener que hacer 1 por cada tipo. Se indica <T> porque puede ser de muchos tipos
    {
        public T Data { get; set; }
        public void Metodo()
        {
            switch(typeof(T).Name)
            {
                case "String":
                    Console.WriteLine($"Texto: {Data}");
                    break;
                case "Int32":
                    Console.WriteLine($"Número: {Data}");
                    break;
                case "ConsoleApp5.Alumno":
                    dynamic temp = this.Data;
                    Console.WriteLine($"Alumno: {temp.Nombre} {temp.Apellidos}");
                    break;
                default:
                    Console.WriteLine($"{typeof(T).Name} {Data}");
                    break;
            }
        }
        public DemoGenerica() { }
        public DemoGenerica(T data)
        { 
            this.Data = data; 
        }
    }

    public static class StringExtensions
    {
        public static string ToTitle( this string str )
        {
            if (string.IsNullOrEmpty(str)) return str;
            else return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public static int WordCount(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            else return str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
