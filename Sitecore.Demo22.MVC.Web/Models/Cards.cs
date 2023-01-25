using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo22.MVC.Web.Models
{
    //public class Cards
    //{
    //    public List<Cardlist> Cardlists { get; set; }

    //}
    public class Cardlist
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString Summary { get; set; }
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString Link { get; set; }

    }
}