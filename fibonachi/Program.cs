using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using fibonachi;
using halfdel;
using Golden;

void main()
{
    Console.WriteLine("Выберите один из 3 способов для решения уравнения:\n1.Метод половинного деления\n2.Метод золотого сечения\n3.Метод чисел Фибоначчи");
    int n = int.Parse(Console.ReadLine());
    switch (n) {
        case 1:
            halfdelete halfdeletee = new halfdelete();
            break;
        case 2:
            TrueGold Goldenn = new TrueGold();
            break;
        case 3:
            Fibbonachi Fib = new Fibbonachi();
            break;
    default:
            Console.WriteLine("Некорректный ввод");
            break;
    }
}
main();

