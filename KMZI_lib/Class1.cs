using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZI_lib
{
    public class Class1
    {
        public static List<long> a = new List<long>();
        public static List<long> x = new List<long>();
        public static List<long> y = new List<long>();
        public static List<long> q = new List<long>();
        static public long InverseNumber(long A, long B, long C)//А-находим обратное к этому числу, В-модуль
        {
            long nod;
            long x1;
            if (Math.Abs(A) < Math.Abs(B))
            {
                nod = NOD(B, A);
                x1 = y[y.Count - 2] * (C / nod);
            }
            else
            {
                nod = NOD(A, B);
                x1 = x[x.Count - 2] * (C / nod);
            }

            while (x1 > B / nod)
            {
                x1 -= B / nod;
            }
            return x1;
            //exponenX1 = Exponentiation(A, B - 2, B);
        }
        static public long Exponentiation(long n, long deg, long modul)
        {
            string binaryCode = Convert.ToString(deg, 2);
            long m = n;
            for (int i = 1; i < binaryCode.Length; i++)
            {
                if (int.Parse(binaryCode[i].ToString()) == 0)
                {
                    n *= n;
                    n %= modul;
                }
                else
                {
                    n *= n;
                    n %= modul;
                    n *= m;
                    n %= modul;
                }
            }
            return n;
        }
        static public bool CheckForSimplicity(long n)
        {
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        static public long NOD(long numA, long numB)
        {
            a.Clear(); x.Clear(); y.Clear(); q.Clear();

            long nod = 0; a.Add(Math.Abs(numA)); x.Add(1); y.Add(0); q.Add(0);

            a.Add(Math.Abs(numB)); x.Add(0); y.Add(1); q.Add(Math.Abs(numA) / Math.Abs(numB));

            for (int i = 2; a[i - 1] != 0; i++)
            {
                a.Add(a[i - 2] % a[i - 1]);
                if (a[i] != 0)
                {
                    q.Add(a[i - 1] / a[i]);
                }
                x.Add(x[i - 2] - x[i - 1] * q[i - 1]);
                y.Add(y[i - 2] - y[i - 1] * q[i - 1]);
            }
            if (numA < 0)
            {
                a[0] *= -1;
                x[x.Count - 2] *= -1;
            }
            if (numB < 0)
            {
                a[1] *= -1;
                y[y.Count - 2] *= -1;
            }
            nod = a[a.Count - 2];
            return nod;
        }
        public static long DecisionCompare(long A, long B, long C)
        {
            long nod;
            long x1;
            if (Math.Abs(A) < Math.Abs(B))
            {
                nod = NOD(B, A);
                x1 = y[y.Count - 2] * (C / nod);
            }
            else
            {
                nod = NOD(A, B);
                x1 = x[x.Count - 2] * (C / nod);
            }
            while (x1 > B / nod)
            {
                x1 -= B / nod;
            } while (x1 < 0)
            {
                x1 += B / nod;
            }
            return x1;
        }
        public static long Lezhandr(long a, long n)
        {
            long SL = 1;
            long deg;
            if (Convert.ToInt32(Math.Sqrt(a)) == Convert.ToDouble(Math.Sqrt(a)))
                return 1;
            if (a < 0)
            {
                a *= -1;
                SL *= (int)Math.Pow(-1, (n - 1) / 2);
            }
            while (a != 0)
            {
                while (a > n)
                {
                    a -= n;
                }
                if (a == 1)
                    return SL;
                if (a == n)
                    return 0;
                if (a % 2 == 0)
                {
                    deg = 0;
                    while (a % 2 == 0)
                    {
                        deg += 1;
                        a /= 2;
                    }
                    if (deg % 2 != 0)
                        SL *= (int)Math.Pow(-1, (n * n - 1) / 8);
                }
                else
                {  //kzv
                    SL *= (int)Math.Pow(-1, (n - 1) * (a - 1) / 4);
                    long buf = a;
                    a = n;
                    n = buf;
                }
            }
            return SL;
        }
        public static long Gorner(List<long> koeff, long point, long mod)
        {
            long buf = koeff[0];
            for (int i = 1; i < koeff.Count; i++)
            {
                buf *= point;
                buf += koeff[i];
                buf %= mod;
                while (buf > mod)
                    buf -= buf;

                while (buf < 0)
                    buf += buf;
            }
            return buf;
        }
    }
}
