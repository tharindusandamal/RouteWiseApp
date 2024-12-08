using Microsoft.Extensions.Logging;
using RouteWiseApp.APPLICATION.Exceptions;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.INFRASTRUCTURE.Services
{
    public class NodePathFinderService : INodePathFinder
    {
        protected readonly ILogger<NodePathFinderService> _logger;

        public NodePathFinderService(ILogger<NodePathFinderService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Find shortest path
        /// </summary>
        /// <param name="fromNodeName"></param>
        /// <param name="toNodeName"></param>
        /// <param name="graphNode"></param>
        /// <returns></returns>
        /// <exception cref="InvalidException"></exception>
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNode)
        {
			try
			{
                var distances = new Dictionary<string, int>();
                var previousNodes = new Dictionary<string, string>();
                var unvisited = new HashSet<Node>();

                foreach (var node in graphNode)
                {
                    distances[node.Name] = int.MaxValue;
                    unvisited.Add(node);
                }
                distances[fromNodeName] = 0;

                while (unvisited.Count > 0)
                {
                    var currentNode = unvisited.OrderBy(n => distances[n.Name]).First();
                    unvisited.Remove(currentNode);

                    if (currentNode.Name == toNodeName)
                    {
                        break;
                    }

                    foreach (var edge in currentNode.Edges)
                    {
                        var newDistance = distances[currentNode.Name] + edge.Weight;

                        var ds = distances[edge.TargetNode.Name];

                        if(ds == null)
                        {
                            var s = 1;
                        }

                        if (newDistance < ds)
                        {
                            distances[edge.TargetNode.Name] = newDistance;
                            previousNodes[edge.TargetNode.Name] = currentNode.Name;
                        }
                    }
                }

                var path = new List<string>();
                var currentNodeName = toNodeName;
                while (currentNodeName != null)
                {
                    path.Insert(0, currentNodeName);
                    previousNodes.TryGetValue(currentNodeName, out currentNodeName);
                }

                return new ShortestPathData
                {
                    NodeNames = path,
                    Distance = distances[toNodeName]
                };
            }
			catch (Exception ex)
			{
                // Add a log
                _logger.LogError(ex.Message);

                // Thorow an error - this will handle by exception middleware - API app
                throw new InvalidException(ex.Message);

            }
        }
    }
}
