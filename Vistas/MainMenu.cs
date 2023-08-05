using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Vistas;

public class MainMenu
{
    public int menu(){
        Console.Clear();
        Console.WriteLine("\tMenu");
        Console.WriteLine("1.Registro panel");
        Console.WriteLine("2.Servicios");
        Console.WriteLine("3.Salir");
        Console.Write("Digite una opcion -> ");
        return int.Parse(Console.ReadLine());
    }
}
