﻿using System.Web;
using System.Web.Mvc;

namespace ConsumingRESTServiceCRUD_Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
