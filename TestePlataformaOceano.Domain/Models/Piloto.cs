namespace TestePlataformaOceano.Domain.Models
{
    public class Piloto
    {
        public int PosicaoChegada { get; private set; }
        public int CodPiloto { get; private set; }
        public string NomePiloto { get; private set; }
        public int QntdDeVoltasCompletadas { get; private set; }
        public TimeSpan TempoTotalDeProva { get; set; }

        public Piloto(int posicaoChegada, int codPiloto, string nomePiloto, int qntdDeVoltasCompletadas, TimeSpan tempoTotalDeProva)
        {
            SetPosicaoChegada(posicaoChegada);
            SetCodPiloto(codPiloto);
            SetNomePiloto(nomePiloto);
            SetQntdDeVoltasCompletadas(qntdDeVoltasCompletadas);
            SetTempoTotalDeProva(tempoTotalDeProva);
        }

        public void SetPosicaoChegada(int posicaoChegada)
        {
            PosicaoChegada = posicaoChegada;
        }
        public void SetCodPiloto(int codPiloto)
        {
            CodPiloto = codPiloto;
        }
        public void SetNomePiloto(string nomePiloto)
        {
            NomePiloto = nomePiloto;
        }
        public void SetQntdDeVoltasCompletadas(int qntdDeVoltasCompletadas)
        {
            QntdDeVoltasCompletadas = qntdDeVoltasCompletadas;
        }
        public void SetTempoTotalDeProva(TimeSpan tempoTotalDeProva)
        {
            TempoTotalDeProva = tempoTotalDeProva;
        }
    }
}