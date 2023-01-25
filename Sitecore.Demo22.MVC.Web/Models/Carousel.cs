using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo22.MVC.Web.Models
{
    public class Carousel
    {
        public List<Slide> Slides { get; set; }
        
    }
    public class Slide
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString SubTitle { get; set; }
        public MvcHtmlString Image { get; set; }
        public MvcHtmlString Link { get; set; }
    }
}