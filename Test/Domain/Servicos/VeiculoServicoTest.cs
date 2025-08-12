using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;
using minimal_api.Infraestrutura.Interfaces;

namespace Test;

[TestClass]
public class VeiculoServicoTest
{
    [TestMethod]
    public void TesteVeiculo()
    {
        var veiculo = new Veiculo()
        {
            Id = 1,
            Nome = "Fusion",
            Marca = "Ford",
            Ano = "2024"
        };

        var _contexto = CriarContextoTeste();
        var veiculoServico = new VeiculoServico(_contexto);

        veiculoServico.Incluir(veiculo);
        var veiculoId = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.AreEqual(1, veiculoServico.Todos(1)?.Count ?? 0);
        Assert.AreEqual(1, veiculoId?.Id);

        veiculo.Nome = "Focus";
        veiculoServico.Atualizar(veiculo);
        var veiculoAtualizado = veiculoServico.BuscaPorId(1);

        Assert.AreEqual("Focus", veiculoAtualizado?.Nome);

        veiculoServico.Apagar(veiculo);
        var veiculoApagado = veiculoServico.BuscaPorId(1);

        Assert.IsNull(veiculoApagado);
        Assert.AreEqual(0, veiculoServico.Todos(1)?.Count ?? 0);

    }

    private DbContexto CriarContextoTeste()
    {
        var opt = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: "TestDataBase")
            .Options;

        return new DbContexto(opt);
    }
}
