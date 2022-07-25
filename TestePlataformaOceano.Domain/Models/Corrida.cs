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
            List<Piloto> pilotosOrdenados = new List<Piloto>();
            var pilotosAgrupadosPorVoltas = Pilotos.GroupBy(x => x.QntdDeVoltasCompletadas).OrderByDescending(x => x.Key);
            foreach (var item in pilotosAgrupadosPorVoltas)
            {
                pilotosOrdenados.AddRange(item.OrderBy(x => x.TempoTotalDeProva).ToList());
            }
            Pilotos = pilotosOrdenados;
            foreach (var item in Pilotos)
            {
                item.SetPosicaoChegada(1 + Pilotos.IndexOf(item));
            }
        }
    }
}