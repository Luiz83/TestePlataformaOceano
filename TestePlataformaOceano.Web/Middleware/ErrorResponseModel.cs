namespace TestePlataformaOceano.Web.Middleware
{
    public class ErrorResponseModel
    {
        public string ErrorMessage { get; set; }

        public ErrorResponseModel(string message)
        {
            ErrorMessage = message;
        }
    }
}