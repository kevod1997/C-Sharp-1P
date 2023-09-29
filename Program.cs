using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace Parcial1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datos del barco
            int tiempoArranque = 20; // segundos
            int tiempoParada = 30; // segundos

            // Tiempos de viaje entre puntos
            int[] tiemposDeViaje = { 120, 180, 350, 250, 100, 230, 270, 190, 110, 200 };
            int acumulador = 0;
            int puntoMenorTiempo = 0; // Inicializamos con un valor que no existe
            int menorTiempo = int.MaxValue; // Inicializamos con un valor máximo para encontrar el mínimo
            int duracionTotal = 0;

        
            for (int i = 0; i < tiemposDeViaje.Length; i++)
            {

                int tiempoActual = tiemposDeViaje[i];
                int tiempo;
                //Console.WriteLine("El tiempo de la parada: "+ i + " es de:" + tiempoActual.ToString());

                if (i == 0)
                {
                    // No sumar el tiempo de parada para el primer elemento
                    acumulador += tiempoActual + tiempoArranque;
                    tiempo = tiempoActual + tiempoArranque;
                }
                else if (i == tiemposDeViaje.Length - 1)
                {
                    // No sumar el tiempo de arranque para el último elemento
                    acumulador += tiempoActual + tiempoParada;
                    tiempo = tiempoActual + tiempoParada;

                }
                else
                {
                    // Sumar el tiempo de parada entre puntos
                    acumulador += tiempoActual + tiempoParada + tiempoArranque;
                    tiempo = tiempoActual + tiempoParada + tiempoArranque;
                }

                //Console.WriteLine($"Tiempo acumulado en el punto {i}: {acumulador} segundos");
                Console.WriteLine($"Entre el punto 0 y el punto {i + 1} hay {acumulador} segundos");
                Console.WriteLine($"Entre el punto {i} y el punto {i + 1} hay {tiempo} segundos de demora");


                if (tiempo < menorTiempo && i > 0)
                {
                    menorTiempo = tiempo;
                    puntoMenorTiempo = i+1;
                    Console.WriteLine(puntoMenorTiempo);
                }

                duracionTotal += tiempo;
            }

            // Imprimir resultados
            if (puntoMenorTiempo != 0)
            {
                Console.WriteLine($"El punto con menor tiempo respecto al anterior es el punto {puntoMenorTiempo} con un tiempo de {menorTiempo} segundos.");
                Console.WriteLine($"La duración total del recorrido es de {duracionTotal} segundos.");
            }


        Console.WriteLine("El tiempo total del recorrido es de " + acumulador + " segundos");

          
        }
    }
}


