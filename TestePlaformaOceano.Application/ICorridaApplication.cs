using Microsoft.AspNetCore.Http;
using TestePlataformaOceano.Domain.Models;

namespace TestePlaformaOceano.Application
{
    public interface ICorridaApplication
    {
        Task<List<Piloto>> BuscarResultadoCorrida(IFormFile logCorrida);
        Task<List<Volta>> LerLogDeVoltas(IFormFile logCorrida);
        Task<List<Piloto>> LerResultadoDosPilotos(List<Volta> listaDeVoltas);
    }
}