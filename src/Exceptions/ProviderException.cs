﻿namespace street_service.Exceptions;

public class ProviderException : Exception
{
    public ProviderException(string message)
        : base(message)
    {
    }
}