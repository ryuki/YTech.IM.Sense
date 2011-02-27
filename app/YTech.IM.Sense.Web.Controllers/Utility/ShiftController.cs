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
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Web.Controllers.ViewModel;

namespace YTech.IM.Sense.Web.Controllers.Utility
{
    [HandleError]
    public class ShiftController : Controller
    {
        private readonly ITShiftRepository _tShiftRepository;
        public ShiftController(ITShiftRepository tShiftRepository)
        {
            Check.Require(tShiftRepository != null, "tShiftRepository may not be null");

            this._tShiftRepository = tShiftRepository;
        }

        [Transaction]
        public ActionResult Closing()
        {
            ShiftFormViewModel viewModel = ShiftFormViewModel.Create(_tShiftRepository);

            ViewData["CurrentItem"] = "Tutup Shift";
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Closing(TShift viewModel, FormCollection formCollection)
        {
            _tShiftRepository.DbContext.BeginTransaction();

            TShift s = new TShift();
            s.SetAssignedIdTo(Guid.NewGuid().ToString());
            s.ShiftDate = viewModel.ShiftDate;
            s.ShiftDateFrom = Convert.ToDateTime(string.Format("{0:dd-MMM-yyyy} {1:HH:mm}", s.ShiftDate.Value, viewModel.ShiftDateFrom.Value));
            s.ShiftDateTo = Convert.ToDateTime(string.Format("{0:dd-MMM-yyyy} {1:HH:mm}", s.ShiftDate.Value, viewModel.ShiftDateTo.Value));
            s.ShiftNo = viewModel.ShiftNo;

            s.CreatedBy = User.Identity.Name;
            s.CreatedDate = DateTime.Now;
            s.DataStatus = EnumDataStatus.New.ToString();

            _tShiftRepository.Save(s);
            bool Success;
            string Message;
            try
            {
                _tShiftRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
                Success = true;
                Message = "Data berhasil disimpan";
            }
            catch (Exception ex)
            {
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
                Success = false;
                Message = ex.Message;
            }
            var e = new { Success, Message };
            return Json(e, JsonRequestBehavior.AllowGet);
        }
    }
}
