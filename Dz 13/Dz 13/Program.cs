using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dz_13
{
    internal class Program
    {
        static void NumbersCalculation()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static int FactorialCalculationOfNumber(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * FactorialCalculationOfNumber(number - 1);
        }

        static async Task<int> FactorialCalculationOfNumberAsync(int number)
        {
            int factorial = await Task.Run(() => FactorialCalculationOfNumber(number));
            Thread.Sleep(8000);

            return factorial;
        }

        static int SquareCalculationOfNumber(int number)
        {
            return (number * number);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Задание 1.\n");

            Thread Thread1 = new Thread(NumbersCalculation);
            Thread Thread2 = new Thread(NumbersCalculation);
            Thread Thread3 = new Thread(NumbersCalculation);

            Thread1.Start();
            Thread2.Start();
            Thread3.Start();
            Thread1.Join();
            Thread2.Join();
            Thread3.Join();



            Console.WriteLine("\nЗадание 2.\n");

            int number = 3;

            int square = SquareCalculationOfNumber(number);
            Console.WriteLine($"Квадрат числа: {number}^2 = {square}");

            int factorial = await FactorialCalculationOfNumberAsync(number);
            Console.WriteLine($"Факториал числа: {number}! = {factorial}");



            Console.WriteLine("Задание 3.\n");

            refl Obj = new refl();

            Type myType = Obj.GetType();
            MethodInfo[] methods = myType.GetMethods();

            Console.WriteLine("Все методы:");

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
