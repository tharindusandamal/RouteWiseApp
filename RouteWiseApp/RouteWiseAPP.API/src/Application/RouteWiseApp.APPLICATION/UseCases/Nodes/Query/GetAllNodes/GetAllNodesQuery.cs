using MediatR;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetAllNodes
{
    public class GetAllNodesQuery : IRequest<IEnumerable<Node>>
    {
    }

    public class GetAllNodesQueryHandler : NodeUseCaseBase, IRequestHandler<GetAllNodesQuery, IEnumerable<Node>>
    {
        public GetAllNodesQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Node>> Handle(GetAllNodesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Nodes.GetNodesAsync();

            return data;
        }
    }
}
