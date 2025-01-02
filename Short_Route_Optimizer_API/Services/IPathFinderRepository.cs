using Short_Route_Optimizer_API.Entities;
using Short_Route_Optimizer_API.Models;

namespace Short_Route_Optimizer_API.Services;

public interface IPathFinderRepository
{
    ShortestPathDto ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
}