using Sitecore.Demo22.MVC.Web.Models;
using System;
using Sitecore.Demo22.MVC.Web.Models.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Fields;
using Sitecore.Demo22.MVC.Web.Extensions;

namespace Sitecore.DemoProject.MVC.Web.Controllers
{
    public class NavigationController : Controller
    {
   
        public ActionResult HeaderNavigationByDS()
        {
            var model = new NavigationViewModel();
            List<Navigation> parentNavigations = new List<Navigation>();

            var dataSource = RenderingContext.Current?.Rendering.Item;

            if (dataSource != null && dataSource.HasChildren)
            {
                foreach (Item parentItem in dataSource.Children)
                {
                    var parentNavigation = BuildNavigationByDS(parentItem);
                    var childNavigations = new List<Navigation>();

                     
                    parentNavigations.Add(parentNavigation);
                }
            }
            model.Navigations = parentNavigations;
            return View(model);
        }

        private Navigation BuildNavigationByDS(Item item)
        {
            return new Navigation
            {
                NavigationTitle = item.Fields["Navigation_Title"]?.Value,
                NavigationLink = ((LinkField)item.Fields["Navigation_Link"]).GetFriendlyUrl(),
                ActiveClass = PageContext.Current.Item.ID == ((LinkField)item.Fields["Navigation_Link"]).TargetID ? "active" : string.Empty
            };
        }
       
    }
}