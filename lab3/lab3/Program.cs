using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {

        class ComplexArray
        {
            
        }

        class Test
        {
            static void Main(string[] args)
            {
                ComplexNumber cn1 = new ComplexNumber(12, -8);
                ComplexNumber cn2 = new ComplexNumber(0, 3);
                
                ComplexNumber q1 = new ComplexNumber(1, 2);
                q1.Re = 3;
                ComplexNumber q2 = new ComplexNumber(im: 4, re: 3);
                Console.WriteLine(q2.Abs);

                ComplexNumber q3 = new ComplexNumber { Im = 2, Re = 3 };
                Console.WriteLine(q3);

                Console.WriteLine("---------");
                q3.SwapComplex();
                Console.WriteLine(q3);

                ComplexNumber q4 = new ComplexNumber(re: 1);
                Console.WriteLine(q4);

                q4.Name = "q4";

                Console.WriteLine(q4.Name);

                ComplexArray mas = new ComplexArray(1, 3, 5, 6, 4, 2, 5, 3, 4, 5, 5, 4, 3);
                Console.WriteLine(mas);
            }
        }
    }
}
