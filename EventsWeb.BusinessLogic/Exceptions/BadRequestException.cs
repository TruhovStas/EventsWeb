﻿namespace EventsWeb.BusinessLogic.Exceptions
{

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
