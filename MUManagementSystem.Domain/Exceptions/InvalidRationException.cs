using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Domain.Exceptions
{
    public class InvalidRationException:Exception
    {
        public InvalidRationException():base("Ration can not be zero or negative.")
        {

        }
    }
}
