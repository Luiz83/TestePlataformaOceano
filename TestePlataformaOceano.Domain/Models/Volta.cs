namespace TestePlataformaOceano.Domain.Models
{
    public class Volta
    {
        public TimeSpan Hora { get; private set; }
        public int CodPiloto { get; private set; }
        public string NomePiloto { get; private set; }
        public int NumVolta { get; private set; }
        public TimeSpan TempoDaVolta { get; set; }
        public double VelocidadeMedia { get; private set; }

        public Volta(TimeSpan hora, int codPiloto, string nomePiloto, int numVolta, TimeSpan tempoDaVolta, double velocidadeMedia)
        {
            SetHora(hora);
            SetCodPiloto(codPiloto);
            SetNomePiloto(nomePiloto);
            SetVolta(numVolta);
            SetTempoDaVolta(tempoDaVolta);
            SetVelocidadeMedia(velocidadeMedia);
        }

        public void SetHora(TimeSpan hora)
        {
            Hora = hora;
        }
        public void SetCodPiloto(int codPiloto)
        {
            CodPiloto = codPiloto;
        }
        public void SetNomePiloto(string nomePiloto)
        {
            NomePiloto = nomePiloto;
        }
        public void SetVolta(int numVolta)
        {
            NumVolta = numVolta;
        }
        public void SetTempoDaVolta(TimeSpan tempoDaVolta)
        {
            TempoDaVolta = tempoDaVolta;
        }
        public void SetVelocidadeMedia(double velocidadeMedia)
        {
            VelocidadeMedia = velocidadeMedia;
        }
    }
}