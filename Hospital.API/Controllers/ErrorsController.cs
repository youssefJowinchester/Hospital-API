using Hospital.API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hospital.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {

        // errors/5
        public ActionResult Error(int code)
        {
            return NotFound(new ApiResponse(code));
        }

    }
}
