using RouteWiseApp.APPLICATION.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases.Nodes
{
    public class NodeUseCaseBase : UseCaseBase
    {
        public NodeUseCaseBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
