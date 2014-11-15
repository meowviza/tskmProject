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
                #region Sample: Current Status Ticket Ratio
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
                        Data = new Data(ticketStatusStat.Select(x => new object[] { x.Name, x.Count }).ToArray())
                    });

                ViewBag.TicketStatusRatioChart = ticketStatusRatioChart;
                #endregion

                //Ticket Opened/Closed in each month
                #region Sample: Ticket Opened/Closed in each month
                var ticketOpenStat = (from ticket in db.Tickets.ToList()
                                      group ticket by new { Month = ticket.CreatedDate.Month, Year = ticket.CreatedDate.Year } into g
                                      select new DotNet.Highcharts.Options.Point
                                      {
                                          Name = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month) + "/" + g.Key.Year,
                                          Y = g.Count()
                                      }).ToArray();

                var ticketCloseStat = (from ticket in db.Tickets.ToList()
                                       where ticket.Status.statusName == "Closed"
                                       group ticket by new { Month = ticket.UpdatedDate.Month, Year = ticket.UpdatedDate.Year } into g
                                       select new DotNet.Highcharts.Options.Point
                                       {
                                           Name = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month) + "/" + g.Key.Year,
                                           Y = g.Count()
                                       }).ToArray();

                var ticketOpenCloseStatChart = new Highcharts("TicketOpenCloseStat")
                    .SetTitle(new Title { Text = "Opened/Closed Ticket in each month" })
                    .SetXAxis(new DotNet.Highcharts.Options.XAxis
                    {
                        Categories = ticketCloseStat.Union(ticketOpenStat).Select(x => x.Name).GroupBy(x => x).Select(x => x.Key).ToArray()
                    })
                    .SetSeries(new Series[] {
                        new Series
                        {
                            Type = ChartTypes.Column,
                            Name = "Opened",
                            Data = new Data(ticketOpenStat)
                        },
                        new Series
                        {
                            Type = ChartTypes.Column,
                            Name = "Closed",
                            Data = new Data(ticketCloseStat)
                        }});

                ViewBag.TicketOpenCloseStatChart = ticketOpenCloseStatChart;
                #endregion

                //Create/Post KM in each month (Line Chart)
                #region Sample: Line Chart for KM
                var knowledgeCreateStat = (from create in db.Knowledgebases.ToList()
                                           group create by new { Month = create.knowledgeDate.Month, Year = create.knowledgeDate.Year } into c
                                           select new DotNet.Highcharts.Options.Point
                                           {
                                               Name = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key.Month) + "/" + c.Key.Year,
                                               Y = c.Count()
                                           }).ToArray();
                                    
                var knowledgeCommentStat = (from comment in db.KnowledgeComments.ToList()
                                            //where comment.commentDate == DateTime.Now
                                            group comment by new { Month = comment.commentDate.Month, Year = comment.commentDate.Year } into c
                                            select new DotNet.Highcharts.Options.Point
                                            {
                                                Name = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key.Month) + "/" + c.Key.Year,
                                                Y = c.Count()
                                            }).ToArray();

                var knowledgeBaseCommentStatChart = new Highcharts("KnowledgeCreateCommentStat")
                .SetTitle(new Title { Text = "Create/Comment Knowledgebase in each month" })
                .SetXAxis(new DotNet.Highcharts.Options.XAxis
                {
                    Categories = knowledgeCommentStat.Union(knowledgeCreateStat).Select(x => x.Name).GroupBy(x => x).Select(x => x.Key).ToArray() 
                })
                .SetYAxis(new YAxis
                {
                    Min = 0
                })
                .SetSeries(new Series[] {
                        new Series
                        {
                            Type = ChartTypes.Line,
                            Name = "Create",
                            Data = new Data(knowledgeCreateStat)
                        },
                        new Series
                        {
                            Type = ChartTypes.Line,
                            Name = "Comment",
                            Data = new Data(knowledgeCommentStat)
                        }});
                ViewBag.KnowledgeCreateCommentStatChart = knowledgeBaseCommentStatChart;
                #endregion

            }
            return View();
        }
    }
}