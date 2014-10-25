using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

#region Highcharts Components
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
#endregion


namespace tskmProject.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            // Get number of each ticket status
            using (tskmProject.Models.tskmContainer db = new Models.tskmContainer())
            {
                var ticketStatusStat = (from status in db.Status
                                        select new
                                        {
                                            Name = status.statusName,
                                            Count = status.Ticket.LongCount()
                                        }).ToList();

                var ticketStatusRatioChart = new Highcharts("TicketStatusRatio")
                    .SetTitle(new Title { Text = "Ticket Status Ratio" })
                    .SetSeries(new Series
                    {
                        Type = ChartTypes.Pie,
                        Name = "TicketStatus",
                        Data = new Data(ticketStatusStat.Select(x=>new object[] { x.Name, x.Count }).ToArray())
                    });

                ViewBag.TicketStatusRatioChart = ticketStatusRatioChart;
            }

            return View();
        }
    }
}