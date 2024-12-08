

using Microsoft.Extensions.Logging;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.DOMAIN.DomanModels;
using RouteWiseApp.INFRASTRUCTURE.Services;

Console.WriteLine("Shortest Path Finder Console App");
Console.WriteLine("--------------------------------");

// Get input for fromNode and toNode
Console.Write("Enter From Node: ");
var fromNode = Console.ReadLine();

Console.Write("Enter To Node: ");
var toNode = Console.ReadLine();

var graphNodes = new List<Node>
{
    new Node { Name = "A",
        Edges = new List<Edge> {
            new Edge { TargetNode = new Node { Name = "B" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "C" }, Weight = 6 }
        } },
    new Node { Name = "B",
        Edges = new List<Edge> {
            new Edge { TargetNode = new Node { Name = "F" }, Weight = 2 }
        } },
    new Node { Name = "C",
        Edges = new List<Edge> {
            new Edge { TargetNode = new Node { Name = "A" }, Weight = 6 },
            new Edge { TargetNode = new Node { Name = "D" }, Weight = 8 }
        } },
    new Node { Name = "D",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "C" }, Weight = 8 },
            new Edge { TargetNode = new Node { Name = "E" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "G" }, Weight = 1 }
        } },
    new Node { Name = "E",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "B" }, Weight = 2 },
            new Edge { TargetNode = new Node { Name = "F" }, Weight = 3 },
            new Edge { TargetNode = new Node { Name = "D" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "I" }, Weight = 8 }
        } },
    new Node { Name = "F",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "B" }, Weight = 2 },
            new Edge { TargetNode = new Node { Name = "E" }, Weight = 3 },
            new Edge { TargetNode = new Node { Name = "G" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "H" }, Weight = 6 }
        } },
    new Node { Name = "G",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "D" }, Weight = 1 },
            new Edge { TargetNode = new Node { Name = "F" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "G" }, Weight = 4 },
            new Edge { TargetNode = new Node { Name = "H" }, Weight = 6 }
        } },
    new Node { Name = "H",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "F" }, Weight = 6 },
            new Edge { TargetNode = new Node { Name = "G" }, Weight = 5 }
        } },
    new Node { Name = "I",
        Edges = new List<Edge>{
            new Edge { TargetNode = new Node { Name = "E" }, Weight = 8 },
            new Edge { TargetNode = new Node { Name = "G" }, Weight = 5 }
        } }
};

ILogger<Program> _logger;
var finder = new NodePathFinderService(null);
// Use the NodePathFinder service
var result = finder.ShortestPath(fromNode, toNode, graphNodes);

// Print the result
if (result == null)
{
    Console.WriteLine("No path found.");
}
else
{
    Console.WriteLine($"Shortest Path Distance: {result.Distance}");
    Console.WriteLine($"Path: {string.Join(" -> ", result.NodeNames)}");
}
