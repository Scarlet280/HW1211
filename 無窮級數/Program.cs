// 學號: 1112410022 / 黃柏維
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. 輸入圓半徑和精度
        Console.Write("請輸入圓的半徑 (允許小數點): ");
        if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
        {
            Console.WriteLine("半徑輸入錯誤，請重新執行程式！");
            return;
        }

        Console.Write("請輸入圓週率的精度 (4 <= n <= 15): ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("精度輸入錯誤，請重新執行程式！");
            return;
        }

        // 2. 計算圓週率
        double pi = CountPi(n);
        if (pi == -1)
        {
            Console.WriteLine("精度超出允許範圍，程式結束！");
            return;
        }

        // 3. 輸出圓週率
        Console.WriteLine("圓週率的精度: {0}", n);
        Console.WriteLine("計算出來的圓週率: {0:g}", pi);

        // 4. 計算圓週長與圓面積
        double circumference = GetCircumference(radius, pi);
        double area = GetCircleArea(radius, pi);

        // 5. 輸出結果
        Console.WriteLine("圓的週長: {0}", circumference);
        Console.WriteLine("圓的面積: {0}", area);
    }

    // 計算圓週率函式
    static double CountPi(int n)
    {
        if (n < 4 || n > 15)
        {
            return -1; // 精度超範圍
        }

        double pi = 0.0;
        for (int i = 0; i <= n; i++)
        {
            pi += Math.Pow(-1, i) / (2 * i + 1);
        }

        return 4 * pi; // Leibniz公式的結果
    }

    // 計算圓週長函式
    static double GetCircumference(double r, double pi)
    {
        return 2 * pi * r;
    }

    // 計算圓面積函式
    static double GetCircleArea(double r, double pi)
    {
        return pi * r * r;
    }
}
