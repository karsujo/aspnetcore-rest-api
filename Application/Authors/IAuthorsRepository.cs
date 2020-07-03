﻿using OdysseyPublishers.Domain;
using System.Collections.Generic;

namespace OdysseyPublishers.Application.Authors
{
    public interface IAuthorsRepository
    {
        bool AuthorExists(string authorId);
        Author GetAuthor(string authorId);
        IEnumerable<Author> GetAuthors();
    }
}