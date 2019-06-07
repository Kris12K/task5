using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_393b
{
    public class Program
    {
        //функция проверки ввода целого числа
        public static int CheckInputInt(string message, int minValue, int maxValue)
        //(сообщение, мин вводимое значение, макс вводимое значение)
        {
            int input; //переменная, которой будет присвоено значение, введенное с клавиатуры
            do
            {
                input = maxValue + 1;  //переменной присваивается значение, выходящее за макс значение
                Console.WriteLine(message); //печать сообщения
                try
                {
                    string buf = Console.ReadLine();
                    input = Convert.ToInt16(buf);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
            } while ((input < minValue) || (input > maxValue)); //пока значение больше макс/меньше мин
            return input;
        }
        

        public static Random rnd = new Random();
        //заполнить матрицу случайными числами
        static int[,] FillRandomMatrix(int[,] matrix, int minValue, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(minValue, maxValue);
            }

            return matrix;
        }
        //заполнить матрицу числами с клавиатуры
        public static int[,] FillatrixByKeyboard(int[,] matrix, int minValue, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = CheckInputInt($"Введите элемент({i + 1};{j + 1}) от {minValue} до {maxValue}",minValue,maxValue);
            }

            return matrix;
        }

        //напечатать матрицу
        public static void PrintMatr(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t");

                Console.WriteLine();
            }
        }

        //функция, возвращающая массив первых положительных элементов в строках матрицы
        public static int[] FirstPositiveNumberInStrings(int[,]matrix)
        {
            if (matrix != null)
            {
                //выделение памяти под массив элементов
                int[] arrayOfFirstPositiveNumbers = new int[matrix.GetLength(0)];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            //если элемент в строке больше нуля, 
                            //то записать элемент в массив под индексом, соответствующим индексу строки матрицы
                            //и перейти на следующую строку
                            arrayOfFirstPositiveNumbers[i] = matrix[i, j]; break;
                        }
                    }
                }

                for (int i = 0; i < arrayOfFirstPositiveNumbers.Length; i++)
                //если значение массива равно 0,то в строке матрицы не было положительных элементов
                //значит записать в массив вместо нуля единицу
                    if (arrayOfFirstPositiveNumbers[i] == 0)
                        arrayOfFirstPositiveNumbers[i] = 1;

                return arrayOfFirstPositiveNumbers;
            }
            else
                throw new NullReferenceException();
           
        }
        static void Main(string[] args)
        {
            //программа находит первые положительные элементы в строках квадратной матрицы и записывает их в массив

            int n = CheckInputInt("Введите n (от  до 100)", 1, 100);//ввод массива матрицы и проверка ввода
            int[,] matrix = new int[n, n];//выделение памяти под квадратную матрицу
            matrix = FillRandomMatrix(matrix, -100, 100);//заполнение матрицы случайными элементами
            Console.WriteLine("Матрица:");
            PrintMatr(matrix);//печать матрицы
            
            int[] arrayOfFirstPositiveNumbers = new int[matrix.GetLength(0)];//выделение памяти 
            arrayOfFirstPositiveNumbers = FirstPositiveNumberInStrings(matrix);//заполнение массива 
                                             //первыми положительными элементами в строках матрицы
            Console.WriteLine("Массив первых положительных элементов в строках:");
            foreach (int a in arrayOfFirstPositiveNumbers)//печать массива
                Console.Write(a + "\t");
            Console.WriteLine();
            
        }
    }
}
