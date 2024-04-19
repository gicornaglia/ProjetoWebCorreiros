using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoWebCorreiros.Steps.PorEnderecoECep;

namespace ProjetoWebCorreiros.Features.PorEnderecoECep
{
    [TestClass]
    public class BuscaPorEnderecoCep : Hooks
    {
        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoBuscaCepComInformacoesInvalidas()
        {
            Report.LogMessage("Dado que: O usuário acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endereço");
            Report.LogMessage("E: Digitar um cep invalido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Então: o sistema mostrará a mensagem 'Dados não encontrado'");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComInformacoesInvalidas("0000000");
           
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoBuscaCepComInformacoesvalidas()
        {
            Report.LogMessage("Dado que: O usuário acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endereço");
            Report.LogMessage("E: Digitar um cep valido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Então: o sistema mostrará o endereço completo correto");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComInformacoesvalidas("03207-000", "Rua Barão de Tramandaí", "Vila Alpina", "São Paulo/SP");
            
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoBuscaCepComUmDigito()
        {
            Report.LogMessage("Dado que: O usuário acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endereço");
            Report.LogMessage("E: Digitar um numero com 1 digito");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Então: o sistema mostrará a mensagem ' Informe o endereço com no mínimo dois caracteres!' ");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComUmDigito("0");
            
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoEsseCepEde()
        {
            Report.LogMessage("Dado que: O usuário acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endereço");
            Report.LogMessage("E: Digitar um Cep Valido");
            Report.LogMessage("E: Escolher uma opção no campo @EsseCepEdE valido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Então: o sistema mostrará o endereço completo correto");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoEsseCepEde("03207-000", "Localidade");
          
        }
    }
}