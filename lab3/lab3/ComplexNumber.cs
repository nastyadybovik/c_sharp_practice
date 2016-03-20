using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ComplexNumber
    {
        // re+i*im
        private double re;
        private double im;

        public string Name { get; set; }

        public void SwapComplex()
        {
            Utils.SwapValues(ref re, ref im);
        }

        public double Abs
        {
            get
            {
                return Math.Sqrt(Re * Re + Im * Im);
            }
        }

        public double Re
        {
            get
            {
                return re;
            }
            set
            {
                this.re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                this.im = value;
            }
        }

        public double this [ComplexNumberPart index]
        {
            get
            {
                if (index == ComplexNumberPart.IM)
                    return im;
                else
                    return re;
            }
            set
            {
                if (index == ComplexNumberPart.IM)
                    this.im = value;
                else
                    this.re = value;
            }
        }

        public ComplexNumber() : this(0, 0)
            {
        }

        public ComplexNumber(double im = 0, double re = 0)
        {
            Im = im;
            Re = re;
        }

        

        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re + y.Re, x.Im + y.Im);
        }

        public static ComplexNumber operator +(ComplexNumber x, double y)
        {
            return new ComplexNumber(x.Re + y, x.Im);
        }

        public static ComplexNumber operator -(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re - y.Re, x.Im - y.Im);
        }
        public static ComplexNumber operator -(ComplexNumber x, double y)
        {
            return new ComplexNumber(x.Re - y, x.Im);
        }

        public static ComplexNumber operator -(double x, ComplexNumber y)
        {
            return new ComplexNumber(x - y.Re, -y.Im);
        }

        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re * y.Re - x.Im * y.Im , x.Re * y.Im + x.Im * y.Re);
        }

        public static ComplexNumber operator *(ComplexNumber x, double y)
        {
            return new ComplexNumber(x.Re * y, x.Im * y);
        }

        public static ComplexNumber operator /(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re * y.Re - x.Im * y.Im, x.Re * y.Im + x.Im * y.Re);
        }

        public static ComplexNumber operator /(ComplexNumber x, double y)
        {
            return new ComplexNumber(x.Re / y, x.Im / y);
        }

        public static bool operator >(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs > y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator <(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs < y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator >=(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs >= y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator <=(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs  <= y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator ==(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs == y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator !=(ComplexNumber x, ComplexNumber y)
        {
            if (x.Abs != y.Abs)
                return true;
            else
                return false;
        }

        public static bool operator true(ComplexNumber x)
        {
            return (x.Re != 0) || (x.Im != 0);
        }

        public static bool operator false(ComplexNumber x)
        {
            return (x.Re != 0) && (x.Im != 0);
        }

        public static ComplexNumber operator ~(ComplexNumber x)
        {
            return new ComplexNumber(x.Re, -x.Im);
        }

        //im*i+re
        public static implicit operator ComplexNumber(string str)
        {
            string complexPart = str.Substring(0, str.IndexOf("*"));
            string realPart = str.Remove(0, str.IndexOf("*") + 2);
            return new ComplexNumber(Convert.ToDouble(complexPart), Convert.ToDouble(realPart));

        }

        public override string ToString()
        {
            if (Im != 0)
                if (Re > 0)
                    return Im + "*i+" + Re;
                else
                    if (Re < 0)
                    return Im + "*i" + Re;
                else
                    return Im + "*i";
            else
                return Re.ToString();

        }

        //как переопределить
        public override bool Equals(object obj)
        {
            /*if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (this.getClass() != obj.getClass())
            {
                return false;
            }*/
            ComplexNumber o = (ComplexNumber)obj;
            if (this.Re != o.Re)
                return false;
            if (this.Im != o.Im)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //как переопределять equals, hashCode, toString

    }
}
