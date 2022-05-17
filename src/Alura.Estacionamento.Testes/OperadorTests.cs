using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class OperadorTests
    {
        [Fact]
        public void TestaDadosOperadorPatio()
        {
            // Arrange
        var operador = new Operador();
        operador.Nome = "Arthur de Souza";
        operador.Matricula = "PE0152";

        // Act

        var dados = operador.ToString();

        // Assert
        Assert.Contains("Operador", dados);
        }
    }
}