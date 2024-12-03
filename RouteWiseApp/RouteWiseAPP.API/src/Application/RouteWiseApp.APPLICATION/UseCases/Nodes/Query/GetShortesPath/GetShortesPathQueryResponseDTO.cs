using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetShortesPath
{
    public class GetShortesPathQueryResponseDTO
    {
        public List<string>? NodeNames { get; set; }
        public int Distance { get; set; }
    }
}
