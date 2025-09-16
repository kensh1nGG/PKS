using System;

class Program
{
    static double memory = 0;
    static double current = 0;
    
    static void Main()
    {
        Console.WriteLine("ПРОСТОЙ КАЛЬКУЛЯТОР");
        Console.WriteLine("Доступные операции: + - * / % i(1/x) s(x^2) q(√x) m+(M+) m-(M-) r(MR) c(clear) e(exit)");
        
        while (true)
        {
            Console.WriteLine($"\nТекущее значение: {current}");
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            
            if (input == "e") break;
            if (input == "c") { current = 0; continue; }
            if (input == "r") { current = memory; continue; }
            if (input == "m+") { memory += current; continue; }
            if (input == "m-") { memory -= current; continue; }
            if (input == "i") { if (current != 0) current = 1/current; else Console.WriteLine("Ошибка: Деление на 0!"); continue; }
            if (input == "s") { current = current * current; continue; }
            if (input == "q") { if (current >= 0) current = Math.Sqrt(current); else Console.WriteLine("Ошибка: Корень из отрицательного числа!"); continue; }
            
            if (double.TryParse(input, out double num))
            {
                current = num;
                continue;
            }
            
            if (input == "+" || input == "-" || input == "*" || input == "/" || input == "%")
            {
                Console.Write("Введите число: ");
                string numInput = Console.ReadLine();
                
                if (double.TryParse(numInput, out double secondNum))
                {
                    if (input == "+") current += secondNum;
                    if (input == "-") current -= secondNum;
                    if (input == "*") current *= secondNum;
                    if (input == "/") 
                    {
                        if (secondNum != 0) current /= secondNum;
                        else Console.WriteLine("Ошибка: Деление на 0!");
                    }
                    if (input == "%") current %= secondNum;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите число!");
                }
            }
        }
        
        Console.WriteLine("Работа завершена!");
    }
}
