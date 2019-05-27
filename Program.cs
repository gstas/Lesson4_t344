using System;

namespace Lesson4_t344
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            344.	Имеются 10 гирь весом 
            100, 200, 300, 500, 1000, 1200, 1400, 1500, 2000 и 3000 г. 
            Сколькими способами гирями этого набора можно 
            составить вес в v граммов (v кратно 100)?
            */

            int[] weights = { 3000, 2000, 1500, 1400, 1200, 1000, 500, 300, 200, 100 };

            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Введите необходимый вес в граммах (кратно 100): ");
                    int needWeight = Convert.ToInt32(Console.ReadLine());

                    if (needWeight % 100 != 0)
                        throw new Exception("Введённый вес не кратен 100!");

                    if (needWeight > 11200)
                        throw new Exception($"Необходимый вес превышает сумму весов всех гирь!");

                    for (int a = 0; a < 1023; a++)
                    {
                        int b = a;
                        int summ = 0;
                        string result = "";

                        for (int i = 0; i < 10; i++)
                        {
                            int last = b & 1;
                            if (last == 1)
                            {
                                summ += weights[i];
                                result += weights[i] + ";";
                            }

                            b = b >> 1;
                        }
                        if (summ == needWeight)
                            Console.WriteLine(result);
                    }

                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Нажмите <Enter> для повтора...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } 

        }

    }
}
