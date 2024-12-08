using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.APPLICATION.Exceptions
{
    public class InvalidException(string error) : Exception($"Error - {error}")
    {
    }
}
