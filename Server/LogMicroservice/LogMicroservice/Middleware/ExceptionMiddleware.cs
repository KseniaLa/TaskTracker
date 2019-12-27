using Common.ErrorHandling;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LogMicroservice.Middleware
{
     public class ExceptionMiddleware
     {
          private readonly RequestDelegate _next;

          public ExceptionMiddleware(RequestDelegate next)
          {
               _next = next;
          }

          public async Task InvokeAsync(HttpContext httpContext)
          {
               try
               {
                    await _next(httpContext);
               }
               catch (Exception ex)
               {
                    await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
               }
          }

          private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
          {
               context.Response.ContentType = "application/json";
               context.Response.StatusCode = (int)code;

               return context.Response.WriteAsync(new ErrorDetails()
               {
                    StatusCode = context.Response.StatusCode,
                    Message = "Server Error",
               }.ToString());
          }
     }
}
