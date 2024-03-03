using System.Diagnostics.Contracts;
using System;
using System.Net;
using System.Collections;
using System.Timers;

namespace Pruebas
{
    public class Cuenta
    {
        public string Tarj { get; set; }
        public decimal Saldo { get; set; }
        public string Titular { get; set; }
        public string EstadoCuenta { get; set; }
        public DateTime FechaTrans { get; set; }
        public int Movimientos { get; set; }
        public string Comprobante { get; set; }
        public List<Transaccion> Transacciones { get; set; }
    }

    public class TarjetaDebito
    {

        public string NumTar { get; private set; }
        public string Pin { get; private set; }
        public string Cuenta { get; private set; }
        public int Contador { get; private set; }

        private int contadorOperaciones;
        private decimal contadorRetiros;
        private const int MaxOperaciones = 5;

        private const int MaxRetiros = 9000;

        
        public TarjetaDebito(string numTar, string pin, string cuenta)
        {
            NumTar = numTar;
            Pin = pin;
            Cuenta = cuenta;
            contadorOperaciones = 0;
            contadorRetiros = 0;
        }

        public string ConteoRetiro(decimal cantidad)
        {
            contadorRetiros += cantidad;
            if (contadorRetiros/2 > MaxRetiros && cantidad > MaxRetiros)
            {
                contadorRetiros = 0;
                return ("No");
            }
            else if (contadorRetiros/2 > MaxRetiros)
            {
                return "No";
            }
            else
            {
                return "";
            }
        }

        public bool PuedeRealizarOperacion()
        {
            return contadorOperaciones < MaxOperaciones;
        }


        public void IncrementarContador()
        {
            if (contadorOperaciones < MaxOperaciones)
            {
                contadorOperaciones++;
            }
        }

        public void CambiarPin(string nuevoPin)
        {
            // Aquí podrías añadir lógica adicional para validar el nuevo PIN
            Pin = nuevoPin;
        }

        // Esta función necesita ser ajustada para trabajar con el sistema de verificación.
    }
}