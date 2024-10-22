
using System;
using System.Windows;

namespace Tringle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных о сторонах треугольника
            int side1, side2, side3;

            if (!TryParseSide(One.Text, out side1) ||
                !TryParseSide(Two.Text, out side2) ||
                !TryParseSide(Three.Text, out side3))
            {
                return; // Ввод невалидный, сообщение об ошибке уже выведено
            }

            // Проверка, является ли ввод допустимым треугольником
            if (!IsValidTriangle(side1, side2, side3))
            {
                MessageBox.Show("Введенные данные не образуют треугольник. Проверьте, что сумма любых двух сторон больше третьей стороны.");
                return;
            }

            // Определение типа треугольника
            string triangleType = DetermineTriangleType(side1, side2, side3);

            // Вывод результата
            MessageBox.Show("Полученный треугольник: " + triangleType + ".", "Результат");
        }

        // Метод для попытки преобразования строки в сторону треугольника
        private bool TryParseSide(string input, out int side)
        {
            bool isValid = int.TryParse(input, out side) && side > 0;

            if (!isValid)
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное целое число для стороны треугольника.");
            }

            return isValid;
        }

        // Проверка, является ли ввод допустимым треугольником
        private bool IsValidTriangle(int side1, int side2, int side3)
        {
            return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
        }

        // Определение типа треугольника
        private string DetermineTriangleType(int side1, int side2, int side3)
        {
            // Проверка на равносторонний треугольник
            if (side1 == side2 && side2 == side3)
            {
                return "Равносторонний";
            }

            // Проверка на равнобедренный треугольник
            if (side1 == side2 || side1 == side3 || side2 == side3)
            {
                return "Равнобедренный";
            }

            // Если не равносторонний и не равнобедренный, то просто треугольник
            return "Треугольник";
        }
    }
}
