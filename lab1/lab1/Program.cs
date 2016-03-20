using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {

        static Object SolveSquareEquation(double a, double b, double c)
        {
            double D = Math.Pow(b, 2) - 4 * a * c;

            if (a != 0)
            {
                if (D < 0)
                {
                    return "No roots in R";
                }
                else if (D == 0)
                {
                    double x = (-b - Math.Sqrt(D)) / (2 * a);
                    return x;
                }
                else if (D > 0)
                {
                    double[] array = new double[2];
                    array[0] = (-b - Math.Sqrt(D)) / (2 * a);
                    array[1] = (-b + Math.Sqrt(D)) / (2 * a);
                    return array;
                }
            }
            else
            {
                return SolveLinearEquation(b, c);
            }
            return null;
        }

        static Object SolveLinearEquation(double b, double c)
        {

            if (b == 0 && c == 0)
            {
                return "Any root";
            }
            else if (b == 0 && c != 0)
            {
                return "No root";
            }
            else
            {
                double x = -c / b;
                return x;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a: ");
            var a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            var b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c: ");
            var c = Convert.ToDouble(Console.ReadLine());

            var obj = SolveSquareEquation(a,b,c) ;
            if (obj is Double)
            {
                Console.WriteLine("x= " + obj);
            }
            else if (obj is String)
            {
                Console.WriteLine(obj);
            }
            else if (obj is Array)
            {
                var array = (double[])obj;
                Console.WriteLine("x1= {0} ; x2= {1}", array[0], array[1]);
            }

        }
    }
}
