using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Demo22.MVC.Web.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sitecore.Demo22.MVC.Web.Controllers
{
    public class CarouselController : Controller
    {
        public ActionResult Index()
        {
            var model = new Carousel();
            List<Slide> slides = new List<Slide>();

            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["Slides"];

            
            var slideCountParam = RenderingContext.Current?.Rendering.Parameters["SlideCount"];
            int.TryParse(slideCountParam, out int result);
            int slideCount = result == 0 ? 2 : result;

            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();

                foreach (var slideItem in slideItems)
                {
                    
                    var title = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Title"));


                    var subTitle = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "SubTitle"));

                    //Image
                    var image = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Image"));

                    
                    var link = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Link"
                        , "class=btn animated fadeInUp"));

                    slides.Add(new Slide
                    {
                        Title = title,
                        SubTitle = subTitle,
                        Image = image,
                        Link = link
                    });
                }
                model.Slides = slides;
            }
            return View(model);
        }
    }
}