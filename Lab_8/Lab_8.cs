using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    static void Main()
    {
        // Инициализация драйвера Chrome
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            // Открываем первую вкладку со стихами Пушкина
            driver.Navigate().GoToUrl("https://www.culture.ru/literature/poems/author-aleksandr-pushkin");
            Console.WriteLine("Открыта вкладка со стихами Пушкина.");

            // Извлекаем названия первых восьми стихотворений
            wait.Until(d => d.FindElements(By.CssSelector("div.poem__title")).Count >= 8); // Ожидание появления хотя бы 8 стихов
            var poemsElements = driver.FindElements(By.CssSelector("div.poem__title"));
            List<string> poems = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                poems.Add(poemsElements[i].Text);
            }

            // Открываем новую вкладку для переводчика
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('https://translate.google.com', '_blank');");
            Console.WriteLine("Открыта вкладка переводчика.");

            // Переключаемся на вкладку переводчика
            var windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);

            // Ожидаем загрузки страницы переводчика
            wait.Until(d => d.FindElement(By.CssSelector("textarea[aria-label='Source text']")));
            IWebElement inputArea = driver.FindElement(By.CssSelector("textarea[aria-label='Source text']"));
            IWebElement outputArea;

            // Переменная для хранения переведенных стихотворений
            List<string> translatedPoems = new List<string>();

            // Перевод каждого стихотворения
            for (int i = 0; i < poems.Count; i++)
            {
                inputArea.Clear();
                inputArea.SendKeys(poems[i]);

                // Ожидаем, пока появится переведенный текст
                wait.Until(d => d.FindElement(By.CssSelector("span[jsname='W297wb']")).Text.Length > 0);
                outputArea = driver.FindElement(By.CssSelector("span[jsname='W297wb']"));
                translatedPoems.Add(outputArea.Text);

                Console.WriteLine($"Стихотворение {i + 1} переведено.");
            }

            // Запись в файл
            using (StreamWriter writer = new StreamWriter("translated_poems.txt"))
            {
                for (int i = 0; i < poems.Count; i++)
                {
                    writer.WriteLine($"Стихотворение {i + 1}:");
                    writer.WriteLine("Оригинал:");
                    writer.WriteLine(poems[i]);
                    writer.WriteLine("Перевод:");
                    writer.WriteLine(translatedPoems[i]);
                    writer.WriteLine(new string('-', 50)); // Разделитель
                }
            }

            Console.WriteLine("Результаты записаны в файл translated_poems.txt.");
        }
        finally
        {
            // Закрытие браузера
            driver.Quit();
        }
    }
}
