using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace Parcial1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datos del barco
            int tiempoArranque = 20;
            int tiempoParada = 30; 
            // Tiempos de viaje entre puntos
            int[] tiemposDeViaje = {0, 120, 180, 350, 250, 100, 230, 270, 190, 110, 200};

            //Varaibles Ejercicio 1

            int acumulador = 0;
            int puntoMenorTiempo = 0;
            int menorTiempo = int.MaxValue; // Inicializamos con un valor máximo para encontrar el mínimo
            int acumuladorReal = 0;
            int tiempoPorParada;
            int tiempoActual;
            string[] ejercicio1A = new string[tiemposDeViaje.Length];
            string[] ejercicio1ABis = new string[tiemposDeViaje.Length];

            //Variables Ejericio 2

            int[] tiemposDeViajeOrdenado = new int[tiemposDeViaje.Length];
            int aux;

            //Variable Ejercicio 3

            int instanteIngresado;
            int proximoPunto = -1;
            int acumuladorE3 = 0;
            int recorridoParada;

            //Variables Ejercicio 4

            int entrada;
            int nuevoValor;

            //------------------------------------------------------------------------//


            //Ejercicio 1

            for (int i = 1; i < tiemposDeViaje.Length; i++)
            {

                tiempoActual = tiemposDeViaje[i];
                acumuladorReal += tiempoActual;

                if (i == 1)
                {
                    // No sumar el tiempo de parada para el primer elemento
                    acumulador += tiempoActual + tiempoArranque;
                    tiempoPorParada = tiempoActual + tiempoArranque;
                }
                else if (i == tiemposDeViaje.Length - 1)
                {
                    // No sumar el tiempo de arranque para el último elemento
                    acumulador += tiempoActual + tiempoParada;
                    tiempoPorParada = tiempoActual + tiempoParada;

                }
                else
                {
                    // Sumar el tiempo de parada entre puntos
                    acumulador += tiempoActual + tiempoParada + tiempoArranque;
                    tiempoPorParada = tiempoActual + tiempoParada + tiempoArranque;
                }

                ejercicio1A[i] = $"Entre el punto 0 y el punto {i} hay {acumuladorReal} segundos.";
                ejercicio1ABis[i] = $"Entre el punto {i -1} y el punto {i} hay una demora de {tiempoActual} segundos.";
                
                if (tiempoPorParada < menorTiempo && i > 1)
                {
                    menorTiempo = tiempoPorParada;
                    puntoMenorTiempo = i;
              
                }
            }

            //1.a
 
            Console.WriteLine("Ejercicio 1.a");
            foreach (string mensaje in ejercicio1A)
            {
                Console.WriteLine(mensaje);
            }
            Console.WriteLine("");
            foreach (var mensaje in ejercicio1ABis)
            {
                Console.WriteLine(mensaje);
            }

            Console.WriteLine("");

            //1.b

            Console.WriteLine("Ejercicio 1.b");
            Console.WriteLine($"El tiempo total del recorrido es de {acumulador} segundos");
            Console.WriteLine("");

            //1.c

            Console.WriteLine("Ejercico 1.c");
            if (puntoMenorTiempo != 0)
            {
                Console.WriteLine($"El punto con menor tiempo respecto al anterior es el punto {puntoMenorTiempo} con un tiempo de {menorTiempo} segundos de duracion.");
            }
            Console.WriteLine("");

            //Ejercicio 2 


            //Copiamos el array original añadiendo el tiempo de arranque y de parada segun corresponda

            for (int i = 1; i < tiemposDeViaje.Length; i++)
            {
                if (i == 1) {
                    tiemposDeViajeOrdenado[i] = tiemposDeViaje[i] + tiempoArranque;
                }else if(i == tiemposDeViaje.Length - 1)
                {
                    tiemposDeViajeOrdenado[i] = tiemposDeViaje[i] + tiempoParada;
                }
                else
                {
                tiemposDeViajeOrdenado[i] = tiemposDeViaje[i] + tiempoParada + tiempoArranque;
                }
            }

            //Ordenamos el array copiado segun el tiempo que tarde

            for (int i = 0; i < tiemposDeViajeOrdenado.Length - 1; i++) 
            {
                for (int j = 0; j < tiemposDeViajeOrdenado.Length - 1 - i; j++) 
                {
                    if (tiemposDeViajeOrdenado[j] > tiemposDeViajeOrdenado[j + 1])
                    {
                        aux = tiemposDeViajeOrdenado[j];
                        tiemposDeViajeOrdenado[j] = tiemposDeViajeOrdenado[j + 1];
                        tiemposDeViajeOrdenado[j + 1] = aux;
                    }
                }
            }

            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Tiempos con menor duracion de recorrido");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine(tiemposDeViajeOrdenado[i]);
            }

            Console.WriteLine("");

            //Ejercicio 3 

            Console.WriteLine("Ejercicio 3");
            Console.Write("Ingrese un instante (entre 0 y 2000): ");
            instanteIngresado = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            for (int i = 1; i < tiemposDeViaje.Length; i++)
            {
                recorridoParada = tiemposDeViaje[i];

                //Si el tiempo ingresado es menor al tiempo acumulado mas el tiempo del recorridoParada(Osea el proxima punto)
                //se rompe el ciclo
                if (acumuladorE3 + recorridoParada >= instanteIngresado)
                {
                    proximoPunto = i;
                    break;
                }

                acumuladorE3 += recorridoParada;
            }

            if (proximoPunto != -1)
            {
                for(int i = 1;i < proximoPunto; i++)
                {
                    Console.WriteLine($"Se alcanzo el punto {i} a los {tiemposDeViaje[i]} segundos.");
                }
                Console.WriteLine("");
                Console.WriteLine($"El próximo punto a alcanzar es el punto {proximoPunto}.");
                Console.WriteLine("");
                Console.WriteLine($"Llevas {acumuladorE3} segundos de recorrido.");
            }
            else
            {
                Console.WriteLine("El instante ingresado excede el tiempo total de recorrido.");
            }

            Console.WriteLine("");

                //Ejercicio 4

                Console.WriteLine("Ejercicio 4");
                Console.WriteLine("");
            do
            {
                Console.Write("Ingresa un número entre 1 y 10 (-1 para salir): ");
                Console.WriteLine("");
                entrada = int.Parse(Console.ReadLine());

                if (entrada > 0 && entrada <= 10)
                {
                    Console.WriteLine($"¿Qué valor deseas darle a la posición {entrada}?");
                    nuevoValor = int.Parse(Console.ReadLine());
                    tiemposDeViaje[entrada] = nuevoValor;

                    Console.WriteLine("");
                    Console.WriteLine("Los valores actualizados quedan de la siguiente manera:");
                    for (int i = 1; i < tiemposDeViaje.Length; i++)
                    {
                        Console.WriteLine($"Punto {i}: {tiemposDeViaje[i]} segundos");
                    }
                }
                else if (entrada != -1)
                {
                    Console.WriteLine("El número ingresado debe estar entre 1 y 10.");
                }

            } while (entrada != -1);

            if (entrada == -1)
            {
                Console.WriteLine("Saliste, gracias por ver mi parcial!");
            }


        }
    }
}




