using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golden
{
    class TrueGold
    {
        public TrueGold()
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
            double[] Lk = new double[20];
            Lk[k] = Accuracy + 1;
            leftk[k] = left;
            rightk[k] = right;

            double[] yk = new double[20];
            double y = leftk[k] + ((3 - Math.Sqrt(5)) / 2) * (rightk[k] - leftk[k]);
            yk[k] = y;
            double[] zk = new double[20];
            double z = rightk[k] + leftk[k] - yk[k];
            zk[k] = z;
            for (k = 0; Lk[k] > Accuracy; k++)
            {
                double fyk = (Math.Pow(yk[k], 3) * a + Math.Pow(yk[k], 2) * b + yk[k] * c + d);
                double fzk = (Math.Pow(zk[k], 3) * a + Math.Pow(zk[k], 2) * b + zk[k] * c + d);
                if (fyk <= fzk)
                {
                    leftk[k + 1] = leftk[k];
                    rightk[k + 1] = zk[k];
                    yk[k + 1] = leftk[k + 1] + rightk[k + 1] - yk[k];
                    zk[k + 1] = yk[k];
                }
                else
                {
                    leftk[k + 1] = yk[k];
                    rightk[k + 1] = rightk[k];
                    yk[k + 1] = zk[k];
                    zk[k + 1] = leftk[k + 1] + rightk[k + 1] - zk[k];
                }
                Lk[k + 1] = Math.Abs(leftk[k + 1] - rightk[k + 1]);
                Console.WriteLine($"Итерация #{k + 1}:\nНовый интервал значений - [{leftk[k + 1]};{rightk[k + 1]}]. Значение z = {zk[k]}. Значение f(z) = {fzk}. Значение y = {yk[k]}. Значение f(y) = {fyk}.");
            }
            double x = (leftk[k] + rightk[k]) / 2;
            Console.WriteLine($"x*={x}, f(x*)={(Math.Pow(x, 3) * a + Math.Pow(x, 2) * b + x * c + d)}, Количество итераций k={k}");
        }
    }
}
