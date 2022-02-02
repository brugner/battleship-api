using System;

namespace Battleship.API.Core.Exceptions;

[Serializable]
public class AppForbiddenException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T:AppForbiddenException"/> class
    /// </summary>
    public AppForbiddenException()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AppForbiddenException"/> class
    /// </summary>
    /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
    public AppForbiddenException(string message) : base(message)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AppForbiddenException"/> class
    /// </summary>
    /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
    /// <param name="inner">The exception that is the cause of the current exception. </param>
    public AppForbiddenException(string message, System.Exception inner) : base(message, inner)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:AppForbiddenException"/> class
    /// </summary>
    /// <param name="context">The contextual information about the source or destination.</param>
    /// <param name="info">The object that holds the serialized object data.</param>
    protected AppForbiddenException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {

    }
}