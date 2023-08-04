using ReparacionAutomotriz.Clases;
using ReparacionAutomotriz.Vistas;
public class Programa{
    public static void Main(string[] args){
        List<Clientes> clientesLista = new();
        List<Vehiculos> vehiculosLista = new();
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
                                break;
                            case 2:
                                Vehiculos vehiculos = new();
                                vehiculos.Crear(vehiculosLista, clientesLista);
                                break;
                        }
                    }while(opcionRegistro != 4);
                break;
            }
        }while(opcion!= 4);
    }
}