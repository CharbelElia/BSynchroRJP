using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using BSynchro.Helpers.Exceptions;

namespace BSynchro.Helpers.ActionFilters
{
    public class BSynchroExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<BSynchroExceptionFilter> _logger;

        public BSynchroExceptionFilter(ILogger<BSynchroExceptionFilter> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// This method will be automatically called when an exception occured and before returning the response to the client
        /// </summary>
        /// <param name="context">The exception context</param>
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = context.Exception.Message;
            string code = context.Exception.HResult.ToString();
            var baseException = context.Exception.GetBaseException();
            var baseExceptionType = baseException.GetType();
            if (baseExceptionType.IsSubclassOf(typeof(BSynchroBaseException)) ||
                baseExceptionType.Equals(typeof(BSynchroBaseException)))
            {
                BSynchroBaseException BSynchroBaseException = baseException as BSynchroBaseException;
                code = BSynchroBaseException.Code;
                message = BSynchroBaseException.Message;
                status = HttpStatusCode.BadRequest;
            }
            this._logger.LogError("Error occured, error code:" + code + ", error message: " + message + "on object");
            context.Result = new JsonResult(new Error() {ErrorCode = code, ErrorDescription = message});
            context.ExceptionHandled = true;
            response.StatusCode = (int) status;
            response.ContentType = "application/json";
        }
    }
}