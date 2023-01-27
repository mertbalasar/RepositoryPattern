using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Exceptions
{
    public class BirthdayException : Exception
    {
        public BirthdayException(string message) : base(message)
        {

        }
    }
}
