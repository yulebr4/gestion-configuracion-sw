using System;
using System.Collections.Generic;

namespace SistemaInventario
{
    class Program
    {
        static List<Producto> inventario = new List<Producto>();

        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("  SISTEMA DE INVENTARIO v1.0");
            Console.WriteLine("=================================\n");

            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        ListarProductos();
                        break;
                    case "3":
                        continuar = false;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida\n");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Listar productos");
            Console.WriteLine("3. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void AgregarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            inventario.Add(new Producto { Nombre = nombre, Cantidad = cantidad });
            Console.WriteLine("✓ Producto agregado exitosamente\n");
        }

        static void ListarProductos()
        {
            Console.WriteLine("\n--- INVENTARIO ---");
            if (inventario.Count == 0)
            {
                Console.WriteLine("No hay productos registrados\n");
                return;
            }

            foreach (var producto in inventario)
            {
                Console.WriteLine($"- {producto.Nombre}: {producto.Cantidad} unidades");
            }
            Console.WriteLine();
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}