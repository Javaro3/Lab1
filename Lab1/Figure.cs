using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Figure
    {
        private float _leftBorder, _rightBorder;

        public Figure(float leftBorder, float rightBorder)
        {
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
        }

        public Figure()
        {
            _leftBorder = 1.0f;
            _rightBorder = 2.0f;
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Левая граница - {_leftBorder}. Правая граница - {_rightBorder}. Формула гиперболы  - y = 1/x.");
        }

        private bool IsPosible()
        {
            return _rightBorder > _leftBorder && (_leftBorder < 0 && _rightBorder < 0 || _leftBorder > 0 && _rightBorder > 0);
        }

        public float GetDownSide()
        {
            return (float)Math.Abs(_leftBorder - _rightBorder);
        }

        private float GetUpSide()
        {
            float upLenght = 0f;
            for (float i = _leftBorder; i < _rightBorder; i += 0.0001f)
            {
                upLenght += (float)(Math.Sqrt(1 + 1/(Math.Pow(i, 4))) * 0.0001f);
            }
            return upLenght;
        }

        private float GetLeftSide()
        {
            return (float)Math.Sqrt(Math.Pow((1 / _leftBorder), 2));
        }

        private float GetRightSide()
        {
            return (float)Math.Sqrt(Math.Pow((1/_rightBorder), 2));
        }

        private float GetArea()
        {
            return (float)(Math.Log(_rightBorder) - Math.Log(_leftBorder));
        }

        private float GetPerimeter()
        {
            return GetDownSide() + GetUpSide() + GetRightSide() + GetLeftSide();
        }

        private bool ThisPointPosible(float x, float y)
        {
            if(_leftBorder < 0 && _rightBorder < 0)
                return x >= _leftBorder && x <= _rightBorder && y >= 1/x && y <= 0;
            else if(_leftBorder > 0 && _rightBorder > 0)
                return x >= _leftBorder && x <= _rightBorder && y <= 1 / x && y >= 0;
            return false;
        } 

        public void Work(Figure figure)
        {
            int choose;
            bool menuIsWork = true;

            while (menuIsWork)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Проверить возможна ли такая фигура");
                Console.WriteLine("2. Вывести данные о фигуре");
                Console.WriteLine("3. Вывести длинну левой стороны");
                Console.WriteLine("4. Вывести длинну правой стороны");
                Console.WriteLine("5. Вывести длинну верхней стороны");
                Console.WriteLine("6. Вывести длинну нижней стороны");
                Console.WriteLine("7. Вывести периметр");
                Console.WriteLine("8. Вывести площадь");
                Console.WriteLine("9. Проверить принадлежит ли точка фигуре");
                Console.WriteLine("10. Задать новую фигуру");
                Console.WriteLine("11. Выход");
                Console.Write("Ваш выбор: ");
                choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choose)
                {
                    case 1:
                        if (figure.IsPosible())
                            Console.WriteLine("Такая фигура существует");
                        else
                            Console.WriteLine("Такая фигура не существует");
                        break;
                    case 2:
                        figure.ShowInfo();
                        break;
                    case 3:
                        Console.WriteLine($"Длинна левой стороны - {figure.GetLeftSide()}");
                        break;
                    case 4:
                        Console.WriteLine($"Длинна правой стороны - {figure.GetRightSide()}");
                        break;
                    case 5:
                        Console.WriteLine($"Длинна верхней стороны - {figure.GetUpSide()}");
                        break;
                    case 6:
                        Console.WriteLine($"Длинна нижней стороны - {figure.GetDownSide()}");
                        break;
                    case 7:
                        Console.WriteLine($"Периметр фигуры - {figure.GetPerimeter()}");
                        break;
                    case 8:
                        Console.WriteLine($"Площадь фигуры - {figure.GetArea()}");
                        break;
                    case 9:
                        Console.Write("Введите координату точки по X: ");
                        float x = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите координату точки по Y: ");
                        float y = Convert.ToSingle(Console.ReadLine());
                        if (figure.ThisPointPosible(x, y))
                            Console.WriteLine("Данная точка лежит на искомой фигуре");
                        else
                            Console.WriteLine("Данная точка не лежит на искомой фигуре");
                        break;
                    case 10:
                        Console.Write("Введите левую границу: ");
                        float leftBorder = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите правую границу: ");
                        float RightBorder = Convert.ToSingle(Console.ReadLine());
                        
                        figure = new Figure(leftBorder, RightBorder);
                        break;
                    case 11:
                        menuIsWork = false;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}