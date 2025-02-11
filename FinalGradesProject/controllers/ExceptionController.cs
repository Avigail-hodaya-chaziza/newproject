using FinalGradesProject.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalGradesProject.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger _logger;
        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/error")]
        [HttpPost("/error")]
        [HttpDelete("/error")]
        [HttpPut("/error")]


        public IActionResult HandleError()
        {
            var Exceptionc = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (Exceptionc != null)
            {
                _logger.LogError(Exceptionc.Error.Message, "error");
                _logger.LogError(Exceptionc.Error, "error");
            }

            if (Exceptionc?.Error is StudentAlradyExsistException)
            {
                return Problem(
                detail: "The student with Id aleady exsist",
                title: "An error occurred",
                statusCode: 333
                );
            }
            if (Exceptionc?.Error is GradeNotExistException)
            {
                return Problem(
                detail: "The grade not exsist",
                title: "An error occurred",
                statusCode: 8888
                );

            }
            return Problem(
                 detail: "The grade not exsist",
                 title: "An error occurred",
                 statusCode: 879);

        }
    }
}
