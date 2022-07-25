using Newtonsoft.Json;

namespace TestePlataformaOceano.Web.Middleware
{
    public class CorridaMiddleware
    {
        private readonly RequestDelegate _next;

        public CorridaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                var responseMessage = JsonConvert.SerializeObject(new ErrorResponseModel(ex.Message));
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(responseMessage);
            }
        }
    }
}