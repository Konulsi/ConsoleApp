using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Exceptions
{
    internal class InvalidTeacherException : Exception
    {
        public InvalidTeacherException(string message) : base(message) { }
        
    }
}
