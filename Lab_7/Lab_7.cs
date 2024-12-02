

using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        
        IWebDriver driver = new ChromeDriver();

        try
        {
            
            driver.Navigate().GoToUrl("https://en.wikipedia.org");
            Console.WriteLine("Открыта первая вкладка: https://en.wikipedia.org");

            
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('https://ru.wikipedia.org', '_blank');");
            Console.WriteLine("Открыта вторая вкладка: https://ru.wikipedia.org");

            
            var windowHandles = driver.WindowHandles;

            
            driver.SwitchTo().Window(windowHandles[1]);
            Console.WriteLine("Переключились на вторую вкладку (русская Википедия).");

            Thread.Sleep(5000);
            
            driver.Close();
            Console.WriteLine("Вторая вкладка закрыта.");

            
            driver.SwitchTo().Window(windowHandles[0]);
            Console.WriteLine("Переключились обратно на первую вкладку (английская Википедия).");

            
            Thread.Sleep(2000);
        }
        finally
        {
            
            driver.Quit();
        }
    }
}
