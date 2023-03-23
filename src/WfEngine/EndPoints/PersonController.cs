using Elsa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elsa.RD.WfEngine.EndPoints
{
    [ApiController]
    [Route("v{apiVersion:apiVersion}/customer-onboarding")]
    public class PersonController : ControllerBase
    {
        private readonly IBuildsAndStartsWorkflow invoker;

    }
}
