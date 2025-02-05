﻿using ABCCorp.EmployeeManagement.Api.Models;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using System.Net;

namespace ABCCorp.EmployeeManagement.Api.Middleware
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem;

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = badRequestException.Message,
                        Detail = badRequestException.InnerException?.Message,
                        Status = (int)statusCode,
                        Type= nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {
                        Title = notFoundException.Message,
                        Detail = notFoundException.InnerException?.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                    };
                    break;
                default:
                    problem = new CustomProblemDetails
                    {
                        Title = ex.Message,
                        Detail = ex.StackTrace,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);   
        }
    }
}
