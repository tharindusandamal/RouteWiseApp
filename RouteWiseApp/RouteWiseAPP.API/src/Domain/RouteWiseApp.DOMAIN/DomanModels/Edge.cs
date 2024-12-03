using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.DOMAIN.DomanModels
{
    public class Edge
    {
        public Node TargetNode { get; set; }
        public int Weight { get; set; }
    }
}
