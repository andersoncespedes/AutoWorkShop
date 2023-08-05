using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;

    public class Empleados : Persona
    {
        private string Especialidad;
        public string especialidad 
        {
            get => Especialidad;
            set => Especialidad = value;
        }
        public Empleados()
        {
        }
        public Empleados(int cc, string nombre, int telefono, string especialidad ): base(cc, nombre, telefono){
            this.especialidad = especialidad;
        } 
        public void Crear(List<Empleados> lista){
            try{
            Console.Clear();
            Console.WriteLine("\tCrear Cliente");
            Console.Write("CC-> ");
            int cc = int.Parse(Console.ReadLine());
            Console.Write("Nombre-> ");
            string nombre = Console.ReadLine();
            Console.Write("Telefono-> ");
            int telefono = int.Parse(Console.ReadLine());
            Console.Write("Apellido-> ");
            string especialidad = Console.ReadLine();
            Console.Write("Email-> ");
            Empleados empleados= new(cc, nombre, telefono, especialidad);
            lista.Add(empleados);
        }catch(Exception err){
            Console.WriteLine("Has Ingresado un dato invalido");
            Console.Write("Presiona enter para continuar -> ");
            Console.ReadLine();
        }
        }
        public void Mostrar(List<Empleados> lista){
        Console.WriteLine("\tNombre\tApellido\tTelefono\tEspecialidad\tFecha");
        foreach(Empleados empleado in lista){
            Console.WriteLine($"{empleado.cc}\t{empleado.nombre}\t{empleado.telefono}\t{empleado.especialidad}");
        }
    }
    }

