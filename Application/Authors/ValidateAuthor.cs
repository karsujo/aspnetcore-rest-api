using Domain.Exceptions;
using OdysseyPublishers.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Authors
{
    public static class ValidateAuthor
    {
        public static void Validate(this Author author)
        {
            if (author == null)
            {
                throw new AuthorNotFoundException(author.AuthorId, null);
            }

        }

        public static void Validate(this IEnumerable<Author> authors)
        {
           foreach( var author in authors)
            {
                if (author == null)
                    throw new AuthorNotFoundException(author.AuthorId, null);
            }
        }
    }
}
