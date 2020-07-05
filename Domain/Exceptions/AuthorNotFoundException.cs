using System;

namespace Domain.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(string authorId, Exception ex) : base($"Author for Id : {authorId} not found", ex) { }

    }
}
