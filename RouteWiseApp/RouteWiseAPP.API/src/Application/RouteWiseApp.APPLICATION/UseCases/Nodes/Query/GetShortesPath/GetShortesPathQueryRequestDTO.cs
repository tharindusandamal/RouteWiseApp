using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetShortesPath
{
    public class GetShortesPathQueryRequestDTO
    {
        public string? FromNodeName { get; set; }
        public string? ToNodeName { get; set; }
        public IEnumerable<Node>? GraphNodes { get; set; }
    }
}
