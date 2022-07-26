namespace TestePlataformaOceano.Domain.Models
{
    public class Piloto
    {
        public int PosicaoChegada { get; private set; }
        public int CodPiloto { get; private set; }
        public string NomePiloto { get; private set; }
        public int QntdDeVoltasCompletadas { get; private set; }
        public TimeSpan TempoTotalDeProva { get; set; }

        public Piloto(int codPiloto, string nomePiloto, int qntdDeVoltasCompletadas, TimeSpan tempoTotalDeProva)
        {
            SetCodPiloto(codPiloto);
            SetNomePiloto(nomePiloto);
            SetQntdDeVoltasCompletadas(qntdDeVoltasCompletadas);
            SetTempoTotalDeProva(tempoTotalDeProva);
        }

        public void SetPosicaoChegada(int posicaoChegada)
        {
            PosicaoChegada = posicaoChegada;
        }
        private void SetCodPiloto(int codPiloto)
        {
            CodPiloto = codPiloto;
        }
        private void SetNomePiloto(string nomePiloto)
        {
            NomePiloto = nomePiloto;
        }
        private void SetQntdDeVoltasCompletadas(int qntdDeVoltasCompletadas)
        {
            QntdDeVoltasCompletadas = qntdDeVoltasCompletadas;
        }
        private void SetTempoTotalDeProva(TimeSpan tempoTotalDeProva)
        {
            TempoTotalDeProva = tempoTotalDeProva;
        }
    }
}