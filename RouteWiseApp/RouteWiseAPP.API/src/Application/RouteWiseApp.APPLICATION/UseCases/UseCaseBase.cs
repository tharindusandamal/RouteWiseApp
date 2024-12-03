using RouteWiseApp.APPLICATION.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.UseCases
{
    public class UseCaseBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public UseCaseBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
