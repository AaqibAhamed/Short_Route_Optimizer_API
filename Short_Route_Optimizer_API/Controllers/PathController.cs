using Microsoft.AspNetCore.Mvc;
using Short_Route_Optimizer_API.Entities;
using Short_Route_Optimizer_API.Models;
using Short_Route_Optimizer_API.Services;

namespace Short_Route_Optimizer_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PathController : ControllerBase
{
    private readonly IPathFinderRepository _pathFinderRepository;

    public PathController(IPathFinderRepository pathFinderRepository)
    {
        _pathFinderRepository = pathFinderRepository?? throw new ArgumentNullException(nameof(pathFinderRepository));
    }

    [HttpPost("shortest-path")]
    public ActionResult<ShortestPathDto> GetShortestPath(string from, string to, [FromBody] List<Node> graph)
    {
        var result = _pathFinderRepository.ShortestPath(from, to, graph);

        if (result == null)
        {
            return NotFound("Invalid nodes specified.");
        }
            
        return Ok(result);
    }
}
