using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Web.Controllers.Helper;

namespace YTech.IM.Sense.Web
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                string rpt = Request.QueryString["rpt"];

                rv.ProcessingMode = ProcessingMode.Local;
                //if (rpt.Equals(Enums.EnumReports.RptPrintFacturService.ToString()))
                //{
                //    SetPaper(rpt);
                //}
                //else
                rv.LocalReport.ReportPath = Server.MapPath(string.Format("~/Views/Transaction/Report/{0}.rdlc", rpt));

                rv.LocalReport.DataSources.Clear();
                ReportDataSource[] repCol = Session["ReportData"] as ReportDataSource[];
                if (repCol != null)
                {
                    foreach (ReportDataSource d in repCol)
                    {
                        rv.LocalReport.DataSources.Add(d);
                    }
                }

                //ReportDataSource d = Session["ReportData"] as ReportDataSource;// new ReportDataSource();
                //d.Name = Session["ReportDataName"].ToString();
                //d.Value = Session["ReportData"] as IEnumerable;

                rv.LocalReport.Refresh();
            }
        }

        void SetPaper(string rpt)
        {
            int rowCount = (int)Session["DetailRowCount"];
            float h = (rowCount - 1) * 1.27f;
            SizeF sizePage = new SizeF(7.6f, 8.5f + h);
            PointF pointMarginsLT = new PointF(0f, 0f);

            PointF pointMarginsRB = new PointF(0f, 0f);

            string path = Server.MapPath(string.Format("~/Views/Transaction/Report/{0}.rdlc", rpt));
            StreamReader sr = new StreamReader(path);
            string sXMLData = sr.ReadToEnd();
            ReportViewerHelper reportHelper = new ReportViewerHelper(sXMLData);

            reportHelper.SetPageSize(sizePage, pointMarginsLT, pointMarginsRB);

            //Change the report here with the helper     
            rv.LocalReport.LoadReportDefinition(reportHelper.GetReport());


        }
    }
}