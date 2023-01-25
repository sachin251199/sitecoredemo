using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Demo22.MVC.Web.Models;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Demo22.MVC.Web.Controllers
{
    public class FeesController : Controller
    {
        // GET: Fees
        public ActionResult FeeStr()
        {
            Fees fee = new Fees();
            List<Fees> feeslist = new List<Fees>();
            var rendringContext = RenderingContext.CurrentOrNull;
            var rendering = rendringContext.Rendering;
            var datasourceId = rendering.DataSource;
            var DatasourceItem = Sitecore.Context.Database.GetItem(datasourceId);

            foreach (Sitecore.Data.Items.Item child in DatasourceItem.Children)
            {
                fee = new Fees();
                fee.Serial_Number = child.Fields["Serial_Number"].Value;
                fee.Maintenance_Money = child.Fields["Maintenance_Money"].Value;
                fee.Registration_Fees = child.Fields["Registration_Fees"].Value;
                fee.Standard = child.Fields["Standard"].Value;
                fee.Exam_Fees = child.Fields["Exam_Fees"].Value;
                fee.Monthaly_Fees = child.Fields["Monthaly_Fees"].Value;
                fee.Anual_Fees = child.Fields["Anual_Fees"].Value;

                feeslist.Add(fee);

            }
            return View(feeslist);




        }
    }
}