using System.IO;
using System.Threading;
using OpenQA.Selenium;

namespace ProjetoWebCorreiros
{
    public static class Utils
    {
        public static void LogMessage(this string report, string message)
        {
            using (StreamWriter sw = new StreamWriter(report, true))
            {
                sw.WriteLine($"<h4>{message}</h4>"); //Escreve no log
            }
        }


        //Estrutura para quando a automação for digitar, ele espere um tempo
        // 1 seconds / ou 1000 miliseconds / ou  meio segundo 500 miliseconds
        public static void SendKeysCharByChar(this IWebElement element, string text, int miliseconds = 500)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (element != null && element.Enabled)
                {
                    foreach (var c in text.ToCharArray())
                    {
                        element.SendKeys(c.ToString());

                        Thread.Sleep(miliseconds);
                        // Para usar esse metodo, eu crio o Page Objects normal e quando eu for criar o steps de vez no final eu colocar .SendKeys(text);eu coloco .SendKeysCharByChar(text);               
                    }
                }
            }
        }
    }
}