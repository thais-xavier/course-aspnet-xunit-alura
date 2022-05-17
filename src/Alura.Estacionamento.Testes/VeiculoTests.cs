using System;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{

    public class VeiculoTests : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTests(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            // var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            // var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            // var carro = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }
        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);

        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ASD-995U";

            //Assert
            var messagem = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );
            Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", messagem.Message);
        }

        [Fact]
        public void TestaMensagemExcecaoComPlacaComMenosDeOitoCaracteres()
        {
            //Arrange
            string placaFormatoErrado = "ADS-857";

            //Assert
            var mensagem = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );
            
            Assert.Equal("A placa deve possuir 8 caracteres", mensagem.Message);

        }

        [Fact]
        public void TestaMensagemExcecaoTresPrimeirosCaracteresDevemSerLetras()
        {
            //Arrange
            string placaFormatoErrado = "AP0-8574";

            //Assert
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placaFormatoErrado
            );

            Assert.Equal("Os 3 primeiros caracteres devem ser letras!", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}