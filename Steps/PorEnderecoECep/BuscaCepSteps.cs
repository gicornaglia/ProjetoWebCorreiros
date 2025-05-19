using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoWebCorreiros.PageObjects.PorEnderecoECep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebCorreiros.Steps.PorEnderecoECep
{
    public class BuscaCepSteps : Hooks
    {
        public static void DigitaCepInvalidoNoCampoCep(string Cep)
        {
            Driver.FindElement(BuscaCepPage.campoProcuraCep).SendKeys(Cep); 
        }

        public static void ClickBotaoBuscar()
        {
            Driver.FindElement(BuscaCepPage.BotaoBuscar).Click();
        }
     
    }
}
