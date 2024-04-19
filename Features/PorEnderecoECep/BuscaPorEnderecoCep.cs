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
            Report.LogMessage("Dado que: O usu�rio acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endere�o");
            Report.LogMessage("E: Digitar um cep invalido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Ent�o: o sistema mostrar� a mensagem 'Dados n�o encontrado'");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComInformacoesInvalidas("0000000");
           
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoBuscaCepComInformacoesvalidas()
        {
            Report.LogMessage("Dado que: O usu�rio acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endere�o");
            Report.LogMessage("E: Digitar um cep valido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Ent�o: o sistema mostrar� o endere�o completo correto");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComInformacoesvalidas("03207-000", "Rua Bar�o de Tramanda�", "Vila Alpina", "S�o Paulo/SP");
            
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoBuscaCepComUmDigito()
        {
            Report.LogMessage("Dado que: O usu�rio acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endere�o");
            Report.LogMessage("E: Digitar um numero com 1 digito");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Ent�o: o sistema mostrar� a mensagem ' Informe o endere�o com no m�nimo dois caracteres!' ");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoBuscaCepComUmDigito("0");
            
        }

        [MyTestMethod]
        [TestCategory("CT001")]
        //[TestCategory("US131876")]
        //[DynamicData(nameof(RetornaInformacoes), DynamicDataSourceType.Method)]
        public void ValidarCampoEsseCepEde()
        {
            Report.LogMessage("Dado que: O usu�rio acesse o site buscar CEP");
            Report.LogMessage("E: clique no campo @Digite um Cep ou um Endere�o");
            Report.LogMessage("E: Digitar um Cep Valido");
            Report.LogMessage("E: Escolher uma op��o no campo @EsseCepEdE valido");
            Report.LogMessage("Quando: clicar em Buscar ");
            Report.LogMessage("Ent�o: o sistema mostrar� o endere�o completo correto");
            Report.LogMessage("");

            BuscaPorEnderecoCepSteps.ValidarCampoEsseCepEde("03207-000", "Localidade");
          
        }
    }
}