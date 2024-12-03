using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.DOMAIN.DomanModels
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; } = new();
        public int Distance { get; set; }
    }
}
