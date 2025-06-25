using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using TaskComputer.Common.Http;

namespace TaskComputer.Common.Errors
{
    public class AppProblemDetailFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _apiBehaviorOptions;

        public AppProblemDetailFactory(ApiBehaviorOptions apiBehaviorOptions)
        {
            _apiBehaviorOptions = apiBehaviorOptions ?? throw new ArgumentNullException(nameof(apiBehaviorOptions));
        }

        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            statusCode ??= 500;
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };
            ApplyProblemDetailsDefaults(problemDetails,httpContext, statusCode.Value);  
            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null, string? instance = null)
        {
            ArgumentNullException.ThrowIfNull(modelStateDictionary);

            statusCode ??= 400; 
            var problemaDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(problemaDetails, httpContext, statusCode.Value);    
            return problemaDetails;
        }

        private void ApplyProblemDetailsDefaults(
            ProblemDetails problemDetails,
            HttpContext httpContext,
            int statusCode)
        {
            problemDetails.Status ??= 500;
            if(_apiBehaviorOptions.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorMapping))
            {
                problemDetails.Title ??= clientErrorMapping.Title;
                problemDetails.Type ??= clientErrorMapping.Link;
            }

            var traceId= Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if(traceId != null)
                problemDetails.Extensions["traceID"] = traceId;

            var error = httpContext?.Items[HttpContextItemKeys.Error] as List<Error>;
            if (error is not null)
                problemDetails.Extensions.Add("errorCodes", error.Select(e => e.Code));
            //Esta propiedad te permite controlar si la inyección de dependencias en
            //los controladores debe ser implícita o explícita,
            //mejorando la claridad y seguridad del código.
            //_apiBehaviorOptions.DisableImplicitFromServicesParameters = true;

        }
    }
}
