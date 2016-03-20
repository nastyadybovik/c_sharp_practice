using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {

        public static void  Print(Object ob) {
            Console.WriteLine(ob.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");
            Console.WriteLine("First (args[0]) " + args[0]);

            //чтобы запустить из консоли приложение, нужно зайти в папку с проектом, далее bin и запустить exe файл. там же можно ввести аргумнты
            //чтобы забить аргументы коммандной строки можно сделать вручную project->properties->debug

            int i = 10;
            Int32 I = 10; //абсолютно одинаковый тип

            //inboxing - это упаковка 
            //до этого i располагался в стеке, а после этого в куче.
            
            Console.WriteLine("Переаод к строке: " + i.GetType());
            //нужен для хорошего полиморфизма

            Print(i);
            Print(3.5);
            Print( new Program() );

            object obj = 453.4;
            //outboxing - преобразование объекта в тип
            double d2 = (double)obj;

            Console.WriteLine(d2);

            try
            {
                int i2 = 100000;
                int i3 = 100000;
                checked
                {
                    //переполнение типа
                    Console.WriteLine(i2 * i3);
                }
            }
            catch (OverflowException ex) {
                Console.WriteLine("ooooooops!");
            }

            //линейное уравнение ax+b=0
            double a, бы;
            //Convert преобразует всё во всё
            a = Convert.ToDouble(Console.ReadLine());
            бы = Convert.ToDouble(Console.ReadLine()); //ржака :)))
            Console.WriteLine(бы);

            double b = бы;
            double x = -b/a;
            Console.WriteLine(x); // выведет -Infinty

            if (a == 0 && b == 0)
            {
                Console.WriteLine("x - любое");

            }
            else if (a == 0 && b != 0) {
                Console.WriteLine("нет корней");
            }

          
        }
    }
}
