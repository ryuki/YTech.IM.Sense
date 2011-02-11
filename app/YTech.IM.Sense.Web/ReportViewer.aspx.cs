using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Data.Repository;

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
    }
}