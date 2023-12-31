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
            Console.WriteLine("\tCrear Empleado");
            Console.Write("CC-> ");
            int cc = int.Parse(Console.ReadLine());
            Console.Write("Nombre-> ");
            string nombre = Console.ReadLine();
            Console.Write("Telefono-> ");
            int telefono = int.Parse(Console.ReadLine());
            Console.Write("Especialidad-> ");
            string especialidad = Console.ReadLine();
            Empleados empleados= new(cc, nombre, telefono, especialidad);
            lista.Add(empleados);
        }catch(Exception){
            Console.WriteLine("Has Ingresado un dato invalido");
            Console.Write("Presiona enter para continuar -> ");
            Console.ReadLine();
        }
        }
        public void Mostrar(List<Empleados> lista)
        {
        Console.WriteLine("\tNombre\tApellido\tTelefono\tEspecialidad\tFecha");
        foreach(Empleados empleado in lista){
            Console.WriteLine($"{empleado.cc}\t{empleado.nombre}\t{empleado.telefono}\t{empleado.especialidad}");
        }
    }
        public Empleados BuscarEmpleado(List<Empleados> lista, int id){
            try{
                Empleados encontrado = lista.Find(e => e.cc == id);
                return encontrado;
            }catch(ArgumentNullException err){
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }

