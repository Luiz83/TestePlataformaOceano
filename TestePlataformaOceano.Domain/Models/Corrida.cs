namespace TestePlataformaOceano.Domain.Models
{
    public class Corrida
    {
        public List<Piloto> Pilotos { get; private set; }
        public List<Volta> VoltasDaCorrida { get; private set; }

        public Corrida(List<Volta> voltasDaCorrida)
        {
            SetVoltasDaCorrida(voltasDaCorrida);
        }

        public void SetPilotos(List<Piloto> resultadoDaCorrida)
        {
            Pilotos = resultadoDaCorrida;
        }
        public void SetVoltasDaCorrida(List<Volta> voltasDaCorrida)
        {
            VoltasDaCorrida = voltasDaCorrida;
        }
    }
}