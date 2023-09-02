using Neu.ANT.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Common.Exceptions
{
    public class AntBaseException : Exception
    {
        private readonly ErrorCode _errorCode;

        public ErrorCode ErrorCode => _errorCode;

        public AntBaseException(ErrorCode code, string message): base(message) {
            _errorCode = code;
        }
    }
}
