using Domain.Exceptions;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authors
{
    public static class ValidateAuthor
    {
      public static void Validate(this Author author )
        {
            if(author == null)
            {
                throw new AuthorNotFoundException(author.AuthorId, null);
            }

        }
    }
}
