using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MsgWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ErrorHandlingControllerBase : ControllerBase
    {
        protected ActionResult<T> GetProperReturnValue<T>(Exception exception) 
        {
            return GetProperReturnValue(exception);
        }

        protected ActionResult GetProperReturnValue(Exception exception) 
        {
            if (exception is NullReferenceException)
            {
                return NotFound(exception.Message);
            }
            else if (exception is DbUpdateConcurrencyException)
            {
                return BadRequest(exception.Message);
            }
            else
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
