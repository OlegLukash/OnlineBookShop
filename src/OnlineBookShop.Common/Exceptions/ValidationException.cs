using System;

namespace OnlineBookShop.Common.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException(string message): base(message)
        {

        }
    }
}
