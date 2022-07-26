using TestePlataformaOceano.Domain.Models;
using Microsoft.AspNetCore.Http;
using ClosedXML.Excel;

namespace TestePlaformaOceano.Application.Services
{
    public class CorridaApplication : ICorridaApplication
    {
        private readonly List<string> _imageFormats = new List<string>() { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" };

        public async Task<List<Piloto>> BuscarResultadoCorrida(IFormFile logCorrida)
        {
            var listaDeVoltas = await LerLogDeVoltas(logCorrida);
            var listaDePilotos = await LerResultadoDosPilotos(listaDeVoltas);
            var corrida = new Corrida(listaDePilotos, listaDeVoltas);
            return corrida.Pilotos;
        }

        public async Task<List<Volta>> LerLogDeVoltas(IFormFile logCorrida)
        {
            if (!_imageFormats.Contains(logCorrida.ContentType))
                throw new Exception("O arquivo não é uma planilha!");
            using (var memoryStream = new MemoryStream())
            {
                await logCorrida.CopyToAsync(memoryStream);

                var xls = new XLWorkbook(memoryStream);
                var planilha = xls.Worksheet(1);

                return LerPlanilhaDeVoltas(planilha);
            }
        }
        public async Task<List<Piloto>> LerResultadoDosPilotos(List<Volta> listaDeVoltas)
        {
            if (listaDeVoltas.Count() == 0)
                throw new Exception("O arquivo está vazio!");
            List<Piloto> pilotos = new List<Piloto>();
            var voltasAgrupadaPorPiloto = listaDeVoltas.GroupBy(x => x.CodPiloto);

            foreach (var item in voltasAgrupadaPorPiloto)
            {
                var nomePiloto = item.First().NomePiloto;
                var totalVoltas = item.Last().NumVolta;
                TimeSpan tempoTotal = new TimeSpan(item.Sum(x => x.TempoDaVolta.Ticks));

                pilotos.Add(new Piloto(item.Key, nomePiloto, totalVoltas, tempoTotal));
            }
            return pilotos;
        }
        public List<Volta> LerPlanilhaDeVoltas(IXLWorksheet planilha)
        {
            List<Volta> listaDeVoltas = new List<Volta>();
            var totalLinhas = planilha.Rows().Count();
            for (int l = 2; l <= totalLinhas; l++)
            {
                var hora = TimeSpan.Parse(planilha.Cell($"A{l}").Value.ToString());
                var texto = planilha.Cell($"B{l}").Value.ToString().Split("–");
                var codPiloto = int.Parse(texto.First());
                var nomePiloto = texto.Last();
                var numVolta = int.Parse(planilha.Cell($"C{l}").Value.ToString());
                var tempoDaVolta = TimeSpan.Parse("00:" + planilha.Cell($"D{l}").Value.ToString());
                var velocidadeMedia = double.Parse(planilha.Cell($"E{l}").Value.ToString());
                listaDeVoltas.Add(new Volta(hora, codPiloto, nomePiloto, numVolta, tempoDaVolta, velocidadeMedia));
            }
            return listaDeVoltas;
        }
    }
}