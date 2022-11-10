using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите левую границу: ");
            float leftBorder = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите правую границу: ");
            float rightBorder = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine();
            Figure figure = new Figure(leftBorder, rightBorder);
            
            figure.Work(figure);
        }
    }
    

}
