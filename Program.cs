using System;


namespace Pruebas;

class Program
{
    static void Main(string[] args)
    {

        var banco = new Banco();
        // Agregar cuentas y tarjetas
        banco.AgregarCuenta(new Cuenta { Tarj = "9456781", Saldo = 10500, Titular = "Rodrigo de la Cruz Gonzales Montero" });
        banco.AgregarTarjeta(new TarjetaDebito("9456781", "3457", "9456781"));

        banco.AgregarCuenta(new Cuenta { Tarj = "9308954", Saldo = 7400, Titular = "Edson Daniel Chavez Merito" });
        banco.AgregarTarjeta(new TarjetaDebito("9308954", "5432", "9308954"));

        banco.AgregarCuenta(new Cuenta { Tarj = "9877643", Saldo = 11800, Titular = "Jose Ariel Martinez Llanes" });
        banco.AgregarTarjeta(new TarjetaDebito("9877643", "9986", "9877643"));

        banco.AgregarCuenta(new Cuenta { Tarj = "9994564", Saldo = 456000, Titular = "Jose Antonio de Jesus Pool Ku" });
        banco.AgregarTarjeta(new TarjetaDebito("9994564", "1298", "9994564"));
        
            string conf = "";
            bool seguir = true;
        
        do
        {

            Console.WriteLine("ATM STARTBANK");
            Console.WriteLine("Introduce uno de los numeros para realizar una acción:  \n [1]Acceder a tu cuenta bancaria \n [2]Salir.");
            conf = Console.ReadLine();
            switch (conf)
            {
                case "1":
                Console.WriteLine("Ingrese el número de tarjeta:");
                string numTar = Console.ReadLine();
                Console.WriteLine("Ingrese el PIN:");
                string pin = Console.ReadLine();
                banco.ValidarTarjetaYMostrarMenu(numTar, pin);
                break;
                case"2":
                Console.WriteLine("Abandonando el programa...");
                seguir = false;
                break;
                default:
                Console.WriteLine("!!! Introduce uno de los numeros adentro del los corchetes !!!");
                break;
            }
        }while(seguir != false);

    }
}
