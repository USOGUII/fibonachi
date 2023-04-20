using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonachi
{
    class Fibbonachi
    {
        public Fibbonachi()
        {
            double Fibonachi(double Income)
            {
                double First = 1;
                double Second = 1;
                double Number = 1;
                if (Income <= 1)
                {
                    return 3;
                }
                else
                {
                    for (Number = 1; Income >= (First + Second); Number++)
                    {
                        double FirstCopy = First;
                        First = Second + First;
                        Second = FirstCopy;
                    }
                    return Number + 2;
                }
            }

            static double Fib(double n)
            {
                return (n < 2) ? n : Fib(n - 1) + Fib(n - 2);
            }

            Console.WriteLine("Введите коэфициент перед x^3:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэфициент перед x^2:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэфициент перед x:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение свободного члена:");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение константы различимости:");
            double Accuracy = double.Parse(Console.ReadLine());
            double[] leftk = new double[20];
            double[] rightk = new double[20];
            Console.WriteLine("Введите значение левого края интервала L:");
            double left = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение правого края интервала L:");
            double right = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение допустимой длины конечного интервала:");
            double l = double.Parse(Console.ReadLine());

            int k = 0;
            double L1 = Accuracy + 1;
            leftk[k] = left;
            rightk[k] = right;
            double N = Fibonachi(Math.Abs(left - right) / l);
            double[] yk = new double[20];
            double y = leftk[k] + (Fib(N - 2) / Fib(N)) * (rightk[k] - leftk[k]);
            yk[k] = y;
            double[] zk = new double[20];
            double z = leftk[k] + (Fib(N - 1) / Fib(N)) * (rightk[k] - leftk[k]);
            zk[k] = z;
            double x;
            int n;
            for (k = 0; ; k++)
            {
                double fyk = (Math.Pow(yk[k], 3) * a + Math.Pow(yk[k], 2) * b + yk[k] * c + d);
                double fzk = (Math.Pow(zk[k], 3) * a + Math.Pow(zk[k], 2) * b + zk[k] * c + d);
                if (fyk <= fzk)
                {
                    leftk[k + 1] = leftk[k];
                    rightk[k + 1] = zk[k];
                    zk[k + 1] = yk[k];
                    yk[k + 1] = leftk[k + 1] + (Fib(N - k - 3) / Fib(N - k - 1)) * (rightk[k + 1] - leftk[k + 1]);
                }
                else
                {
                    leftk[k + 1] = yk[k];
                    rightk[k + 1] = rightk[k];
                    yk[k + 1] = zk[k];
                    zk[k + 1] = leftk[k + 1] + (Fib(N - k - 2) / Fib(N - k - 1)) * (rightk[k + 1] - leftk[k + 1]);
                }
                if (k != N - 3)
                {
                    Console.WriteLine($"Итерация #{k + 1}:\nНовый интервал значений - [{leftk[k + 1]};{rightk[k + 1]}]. Значение z = {zk[k]}. Значение f(z) = {fzk}. Значение y = {yk[k]}. Значение f(y) = {fyk}.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Итерация #{k + 1}:\nНовый интервал значений - [{leftk[k + 1]};{rightk[k + 1]}]. Значение z = {zk[k]}. Значение f(z) = {fzk}. Значение y = {yk[k]}. Значение f(y) = {fyk}.");
                    n = (int)N;
                    yk[n - 2] = ((leftk[n - 2] + rightk[n - 2]) / 2);
                    zk[n - 2] = ((leftk[n - 2] + rightk[n - 2]) / 2);
                    yk[n - 1] = yk[n - 2];
                    zk[n - 1] = yk[n - 1] + Accuracy;
                    fyk = (Math.Pow(yk[n - 1], 3) * a + Math.Pow(yk[n - 1], 2) * b + yk[n - 1] * c + d);
                    fzk = (Math.Pow(zk[n - 1], 3) * a + Math.Pow(zk[n - 1], 2) * b + zk[n - 1] * c + d);
                    if (fyk <= fzk)
                    {
                        leftk[n - 1] = leftk[n - 2];
                        rightk[n - 1] = zk[n - 1];
                    }
                    else
                    {
                        leftk[n - 1] = yk[n - 1];
                        rightk[n - 1] = rightk[n - 2];
                    }
                    x = (leftk[n - 1] + rightk[n - 1]) / 2;
                    Console.WriteLine($"x*={x}, f(x*)={(Math.Pow(x, 3) * a + Math.Pow(x, 2) * b + x * c + d)}, Количество итераций k={k + 1}");
                    break;
                }
            }
        }
    }
}
