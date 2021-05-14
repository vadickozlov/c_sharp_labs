using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace Lab7 {
    public class Fraction : IComparable<Fraction>, IFormattable, IConvertible, ICloneable {
        protected bool Equals(Fraction other) {
            return CompareTo(other) == 0;
        }

        private long _numerator;
        private long _denominator;

        public Fraction() { }

        public Fraction(long numerator, long denominator = 1) {
            Denominator = denominator;
            Numerator = numerator;
        }

        private double GetDouble() {
            return (double)_numerator / _denominator;
        }

        private static long GCD(long a, long b) {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a > 0 && b > 0) {
                a %= b;
                (a, b) = (b, a);
            }
            return a;
        }

        private void Simplify() {
            long gcd = GCD(_numerator, _denominator);
            _numerator /= gcd;
            _denominator /= gcd;
        }

        public long Numerator {
            get => _numerator;
            set {
                _numerator = value;
                if (_numerator != 0) Simplify();
            }
        }
        
        public long Denominator {
            get => _denominator;
            set {
                if (value == 0) {
                    throw new Exception("Error. Division by zero");
                }
                _denominator = value;
                if (_denominator < 0) {
                    _denominator *= -1;
                    _numerator *= -1;
                }
                if (_numerator != 0) Simplify();
            }
        }

        public int CompareTo(Fraction other) {
            long lcm = Denominator / GCD(Denominator, other.Denominator) * other.Denominator;
            long thisNumerator = Numerator * (lcm / Denominator);
            long otherNumerator = other.Numerator * (lcm / other.Denominator);
            return thisNumerator.CompareTo(otherNumerator);
        }

        public string ToString(string format) {
            return ToString(format, null);
        }

        public override string ToString() {
            return ToString("S");
        }

        public string ToString(string format, IFormatProvider formatProvider) {
            // S - standard, D - double, M - mixed, I - integer 
            
            if (string.IsNullOrEmpty(format)) format = "S";
            if (format == "S") {
                return $"{Numerator}/{Denominator}";
            }

            if (format == "D") {
                double result = (double)_numerator / _denominator;
                return $"{result}";
            }

            if (format == "M") {
                if (Denominator == 1) {
                    return ToString("I", null);
                }
                if (Math.Abs(Numerator) > Denominator) {
                    return $"{Numerator / Denominator}({Math.Abs(Numerator) % Denominator}/{Denominator})";
                }

                return ToString("S", null);
            }

            if (format == "I") {
                return $"{Numerator / Denominator}";
            }

            throw new Exception("Unsupported format type");
        }

        public static bool TryParse(String s, out Fraction fr) {
            fr = null;
            Regex standardPattern = new Regex(@"^(-?\d+)/(\d+)$");
            Regex mixedPattern = new Regex(@"^(-?\d+)\((\d+)/(\d+)\)$");
            Regex doublePattern = new Regex(@"^(-?\d+)[,\.](\d+)$");
            Regex integerPattern = new Regex(@"^(-?\d+)$");
            if (standardPattern.IsMatch(s)) {
                Match match = standardPattern.Match(s);
                long num = long.Parse(match.Groups[1].Value);
                long den = long.Parse(match.Groups[2].Value);
                fr = new Fraction(num, den);
                return true;
            }
            if (mixedPattern.IsMatch(s)) {
                Match match = mixedPattern.Match(s);
                long integer = long.Parse(match.Groups[1].Value);
                long num = long.Parse(match.Groups[2].Value);
                long den = long.Parse(match.Groups[3].Value);
                int sign = (integer >= 0) ? 1 : -1;
                fr = new Fraction(sign * (Math.Abs(integer) * den + num), den);
                return true;
            }
            if (doublePattern.IsMatch(s)) {
                double num = Double.Parse(s);
                int den = 1;
                while (num != (int)num) {
                    num *= 10;
                    den *= 10;
                }

                fr = new Fraction((int) num, den);
                return true;
            }
            if (integerPattern.IsMatch(s)) {
                long num = long.Parse(s);
                fr = new Fraction(num);
                return true;
            }
            return false;
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider) {
            return Numerator != 0;
        }
        
        public byte ToByte(IFormatProvider provider) { 
            return Convert.ToByte(GetDouble(), provider); 
        }
        
        public char ToChar(IFormatProvider provider) { 
            return Convert.ToChar(GetDouble(), provider);
        }
        
        public DateTime ToDateTime(IFormatProvider provider) { 
            return Convert.ToDateTime(GetDouble(), provider); 
        }
        
        public decimal ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal(GetDouble(), provider); 
        }
        
        public double ToDouble(IFormatProvider provider) { 
            return GetDouble();
        }
        
        public short ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(GetDouble(), provider);
        }
        
        public int ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(GetDouble(), provider);
        }
        
        public long ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(GetDouble(), provider); 
        }
        
        public SByte ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(GetDouble(), provider); 
        }
        
        public float ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(GetDouble(), provider);
        }
        
        public string ToString(IFormatProvider provider) {
            return ToString("S", provider);
        }
        
        public object ToType(Type conversionType, IFormatProvider provider) {
            return Convert.ChangeType(GetDouble(), conversionType);
        }
        
        public UInt16 ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(GetDouble(), provider); 
        }
        
        public UInt32 ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(GetDouble(), provider);
        }
        
        public UInt64 ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(GetDouble(), provider);
        }
        
        public static explicit operator sbyte(Fraction fract) {
            return fract.ToSByte(null);
        }
        
        public static explicit operator short(Fraction fract) {
            return fract.ToInt16(null);
        }
        
        public static explicit operator int(Fraction fract) {
            return fract.ToInt32(null);
        }
        
        public static explicit operator long(Fraction fract) {
            return fract.ToInt64(null); 
        }
        
        public static explicit operator float(Fraction fract) {
            return fract.ToSingle(null);
        }
        
        public static implicit operator double(Fraction fract) {
            return fract.ToDouble(null);
        }
        
        public static explicit operator decimal(Fraction fract) {
            return fract.ToDecimal(null);
        }

        public object Clone() {
            return new Fraction(Numerator, Denominator);
        }
        
        public override bool Equals(object obj) {
            if (obj.GetType() != GetType()) {
                return false;
            }
            return CompareTo((Fraction)obj) == 0;
        }
        
        public static Fraction operator +(Fraction fr) { 
            return fr;
        }
        
        public static Fraction operator -(Fraction fr) {
            fr = new Fraction(-fr.Numerator, fr.Denominator);
            return fr;
        }
        
        public static Fraction operator +(Fraction a, Fraction b) { 
            Fraction fr = new Fraction(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator, 
                a.Denominator * b.Denominator);
            return fr;
        }
        public static Fraction operator -(Fraction a, Fraction b) { 
            return a + (-b);
        }
        public static Fraction operator *(Fraction a, Fraction b) { 
            Fraction fr = new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            return fr;
        }
        public static Fraction operator *(Fraction a, long b) { 
            Fraction fr = new Fraction(a.Numerator * b, a.Denominator);
            return fr;
        }
        public static Fraction operator /(Fraction a, Fraction b) {
            Fraction fr = new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            return fr;
        }
        public static Fraction operator /(Fraction a, long b) {
            if (b == 0) {
                throw new DivideByZeroException();
            }
            Fraction fr = new Fraction(a.Numerator, a.Denominator * b);
            return fr;
        }
        public static bool operator ==(Fraction a, Fraction b) {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b) {
            return a.CompareTo(b) != 0;
        }
        public static bool operator >(Fraction a, Fraction b) {
            return a.CompareTo(b) == 1;
        }
        public static bool operator <(Fraction a, Fraction b) {
            return a.CompareTo(b) == -1;
        }
        public static bool operator >=(Fraction a, Fraction b) {
            return a.CompareTo(b) != -1;
        }
        public static bool operator <=(Fraction a, Fraction b) {
            return a.CompareTo(b) != 1;
        }
    }
}