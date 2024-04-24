using System; 
namespace MatrixMultiplication 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Введите два числа x и y для создания матрицы умножения:"); 
            int x, y; 
            bool isValidInput = false; // Объявление переменной isValidInput, отвечающей за корректность ввода

            // Цикл для ввода и проверки числа x
            do
            {
                Console.Write("Введите число x: "); 
                if (!int.TryParse(Console.ReadLine(), out x)) // Попытка преобразования введенной строки в int
                {
                    Console.WriteLine("Ошибка: Некорректный ввод числа x. Попробуйте снова."); 
                }
                else
                {
                    isValidInput = true; // Установка  корректности ввода
                }
            } while (!isValidInput); // Повторять, пока ввод не будет корректным

            isValidInput = false; // Сброс  для числа y

            // Цикл для ввода и проверки числа y
            do
            {
                Console.Write("Введите число y: "); 
                if (!int.TryParse(Console.ReadLine(), out y)) // Попытка преобразования введенной строки в int
                {
                    Console.WriteLine("Ошибка: Некорректный ввод числа y. Попробуйте снова.");
                }
                else
                {
                    isValidInput = true; // Установка  корректности ввода
                }
            } while (!isValidInput); // Повторять, пока ввод не будет корректным

            Console.WriteLine("Матрица умножения:");

            // Вложенные циклы для создания и вывода матрицы умножения
            for (int i = 1; i <= y; i++) // Цикл по строкам
            {
                for (int j = 1; j <= x; j++) // Цикл по столбцам
                {
                    Console.Write(i * j + " "); // Вывод элемента матрицы (произведение индексов)
                }
                Console.WriteLine(); 
            }
        }
    }
}