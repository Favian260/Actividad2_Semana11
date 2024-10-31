//N00458733
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Actividad_2_Funal_S11
{
    public class Program
    {

        //Invocacion de la biblioteca.

        static string[] libreria = new string[5000];
        static double[] precio = new double[5000];


        static void Main(string[] args)
        {
            //Variables necesarias.
            int cantLibros, i;
            int cantFinalLibros;
            char caracterDeConfirmacion = 'r';
            int opciones = 2;
            //Variables auxiliares
            char omitir;


            //Inicialización del programa.
            Console.Write("Actualmente no se cuenta ningún libro registrado, debe registrarlos, presione cualquier tecla para continuar.");
            omitir = char.ToUpper(Console.ReadKey(true).KeyChar);


            //Implementacion de la cantidad de libros que se quiere ingresar.
            Console.Clear();
            Console.WriteLine("INGRESO DE LIBROS");
            Console.Write("Ingrese la cantidad de Libros que desea registrar: ");
            while ((!int.TryParse(Console.ReadLine(), out cantLibros) || cantLibros <= 0))
            {
                Console.WriteLine("El valor debe ser un entero mayor que cero");
                Console.Write("Ingrese la cantidad de Libros que desea registrar: ");
            }

            //Asignación de libros.
            for (i = 0; i < cantLibros; i++)
            {
                Console.Write($"\nIngrese el coste del libro {i + 1}, este debe ser necesariamente decimal y positivo: ");
                while ((!double.TryParse(Console.ReadLine(), out precio[i]) || precio[i] % 1 == 0 || precio[i] <= 0))
                {
                    Console.WriteLine("El valor debe ser decimal y positivo.");
                    Console.Write($"Ingrese el coste del libro {i + 1} nuevamente: ");
                }
                Console.Write($"Ingrese el nombre del libro número {i + 1}: ");
                libreria[i] = Console.ReadLine();

                while (!(libreria[i].Length >= 2))
                {
                    Console.WriteLine("Error, recuerde que el titulo de un libro al menos tiene dos caracteres.");
                    Console.Write($"Ingrese el nombre del libro número {i + 1}: ");
                    libreria[i] = Console.ReadLine();

                }

                if (i < cantLibros - 1)
                {
                    Console.WriteLine("¿Desea dejar el registro de Libros hasta aquí?");
                    Console.WriteLine("Presionar P para parar y cualquier otra tecla para continuar.");
                    caracterDeConfirmacion = char.ToUpper(Console.ReadKey(true).KeyChar);
                }

                if (caracterDeConfirmacion == 'P')
                {
                    break;
                }
            }

            //Redimensionar arreglo a la cantidad de terminos de i mas 1
            Array.Resize(ref libreria, i + 1);
            Array.Resize(ref precio, i + 1);

            //Contador de cantidad de libros
            cantFinalLibros = libreria.Length;

            //Inicio del menú
            Console.Clear();
            menu();
            do
            {
                Console.Write("Ingrese una de las opciones que ve del menú: ");
                opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            MostrarElementos(libreria, precio);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            BuscarNombreYModificarPrecio(ref libreria, ref precio, cantFinalLibros);
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            menu();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ingresó una opción fuera del menú ingrese nuevamente,presione cualquier tecla para volver al menú.");
                            omitir = char.ToUpper(Console.ReadKey(true).KeyChar);
                            Console.Clear();
                            menu();
                            break;
                        }
                }
            } while (opciones != 4);

            Console.ReadKey();
        }


        //Metodos.

        //Metodo base.
        static void BuscarNombreYModificarPrecio(ref string[] nombre, ref double[] precio, int cantidadDeNumeros)
        {
            int contador = 0;
            string nombreABuscar;
            Console.Write("Ingrese el nombre del libro que desee buscar: ");
            nombreABuscar = Console.ReadLine();
            for (int i = 0; i < nombre.Length; i++)
            {
                if (nombreABuscar == nombre[i])
                {
                    contador++;
                    Console.WriteLine($"El libro de orden {contador} con el nombre buscado es el producto número {i + 1} de la lista.");
                    Console.WriteLine($"El precio del producto que desea modificar es de {precio[i]}.");
                    EditarNombreYPrecio(ref nombre[i], ref precio[i]);
                }
            }
            Console.WriteLine();
        }
        static void EditarNombreYPrecio(ref string nombreDelLibro, ref double precioDelLibro)
        {
            char opcion;
            Console.WriteLine();
            Console.WriteLine("¿Desea editar nombre (N), precio (P),ambos (A) o Cancelar (Otro caracter)?");
            Console.WriteLine("Pulse la tecla respectiva para continuar.");
            Console.WriteLine();
            opcion = char.ToUpper(Console.ReadKey(true).KeyChar);
            switch (opcion)
            {
                case 'N':
                    {
                        editarNombre(ref nombreDelLibro);
                        break;
                    }
                case 'P':
                    {
                        editarPrecio(ref precioDelLibro);
                        break;
                    }
                case 'A':
                    {
                        editarNombre(ref nombreDelLibro);
                        editarPrecio(ref precioDelLibro);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        //Editar precio.
        static void editarPrecio(ref double precio)
        {
            Console.Write("Ingrese el precio a asignar: ");
            precio = double.Parse(Console.ReadLine());
        }
        static void editarNombre(ref string nombre)
        {
            Console.Write("Ingrese el nuevo nombre a asignar: ");
            nombre = Console.ReadLine();
        }

        //Menú.
        static void menu()
        {
            Console.WriteLine("-----------BIENVENIDO A LA LIBRERÍA -----------");
            Console.WriteLine("----------Ingrese una de las opciones----------");
            Console.WriteLine("(1) Mostrar Libros Registrados.");
            Console.WriteLine("(2) Editar nombre y precio del libro buscado por medio de su nombre.");
            Console.WriteLine("(3) Limpiar Consola.");
            Console.WriteLine("(4) Salir.");
        }

        //Mostrar Elementos.
        static void MostrarElementos(string[] nombres, double[] precios)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("---------Lista de Libros----------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Nombre del libro\t\tPrecio del libro");
            for (int i = 0; i < nombres.Length || i == 0; i++)
            {
                Console.WriteLine($"{i + 1}){nombres[i]}\t\t\t\t\t{precios[i]}");
            }
            IngreseOtraOpcion();
        }

        static void IngreseOtraOpcion()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vuelva ingresar una opción");
        }
    }
}

