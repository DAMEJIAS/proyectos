﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto1_BANCOELMAMALON
{
    class Program
    {
        static int contador = 0;
        static int contador2 = 0;

        static int cuenta1 = 0;

        // Declaración de variables para almacenar los datos del usuario
        private static string Nombre;
        private static int DPI;
        private static int NumeroTelefonico;
        private static string Direccion;
        private static decimal saldoin;
        private static bool mostrarMenu;
        private static string tipcuenta;
        private static string tip;

        static void Main(string[] args)
        {
            int cuenta1 = 0;
            saldoin = 2500; //se declara el saldo inicial de la cuenta
            decimal saldo = 100.0m;
            ingresodatos();
            // Crear un hilo para el ciclo infinito
            Thread hiloInfinito = new Thread(CicloInfinito);
            hiloInfinito.Start();
            menu();

            if (contador > 30)
            {
                cuenta1 = 0;
            }
        }

        static void ingresodatos()
        {
            Console.WriteLine("DATOS DEL USUARIO\n");

            // INGRESO DE NOMBRE DE USUARIO
            Console.WriteLine("Ingrese Su Nombre Completo");
            Nombre = Console.ReadLine();

            // INGRESO DE DPI
            do
            {
                Console.WriteLine("Ingrese Su DPI (5 digitos):");
                DPI = int.Parse(Console.ReadLine());
                if (DPI <= 10000)
                {
                    Console.WriteLine("DPI NO VALIDO");
                }
            } while (DPI <= 10000);
            Console.WriteLine("");

            // INGRESO DE TELEFONO
            do
            {
                Console.WriteLine("Ingrese Su Numero Telefonico (8 digitos)");
                NumeroTelefonico = int.Parse(Console.ReadLine());
                if (NumeroTelefonico <= 10000)
                {
                    Console.WriteLine("Numero de Telefono no Valido");
                }
            } while (NumeroTelefonico <= 10000);
            Console.WriteLine("");

            // INGRESO DE LA DIRECCION
            Console.WriteLine("Ingrese Su Direccion");
            Direccion = Console.ReadLine();
            cuenta();
        }

        static void menu()
        {
            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("MENU DE USUARIO\n");
                Console.WriteLine("1. VER INFORMACION DE LA CUENTA");
                Console.WriteLine("2. COMPRAR UN PRODUCTO FINANCIERO");
                Console.WriteLine("3. VENDER PRODUCTO FINANCIERO");
                Console.WriteLine("4. ABONAR A CUENTA");
                Console.WriteLine("5. SIMULAR PASO DEL TIEMPO");
                Console.WriteLine("6. SALIR");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("INGRESE LA OPCION QUE DESEA EFECTUAR");
                int numero = int.Parse(Console.ReadLine());

                switch (numero)
                {
                    case 1:
                        InfoCuenta();
                        break;
                    case 2:
                        Console.WriteLine("COMPRAR UN PRODUCTO FINANCIERO");
                        Comprar();
                        break;
                    case 3:
                        Vender();
                        // venta();
                        break;
                    case 4 when cuenta1 < 2:
                        Console.WriteLine("ABONAR A CUENTA");
                        Abonar();
                        break;
                    case 5:
                        Console.WriteLine("SIMULAR PASO DEL TIEMPO");

                        break;
                    case 6:
                        Console.WriteLine("SALIR");
                        mostrarMenu = false;
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida.");
                        break;
                }
            }
        }

        public static void InfoCuenta()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("VER INFORMACION DE LA CUENTA");
            Console.WriteLine($"Nombre:" + Nombre);
            Console.WriteLine($"DPI:" + DPI);
            Console.WriteLine($"Numero Telefonico:" + NumeroTelefonico);
            Console.WriteLine($"Direccion:" + Direccion);
            Console.WriteLine($"Saldo Inicial:" + saldoin);
            Console.WriteLine($"Su cuenta es de tipo:"+ tip);
            Console.WriteLine("-------------------------------------");

            Console.ReadKey();
        }

        public static void Comprar()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ha ingresado a la compra de producto financiero");
            Console.WriteLine("Desea realizar una compra?");
            Console.WriteLine("Ingresar 'y' para si o 'n' para no");
            Console.WriteLine("-------------------------------------");

            char opcion2 = Console.ReadLine().ToLower()[0];
            //decimal saldoin = 2500m;
            decimal multp = 0.1m;
            decimal resultado = 0.0m;
            decimal totaln = 0.0m;

            if (opcion2 == 'y')
            {
                resultado = saldoin * multp;
                totaln = saldoin - resultado;

                saldoin = totaln;
                Console.WriteLine(saldoin);
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
            else if (opcion2 == 'n')
            {
                Console.ReadKey();
            }
        }

        public static void Vender()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ha ingresado a la venta de producto financiero");
            Console.WriteLine("Desea realizar una venta?");
            Console.WriteLine("Ingresar 's' para sí o 'n' para no");
            Console.WriteLine("-------------------------------------");

            char opcionv = Console.ReadLine().ToLower()[0];
            //decimal saldoinicial =2500;
            decimal porc = 0.11m;
            decimal resultado = 0.0m;
            decimal totaln = 0.0m;

            if (opcionv == 's')
            {
                if (saldoin > 500)
                {
                    resultado = saldoin * porc;
                    totaln = saldoin + resultado;
                    saldoin = totaln;

                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Nuevo saldo: {saldoin}");
                    Console.WriteLine("El porcentaje de su venta es del 11%");
                    Console.WriteLine("-------------------------------------");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("El monto debe ser mayor a 500.");
                    Console.WriteLine("-------------------------------------");
                    Console.ReadKey();
                }
            }
            else if (opcionv == 'n')
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Operación cancelada.");
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Opción no válida.");
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        public static void Abonar()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Abonar el doble a su cuenta?");
            Console.WriteLine("Solo puede realizar esta accion 1 vez cada 2 meses");
            Console.WriteLine("-------------------------------------");
            int verif = 30;
            int verif2 = contador % 30;
            cuenta1++;


            if (contador < 30 && contador > 0)
            {
                saldoin = saldoin * 2;
                Console.WriteLine("Se ha abonado existosamente, su nuevo saldo es:");
                Console.WriteLine(saldoin);
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("No puede abonar a su cuenta");
                Console.WriteLine("-------------------------------------");
                Console.ReadKey();
            }
        }

        static void CicloInfinito()
        {
            int dias = 0;
            while (true)
            {
                Console.WriteLine($"Contador: {contador}");
                Thread.Sleep(1000); // Pausa de 1 segundo (ajustable)
                contador++;
                contador2 = 0;
                if (contador == 30)
                {
                    contador = contador - 30;
                    cuenta1 = 0;
                    Console.WriteLine(contador);
                    Console.WriteLine(contador2);
                    Console.WriteLine(cuenta1);
                    saldoin = saldoin * 1.2m;
                }
            }
        }
        public static void cuenta()
        {
            Console.WriteLine("Selecciona un tipo de cuenta:");
            Console.WriteLine("1. monetaria quetzales");
            Console.WriteLine("2. monetaria, dolares");
            Console.WriteLine("3. ahorro quetzales");
            Console.WriteLine("4. ahorro dólares");

            int tipcuenta = int.Parse(Console.ReadLine());
            string tip;
            switch (tipcuenta)
            {
                case 1:
                    Console.WriteLine("Ha seleccionado cuenta monetaria quetzales.");
                    tip = "monetaria quetzales";
                    break;
                case 2:
                    Console.WriteLine("Ha seleccionado cuenta monetaria dolares.");
                    tip = "monetaria dolares";
                    break;
                case 3:
                    Console.WriteLine("Ha seleccionado cuenta ahorro quetzales.");
                    tip = "ahorro quetzales";
                    break;
                case 4:
                    Console.WriteLine("Ha seleccionado cuenta ahorro dólares");
                    tip = " ahorro dólares";
                    break;
                default:
                    Console.WriteLine("Opción no válida. ");
                    break;
            }
        }
    }

}