using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebCorreiros.PageObjects.PorEnderecoECep
{
    public class BuscaCepPage : Hooks
    {
        public static By campoProcuraCep = By.XPath("//input[@id='endereco']");
        public static By BotaoBuscar = By.XPath("//button[@id='btn_pesquisar']");
        public static By MensagemDadosNaoEncontrados = By.XPath("//*[@id='mensagem-resultado-alerta']/h6");
        public static By Lograduro = By.XPath("//*[@id='resultado-DNEC']/tbody/tr/td[1]");
        public static By Bairro = By.XPath("//*[@id='resultado-DNEC']/tbody/tr/td[2]");
        public static By Localidade = By.XPath("//*[@id='resultado-DNEC']/tbody/tr/td[3]");
        public static By Cep = By.XPath("//*[@id='resultado-DNEC']/tbody/tr/td[4]");
        public static By RetornaCep = By.XPath("//td[@data-th='CEP']");
        public static By MensagemDigiteDoisNumero = By.XPath("//*[@id='alerta']/div[1]");
        public static By CampoEsseCepEDe = By.XPath("//*[@id='tipoCEP']");

        //Exemplos
        public static By BtnFaturamentoECobranca() { return By.XPath("//*[text()='Faturamento e Cobrança']"); }
        public static By CampoEmpresaGrid(string Empresa) { return By.XPath($"//td[@title='{Empresa}']"); }
        public static By MessageBaseHistorica() { return By.XPath("(//*[contains(text(), ' base Historica')])[1]"); }
        public static By CampoDeBuscaBase() { return By.XPath("(//span[@class='euiButton__text'])[1]"); }
    }
}
