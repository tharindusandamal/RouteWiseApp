using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetAllNodes;
using RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetShortesPath;

namespace RouteWiseApp.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NodesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetNodesAsync()
        {
            return Ok(await Mediator.Send(new GetAllNodesQuery { }));
        }

        [HttpPost]
        [Route("find")]
        public async Task<IActionResult> FindShortestPath([FromBody] GetShortesPathQueryRequestDTO model)
        {
            return Ok(await Mediator.Send(new GetShortesPathQuery { Request = model }));
        }
    }
}
