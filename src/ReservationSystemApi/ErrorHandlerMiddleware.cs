using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Http;

namespace PlaneTicketReservationSystem.ReservationSystemApi
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                logger.Error(error, error.Message);

                response.StatusCode = (int) HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
