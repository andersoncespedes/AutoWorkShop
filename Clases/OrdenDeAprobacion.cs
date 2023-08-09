using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;
    public class Aprobacion {
        public string Item {get; set;}
        public string Repuesto {get; set;}
        public double VUnit {get; set;}
        public int Cant {get; set;}
        public int Total {get; set;}
        public char Estado {get; set;}
        public Aprobacion(string item, string repuesto, int vUnit, int Cant, int Total, char Estado) {
            this.Item = item;
            this.Repuesto = repuesto;
            this.VUnit = vUnit;
            this.Cant = Cant;
            this.Total = Total;
            this.Estado = Estado;
        }
    }
    public class OrdenDeAprobacion
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
        public int NroOrdenServicio { get; set; }
        public List<Aprobacion> Aprobaciones {get; set;}
        public OrdenDeAprobacion(){

        }
        public OrdenDeAprobacion(int NroOrden, DateTime fecha, int IdEmpleado, int NroOrdenServicio, List<Aprobacion> aprobaciones){
            this.NroOrden=NroOrden;
            this.Fecha=fecha;
            this.IdEmpleado=IdEmpleado;
            this.NroOrdenServicio= NroOrdenServicio;
            this.Aprobaciones=aprobaciones;
        }
        public void GenerarOrden(List<OrdenDeServicio> ordenDeServicios, List<Empleados> empleados, List<OrdenDeAprobacion> ordenDeAprobaciones)
    {
        try
        {
            OrdenDeServicio ordenDeServicio = new();
            Empleados empleado = new();

            ordenDeServicio.Mostrar(ordenDeServicios);
            Console.Write("Digite el Numero de Orden -> ");

            int NumeroOrden = int.Parse(Console.ReadLine());
            OrdenDeServicio ordenDeServicioSeleccionada = ordenDeServicio.Encontrar(ordenDeServicios, NumeroOrden) ?? throw new Exception("No se Encontro la orden de servicio");
           
            empleado.Mostrar(empleados);
            Console.Write("Digite la cedula del empleado -> ");
            
            int idEmpleado = int.Parse(Console.ReadLine());
            Empleados empleados1 = empleado.BuscarEmpleado(empleados, idEmpleado) ?? throw new Exception("No se encontro el empleado");
            
            List<Aprobacion> aprobados = GuardarAprobaciones() ?? throw new Exception("Hubo un error al registrar");
            int id = GenerarId(ordenDeAprobaciones);
            OrdenDeAprobacion ordenDeAprobacion = new(id, DateTime.Now, idEmpleado,NroOrden, aprobados);
            ordenDeAprobaciones.Add(ordenDeAprobacion);
            GenerarVista(ordenDeAprobacion, aprobados);
        }catch(Exception err){
            Console.WriteLine(err.Message);
            Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
            Console.ReadLine();
        }
    }
    public List<Aprobacion> GuardarAprobaciones(){
        try{
            List<Aprobacion> aprobaciones = new();
            bool flag =true;
            while(flag){
                Console.Write("Ingrese el item -> ");
                string item = Console.ReadLine();
                Console.Write("Ingrese el Repuesto -> ");
                string repuesto = Console.ReadLine();
                Console.Write("Ingrese el Valor Unitario -> ");
                int VUnit = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la Cantidad -> ");
                int cantidad = int.Parse(Console.ReadLine());
                int total = VUnit * cantidad;
                Console.Write("Ingrese el Estado (Aprobado(A) | Rechazado(R) -> ");
                char estado = Console.ReadLine() == "A" ? 'A' : 'R';
                Aprobacion aprobacion = new(item, repuesto,VUnit, cantidad,total, estado);
                aprobaciones.Add(aprobacion);
                Console.Write("DESEA SEGUIR AGREGANDO ITEMS (S/N) -> ");
                flag = Console.ReadLine() == "S";
            }
            return aprobaciones;
        }catch(Exception){
            return null;
        }
    }
     public int GenerarId(List<OrdenDeAprobacion> listaOrden){
        try{
            int longitud = listaOrden.ToArray().Length;
            return listaOrden[longitud - 1].NroOrden + 1;
        }catch(Exception){
            return 0;
        }
    }
    public void GenerarVista(OrdenDeAprobacion orden, List<Aprobacion> lista){
        try{
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine($"|Nro Orden: {orden.NroOrden}");
            Console.WriteLine($"|Fecha: {orden.Fecha}");
            Console.WriteLine($"|Id Empleado: {orden.IdEmpleado}");
            Console.WriteLine("==============================================");
            Console.WriteLine("           DETALLES DE LA APROBACION          ");
            Console.WriteLine("==============================================");
            Console.WriteLine("ITEM   REPUESTO  UNIT   CANT   V TOTAL  ESTADO");
            Console.WriteLine("==============================================");
            foreach(Aprobacion a in lista){
                Console.WriteLine($"{a.Item}  {a.Repuesto}  {a.VUnit}  {a.Cant}  {a.Total}  {a.Estado}");
            }
            Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
            Console.ReadLine();
        }catch(Exception){
            Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
            Console.ReadLine();
        }
    }
    }
