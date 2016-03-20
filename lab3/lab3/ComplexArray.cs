using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ComplexArray
    {
        ComplexNumber[] array;
        int length;
        public int Length
        {
            get { return length; }
        }

        public ComplexArray()
        {

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
                array[Length - 1] = new ComplexNumber(re: mas[mas.Length - 1]);
            }

            for (int i = 0; i < lastIndex; i++)
            {
                array[i] = new ComplexNumber(mas[i * 2], mas[i * 2 + 1]);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (ComplexNumber number in array)
                str = str + number.ToString() + " ";
            return str;

        }
        
    }
}
