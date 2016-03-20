using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    class Rational
    {
        private int a;
        private int b;

        //по умолчанию идентификатор домтупа - private
        public Rational(int  a, int b)
        {
            this.a = a/NOD(a,b);
            this.b = b/NOD(a,b);
        }

        public Rational():this(0,1)
        {
        }

        // "23/123" -> Rational(23,123)
        // Сделаем возможным  Rational r = "89/77"
        // Неявное преобразование типов!!!! - нет в джаве 
        // void M(Ratinal a);
        // M("24/55");

        public static implicit operator Rational (string str)
        {
            string nominator = str.Substring(0, str.IndexOf("/"));
            string denominator = str.Remove(0, str.IndexOf("/")+1);
            return new Rational(Convert.ToInt32(nominator), Convert.ToInt32(denominator) );

        }

        public override string ToString()
        {
            return a + "/" + b ;
        }

        private int NOD(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);

            if (x < y)
            {
                int temp = x;
                x = y;
                y = temp;
            }

            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }

            return x;
        }

    }

    class RationalMatrix
    {
        Rational[,] array;
        int n;
        int m;

        public RationalMatrix(int n, int m, String str)
        {
            
        }

        public RationalMatrix(int n, int m, Rational[] mas)
        {
            this.n = n;
            this.m = m;
            array = new Rational[n, m]; //вызовется конструктор по умолчанию
            if (n * m != mas.Length)
                throw new Exception("Doesn't require dimension");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = mas[i*m + j];
                }

        }

        public override string ToString()
        {
            var str = "";
            for (int i=0; i< n; i++)
            {
                for (int j = 0; j < m-1; j++)
                {
                    str = str + array[i,j] + "\t";
                }
                str = str + array[i, m-1] + "\n";

            }
            str = str.Remove(str.Length -1);
            return str;
        }
    }

    class Test
    {
        public static void Main() {
            var q1 = new Rational(4,8);
            Console.WriteLine(q1);

            var ra = new Rational[6] { "2/3", "2/5", "7/3", "6/4", "2/9", "1/5" };
            /*for (int i = 0; i < 6; i++)
            {
                ra[i] = new Rational();
            } */

            var rm = new RationalMatrix(2,3, ra);
            Console.WriteLine(rm);

            Rational q2 = "4/8";
            Console.WriteLine("Неявное преобразование типов: " + q2);

        }
    }

    //Д.з: создать класс комплексных чисел
    //Д.з Никита: матрица смежности

    //Лекция
    //readonly - константа в пределах одного класса, у разных объектов могут быть разные константы, в отличие от private static поля
    //отличие out от ref: почти как ref, только не обяательно инициализировать до, и если оut переменная не была инициализирована до, то обязана быть инициализирована после 
    //статический конструктор вместо статического блока в джаве - вызывается при создании объекта или иначе при первом обращении к статике
    //деструктор ~Car() - закрываются коннекшны к базе, сокеты и тд, но не освобождается память, ей занимается gc
    //инкапсуляция!  obj.Year = 1996 - обращение к property
    // auto-implemented properties - не поняла

    /*мой реп это не твой реп твой реп это не мой реп я в репе тут ты там мой реп это пау реп это э-э-э
    мой реп это мой мой реп реп реп, реп это мой мой реп реп реп, дофига репа в репе но всем репам мой мой
    реп реп реп
    Я не вижу когда мой реп делает тым-дым чо-то там но если мой реп на микро то кричи васап-васап
    я такой нифига но если мой реп то давай я такой читаю пока ты тым-ды-дым-тым агааа
    ПАУ ПАУ ПАУ все такие все такие НО НО НО мы не такие не такие ЙОУ ЙОУ ЙОУ видишь кеды 
    
    */



}
