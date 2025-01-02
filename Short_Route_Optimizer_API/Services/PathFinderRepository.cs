using Short_Route_Optimizer_API.Entities;
using Short_Route_Optimizer_API.Models;

namespace Short_Route_Optimizer_API.Services;

public class PathFinderRepository : IPathFinderRepository
{
    public ShortestPathDto ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
    {
        var startNode = graphNodes.FirstOrDefault(n => n.Name == fromNodeName);
        var endNode = graphNodes.FirstOrDefault(n => n.Name == toNodeName);
        
        if (startNode == null || endNode == null)
        {
           
            var shortestPath = new ShortestPathDto(new List<string>(), 0);

            return shortestPath;
        }

        var distances = new Dictionary<Node, int>();
        var previousNodes = new Dictionary<Node, Node>();
        var priorityQueue = new List<Node> { startNode };

        foreach (var node in graphNodes)
        {
            distances[node] = int.MaxValue;
            previousNodes[node] = new Node();
        }

        distances[startNode] = 0;

        while (priorityQueue.Count > 0)
        {
            priorityQueue.Sort((x, y) => distances[x].CompareTo(distances[y]));
            var currentNode = priorityQueue.First();
            priorityQueue.Remove(currentNode);

            if (currentNode == endNode)
                break;

            foreach (var neighbor in currentNode.Neighbors.Keys)
            {
                var newDist = distances[currentNode] + currentNode.Neighbors[neighbor];
                if (newDist < distances[neighbor])
                {
                    distances[neighbor] = newDist;
                    previousNodes[neighbor] = currentNode;
                    if (!priorityQueue.Contains(neighbor))
                        priorityQueue.Add(neighbor);
                }
            }
        }

        var path = new List<string>();
        var totalDistance = distances[endNode];

        for (var at = endNode; at != null; at = previousNodes[at])
        {
            if (at.Name != null)
            {
                path.Add(at.Name);
            }
          
        }
            
        path.Reverse();

        //return new ShortestPathDto { NodeNames = path, Distance = totalDistance };
        
        return new ShortestPathDto(path, totalDistance);
    }
}