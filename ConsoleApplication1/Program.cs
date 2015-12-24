using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string a1 = "00001111112222222223333334444444444,32111";
            Console.WriteLine(a1);
            var a = Inc(a1);
            Console.WriteLine(a);
            Console.ReadKey();
        }

        public static string Inc(string stInt)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            return IncrementClass2.Inc(stInt);

            //string st1= IncrementClass2.Inc(stInt);
            //Debug.WriteLine(sw.ElapsedMilliseconds);
            //sw.Reset();
            //string st = IncrementClass1.Inc(stInt);
            //Debug.WriteLine(sw.ElapsedMilliseconds);
            //return st;
        }
    }
}
