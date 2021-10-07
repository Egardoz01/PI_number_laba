using System;
using System.IO;
using System.Text;

namespace CountPI
{
    class Program
    {
        public static string piSpigot(int n)
        {
            //https://habr.com/ru/post/188700/
            // найденные цифры сразу же будем записывать в StringBuilder
            StringBuilder pi = new StringBuilder(n);
            int boxes = n * 10 / 3; // размер массива
            int[] reminders = new int[boxes];
            // инициализируем масив двойками
            for (int i = 0; i < boxes; i++)
            {
                reminders[i] = 2;
            }
            int heldDigits = 0;    // счётчик временно недействительных цифр
            for (int i = 0; i < n; i++)
            {
                if (i == 32)
                {
                    int ppl = 0;
                }
                int carriedOver = 0;    // перенос на следующий шаг
                int sum = 0;
                for (int j = boxes - 1; j >= 0; j--)
                {
                    reminders[j] *= 10;
                    sum = reminders[j] + carriedOver;
                    int quotient = sum / (j * 2 + 1);   // результат деления суммы на знаменатель
                    reminders[j] = sum % (j * 2 + 1);   // остаток от деления суммы на знаменатель
                    carriedOver = quotient * j;   // j - числитель
                }
                reminders[0] = sum % 10;
                int q = sum / 10;   // новая цифра числа Пи
                                    // регулировка недействительных цифр
                if (q == 9)
                {
                    heldDigits++;
                }
                else if (q == 10)
                {
                    q = 0;
                    for (int k = 1; k <= heldDigits; k++)
                    {
                        int replaced = int.Parse(pi.ToString(i - k, 1));
                        if (replaced == 9)
                        {
                            replaced = 0;
                        }
                        else
                        {
                            replaced++;
                        }
                        pi.Remove(i - k, 1);
                        pi.Insert(i - k, replaced);
                    }
                    heldDigits = 1;
                }
                else
                {
                    heldDigits = 1;
                }
                pi.Append(q);   // сохраняем найденную цифру
            }
            if (pi.Length >= 2)
            {
                pi.Insert(1, '.');  // добавляем в строчку точку после 3
            }
            return pi.ToString();
        }
        static void Main(string[] args)
        {

            File.WriteAllText("pi.txt", piSpigot(500000));
        }
    }
}
