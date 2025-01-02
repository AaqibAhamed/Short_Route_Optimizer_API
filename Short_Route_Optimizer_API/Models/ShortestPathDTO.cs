namespace Short_Route_Optimizer_API.Models;

public class ShortestPathDto
{
    public List<string>? NodeNames { get; set; }
    public int? Distance { get;  }

   public ShortestPathDto(List<string> nodeNames, int distance)
    {
        NodeNames = nodeNames;
        Distance = distance;
    }
}