using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Vistas;

    public class MenuRegistro
    {
        public int MenuCrear(){
            Console.Clear();
            Console.WriteLine("1.Registro de Cliente");
            Console.WriteLine("2.Registro de Vehiculo");
            Console.WriteLine("3.Registro de Empleados");
            Console.WriteLine("4.Salir");
            Console.Write("Digite una opcion -> ");
            return int.Parse(Console.ReadLine());
        }
    }
