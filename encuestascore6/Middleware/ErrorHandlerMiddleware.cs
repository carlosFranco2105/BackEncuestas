using Logic.Session;

namespace ApiEncuesta.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            // Clase 11: sintaxis para enganchar el middleware al siguietne eslabón.
            _next = next;
        }

        // Clase 11: Método que implementa la funcionalidad del middleware
        public async Task InvokeAsync(HttpContext context)
        {
            // Clase 11: Antes de procesar el controlador
            Console.WriteLine(">>> Entrando al middleware de errores");

            try
            {
                // Clase 11: Invocación al controlador o siguiente middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                // Clase 11: Manejo de errores originados en los controladores.
                HttpResponse response = context.Response;
                switch (ex)
                {
                    case ArgumentNullException:
                    case ArgumentException:
                    case InvalidOperationException:
                        //response.StatusCode = 400;
                        response.StatusCode = 200;  //Pruebas para utilizar en AFIP. StatusCode 200
                        break;

                    case LoginException:
                        response.StatusCode = 403;
                        break;

                    default:
                        response.StatusCode = 500;
                        break;
                }

                await response.WriteAsJsonAsync(new { result = false, error = ex.Message, handled = true });
            }

            // Clase 11: Luego de procesar el controlador
            Console.WriteLine("<<< Saliendo del middleware de errores");
        }
    }
}