namespace RouteWiseApp.DOMAIN.DomanModels
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; } = new();
    }
}
