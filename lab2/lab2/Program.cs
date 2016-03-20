using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab2
{

    class Utils
    {
        public static void SwapValues (ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp; 
        }
    }

    class ComplexArray
    {
        ComplexNumber[] array;
        int length;
        public int Length
        {
            get {return length; }
        }

        public ComplexArray()
        {

        }

        public override string ToString()
        {
            string str = "";
            foreach (ComplexNumber number in array)
                str = str + number+" ";
            return str;

        }
        public ComplexArray(params double[] mas)
        {
            length = (int)(Math.Ceiling(mas.Length / 2d));
            array = new ComplexNumber[Length];
            int lastIndex = 0;
            if ((mas.Length / 2) * 2 == mas.Length)
                lastIndex = Length;
            else
            {
                lastIndex = Length - 1;
                array[Length - 1] = new ComplexNumber(b:mas[mas.Length - 1]);
            }

            for (int i=0; i<lastIndex;i++)
            {
                array[i] = new ComplexNumber(mas[i * 2], mas[i * 2 + 1]);
            }
        }
    }

    class ComplexNumber
    {
        // a*i+b
        private double a;
        private double b;

        public string Name { get; set; }

        public void SwapComplex()
        {
            Utils.SwapValues(ref a, ref b);
        }

        public double Abs
        {
            get {
                return Math.Sqrt(A * A + B * B);
            }
        }

        public double A {
            get {
                return a;
            }
            set {
                this.a = value;
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                this.b = value;
            }
        }

        public ComplexNumber():this(0,0)
        {
        }

        public ComplexNumber(double a=0, double b=0)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            if( a!=0 )
                if(b > 0)
                    return a + "*i+" + b;
                else
                    return a + "*i" + b;
            else
                return b.ToString();
               
        }

        public ComplexNumber add(ComplexNumber x)
        {
            return new ComplexNumber(x.A + this.A , x.B + this.B);
        }

        public ComplexNumber subtract(ComplexNumber x)
        {
            return new ComplexNumber(this.A - x.A, this.B - x.B);
        }

        public ComplexNumber multiply(double y)
        {
            return new ComplexNumber(this.A * y, this.B * y);
        }

        public ComplexNumber divide(double y)
        {
            return new ComplexNumber(this.a / y, this.b / y);
        }

        public static implicit operator ComplexNumber(string str)
        {
            string complexPart = str.Substring(0, str.IndexOf("*"));
            string realPart = str.Remove(0, str.IndexOf("*") + 2);
            return new ComplexNumber(Convert.ToDouble(complexPart), Convert.ToDouble(realPart));

        }

    }
    class Test
    {
        static void Main(string[] args)
        {
            ComplexNumber cn1 = new ComplexNumber(12,-8);
            ComplexNumber cn2 = new ComplexNumber(0, 3);
        
            Console.WriteLine("( " + cn1 + " ) + ( " + cn2 + " ) = " + cn1.add("0*i+3") );

            Console.WriteLine("( " + cn1 + " ) - ( " + cn2 + " ) = " + cn1.subtract(cn2));

            Console.WriteLine("( " + cn1 + " ) * 5 = " + cn1.multiply(5));

            Console.WriteLine("( " + cn1 + " ) / 5 = " + cn1.divide(5));

            ComplexNumber q1 = new ComplexNumber(1, 2);
            q1.B = 3;
            ComplexNumber q2 = new ComplexNumber( b: 4, a:3);
            Console.WriteLine(q2.Abs);

            ComplexNumber q3 = new ComplexNumber { A = 2, B = 3 };
            Console.WriteLine(q3);

            Console.WriteLine("---------");
            q3.SwapComplex();
            Console.WriteLine(q3);

            ComplexNumber q4 = new ComplexNumber(b:1);
            Console.WriteLine(q4);

            q4.Name = "q4";

            Console.WriteLine(q4.Name);

            ComplexArray mas = new ComplexArray(1, 3, 5, 6, 4, 2, 5,3,4,5,5,4,3);
            Console.WriteLine(mas);
        }
    }
}

// Полиморфизм - это различная реализация однотипных действий
// Виртуальный метод - это метод, который МОЖЕТ быть переопределен в классе-наследнике. Такой метод может иметь стандартную реализацию в базовом классе.
// без override , то мы не скроем метод базового класса
// любой override остаётся virtual, чтобы остановить полиморфизм пишем: sealed override

// abstract метод нужен для переопределения в производных кдассах. поэтому для него не пишем virual
// static abstract ! ERROR ! because:
// static method i can use witout creating an object, but abstract - not

// В интерфейсе нет констант (в отличие от джавы)
// Интерфейс отвечает толко за поведение, а абстрактный класс за сущность
// В интерфейсе спецификаторы доступа - public, не пишем abstarct
// Наследование только от ОДНОГО класса, а реализация от разного числа интерфейсов

// Если реализуем несколько интерфейсов с одинаковыми методами GetInfo, то  явно указываем с какого интерфейса: Car.GetInfo, а вызов ((Luxury)obj).GetInfo();

// Структры содержатся в стеке (гораздно быстрее доступ)
// Структуры не могут наследовать структуры и классы и служить в качестве базовых
// имеет сво члены: методы, поля, индексаторы, свойства, операторные методы, события; имеют конструкторы (но не по умолчанию), без деструкторов