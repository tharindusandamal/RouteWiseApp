using Microsoft.Extensions.Options;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.DOMAIN.AppModels;
using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.INFRASTRUCTURE.Repositories
{
    public class NodeRepository : INodeRepository
    {
        protected readonly IOptions<MockData> _mockData;

        public NodeRepository(IOptions<MockData> mockData)
        {
            _mockData = mockData;
        }

        public async Task<IEnumerable<Node>> GetNodesAsync()
        {
            var data = _mockData.Value.Nodes;

            return await Task.FromResult(data);
        }
    }
}
