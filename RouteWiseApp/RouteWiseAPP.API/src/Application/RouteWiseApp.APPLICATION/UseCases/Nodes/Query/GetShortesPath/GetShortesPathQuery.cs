using MediatR;
using Microsoft.Extensions.Logging;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetShortesPath
{
    public class GetShortesPathQuery : IRequest<GetShortesPathQueryResponseDTO>
    {
        public GetShortesPathQueryRequestDTO Request { get; set; }
    }

    public class GetShortesPathQueryHandler : NodeUseCaseBase, IRequestHandler<GetShortesPathQuery, GetShortesPathQueryResponseDTO>
    {
        protected readonly INodePathFinder _nodePathFinder;
        protected readonly ILogger<GetShortesPathQueryHandler> _logger;

        public GetShortesPathQueryHandler(IUnitOfWork unitOfWork, INodePathFinder nodePathFinder, ILogger<GetShortesPathQueryHandler> logger) : base(unitOfWork)
        {
            _nodePathFinder = nodePathFinder;
            _logger = logger;
        }

        public async Task<GetShortesPathQueryResponseDTO> Handle(GetShortesPathQuery request, CancellationToken cancellationToken)
        {
            // Validate object - from node
            if (string.IsNullOrEmpty(request.Request.FromNodeName))
                throw new Exception();

            // Validate object - to node
            if (string.IsNullOrEmpty(request.Request.ToNodeName))
                throw new Exception();

            // If request does not contains graph nodes, inject them from mock
            if (request.Request.GraphNodes == null || !request.Request.GraphNodes.Any())
                request.Request.GraphNodes = await _unitOfWork.Nodes.GetNodesAsync();

            // find the path
            var result = _nodePathFinder.ShortestPath(request.Request.FromNodeName, request.Request.ToNodeName, request.Request.GraphNodes.ToList());

            // retun result
            if (result == null)
                return new GetShortesPathQueryResponseDTO { Distance = 0, NodeNames = new List<string> { } };
            else
                return new GetShortesPathQueryResponseDTO { Distance = result.Distance, NodeNames = result.NodeNames };
        }
    }
}
