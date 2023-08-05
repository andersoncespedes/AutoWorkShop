using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ReparacionAutomotriz.Clases;
public abstract class Persona
{
    private int Cc ;
    private string Nombre;
    private int Telefono;
    public int cc { 
        get{
            return this.Cc;
        }
        set{
            if(value.ToString().Length > 5){
                this.Cc = value;
            }else{
                  throw new ArgumentOutOfRangeException("asd");
            }
        } 
     }
    public string nombre { 
        get{
            return this.Nombre;
        } set{
            string rx = "[0-9]+";
            if(value.Length > 1 && !Regex.IsMatch(value, rx,  RegexOptions.IgnoreCase)){
                this.Nombre = value;
            }else{
                  throw new ArgumentOutOfRangeException(value, "/* etc... */");
            }
        } 
    }
     public int telefono { 
        get{
            return this.Telefono;
        } set{
            if(value.ToString().Length > 5 ){
                this.Telefono = value;
            }else{
                  throw new ArgumentOutOfRangeException("value");
            }
        } 
    }
    public Persona(int cc, string nombre, int telefono){
        this.cc = cc;
        this.nombre = nombre;
        this.telefono=telefono;
    }
    public Persona(){

    }
}
