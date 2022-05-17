using System;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTests : IDisposable
    {
        private Veiculo veiculo;
        private Operador operador;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTests(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "Pedro Fagundes";
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            // Arrange
            // var estacionamento = new Patio();
            // var veiculo = new Veiculo();

            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";
            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
            Assert.Equal("Pedro Fagundes", operador.Nome);
        }

        [Theory]
        [InlineData("André Silva", "ADS-1498", "preto", "Gol")]
        [InlineData("José Silva", "POL-9242", "cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "azul", "Opala")]
        [InlineData("Pedro Silva", "GDR-0101", "azul", "Corsa")]

        public void ValidaFaturamentoDoestacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            // var estacionamento = new Patio();
            // var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ADS-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            // var estacionamento = new Patio();
            // var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.OperadorPatio = operador;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            // var estacionamento = new Patio();
            // var veiculo = new Veiculo();

            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();

            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Opala";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}