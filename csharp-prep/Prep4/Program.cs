using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        List<int> numeros = new List<int>();

        while (true) {
            Console.Write("Ingresa un número (ingresa 0 para salir): ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0) {
                break;
            }

            numeros.Add(num);
        }

        Console.WriteLine("Los números ingresados son:");
        foreach (int num in numeros) {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int suma = numeros.Sum();
        double promedio = numeros.Average();
        int maximo = numeros.Max(); // Encontrar el número máximo en la lista

        Console.WriteLine("La suma de los números es: " + suma);
        Console.WriteLine("El promedio de los números es: " + promedio);
        Console.WriteLine("El número máximo en la lista es: " + maximo);
    }
}