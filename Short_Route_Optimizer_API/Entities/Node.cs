namespace Short_Route_Optimizer_API.Entities;

public class Node
{
    public string? Name { get; set; }
    public Dictionary<Node, int> Neighbors { get; set; } = new Dictionary<Node, int>();
}