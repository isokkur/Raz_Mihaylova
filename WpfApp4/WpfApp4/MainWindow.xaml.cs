using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Главное окно приложения, содержащее логику обработки файлов.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "ProcessFileButton"
        private async void ProcessFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем параметры из текстовых полей и чекбокса
            string inputFile = InputFileTextBox.Text;
            string outputFile = OutputFileTextBox.Text;
            int minWordLength = int.Parse(MinWordLengthTextBox.Text);
            bool removePunctuation = RemovePunctuationCheckBox.IsChecked ?? false;

            // Асинхронно запускаем обработку файла в отдельном потоке
            await Task.Run(() => ProcessFile(inputFile, outputFile, minWordLength, removePunctuation));

            // Отображаем сообщение об успешном завершении обработки файла
            MessageBox.Show("File processing completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Метод обработки файла с указанными параметрами
        private void ProcessFile(string inputFile, string outputFile, int minWordLength, bool removePunctuation)
        {
            try
            {
                // Читаем все строки из входного файла
                string[] lines = File.ReadAllLines(inputFile);
                List<string> processedLines = new List<string>();

                // Обходим каждую строку и обрабатываем её
                foreach (string line in lines)
                {
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder processedLine = new StringBuilder();

                    // Обходим каждое слово в строке и обрабатываем его
                    foreach (string word in words)
                    {
                        if (word.Length >= minWordLength)
                        {
                            string processedWord = word;

                            // Удаляем пунктуацию, если указано
                            if (removePunctuation)
                            {
                                processedWord = Regex.Replace(processedWord, @"[^\w\s]", "");
                            }

                            processedLine.Append(processedWord + " ");
                        }
                    }

                    // Добавляем обработанную строку в список
                    processedLines.Add(processedLine.ToString().Trim());
                }

                // Записываем обработанные строки в выходной файл
                File.WriteAllLines(outputFile, processedLines);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение об ошибке
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
