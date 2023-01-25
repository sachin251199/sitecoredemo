using System.Collections.Generic;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Demo22.MVC.Web.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace Sitecore.Demo22.MVC.Web.Controllers
{
    public class GridCardController : Controller
    {

        public ActionResult Index()
        {
            var model = new Cardlist();
            List<Cardlist> cards = new List<Cardlist>();

            var dataSourceid = RenderingContext.Current?.Rendering.DataSource;
            var datasource = Sitecore.Context.Database.GetItem(dataSourceid);

            foreach (Item cardItem in datasource.GetChildren())
            {
                model = new Cardlist();
                var title = new MvcHtmlString(FieldRenderer.Render(cardItem, "Title"));


                var summary = new MvcHtmlString(FieldRenderer.Render
                    (cardItem, "Summary"));

                //Image
                var image = new MvcHtmlString(FieldRenderer.Render
                    (cardItem, "Image"));



                cards.Add(new Cardlist
                {
                    Title = title,
                    Summary = summary,
                    Image = image,
                });
            }

            

            return View(cards);

        }
    }
}