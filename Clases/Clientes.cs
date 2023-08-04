namespace ReparacionAutomotriz.Clases;
using System;
using System.Text.RegularExpressions;
public class Clientes : Persona
{
    // Declaracion de Atributos Privados
    
    private string Apellido;
    private string Email;
    private DateTime FechaRegistro;
    
    //Control de Atributos
    
    public string? apellido 
    { 
        get{
            return this.Apellido;
        } 
        set{
            if(value.Length > 1 && !Regex.IsMatch(value, @"[0-9]+",  RegexOptions.IgnoreCase)){
                this.Apellido = value;
            }else{
                  throw new ArgumentOutOfRangeException(value, "/* etc... */");
            }

        }
    }
    public string? email 
    { 
        get{
            return this.Email;
        } 
        set{
            if(Regex.IsMatch(value, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$",RegexOptions.IgnoreCase) == true){
                this.Email = value;
            }else{
                  throw new ArgumentOutOfRangeException(value, "/* etc... */");
            }
        } 
    }
    //Constructores
    public DateTime fechaRegistro {get => FechaRegistro;set => FechaRegistro = value; }
    public Clientes(int cc, string nombre, int telefono, string apellido, string email, DateTime fechaRegistro ): base(cc, nombre, telefono)
    {
            this.apellido = apellido;
            this.email = email;
            this.fechaRegistro = fechaRegistro;
    } 
    public Clientes(){

    }
    public void Crear(List<Clientes> lista){
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
            string apellido = Console.ReadLine();
            Console.Write("Email-> ");
            string email = Console.ReadLine();
            DateTime ahora = DateTime.Now;
            Clientes clientes= new Clientes(cc, nombre, telefono, apellido, email, ahora);
            lista.Add(clientes);
        }catch(Exception err){
            Console.WriteLine("Has Ingresado un dato invalido");
            Console.Write("Presiona enter para continuar -> ");
            Console.ReadLine();
        }
    }
    public void Mostrar(List<Clientes> lista){
        Console.WriteLine("\tNombre\tApellido\tTelefono\tEmail\tFecha");
        foreach(Clientes cliente in lista){
            Console.WriteLine($"\t{cliente.nombre}\t{cliente.apellido}\t{cliente.telefono}\t{cliente.email}\t{cliente.fechaRegistro}");
        }
    }
     public bool Validar(List<Clientes> lista, int valor){
        return lista.Exists(e => e.cc == valor);
    }
}