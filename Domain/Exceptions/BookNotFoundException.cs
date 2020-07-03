﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OdysseyPublishers.Domain.Exceptions
{
    public class BookNotFoundException :Exception
    {
        public BookNotFoundException(string book, Exception ex) : base($"Book : {book} not found ", ex) { }
    }
}
