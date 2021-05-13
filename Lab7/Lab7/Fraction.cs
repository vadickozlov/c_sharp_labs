using System;

namespace Lab7 {
    public class Fraction : IComparable<Fraction>, IFormattable, IConvertible, ICloneable {
        private long _numerator;
        private long _denominator;

        public Fraction() { }

        public Fraction(long numerator, long denominator = 1) {
            Numerator = numerator;
            Denominator = denominator;
        }

        private double GetDouble() {
            return (double)_numerator / _denominator;
        }

        private static long GCD(long a, long b) {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b > 0) {
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
                if (_denominator == 0) {
                    throw new Exception("Error. Division by zero");
                }
                _denominator = value;
                if (_denominator < 0) {
                    _denominator = -_denominator;
                    _numerator = -_numerator;
                }
                Simplify();
            }
        }

        public int CompareTo(Fraction other) {
            long lcm = Denominator / GCD(Denominator, other.Denominator) * other.Denominator;
            long thisNumerator = Numerator * (lcm / Denominator);
            long otherNumerator = other.Numerator * (lcm / other.Denominator);
            return thisNumerator.CompareTo(otherNumerator);
        }

        public string ToString(string format, IFormatProvider formatProvider) {
            // S - standard, D - double, M - mixed, I - integer 
            
            if (string.IsNullOrEmpty(format)) format = "S";
            if (format == "S") {
                return $"{_numerator}/{_denominator}";
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
                    return $"{Numerator / Denominator}({Numerator % Denominator}/{Denominator})";
                }

                return ToString("S", null);
            }

            if (format == "I") {
                return $"{Numerator / Denominator}";
            }

            throw new Exception("Unsupported format type");
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
        
        public static explicit operator double(Fraction fract) {
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