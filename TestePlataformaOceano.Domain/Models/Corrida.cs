namespace TestePlataformaOceano.Domain.Models
{
    public class Corrida
    {
        public List<Piloto> Pilotos { get; private set; }
        public List<Volta> Voltas { get; private set; }

        public Corrida(List<Piloto> pilotos, List<Volta> voltas)
        {
            SetPilotos(pilotos);
            SetVoltasDaCorrida(voltas);
            DefinirOrdemDeChegada();
        }

        public void SetPilotos(List<Piloto> resultadoDaCorrida)
        {
            Pilotos = resultadoDaCorrida;
        }
        public void SetVoltasDaCorrida(List<Volta> voltas)
        {
            Voltas = voltas;
        }

        public void DefinirOrdemDeChegada()
        {
            Pilotos.OrderBy(x => x.TempoTotalDeProva);
            foreach (var item in Pilotos)
            {
                item.SetPosicaoChegada(1 + Pilotos.IndexOf(item));
            }
        }
    }
}