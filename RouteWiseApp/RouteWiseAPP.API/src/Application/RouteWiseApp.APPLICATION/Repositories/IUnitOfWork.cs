using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.Repositories
{
    public interface IUnitOfWork
    {
        INodeRepository Nodes { get; }
    }
}
