﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.API.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }

}
