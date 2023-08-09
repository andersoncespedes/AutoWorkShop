using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ReparacionAutomotriz.Clases;

public class Facturas
{
    public int NroOrdenServicio {get; set;}
    public int NroFactura {get; set;}
    public int idCliente {get; set;}
    public double SubTotal {get; set;}
    public const double Iva = 0.10;
    public double ManoObra {get; set;}
    public int Total    {get; set;}
    
    public Facturas(){

    }

}
