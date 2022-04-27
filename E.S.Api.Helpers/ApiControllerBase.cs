using E.S.Api.Helpers.Filters;
using Microsoft.AspNetCore.Mvc;

namespace E.S.Api.Helpers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(ApiExceptionFilterAttribute))]
    [ApiValidateModelAttribute]
    public class ApiControllerBase : Controller
    {
    }
}