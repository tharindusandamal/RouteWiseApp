using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.Services
{
    public interface INodePathFinder 
    {
        ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNode);
    }
}
