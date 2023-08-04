using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReparacionAutomotriz.Clases;

    public class Empleados : Persona
    {
        private string Especialidad;
        public string especialidad 
        {
            get => Especialidad;
            set => Especialidad = value;
        }
        public Empleados()
        {
        }
        public Empleados(int cc, string nombre, int telefono, string especialidad ): base(cc, nombre, telefono){
            this.especialidad = especialidad;
        } 
    }

