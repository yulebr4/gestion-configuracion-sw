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
            Console.WriteLine("  SISTEMA DE INVENTARIO v1.2");
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
                        BuscarProducto();
                        break;
                    case "4":
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
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void AgregarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            
            // Validación de nombre vacío
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("✗ Error: El nombre no puede estar vacío\n");
                return;
            }

            Console.Write("Cantidad: ");
            string cantidadStr = Console.ReadLine();
            
            // Validación de cantidad numérica
            if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
            {
                Console.WriteLine("✗ Error: La cantidad debe ser un número positivo\n");
                return;
            }

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

        static void BuscarProducto()
        {
            Console.Write("Nombre del producto a buscar: ");
            string nombre = Console.ReadLine();

            var producto = inventario.Find(p => p.Nombre.ToLower().Contains(nombre.ToLower()));
            
            if (producto != null)
            {
                Console.WriteLine($"✓ Encontrado: {producto.Nombre} - {producto.Cantidad} unidades\n");
            }
            else
            {
                Console.WriteLine("✗ Producto no encontrado\n");
            }
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}