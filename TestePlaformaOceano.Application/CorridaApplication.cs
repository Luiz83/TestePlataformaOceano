using TestePlataformaOceano.Domain.Models;
using Microsoft.AspNetCore.Http;
using ClosedXML.Excel;

namespace TestePlaformaOceano.Application
{
    public class CorridaApplication
    {

        public async Task<Corrida> BuscarCorrida(IFormFile logCorrida)
        {
            var listaDeVoltas = await LerLogDeVoltas(logCorrida);
            var listaDePilotos = await LerResultadoDosPilotos(listaDeVoltas);
            var corrida = new Corrida(listaDePilotos, listaDeVoltas);
            return corrida;
        }

        public async Task<List<Volta>> LerLogDeVoltas(IFormFile logCorrida)
        {
            using (var memoryStream = new MemoryStream())
            {
                await logCorrida.CopyToAsync(memoryStream);

                var xls = new XLWorkbook(memoryStream);
                var planilha = xls.Worksheet(1);
                var totalLinhas = planilha.Rows().Count();

                List<Volta> listaDeVoltas = new List<Volta>();

                for (int l = 2; l <= totalLinhas; l++)
                {
                    var hora = TimeSpan.Parse(planilha.Cell($"A{l}").Value.ToString());
                    var texto = planilha.Cell($"B{l}").Value.ToString().Split("-");
                    var codPiloto = int.Parse(texto.First());
                    var nomePiloto = texto.Last();
                    var numVolta = int.Parse(planilha.Cell($"C{l}").Value.ToString());
                    var tempoDaVolta = TimeSpan.Parse(planilha.Cell($"D{l}").Value.ToString());
                    var velocidadeMedia = double.Parse(planilha.Cell($"E{l}").Value.ToString());
                    listaDeVoltas.Add(new Volta(hora, codPiloto, nomePiloto, numVolta, tempoDaVolta, velocidadeMedia));
                }

                return listaDeVoltas;
            }
        }
        public async Task<List<Piloto>> LerResultadoDosPilotos(List<Volta> listaDeVoltas)
        {
            List<Piloto> pilotos = new List<Piloto>();

            foreach (var item in listaDeVoltas)
            {
                if (!pilotos.Exists(x => x.CodPiloto == item.CodPiloto))
                {
                    TimeSpan tempoTotal = new TimeSpan();
                    int numVolta = 0;
                    foreach (var volta in listaDeVoltas)
                    {

                        if (item.CodPiloto == volta.CodPiloto)
                        {
                            numVolta = volta.NumVolta;
                            tempoTotal = tempoTotal + volta.TempoDaVolta;
                        }
                    }
                    pilotos.Add(new Piloto(item.CodPiloto, item.NomePiloto, numVolta, tempoTotal));
                }
            }
            return pilotos;
        }
    }
}