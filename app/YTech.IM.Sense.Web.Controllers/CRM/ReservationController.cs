using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using SharpArch.Core;
using SharpArch.Web.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Accounting;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Web.Controllers.ViewModel;

namespace YTech.IM.Sense.Web.Controllers.CRM
{
    [HandleError]
    public class ReservationController : Controller
    {
        private readonly IMBrandRepository _mBrandRepository;
        public ReservationController(IMBrandRepository mBrandRepository)
        {
            Check.Require(mBrandRepository != null, "mBrandRepository may not be null");

            this._mBrandRepository = mBrandRepository;
        }

        public ActionResult Index()
        {
            return View(ReservationFormViewModel.Create());
        }
    }
}
