﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumingRESTServiceCRUD_Client.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }
    }
}