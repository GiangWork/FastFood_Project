using FastFood.Core.Base;

namespace FastFood.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int errorstatusCode = (int)StatusCodes.Status500InternalServerError;
            string errorCode = "internal_error";
            object errorMessage = "An unexpected error occurred.";

            if (exception is BaseException.ErrorException errorException)
            {
                errorstatusCode = errorException.StatusCode;
                errorCode = errorException.ErrorDetail.ErrorCode ?? "unknown_error";
                errorMessage = errorException.ErrorDetail.ErrorMessage ?? "No message provided";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorstatusCode;

            var response = new
            {
                message = errorMessage,
                statusCode = errorstatusCode,
                code = errorCode,
            };

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
