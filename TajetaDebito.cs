using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pruebas
{

    public class Banco
    {
        Proce obj = new Proce();
        int b1000, b500, b200, b100, b50;
        int cantidad = 0;
        string tipo = "";
        private decimal contadorRetiros;
        private List<Cuenta> cuentas = new List<Cuenta>();
        private List<TarjetaDebito> tarjetas = new List<TarjetaDebito>();
        private TarjetaDebito tarjetaActual;

        public void RegistrarTransaccion(Cuenta cuenta, decimal monto)
    {
        cuenta.Transacciones.Add(new Transaccion { Monto = monto, Fecha = DateTime.Now });
    }

    public void MostrarTransacciones(Cuenta cuenta, bool ordenAscendente)
    {
        var transacciones = cuenta.Transacciones;

        if (ordenAscendente)
        {
            transacciones = transacciones.OrderBy(t => t.Monto).ToList();
        }
        else
        {
            transacciones = transacciones.OrderByDescending(t => t.Monto).ToList();
        }

        foreach (var transaccion in transacciones)
        {
            Console.WriteLine($"Fecha: {transaccion.Fecha}, Monto: {transaccion.Monto}");
        }
    }
        public void AgregarCuenta(Cuenta cuenta)
        {
            cuentas.Add(cuenta);
        }

        public void AgregarTarjeta(TarjetaDebito tarjeta)
        {
            tarjetas.Add(tarjeta);
        }

            public void ValidarTarjetaYMostrarMenu(string numTar, string pin)
    {
        tarjetaActual = tarjetas.FirstOrDefault(t => t.NumTar == numTar && t.Pin == pin);
        if (tarjetaActual == null || !tarjetaActual.PuedeRealizarOperacion())
        {
            Console.WriteLine("Tarjeta no válida o límite de operaciones alcanzado.");
            return;
        }

        var cuentaAsociada = cuentas.FirstOrDefault(c => c.Tarj == tarjetaActual.Cuenta);
        if (cuentaAsociada == null)
        {
            Console.WriteLine("No se encontró una cuenta asociada a esta tarjeta.");
            return;
        }

        MostrarMenu(cuentaAsociada);
    }

    private void MostrarMenu(Cuenta cuenta)
    {
        do
        {
            Console.WriteLine($"Bienvenido, {cuenta.Titular}");
            Console.WriteLine("1. Retirar Dinero");
            Console.WriteLine("2. Ingresar Dinero");
            Console.WriteLine("3. Cambiar PIN");
            Console.WriteLine("4. Mostrar Saldo");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RetirarDinero(cuenta);
                    tarjetaActual.IncrementarContador();
                    break;
                case "2":
                    IngresarDinero(cuenta);
                    tarjetaActual.IncrementarContador();
                    break;
                case "3":
                    Console.Write("Ingrese el nuevo PIN: ");
                    var nuevoPin = Console.ReadLine();
                    tarjetaActual.CambiarPin(nuevoPin);
                    Console.WriteLine("PIN cambiado exitosamente.");
                    break;
                case "4":
                    Console.WriteLine($"Saldo actual: {cuenta.Saldo}");
                    tarjetaActual.IncrementarContador();
                    break;
                case "5":
                    return;
                case "6":
                Console.WriteLine("Seleccione el orden de las transacciones:");
                Console.WriteLine("1. De menor a mayor monto");
                Console.WriteLine("2. De mayor a menor monto");
                var orden = Console.ReadLine();
                bool ascendente = orden == "1";
                MostrarTransacciones(cuenta, ascendente);
                break;
                default:
                    Console.WriteLine("!!!! Opción no válida. Ingresa uno de los numeros !!!!");
                    break;
            }

            if (!tarjetaActual.PuedeRealizarOperacion())
            {
                Console.WriteLine("Ha alcanzado el límite de operaciones. Sesión finalizada.");
                return;
            }

        } while (true);
    }


        private void RetirarDinero(Cuenta cuenta)
        {
            Console.WriteLine("Selecciona el monto a  retirar: \n [1] 50 \n [2]100 \n [3]200 \n [4] 500 \n [5] 1000 \n [6] Monto especifico");
            tipo = Console.ReadLine();
            switch(tipo)
            {
                case "1":
                cantidad = 50;
                break;
                case "2":
                cantidad = 100;
                break;
                case "3":
                cantidad = 200;
                break;
                case "4":
                cantidad = 500;
                break;
                case "5":
                cantidad = 1000;
                break;
                case "6" :
                cantidad = Convert.ToInt32(Console.ReadLine());
                break;
                default:
                Console.WriteLine("!!! Introduzca uno de los numeros dentro de los corchetes !!!");
                break;
            }
             
            tarjetaActual.ConteoRetiro(cantidad);
            if(tarjetaActual.ConteoRetiro(cantidad) == "No")
            {
                Console.WriteLine("No es posible retirar mas dinero ya que el limite de retiro diario es de 9000"); 

            }
            else
            {  
            if (cantidad <= cuenta.Saldo)
                {
                    cuenta.Saldo -= cantidad;
                    Console.WriteLine($"Se han retirado {cantidad}. Saldo actual: {cuenta.Saldo}");
                    Console.WriteLine(obj.Rapido(cantidad));
                    
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes.");
                }
            }
           
        }

        private void IngresarDinero(Cuenta cuenta)
        {
            Console.Write("Ingrese la cantidad a depositar: ");
            decimal cantidad = Convert.ToDecimal(Console.ReadLine());
            cuenta.Saldo += cantidad;
            Console.WriteLine($"Se han depositado {cantidad}. Saldo actual: {cuenta.Saldo}");
        }
    }
}
