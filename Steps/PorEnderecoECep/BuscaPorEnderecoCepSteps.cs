using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoWebCorreiros.PageObjects.PorEnderecoECep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebCorreiros.Steps.PorEnderecoECep
{
    public class BuscaPorEnderecoCepSteps : Hooks
    {
        public static void ValidarCampoBuscaCepComInformacoesInvalidas(string Cep)
        {            
            BuscaCepSteps.DigitaCepInvalidoNoCampoCep(Cep);
            BuscaCepSteps.ClickBotaoBuscar();
            string MensagemRetorno = "Dados não encontrado";
            string MensagemElemento = Driver.FindElement(BuscaCepPage.MensagemDadosNaoEncontrados).Text.ToString();
            Assert.IsTrue(MensagemElemento.Contains(MensagemRetorno), "Dados não encontrados");

        }
        public static void ValidarCampoBuscaCepComInformacoesvalidas(string Cep, string NomeDaRua, string NomeDoBairro, string Uf)
        {
            BuscaCepSteps.DigitaCepInvalidoNoCampoCep(Cep);
            BuscaCepSteps.ClickBotaoBuscar();

            string Lograduro = Driver.FindElement(BuscaCepPage.Lograduro).Text.ToString();
            string Bairro = Driver.FindElement(BuscaCepPage.Bairro).Text.ToString();
            string Localidade = Driver.FindElement(BuscaCepPage.Localidade).Text.ToString();
            string Cep1 = Driver.FindElement(BuscaCepPage.Cep).Text.ToString();

            Assert.IsTrue(Lograduro.Contains(NomeDaRua), "contém o nome da rua ");
            Assert.IsTrue(Bairro.Contains(NomeDoBairro), "contém o nome do Bairro");
            Assert.IsTrue(Localidade.Contains(Uf), "contém o nome da Localidade ");
            Assert.IsTrue(Cep1.Contains(Cep), "contém o Cep");

        }
        public static void ValidarCampoBuscaCepComUmDigito(string Cep)
        {
            BuscaCepSteps.DigitaCepInvalidoNoCampoCep(Cep);
            BuscaCepSteps.ClickBotaoBuscar();

            string MensagemErro1 = "Informe o Endereço com no mínimo 2(dois) caracteres!";
            string MensagemErro2 = Driver.FindElement(BuscaCepPage.MensagemDigiteDoisNumero).Text.ToString();
            Assert.IsTrue(MensagemErro1.Contains(MensagemErro2), "Dados não encontrados");
        }

        public static void ValidarCampoEsseCepEde(string Cep, string Localidade)
        {
            BuscaCepSteps.DigitaCepInvalidoNoCampoCep(Cep);
            //Escolhe opções no campo @Esse cep é de? 
            Driver.FindElement(BuscaCepPage.CampoEsseCepEDe).SendKeys(Localidade);
            BuscaCepSteps.ClickBotaoBuscar();

            string Localidade1 = Driver.FindElement(BuscaCepPage.Localidade).Text.ToString();
            if (Localidade1 == ("Rua Barão de Tramandaí"))
            {
                Assert.IsTrue(Localidade1 == ("Rua Barão de Tramandaí"), "Rua Barão de Tramandaí");
            }

            else if (Localidade1 != "Dados não encontrado")
            {
                Assert.Fail("Dados não encontrado");
            }

        }
    }
}
