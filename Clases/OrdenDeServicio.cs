using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;
public class OrdenDeServicio
{
    public int IdCliente {get; set; }
    public int NrOrden {get; set; }
    public string NroPlaca {get; set;}
    public string DiagnosticoCliente {get; set;}
    public string DiagnosticoExperto {get; set;}

    public List<int> IdEmpleado  {get; set;}
    public int IdEncargado {get; set;} 
    public OrdenDeServicio(int idCliente, string NroPlaca, string DiagnosticoCliente, string DiagnosticoExperto, List<int> IdEmpleado, int IdEncargado){
        this.IdCliente = idCliente;
        this.NroPlaca = NroPlaca;
        this.DiagnosticoCliente = DiagnosticoCliente;
        this.DiagnosticoExperto = DiagnosticoExperto;
        this.IdEmpleado = IdEmpleado;
        this.IdEncargado = IdEncargado;
    }
    public OrdenDeServicio(){

    }
    public void GenerarOrden(List<Clientes> listaCliente, List<Vehiculos> listaVehiculos, List<Empleados> listaEmpleados, List<OrdenDeServicio> listaOrden)
    {
        try
        {
            Console.Clear();
            Clientes clientes = new();
            Vehiculos vehiculos = new();
            Empleados empleados = new();
            HashSet<Empleados> empleadosSeleccionados = new();
            List<int> idsEmpleados = new();
            clientes.Mostrar(listaCliente);
            Console.Write("Digite la Cedula del Cliente -> ");
            int idCliente = int.Parse(Console.ReadLine());
            List<Vehiculos> vehiculosSeleccionados = vehiculos.CarrosByIdCliente(idCliente,listaVehiculos);
            Console.WriteLine("Digite la placa del Vehiculo Seleccionado -> ");
            string placa = Console.ReadLine();
            Vehiculos vehiculoSeleccionado = vehiculos.GetCarroByPlaca(placa, vehiculosSeleccionados);
            if(vehiculoSeleccionado == null) throw new Exception("error, no se ha encontrado el vehiculo");
            string diagnosticoC = diagnosticoCliente();
            empleados.Mostrar(listaEmpleados);
            bool Flag = true;
            while(Flag){
                Console.Write("Digite la Cedula del Empleado -> ");
                int EmpleadoId = int.Parse(Console.ReadLine());
                Empleados empleadoSeleccionado = empleados.BuscarEmpleado(listaEmpleados, EmpleadoId);
                empleadosSeleccionados.Add(empleadoSeleccionado);
                idsEmpleados.Add(EmpleadoId);
                Console.Write("Desea Continuar (S/N) -> ");
                Flag = Console.ReadLine().ToLower() == "s" ? true : false;
            }
            empleados.Mostrar(empleadosSeleccionados.ToList());
            Console.Write("Digite la cedula del Empleado que sera el encargado -> ");
            int LiderId = int.Parse(Console.ReadLine());
            string diagnosticoE = diagnosticoExperto();

            OrdenDeServicio nuevaOrden = new(idCliente, placa, diagnosticoC, diagnosticoE, idsEmpleados, LiderId);
            listaOrden.Add(nuevaOrden);
            GenerarVistaOrden(nuevaOrden);
        }catch(Exception err){
            Console.WriteLine(err.Message);
        }
    }
    public string diagnosticoCliente(){
        Console.WriteLine("Digite el diagnostico del cliente:");
        Console.Write("-> ");
        return Console.ReadLine();
    }
    public string diagnosticoExperto(){
        Console.WriteLine("Digite el diagnostico del experto:");
        Console.Write("-> ");
        return Console.ReadLine();
    }
    public void GenerarVistaOrden(OrdenDeServicio orden){
        Console.WriteLine("============================================");
        Console.WriteLine("\tDATOS DE LA ORDEN");
        Console.WriteLine("=============================================");
        Console.WriteLine("Nro Orden: 1          Fecha: ");
        Console.WriteLine("Id Cliente: 1         Nombre Cliente: ");

    }
}
