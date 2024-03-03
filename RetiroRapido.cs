namespace Pruebas
{
public class Proce
{
    int b1000, b500, b200, b100, b50;
    public string Rapido(int cantidad)
    {
            b1000 = 0;
            b500 = 0;
            b200 = 0;
            b100 = 0;
            b50 = 0;
            do
            {
                if (cantidad >= 1000)
                {
                    cantidad = cantidad - 1000;
                    b1000 = b1000 + 1;
                }
                else if (cantidad >= 500)
                {
                    cantidad = cantidad - 500;
                    b500 = b500 + 1;
                }
                else if (cantidad >= 200)
                {
                    cantidad = cantidad - 200;
                    b200 = b200 + 1;
                }
                else if (cantidad >= 100)
                {
                    cantidad = cantidad - 100;
                    b100 = b100 + 1;
                }

                else if (cantidad < 50)
                {
                    Console.WriteLine("Es imposible realizar el retiro. Solo se aceptan retiros en cantidades de multiplos de 50, como 50, 100, 200, 300, 500, 800, y 1000");
                    break;
                } 

                else if (cantidad >= 50)
                {
                    cantidad = cantidad - 50;
                    b50 = b50 + 1;
                }

            }while (cantidad > 0);
            return("Su retiro se entregará de la siguiente manera: \n" + b1000 + " billetes de 1000 pesos\n" + b500 + " billetes de 500 pesos\n" + b200 + " billetes de 200 pesos\n" + b100 + " billetes 100 pesos\n" + b50 + " Billetes de 50 pesos");
    }
}
}