using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatStat
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] list = { 4, 4, 3, 2, 6, 2, 5, 6, 3, 5, 2,
                3, 4, 3, 4, 4, 2, 5, 5, 1, 4, 5, 4, 3, 4, 2, 4,
                1, 3, 4, 4, 4, 5, 1, 5, 4, 4, 6, 3, 3, 6, 4, 4,
                4, 6, 2, 3, 2, 5, 4, 6, 3,
                7, 8, 1, 1, 4, 3, 6, 5, 3, 4, 3, 3, 4, 6, 5, 5,
                4, 4, 6, 4, 4, 6, 4, 4, 3, 5, 4, 4, 7, 5, 5, 7,
                3, 4, 1, 5, 3, 5, 5, 5, 6, 3, 3, 3, 3, 5, 3, 5};
            List<double> data = new List<double>(list);
            List<double> N =
                new List<double>(new double[] {0, 6, 7, 22, 30, 20, 11, 3, 1 });
            List<double> p = new List<double>();
            for (int i = 0; i <=9 ; i++)
            {
                p.Add(Fact(9) * Math.Pow(0.446, i) * Math.Pow(0.554, 9 - i) / Fact(i) / Fact(9 - i));
            }
            Console.WriteLine("P[i]");
            double one = 0;
            foreach (var item in p)
            {
                Console.Write(" ");
                Console.Write(item);
                one += item;
            }
            Console.WriteLine("One: {0}", one);

            data.Sort();
            
            
            List<double> P_new = new List<double>();
            P_new.Add(0);
            P_new.Add(p[0]+p[1] + p[2]);
            P_new.Add(p[3]);
            P_new.Add(p[4]);
            P_new.Add(p[5]);
            P_new.Add(p[6] + p[7] + p[8]+p[9]);
            

            List<double> N_new = new List<double>();
            N_new.Add(0);
            N_new.Add(N[1] + N[2]);
            N_new.Add(N[3]);
            N_new.Add(N[4]);
            N_new.Add(N[5]);
            N_new.Add(N[6] + N[7] + N[8]);

            double Xi = 0;
            for (int i = 1; i <= 5; i++)
            {
                Xi += Math.Pow((N_new[i] - 100 * P_new[i]), 2) / (100 * P_new[i]);
            }
            Console.WriteLine("Xi = {0} ", Xi);

            Console.WriteLine();
            for (int i = 0; i <=9; i++)
            {
                Console.Write("{0} ",p[i]);
            }
            Console.WriteLine();
            for (int i = 1; i <=5; i++)
            {
                Console.Write("{0} ",P_new[i]);
            }
            Console.WriteLine();
            double E = 0;

            foreach (var item in data)
            {
                E += item;
                Console.Write("{0} ", item);
            }
            Console.WriteLine("\nSeredne:");
            E /= 100;
            Console.WriteLine(E);

            double As = 0;
            double u = 0;
            double l = 0;
            for (int i = 0; i < list.Length; i++)
            {
                u += Math.Pow((list[i] - E), 3)/100;
                l = Math.Pow(2.15, 1.5);
            }
            As = u / l;
            Console.WriteLine("As : {0} ",As);

            double Ex = 0;
            for (int i = 0; i < list.Length; i++)
            {

            }
           

            Console.WriteLine();
            double[] w = new double[9];
            double[] w_h = new double[9];
            for(int i =1; i<9; i++)
            {
                w[i] = N[i] / 100;
                w_h[i] = w_h[i - 1] + w[i];
                Console.Write("W[{0}] = {1} ", i, w[i]);
                Console.Write("W_h[{0}] = {1} ", i, w_h[i]);
                Console.WriteLine();

            }
            Console.WriteLine();
            foreach (var item in N_new)
            {
                Console.Write("{0} ", item);
            }
            
 
            Console.ReadKey(); 
        }
      static double Fact(double x)
    {
        double result = 1;
        for(int i = (int)x; i>=1; i--)
        {
            result *= i;
        }
        return result;
    }
   
    }
  
}
