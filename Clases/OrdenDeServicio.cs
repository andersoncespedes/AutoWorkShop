using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;
public class OrdenDeServicio
{
    public int IdCliente {get => IdCliente; set => IdCliente = value; }
    public int NrOrden {get => NrOrden; set => NrOrden = value; }
    public int NroPlaca {get => NroPlaca; set => NroPlaca = value;}
    public string DiagnosticoCliente {get => DiagnosticoCliente; set => DiagnosticoCliente = value;}
    public int[] IdEmpleado  {get => IdEmpleado; set => IdEmpleado = value;}
    public int IdEncargado {get => IdEncargado; set => IdEncargado = value;} 
    public void GenerarOrden(List<Clientes> listaCliente, List<Vehiculos> listaVehiculos, List<Empleados> listaEmpleados)
    {
        Clientes clientes = new();
        Vehiculos vehiculos = new();
        clientes.Mostrar(listaCliente);
        Console.Write("Digite la Cedula del Cliente");
        int id = int.Parse(Console.ReadLine());
        vehiculos.CarrosById(id,listaVehiculos);
        Console.ReadLine();
    }
}
