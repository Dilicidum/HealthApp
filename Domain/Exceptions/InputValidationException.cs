using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InputValidationException(string message = "Input is invalid"):Exception(message) {} 
}
