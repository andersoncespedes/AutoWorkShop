using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ReparacionAutomotriz.Clases;
using ReparacionAutomotriz.Vistas;

public class Programa{

        static List<T> Serializar<T>(string path){
            try{
                using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                List<T> objeto = JsonConvert.DeserializeObject<List<T>>(json);
                return objeto;
            }
            }catch(Exception){
                return null;
            }
            
        }
        static  List<Clientes> clientesLista = Serializar<Clientes>(@"Json/Clientes.json") ?? new();
        static  List<Vehiculos> vehiculosLista = Serializar<Vehiculos>(@"Json/Vehiculos.json") ?? new();
        static  List<Empleados> empleadosLista = Serializar<Empleados>(@"Json/Empleados.json") ?? new();
        static  List<OrdenDeServicio> OrdenesLista = Serializar<OrdenDeServicio>(@"Json/OrdenDeServicio.json") ?? new();
        static  List<OrdenDeAprobacion> OrdenesDeAprobacionLista = Serializar<OrdenDeAprobacion>(@"Json/OrdenDeAprobacion.json") ?? new();
        static  List<Facturas> facturasLista = new();
    static void ActualizarJson(string path, string lista){
        string json;
        switch (lista){
            case "clientes":
                json = JsonConvert.SerializeObject(clientesLista); 
                File.WriteAllText(path, json);
                break;
            case "vehiculos":
                json = JsonConvert.SerializeObject(vehiculosLista); 
                File.WriteAllText(path, json);
                break;
            case "empleados":
                json = JsonConvert.SerializeObject(empleadosLista); 
                File.WriteAllText(path, json);
                break;
            case "ordenDeServicio":
                json = JsonConvert.SerializeObject(OrdenesLista); 
                File.WriteAllText(path, json);
                break;
            case "ordenDeAprobacion":
                json = JsonConvert.SerializeObject(OrdenesDeAprobacionLista); 
                File.WriteAllText(path, json);
                break;
        }
    }
    public static void Main(string[] args){
        int opcion = 0;
        MainMenu mainMenu = new();
        do{
            opcion = mainMenu.menu();
            switch(opcion){
                case 1:
                    int opcionRegistro = 0; 
                    MenuRegistro menuRegistro = new();
                    do{
                        opcionRegistro = menuRegistro.MenuCrear();
                        foreach(Clientes clientes1 in clientesLista){
                            Console.WriteLine(clientes1.fechaRegistro);
                        }
                        Console.ReadLine();
                        switch(opcionRegistro){
                            case 1:
                                Clientes clientes = new();
                                clientes.Crear(clientesLista);
                                ActualizarJson(@"Json/Clientes.json", "clientes");
                                break;
                            case 2:
                                Vehiculos vehiculos = new();
                                vehiculos.Crear(vehiculosLista, clientesLista);
                                ActualizarJson(@"Json/Vehiculos.json", "vehiculos");
                                break;
                            case 3:
                                Empleados empleados = new();
                                empleados.Crear(empleadosLista);
                                ActualizarJson(@"Json/Empleados.json", "empleados");
                                break;
                        }
                    }while(opcionRegistro != 4);
                break;
                case 2:
                    int opcionOrden = 0;
                    MenuOrden menuOrden = new();
                    do{
                        Console.Clear();
                        opcionOrden = menuOrden.Menu();
                        switch(opcionOrden){
                            case 1:
                                OrdenDeServicio ordenDeServicio = new();
                                ordenDeServicio.GenerarOrden(clientesLista, vehiculosLista, empleadosLista, OrdenesLista);
                                ActualizarJson(@"Json/OrdenDeServicio.json", "ordenDeServicio");
                                break;
                            case 2:
                                OrdenDeAprobacion ordenDeAprobacion = new();
                                ordenDeAprobacion.GenerarOrden(OrdenesLista, empleadosLista, OrdenesDeAprobacionLista);
                                ActualizarJson(@"Json/OrdenDeAprobacion.json", "ordenDeAprobacion");
                                break;
                        }
                    }while(opcionOrden != 4);
                    break;
            }
        }while(opcion!= 4);
    }
}