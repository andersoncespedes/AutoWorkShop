using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;

public class Vehiculos
{
    private string? Placa;
    private string? Modelo;
    private string? Marca;
    private string? Color;
    private string? Km;
    private int IdCliente;
    public int idCliente {get => IdCliente; set => this.IdCliente = value;}
    public string placa {
        get => Placa;
        set
        {
            if(value.Length > 4){
                Placa = value;
            }
        }
    }
    public string modelo {
        get => Modelo;
        set
        {
            if(value.Length > 2){
                Modelo = value;
            }
        }
    }
    public string marca 
    {
        get => Marca;
        set
        {
            if(value.Length > 2){
                Marca = value;
            }
        }
    }
    public string color{
        get => Color;
        set
        {
            if(value.Length >2){
                Color = value;
            }
        }
    }
    public string km{
        get => Km;
        set => Km = value;
    }
    public Vehiculos(){

    }
    public Vehiculos(string placa, string modelo, string marca, string color, string km){
        this.placa = placa;
        this.modelo = modelo;
        this.marca = marca;
        this.color = color;
        this.km = km;
    }
    public void Crear(List<Vehiculos> listaVehiculo, List<Clientes> listaCliente)
    {
        try{
            Clientes clientes1 = new();
            Console.Clear();
            Console.WriteLine("\tGuardar Vehiculo");
            Console.Write("Placa-> ");
            string placa = Console.ReadLine();
            Console.Write("Modelo-> ");
            string modelo = Console.ReadLine();
            Console.Write("Marca-> ");
            string marca = Console.ReadLine();
            Console.Write("Color-> ");
            string color = Console.ReadLine();
            Console.Write("Kilometraje-> ");
            string km = Console.ReadLine();
            Console.Clear();
            clientes1.Mostrar(listaCliente);
            Console.Write("Cedula del cliente-> ");
            int cedula = int.Parse( Console.ReadLine());
            if(!clientes1.Validar(listaCliente, cedula)) throw new Exception("Error, no se ha encontrado la cedula en la base de datos");
            Vehiculos clientes= new(placa, modelo, marca, color, km);
            listaVehiculo.Add(clientes);
        }catch(Exception err){
            Console.WriteLine("Has Ingresado un dato invalido");
            Console.WriteLine(err.Message);
            Console.Write("Presiona enter para continuar -> ");
            Console.ReadLine();
        }
    }
}
