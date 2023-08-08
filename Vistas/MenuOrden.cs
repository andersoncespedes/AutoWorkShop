using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Vistas;
public class MenuOrden
{
    public int Menu()
    {
        Console.WriteLine("\tMenu");
        Console.WriteLine("1. Orden de Servicio");
        Console.WriteLine("2. Orden de Aprobacion");
        Console.WriteLine("3. Facturacion");
        Console.WriteLine("4. Salir");
        Console.Write("Digite Una Opcion -> ");
        return int.Parse(Console.ReadLine());
    }
}
