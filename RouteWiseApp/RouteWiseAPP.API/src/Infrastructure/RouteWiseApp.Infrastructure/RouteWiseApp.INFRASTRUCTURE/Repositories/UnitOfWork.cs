using RouteWiseApp.APPLICATION.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.INFRASTRUCTURE.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly INodeRepository _nodeRepository;

        public UnitOfWork(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public INodeRepository Nodes => _nodeRepository;
    }
}
