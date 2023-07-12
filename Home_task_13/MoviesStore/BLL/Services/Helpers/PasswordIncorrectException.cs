﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Helpers
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException()
        {
        }

        public PasswordIncorrectException(string message)
            : base(message)
        {
        }

        public PasswordIncorrectException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
