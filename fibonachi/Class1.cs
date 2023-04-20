using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace halfdel
{
    class halfdelete
    {
        public halfdelete()
        {
            Console.WriteLine("Введите коэфициент перед x^3:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэфициент перед x^2:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэфициент перед x:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение свободного члена:");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность:");
            double Accuracy = double.Parse(Console.ReadLine());
            double[] leftk = new double[20];
            double[] rightk = new double[20];
            Console.WriteLine("Введите значение левого края интервала L:");
            double left = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение правого края интервала L:");
            double right = double.Parse(Console.ReadLine());

            int k = 0;
            double[] xk = new double[20];
            double x = (left + right) / 2;
            xk[k] = x;
            double[] Lk = new double[20];
            double L = Math.Abs(right - left);
            Lk[k] = L;
            double L1 = Accuracy + 1;
            leftk[k] = left;
            rightk[k] = right;

            for (k = 0; L1 > Accuracy; k++)
            {
                double[] yk = new double[20];
                double y = leftk[k] + Lk[k] / 4;
                yk[k] = y;
                double[] zk = new double[20];
                double z = rightk[k] - Lk[k] / 4;
                zk[k] = z;
                double fxk = (Math.Pow(xk[k], 3) * a + Math.Pow(xk[k], 2) * b + xk[k] * c + d);
                double fyk = (Math.Pow(yk[k], 3) * a + Math.Pow(yk[k], 2) * b + yk[k] * c + d);
                double fzk = (Math.Pow(zk[k], 3) * a + Math.Pow(zk[k], 2) * b + zk[k] * c + d);
                if (fyk < fxk)
                {
                    rightk[k + 1] = xk[k];
                    leftk[k + 1] = leftk[k];
                    xk[k + 1] = yk[k];
                }
                else
                {
                    if (fzk < fxk)
                    {
                        leftk[k + 1] = xk[k];
                        rightk[k + 1] = rightk[k];
                        xk[k + 1] = zk[k];
                    }
                    else
                    {
                        leftk[k + 1] = yk[k];
                        rightk[k + 1] = zk[k];
                        xk[k + 1] = xk[k];
                    }
                }
                L1 = rightk[k + 1] - leftk[k + 1];
                L1 = Math.Abs(L1);
                Lk[k + 1] = L1;
                Console.WriteLine($"Итерация #{k + 1}:\nНовый интервал значений - [{leftk[k + 1]};{rightk[k + 1]}]. Значение z = {zk[k]}. Значение f(z) = {fzk}. Значение y = {yk[k]}. Значение f(y) = {fyk}. Значение x = {xk[k]}. Значение f(x) = {fxk}.");
            }
            Console.WriteLine($"x*={xk[k]}, f(x*)={(Math.Pow(xk[k], 3) * a + Math.Pow(xk[k], 2) * b + xk[k] * c + d)}, Количество итераций k={k}");
        }
    }
}
