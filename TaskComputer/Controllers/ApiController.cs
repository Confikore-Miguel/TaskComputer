using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaskComputer.Common.Http;

namespace TaskComputer.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count == 0)
                return Problem();
            if (errors.All(e => e.Type == ErrorType.Validation))
                return ValidationProblem(errors);
            HttpContext.Items[HttpContextItemKeys.Error] = errors;
            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            ModelStateDictionary modelStateDictionary = new();
            foreach (var item in errors)
            {
                modelStateDictionary.AddModelError(item.Code, item.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}
