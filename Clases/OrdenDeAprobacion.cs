using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;
    public class Aprobacion {
        public string Item {get; set;}
        public string Repuesto {get; set;}
        public int VUnit {get; set;}
        public int Cant {get; set;}
        public int Total {get; set;}
        public char Estado {get; set;}
        public Aprobacion(string item, string repuesto, int vUnit, int Cant, int Total, char Estado) {
        
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
            OrdenDeAprobacion ordenDeAprobacion = new(0, DateTime.Now, idEmpleado,NroOrden, aprobados);
            ordenDeAprobaciones.Add(ordenDeAprobacion);
            Console.Write("PRESIONE ENTER PARA CONTINUAR -> ");
            Console.ReadLine();
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
            }
            return aprobaciones;
        }catch(Exception){
            return null;
        }
    }
    }
