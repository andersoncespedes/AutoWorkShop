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
    public OrdenDeServicio(int idCliente, string NroPlaca, string DiagnosticoCliente, string DiagnosticoExperto, List<int> IdEmpleado, int IdEncargado, int NrOrden){
        this.IdCliente = idCliente;
        this.NroPlaca = NroPlaca;
        this.DiagnosticoCliente = DiagnosticoCliente;
        this.DiagnosticoExperto = DiagnosticoExperto;
        this.IdEmpleado = IdEmpleado;
        this.IdEncargado = IdEncargado;
        this.NrOrden = NrOrden;
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
            Vehiculos vehiculoSeleccionado = vehiculos.GetCarroByPlaca(placa, vehiculosSeleccionados) ?? throw new Exception("error, no se ha encontrado el vehiculo");
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
                Flag = Console.ReadLine().ToLower() == "s";
            }
            empleados.Mostrar(empleadosSeleccionados.ToList());
            Console.Write("Digite la cedula del Empleado que sera el encargado -> ");
            int LiderId = int.Parse(Console.ReadLine());
            string diagnosticoE = diagnosticoExperto();
            int nmrOrden = GenerarId(listaOrden);
            OrdenDeServicio nuevaOrden = new(idCliente, placa, diagnosticoC, diagnosticoE, idsEmpleados, LiderId, nmrOrden);
            listaOrden.Add(nuevaOrden);
            GenerarVistaOrden(nuevaOrden, listaCliente, listaVehiculos, listaEmpleados);
        }catch(Exception err){
            Console.WriteLine(err.Message);
        }
    }
    public int GenerarId(List<OrdenDeServicio> listaOrden){
        try{
            int longitud = listaOrden.ToArray().Length;
            return listaOrden[longitud - 1].NrOrden + 1;
        }catch(Exception){
            return 0;
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
    public void Mostrar(List<OrdenDeServicio> lista){
        Console.WriteLine("Nro De Orden\t id del Encargado\tPlaca");
        foreach(OrdenDeServicio Orden in lista){
            Console.WriteLine($"{Orden.NrOrden}\t{Orden.IdEncargado}\t{Orden.NroPlaca}");
        }
    }
    public void GenerarVistaOrden(OrdenDeServicio orden, List<Clientes> listaCliente, List<Vehiculos> vehiculos, List<Empleados> empleados){
        Clientes clientes = new();
        Vehiculos vehiculo= new ();
        Empleados empleado = new();
        Clientes clientesEncontrado = clientes.Encontrar(orden, listaCliente);
        Vehiculos vehiculoEncontrado= vehiculo.GetCarroByPlaca(orden.NroPlaca, vehiculos);
        Empleados Encargado = empleado.BuscarEmpleado(empleados, orden.IdEncargado);
        DateTime fecha = DateTime.Now;
        Console.WriteLine(clientesEncontrado.email);
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("|            DATOS DE LA ORDEN             |");
        Console.WriteLine("============================================");
        Console.WriteLine($"|Nro Orden: 1          Fecha:{fecha}      |");
        Console.WriteLine($"|Id Cliente:{orden.IdCliente} Nombre Cliente:{clientesEncontrado.nombre} |");
        Console.WriteLine("============================================");
        Console.WriteLine("|            DATOS DEL VEHICULO            |");
        Console.WriteLine("============================================");
        Console.WriteLine($"|Nro Placa: {vehiculoEncontrado.placa}    Km:{vehiculoEncontrado.km}           |");
        Console.WriteLine("============================================");
        Console.WriteLine("|          DIAGNOSTICO DEL CLIENTE          |");
        Console.WriteLine("============================================");
        Console.WriteLine($"|{orden.DiagnosticoCliente}    |");
        Console.WriteLine("============================================");
        Console.WriteLine("|              PERSONAL A CARGO            |");
        Console.WriteLine("============================================");
        foreach(int IdEmpleado in orden.IdEmpleado){
            Empleados empleadosEncontrados = empleado.BuscarEmpleado(empleados, IdEmpleado);
            Console.WriteLine($"|Nro CC: {empleadosEncontrados.cc}         Nombre:{empleadosEncontrados.nombre}           |");
            Console.WriteLine($"|Especialidad:{empleadosEncontrados.especialidad}                           |");
            Console.WriteLine("============================================");
        }
        Console.WriteLine("============================================");
        Console.WriteLine("|          DIAGNOSTICO DEL EXPERTO          |");
        Console.WriteLine("============================================");
        Console.WriteLine($"|Nro CC: {Encargado.cc}         Nombre:{Encargado.nombre}           |");
        Console.WriteLine("|Diagnostico Experto:            |");
        Console.WriteLine($"| {orden.DiagnosticoExperto}");
        Console.WriteLine("============================================");
        Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
        Console.ReadLine();
    }
    public OrdenDeServicio Encontrar(List<OrdenDeServicio> lista, int Nro){
        try{    
            OrdenDeServicio encontrado = lista.Find(e => e.NrOrden == Nro);
            return encontrado;
        }catch(Exception){
            Console.WriteLine("NO SE PUDO ENCONTRAR LA ORDEN DE SERVICIO");
            Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
            Console.ReadLine();
            return null;
        }
    }
}
