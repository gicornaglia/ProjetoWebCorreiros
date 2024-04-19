using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace ProjetoWebCorreiros
{
    public class Hooks
    {
        #region Variáveis globais

        private static ChromeDriver ChromeDriver;
        public static EventFiringWebDriver Driver; // consigo add eventos, ele tira a foto e coloca no nosso report
        public static string Report;

        #endregion Variáveis globais

        #region Atributos
        // vai acontecer sempre antes (initialize) e depois(Cleanup) do metodo de teste 
        // essa CLASSE HOOKS fazemos somente uma vez dentro do projeto, posso copiar e colar no projeto novo
        [TestInitialize]
        public void MyTestInitialize()
        {
            ChromeDriver = new ChromeDriver("Deploy");
            ChromeDriver.Url = "https://buscacepinter.correios.com.br/app/endereco/index.php";
            ChromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60); //Comando para que toda vez que mudar a URL ele esperar 60 segundos
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60); // Comando para toda esperar 60 segundos para procurar o elemento e não quebrar 
            ChromeDriver.Manage().Window.Maximize();
            Driver = new EventFiringWebDriver(ChromeDriver);

            //Esse comando, criamos uma variavel testResultDir,usei o metodo path para combinar dois caminhos (onde esta a pasta bin, e cria uma´pasta testeResults)
            //NOME DO DIRETÓRIO 
            var testResultsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults");

            // Esse comando é se não tiver esse diretorio na pasta bin então é para ser criado
            if (!Directory.Exists(testResultsDir))
            {
                Directory.CreateDirectory(testResultsDir);
            }

            //Comando que diz o NOME DO REPORT que vai contem tbm o data hora e  a extensão do html

            Report = Path.Combine(testResultsDir, $"{TestContext.TestName.Replace("(System.String)", "")}_{DateTime.Now:ddMMyyyyTHHmmss}.html");

            Report.LogMessage($"{TestContext.TestName.Replace("(System.String)", "")} @OUTCOME<hr/>"); //mensagem que vai aparecer no log e no html 

            Driver.FindElementCompleted += Driver_FindElementCompleted;
            Driver.ElementClicking += Driver_ElementClicking;
            Driver.ElementValueChanging += Driver_ElementValueChanging;


        }
        //Metodo toda vez que digitar, vai escrever no report o nome do elemento que digitou e o conteudo
        private void Driver_ElementValueChanging(object sender, WebElementValueEventArgs e)
        {
            Report.LogMessage($"SendKeys: {e.Value}| Elemento: {e.Element.TagName} {e.Element.Text}<hr/>");
        }

        //Metodo toda vez que der click, vai escrever no report o nome do elemento que clicou 
        private void Driver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Report.LogMessage($"Click | Elemento: {e.Element.TagName} {e.Element.Text}<hr/>");
        }

        //METODO DRIVE Mostra no report o elemento e tira uma imagem 
        private void Driver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
            Report.LogMessage($"Elemento encontrado pelo localizador: {e.FindMethod}");
            Report.LogMessage($"<img style='width:50%;height:auto;' src='data:image/png; base64, {Driver.GetScreenshot().AsBase64EncodedString}'/></center>");
        }



        [TestCleanup]
        public void MyTestCleanup()
        {
            // Comando para printar a ultima tela e aparecer o report html 
            Report.LogMessage($"<p>Ultima Tela Apresentada</p><img style='Width:50%;height:auto;' src='data:image/png; base64, {Driver.GetScreenshot().AsBase64EncodedString}'/><hr/>");

            ChromeDriver.Quit();
            Driver.Quit();

            File.WriteAllText(Report, File.ReadAllText(Report).Replace("@OUTCOME", TestContext.CurrentTestOutcome.ToString()));

            Console.WriteLine("Link");
            testContext.AddResultFile(Report);
            Console.WriteLine(Report);

        }

        #endregion Atributos 

        #region Propriedades 

        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        #endregion Propriedades 


    }
}