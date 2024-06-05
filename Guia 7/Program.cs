using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guia_7
{
    internal class Program
    {
        static int contAccesos = 0;
        static double recaudacion = 0;
        static int contPatentes = 0;
        static int[] patentes = new int[100];
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\nBienvenido, seleccione una opcion");
                Console.WriteLine("1 - Verificar Acceso\n2 - Imprimir Recaudacion\n3 - Mostrar cantidad de accesos\n4 - Mostrar orden de patentes registradas\n5 - Buscar patente\n6 - Salir");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nPosee ticket?\n1 - Si\n2 - No");
                        int ticket = Convert.ToInt32(Console.ReadLine());
                        if (registrarAcceso(ticket))
                        {
                            Console.WriteLine("\nBienvenido al predio!\nEspere 5 segundos...");
                            Thread.Sleep(5000);
                            Console.Clear();

                        }
                        else
                        {
                            int precio = 0;
                            int tipoVehiculo;
                            int verificarPatente;
                            do
                            {
                                Console.WriteLine("\nNo posee ticket, Generando...\nseleccione su tipo de vehiculo");
                                Console.WriteLine("1 - Sin vehiculo - 100$\n2 - Moto - 800$\n3 - Auto - 1000$\n4 - Camioneta - 1500$\n5 - Bugy - 5000$\n6 - Vehiculo Nautico - 1200$");
                                tipoVehiculo = Convert.ToInt32(Console.ReadLine());                               

                                switch (tipoVehiculo)
                                {
                                    case 1:
                                        precio = 100;
                                    break;

                                    case 2:
                                        precio = 800;
                                    break;

                                    case 3:
                                        precio = 1000;
                                    break;

                                    case 4:
                                        precio = 1500;
                                    break;

                                    case 5:
                                        precio = 5000;
                                    break;

                                    case 6:
                                        precio = 1200;
                                    break;

                                    default:
                                        Console.Clear();
                                    break;
                                }
                            } while (tipoVehiculo < 1 || tipoVehiculo > 6);
                                Console.WriteLine("\nPosee patente?");
                                Console.WriteLine("1 - Si\n2 - No");
                                verificarPatente = Convert.ToInt32(Console.ReadLine());
                                if (poseePatente(verificarPatente))
                                {
                                     Console.WriteLine("Ingrese su patente");
                                     patentes[contPatentes++] = Convert.ToInt32(Console.ReadLine());
                                }
                                else
                                {
                                     Console.WriteLine("Saliendo...");
                                     Console.Clear();
                                }

                            double porcentaje = 0;
                            int cantidadDias = 0;
                            while ((cantidadDias < 1 || cantidadDias > 5) && verificarPatente == 1)
                            {
                                
                                Console.WriteLine("\nSeleccione cuantos dias desea quedarse en el predio (Max - 10 dias)");
                                Console.WriteLine("1 - 1 dia\n2 - 2 dias\n3 - 3 dias\n4 - 4 dias\n5 - 5 a 10 dias");
                                cantidadDias = Convert.ToInt32(Console.ReadLine());

                                switch (cantidadDias)
                                {
                                    case 1:
                                        porcentaje = 1;
                                    break;

                                    case 2:
                                        porcentaje = 1.2;
                                    break;

                                    case 3:
                                        porcentaje = 2.2;
                                    break;

                                    case 4:
                                        porcentaje = 3.2;
                                    break;

                                    case 5:
                                        porcentaje = 3.8;
                                    break;

                                    default:
                                        Console.WriteLine("Opcion invalida");
                                    break;
                                }
                                double costoTotal = generarTicket(precio, porcentaje);
                                recaudacion += costoTotal;
                                Console.WriteLine("Costo del ticket: {0}", costoTotal);
                            }
                            Console.WriteLine("Apriete cualquier tecla para limpiar la pantalla");
                            Console.ReadKey();
                            Console.Clear();
                            
                        }
                    break;

                    case 2:
                        Console.WriteLine("El total recaudado es: {0}" ,totalRecaudado(recaudacion));
                    break;

                    case 3:
                        Console.WriteLine("La cantidad de accesos es de: {0}",cantidadAccesos(contAccesos));
                    break;

                    case 4:
                        burbuja(patentes);
                        Console.WriteLine("Ordenando identificadores...");
                        for (int i = 0; i < contPatentes; i++)
                        {
                            Console.WriteLine(patentes[i]);
                        }
                    break;
                    case 5:
                        Console.WriteLine("Ingrese el identificador a buscar");
                        int identificador = Convert.ToInt32(Console.ReadLine());
                        int posicion = busquedaSecuencial(patentes, identificador);
                        if (posicion != -1)
                        {
                            Console.WriteLine("Identificador encontrado en la posicion {0}" ,posicion+1);
                        }
                        else
                        {
                            Console.WriteLine("Identificador no encontrado");
                        }
                    break;

                    default:
                        Console.Clear();
                    break;
                }
            } while (opcion != 6);
        }

        static bool registrarAcceso (int verificando)
        {
            bool verificar;
            contAccesos++;
            if (verificando == 1)
            {
                verificar = true;
            }
            else
            {
                verificar = false;
            }
            return verificar;
        }

        static double generarTicket(int precio, double porcentaje)
        {
            double costo = precio + (precio * porcentaje);
            double costoIva21 = costo + (costo * 0.21);
            double costoTotal = costoIva21 + (costoIva21 * 0.15);
            return costoTotal;
        }

        static double totalRecaudado(double recaudacionTotal)
        {
            return recaudacionTotal;
        }

        static int cantidadAccesos(int contador)
        {
            return contador++;
        }

        static bool poseePatente(int verificar)
        {
            bool patente;
            if (verificar == 1)
            {
                patente = true;
            }
            else
            {
                patente = false;
                contAccesos--;
            }
            return patente;
        }

        static void burbuja(int[] patentes)
        {
            int aux, i, j;
            for (i = 0; i < contPatentes - 1; i++)
            {
                for (j = i + 1; j < contPatentes; j++)
                {
                    if (patentes[i] > patentes[j])
                    {
                        aux = patentes[i];
                        patentes[i] = patentes[j];
                        patentes[j] = aux;
                    }
                }
            }
        }

        static int busquedaSecuencial(int[]patentes,int identificador)
        {
            int i = 0;
            int pos = -1;
            while (pos == -1 && i < contPatentes)
            {
                if (patentes[i] == identificador)
                {
                    pos = i;
                }
                i++;
                
            }
            return pos;
        }
    }
}
