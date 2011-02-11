using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Reporting.WebForms;
using SharpArch.Core;
using SharpArch.Web.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Web.Controllers.ViewModel;

namespace YTech.IM.Sense.Web.Controllers.Transaction
{
    [HandleError]
    public class InventoryController : Controller
    {
        //public InventoryController()
        //    : this(new TTransRepository(), new MWarehouseRepository(), new MSupplierRepository(), new MItemRepository(), new TStockCardRepository(), new TStockItemRepository(), new TTransRefRepository(), new TStockRepository(), new TStockRefRepository(), new MCustomerRepository(), new MRoomRepository(), new MEmployeeRepository(), new TTransDetRepository(), new TTransRoomRepository(), new MPacketRepository())
        //{
        //}

        private readonly ITTransRepository _tTransRepository;
        private readonly IMWarehouseRepository _mWarehouseRepository;
        private readonly IMSupplierRepository _mSupplierRepository;
        private readonly IMItemRepository _mItemRepository;
        private readonly ITStockCardRepository _tStockCardRepository;
        private readonly ITStockItemRepository _tStockItemRepository;
        private readonly ITTransRefRepository _tTransRefRepository;
        private readonly ITStockRepository _tStockRepository;
        private readonly ITStockRefRepository _tStockRefRepository;
        private readonly IMCustomerRepository _mCustomerRepository;
        private readonly IMRoomRepository _mRoomRepository;
        private readonly IMEmployeeRepository _mEmployeeRepository;
        private readonly ITTransDetRepository _tTransDetRepository;
        private readonly ITTransRoomRepository _tTransRoomRepository;
        private readonly IMPacketRepository _mPacketRepository;


        public InventoryController(ITTransRepository tTransRepository, IMWarehouseRepository mWarehouseRepository, IMSupplierRepository mSupplierRepository, IMItemRepository mItemRepository, ITStockCardRepository tStockCardRepository, ITStockItemRepository tStockItemRepository, ITTransRefRepository tTransRefRepository, ITStockRepository tStockRepository, ITStockRefRepository tStockRefRepository, IMCustomerRepository mCustomerRepository, IMRoomRepository mRoomRepository, IMEmployeeRepository mEmployeeRepository, ITTransDetRepository tTransDetRepository, ITTransRoomRepository tTransRoomRepository, IMPacketRepository mPacketRepository)
        {
            Check.Require(tTransRepository != null, "tTransRepository may not be null");
            Check.Require(mWarehouseRepository != null, "mWarehouseRepository may not be null");
            Check.Require(mSupplierRepository != null, "mSupplierRepository may not be null");
            Check.Require(mItemRepository != null, "mItemRepository may not be null");
            Check.Require(tStockCardRepository != null, "tStockCardRepository may not be null");
            Check.Require(tStockItemRepository != null, "tStockItemRepository may not be null");
            Check.Require(tTransRefRepository != null, "tTransRefRepository may not be null");
            Check.Require(tStockRepository != null, "tStockRepository may not be null");
            Check.Require(tStockRefRepository != null, "tStockRefRepository may not be null");
            Check.Require(mCustomerRepository != null, "mCustomerRepository may not be null");
            Check.Require(mRoomRepository != null, "mRoomRepository may not be null");
            Check.Require(mEmployeeRepository != null, "mEmployeeRepository may not be null");
            Check.Require(tTransDetRepository != null, "tTransDetRepository may not be null");
            Check.Require(tTransRoomRepository != null, "tTransRoomRepository may not be null");
            Check.Require(mPacketRepository != null, "mPacketRepository may not be null");

            this._tTransRepository = tTransRepository;
            this._mWarehouseRepository = mWarehouseRepository;
            this._mSupplierRepository = mSupplierRepository;
            this._mItemRepository = mItemRepository;
            this._tStockCardRepository = tStockCardRepository;
            this._tStockItemRepository = tStockItemRepository;
            this._tTransRefRepository = tTransRefRepository;
            this._tStockRepository = tStockRepository;
            this._tStockRefRepository = tStockRefRepository;
            this._mCustomerRepository = mCustomerRepository;
            this._mRoomRepository = mRoomRepository;
            this._mEmployeeRepository = mEmployeeRepository;
            this._tTransDetRepository = tTransDetRepository;
            this._tTransRoomRepository = tTransRoomRepository;
            this._mPacketRepository = mPacketRepository;
        }

        public ActionResult Index()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.PurchaseOrder);

            ListDetTrans = new List<TTransDet>();

            return View(viewModel);
        }

        private TransactionFormViewModel SetViewModelByStatus(EnumTransactionStatus enumTransactionStatus)
        {
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository, _mCustomerRepository);
            viewModel.Trans = SetNewTrans(enumTransactionStatus);

            switch (enumTransactionStatus)
            {
                case EnumTransactionStatus.PurchaseOrder:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Order Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.TransByText = "Supplier :";
                    viewModel.TransByList = GetSupplierList();
                    viewModel.UsePrice = EnumPrice.Purchase;
                    break;
                case EnumTransactionStatus.Purchase:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = true;
                    viewModel.TransByText = "Supplier :";
                    viewModel.TransByList = GetSupplierList();
                    viewModel.UsePrice = EnumPrice.Purchase;
                    break;
                case EnumTransactionStatus.ReturPurchase:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Retur Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = true;
                    viewModel.TransByText = "Supplier :";
                    viewModel.TransByList = GetSupplierList();
                    viewModel.UsePrice = EnumPrice.Purchase;
                    break;
                case EnumTransactionStatus.Sales:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Penjualan";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = true;
                    viewModel.TransByText = "Konsumen :";
                    viewModel.TransByList = GetCustomerList();
                    viewModel.UsePrice = EnumPrice.Sale;
                    break;
                case EnumTransactionStatus.ReturSales:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Retur Penjualan";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = true;
                    viewModel.TransByText = "Konsumen :";
                    viewModel.TransByList = GetCustomerList();
                    viewModel.UsePrice = EnumPrice.Sale;
                    break;
                case EnumTransactionStatus.Using:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Pemakaian Material";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = false;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = false;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.UsePrice = EnumPrice.None;
                    break;
                case EnumTransactionStatus.Mutation:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Mutasi Stok";
                    viewModel.ViewWarehouseTo = true;
                    viewModel.ViewTransBy = false;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = false;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.UsePrice = EnumPrice.None;
                    break;
                case EnumTransactionStatus.Adjusment:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Penyesuaian Stok";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = false;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPrice = false;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.UsePrice = EnumPrice.None;
                    break;
                case EnumTransactionStatus.Received:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Penerimaan Stok";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.UsePrice = EnumPrice.None;
                    break;
                case EnumTransactionStatus.Budgeting:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Rencana Anggaran Belanja";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewTransBy = false;
                    viewModel.ViewDate = false;
                    viewModel.ViewFactur = false;
                    viewModel.ViewPrice = true;
                    viewModel.ViewPaymentMethod = false;
                    viewModel.UsePrice = EnumPrice.Purchase;
                    break;
            }

            ViewData["CurrentItem"] = viewModel.Title;
            //ViewData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.NotSaved;

            return viewModel;
        }

        private SelectList GetSupplierList()
        {
            IList<MSupplier> listSupplier = _mSupplierRepository.GetAll();
            MSupplier mSupplier = new MSupplier();
            mSupplier.SupplierName = "-Pilih Supplier-";
            listSupplier.Insert(0, mSupplier);
            return new SelectList(listSupplier, "Id", "SupplierName");
        }

        private SelectList GetCustomerList()
        {
            var listCustomer = _mCustomerRepository.GetAll();
            MCustomer mCustomer = new MCustomer();
            //mCustomer.SupplierName = "-Pilih Supplier-";
            listCustomer.Insert(0, mCustomer);
            var custs = from cust in listCustomer
                        select new { Id = cust.Id, Name = cust.PersonId != null ? cust.PersonId.PersonName : "-Pilih Konsumen-" };
            return new SelectList(custs, "Id", "Name");
        }

        private TTrans SetNewTrans(EnumTransactionStatus enumTransactionStatus)
        {
            TTrans trans = new TTrans();
            trans.TransDate = DateTime.Today;
            trans.TransFactur = Helper.CommonHelper.GetFacturNo(enumTransactionStatus);
            trans.SetAssignedIdTo(Guid.NewGuid().ToString());
            trans.TransStatus = enumTransactionStatus.ToString();
            return trans;
        }

        public ActionResult Purchase()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Purchase);

            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Purchase(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        private ActionResult SaveTransactionRef(TTrans Trans, FormCollection formCollection)
        {
            _tTransRepository.DbContext.BeginTransaction();
            if (Trans == null)
            {
                Trans = new TTrans();
            }
            Trans.SetAssignedIdTo(formCollection["Trans.Id"]);
            Trans.CreatedDate = DateTime.Now;
            Trans.CreatedBy = User.Identity.Name;
            Trans.DataStatus = Enums.EnumDataStatus.New.ToString();
            Trans.TransSubTotal = ListTransRef.Sum(x => x.TransIdRef.TransSubTotal);
            _tTransRepository.Save(Trans);
            _tTransRepository.DbContext.CommitTransaction();

            _tTransRefRepository.DbContext.BeginTransaction();
            TTransRef detToInsert;
            foreach (TTransRef det in ListTransRef)
            {
                detToInsert = new TTransRef();
                detToInsert.SetAssignedIdTo(det.Id);
                detToInsert.TransId = Trans;
                detToInsert.TransIdRef = det.TransIdRef;
                detToInsert.TransRefDesc = det.TransRefDesc;
                detToInsert.TransRefStatus = det.TransRefStatus;

                detToInsert.CreatedBy = User.Identity.Name;
                detToInsert.CreatedDate = DateTime.Now;
                detToInsert.DataStatus = EnumDataStatus.New.ToString();
                _tTransRefRepository.Save(detToInsert);
            }
            try
            {
                _tTransRefRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception)
            {
                _tTransRefRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            if (!Trans.TransStatus.Equals(EnumTransactionStatus.PurchaseOrder.ToString()))
            {
                return RedirectToAction(Trans.TransStatus);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ReturPurchase()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.ReturPurchase);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReturPurchase(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        public ActionResult Using()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Using);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Using(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        public ActionResult Received()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Received);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Received(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        public ActionResult Mutation()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Mutation);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Mutation(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        [Transaction]
        public ActionResult Adjusment()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Adjusment);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adjusment(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        private List<TTransDet> ListDetTrans
        {
            get
            {
                if (Session["listDetTrans"] == null)
                {
                    Session["listDetTrans"] = new List<TTransDet>();
                }
                return Session["listDetTrans"] as List<TTransDet>;
            }
            set
            {
                Session["listDetTrans"] = value;
            }
        }

        private List<TTransRef> ListTransRef
        {
            get
            {
                if (Session["ListTransRef"] == null)
                {
                    Session["ListTransRef"] = new List<TTransRef>();
                }
                return Session["ListTransRef"] as List<TTransRef>;
            }
            set
            {
                Session["ListTransRef"] = value;
            }
        }

        [Transaction]
        public virtual ActionResult List(string sidx, string sord, int page, int rows, string usePrice)
        {
            int totalRecords = 0;
            var transDets = ListDetTrans;
            int pageSize = rows;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = (
                           from det in transDets
                           select new
                                      {
                                          i = det.Id.ToString(),
                                          cell = new string[]
                                                     {
                                                         det.Id,
                                                         det.ItemId != null ? det.ItemId.Id : null,
                                                         det.ItemId != null ? det.ItemId.ItemName : null,
                                                         det.TransDetQty.HasValue ?  det.TransDetQty.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetPrice.HasValue ?  det.TransDetPrice.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetDisc.HasValue ?   det.TransDetDisc.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetTotal.HasValue ?   det.TransDetTotal.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                         det.TransDetDesc
                                                     }
                                      });

            decimal? transDetTotal = transDets.Sum(det => det.TransDetTotal);
            decimal? transDetQty = transDets.Sum(det => det.TransDetQty);
            var userdata = new
            {
                ItemName = "Total",
                TransDetQty = transDetQty.Value.ToString(Helper.CommonHelper.NumberFormat),
                TransDetTotal = transDetTotal.Value.ToString(Helper.CommonHelper.NumberFormat)
            };
            if (usePrice.Equals(false.ToString()))
            {
                result = (
                           from det in transDets
                           select new
                           {
                               i = det.Id.ToString(),
                               cell = new string[]
                                                     {
                                                         det.Id,
                                                         det.ItemId != null ? det.ItemId.Id : null,
                                                         det.ItemId != null ? det.ItemId.ItemName : null,
                                                       det.TransDetQty.HasValue ?    det.TransDetQty.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                         det.TransDetDesc
                                                     }
                           });
            }

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = result.ToArray(),
                userdata
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [Transaction]
        public virtual ActionResult ListBill(string sidx, string sord, int page, int rows, string TransId)
        {
            int totalRecords = 0;
            IList<TTransDet> transDets = new List<TTransDet>();
            if (!string.IsNullOrEmpty(TransId))
            { 
                transDets = _tTransDetRepository.GetListByTransId(TransId, EnumTransactionStatus.Service);
            }

            int pageSize = rows;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var result = (
                           from det in transDets
                           select new
                           {
                               i = det.Id.ToString(),
                               cell = new string[]
                                                     {
                                                         det.Id,
                                                         det.PacketId != null ? det.PacketId.Id : null,
                                                         det.PacketId != null ? det.PacketId.PacketName : null,
                                                         det.TransDetQty.HasValue ?  det.TransDetQty.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetPrice.HasValue ?  det.TransDetPrice.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetDisc.HasValue ?   det.TransDetDisc.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                        det.TransDetTotal.HasValue ?   det.TransDetTotal.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                                                     det.EmployeeId != null ? det.EmployeeId.Id : null,
                                                      det.EmployeeId != null ? det.EmployeeId.PersonId.PersonName : null
                                                     }
                           });

            decimal? transDetTotal = transDets.Sum(det => det.TransDetTotal);
            decimal? transDetQty = transDets.Sum(det => det.TransDetQty);
            var userdata = new
                               {
                                   PacketName = "Total",
                                   TransDetQty = transDetQty.Value.ToString(Helper.CommonHelper.NumberFormat),
                                   TransDetTotal = transDetTotal.Value.ToString(Helper.CommonHelper.NumberFormat)
                               };
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = result.ToArray(),
                userdata
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [Transaction]
        public virtual ActionResult GetListTransRef(string sidx, string sord, int page, int rows)
        {
            int totalRecords = 0;
            var transRefs = ListTransRef;
            int pageSize = rows;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (
                    from det in transRefs
                    select new
                    {
                        i = det.Id.ToString(),
                        cell = new string[] {
                             det.TransIdRef.Id,
                             det.TransIdRef.Id,
                            det.TransIdRef.TransFactur, 
                            det.TransIdRef.TransDate.HasValue ? det.TransIdRef.TransDate.Value.ToString(Helper.CommonHelper.DateFormat) : null,
                           det.TransIdRef.TransSubTotal.HasValue ?  det.TransIdRef.TransSubTotal.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                            det.TransIdRef.TransDesc
                        }
                    }).ToArray()
                //userdata: {price:1240.00} 
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(TTransDet viewModel, FormCollection formCollection)
        {
            TTransDet transDetToInsert = new TTransDet();
            TransferFormValuesTo(transDetToInsert, viewModel);
            transDetToInsert.SetAssignedIdTo(viewModel.Id);
            transDetToInsert.CreatedDate = DateTime.Now;
            transDetToInsert.CreatedBy = User.Identity.Name;
            transDetToInsert.DataStatus = EnumDataStatus.New.ToString();

            ListDetTrans.Add(transDetToInsert);
            return Content("success");
        }

        public ActionResult Delete(TTransDet viewModel, FormCollection formCollection)
        {
            ListDetTrans.Remove(viewModel);
            return Content("success");
        }

        public ActionResult DeleteTransRef(TTransRef viewModel, FormCollection formCollection)
        {
            ListTransRef.Remove(viewModel);
            return Content("success");
        }

        public ActionResult DeleteBill(TTransDet viewModel, FormCollection formCollection)
        {
            _tTransDetRepository.DbContext.BeginTransaction();
            TTransDet det = _tTransDetRepository.Get(viewModel.Id);

            if (det != null)
            {
                _tTransDetRepository.Delete(det);
            }
            try
            {
                _tTransDetRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
                return Content("success");
            }
            catch (Exception ex)
            {
                _tTransDetRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
                return Content(ex.Message);
            }
        }

        public ActionResult Insert(TTransDet viewModel, FormCollection formCollection)
        {
            UpdateNumericData(viewModel, formCollection);
            TTransDet transDetToInsert = new TTransDet();
            TransferFormValuesTo(transDetToInsert, viewModel);
            transDetToInsert.SetAssignedIdTo(Guid.NewGuid().ToString());
            transDetToInsert.ItemId = _mItemRepository.Get(formCollection["ItemId"]);
            transDetToInsert.SetAssignedIdTo(viewModel.Id);
            transDetToInsert.CreatedDate = DateTime.Now;
            transDetToInsert.CreatedBy = User.Identity.Name;
            transDetToInsert.DataStatus = EnumDataStatus.New.ToString();

            ListDetTrans.Add(transDetToInsert);
            return Content("success");
        }


        public ActionResult InsertBill(TTransDet viewModel, FormCollection formCollection, string transId)
        {
            _tTransDetRepository.DbContext.BeginTransaction();
            TTrans trans = _tTransRepository.Get(transId);

            UpdateNumericData(viewModel, formCollection);
            TTransDet transDetToInsert = new TTransDet(trans);
            MEmployee emp = _mEmployeeRepository.Get(formCollection["EmployeeId"]);
            TransferFormValuesTo(transDetToInsert, viewModel);
            transDetToInsert.SetAssignedIdTo(Guid.NewGuid().ToString());
            transDetToInsert.PacketId = _mPacketRepository.Get(formCollection["PacketId"]);
            transDetToInsert.EmployeeId = emp;
            if (emp.EmployeeCommissionServiceType == EnumCommissionType.Percent.ToString())
            {
                transDetToInsert.TransDetCommissionService = emp.EmployeeCommissionServiceVal * transDetToInsert.TransDetTotal /
                                                         100;
            }
            else
            {
                transDetToInsert.TransDetCommissionService = emp.EmployeeCommissionServiceVal;
            }



            transDetToInsert.CreatedDate = DateTime.Now;
            transDetToInsert.CreatedBy = User.Identity.Name;
            transDetToInsert.DataStatus = EnumDataStatus.New.ToString();
            _tTransDetRepository.Save(transDetToInsert);
            try
            {
                _tTransDetRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
                return Content("success");
            }
            catch (Exception ex)
            {
                _tTransDetRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
                return Content(ex.Message);
            }

        }

        private static void UpdateNumericData(TTransDet viewModel, FormCollection formCollection)
        {
            if (!string.IsNullOrEmpty(formCollection["TransDetQty"]))
            {
                string wide = formCollection["TransDetQty"].Replace(",", "");
                decimal? qty = Convert.ToDecimal(wide);
                viewModel.TransDetQty = qty;
            }
            else
            {
                viewModel.TransDetQty = null;
            }
            if (!string.IsNullOrEmpty(formCollection["TransDetPrice"]))
            {
                string wide = formCollection["TransDetPrice"].Replace(",", "");
                decimal? price = Convert.ToDecimal(wide);
                viewModel.TransDetPrice = price;
            }
            else
            {
                viewModel.TransDetPrice = null;
            }
            if (!string.IsNullOrEmpty(formCollection["TransDetDisc"]))
            {
                string wide = formCollection["TransDetDisc"].Replace(",", "");
                decimal? disc = Convert.ToDecimal(wide);
                viewModel.TransDetDisc = disc;
            }
            else
            {
                viewModel.TransDetDisc = null;
            }
            if (!string.IsNullOrEmpty(formCollection["TransDetTotal"]))
            {
                string wide = formCollection["TransDetTotal"].Replace(",", "");
                decimal? total = Convert.ToDecimal(wide);
                viewModel.TransDetTotal = total;
            }
            else
            {
                viewModel.TransDetTotal = null;
            }
        }

        public ActionResult InsertTransRef(TTransRef viewModel, FormCollection formCollection)
        {
            TTransRef transDetToInsert = new TTransRef();

            transDetToInsert.SetAssignedIdTo(Guid.NewGuid().ToString());
            transDetToInsert.TransIdRef = _tTransRepository.Get(formCollection["TransIdRef"]);
            //transDetToInsert.TransId = _tTransRepository.Get(formCollection["TransId"]);
            transDetToInsert.CreatedDate = DateTime.Now;
            transDetToInsert.CreatedBy = User.Identity.Name;
            transDetToInsert.DataStatus = EnumDataStatus.New.ToString();

            ListTransRef.Add(transDetToInsert);
            return Content("success");
        }



        private void TransferFormValuesTo(TTransDet transDet, TTransDet viewModel)
        {
            transDet.TransDetNo = ListDetTrans.Count + 1;
            transDet.TransDetQty = viewModel.TransDetQty;
            transDet.TransDetPrice = viewModel.TransDetPrice;
            transDet.TransDetDisc = viewModel.TransDetDisc;
            transDet.TransDetTotal = viewModel.TransDetTotal;
            transDet.TransDetDesc = viewModel.TransDetDesc;
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        private ActionResult SaveTransaction(TTrans Trans, FormCollection formCollection)
        {
            _tTransRepository.DbContext.BeginTransaction();
            if (Trans == null)
            {
                Trans = new TTrans();
            }
            Trans.SetAssignedIdTo(formCollection["Trans.Id"]);
            Trans.WarehouseId = _mWarehouseRepository.Get(formCollection["Trans.WarehouseId"]);
            if (!string.IsNullOrEmpty(formCollection["Trans.WarehouseIdTo"]))
            {
                Trans.WarehouseIdTo = _mWarehouseRepository.Get(formCollection["Trans.WarehouseIdTo"]);
            }
            Trans.CreatedDate = DateTime.Now;
            Trans.CreatedBy = User.Identity.Name;
            Trans.DataStatus = Enums.EnumDataStatus.New.ToString();

            Trans.TransDets.Clear();

            //save stock card
            bool addStock = true;
            bool calculateStock = false;
            EnumTransactionStatus status = (EnumTransactionStatus)Enum.Parse(typeof(EnumTransactionStatus), Trans.TransStatus);
            switch (status)
            {
                case EnumTransactionStatus.Received:
                    addStock = true;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.Adjusment:
                    addStock = true;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.ReturPurchase:
                    addStock = false;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.ReturSales:
                    addStock = true;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.Sales:
                    addStock = false;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.Using:
                    addStock = false;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.Mutation:
                    addStock = false;
                    calculateStock = true;
                    break;
                case EnumTransactionStatus.Purchase:
                    addStock = true;
                    calculateStock = true;
                    break;
            }

            TTransDet detToInsert;
            IList<TTransDet> listDet = new List<TTransDet>();
            decimal total = 0;
            foreach (TTransDet det in ListDetTrans)
            {
                detToInsert = new TTransDet(Trans);
                detToInsert.SetAssignedIdTo(Guid.NewGuid().ToString());
                detToInsert.ItemId = det.ItemId;
                detToInsert.ItemUomId = det.ItemUomId;
                detToInsert.TransDetQty = det.TransDetQty;
                detToInsert.TransDetPrice = det.TransDetPrice;
                detToInsert.TransDetDisc = det.TransDetDisc;
                detToInsert.TransDetTotal = det.TransDetTotal;
                detToInsert.CreatedBy = User.Identity.Name;
                detToInsert.CreatedDate = DateTime.Now;
                detToInsert.DataStatus = Enums.EnumDataStatus.New.ToString();
                Trans.TransDets.Add(detToInsert);
                total += det.TransDetTotal.HasValue ? det.TransDetTotal.Value : 0;
                listDet.Add(detToInsert);
            }
            Trans.TransSubTotal = total;
            _tTransRepository.Save(Trans);
            //_tTransRepository.DbContext.CommitTransaction();

            //_tStockCardRepository.DbContext.BeginTransaction();
            if (calculateStock)
            {
                foreach (TTransDet det in listDet)
                {
                    //save stock
                    if (Trans.TransStatus.Equals(EnumTransactionStatus.Mutation.ToString()))
                    {
                        SaveStock(Trans, det, false, Trans.WarehouseId);
                        SaveStock(Trans, det, true, Trans.WarehouseIdTo);
                        UpdateStockDetail(Trans, det, false, Trans.WarehouseId);
                        UpdateStockDetail(Trans, det, true, Trans.WarehouseIdTo);
                    }
                    else
                    {
                        SaveStock(Trans, det, addStock, Trans.WarehouseId);
                        UpdateStockDetail(Trans, det, addStock, Trans.WarehouseId);
                    }
                }
            }

            try
            {
                _tTransRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception)
            {
                _tTransRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            //if (!Trans.TransStatus.Equals(EnumTransactionStatus.PurchaseOrder.ToString()))
            //{
            //    return RedirectToAction(Trans.TransStatus.ToString());
            //}
            //return RedirectToAction("Index");
            return View("Status");
        }

        private void SaveStock(TTrans Trans, TTransDet det, bool addStock, MWarehouse mWarehouse)
        {
            TStockCard stockCard;
            TStockItem stockItem;
            //foreach (TTransDet det in ListDetTrans)
            {
                stockItem = _tStockItemRepository.GetByItemAndWarehouse(det.ItemId, mWarehouse);
                bool isSave = false;
                if (stockItem == null)
                {
                    isSave = true;
                    stockItem = new TStockItem();
                    stockItem.SetAssignedIdTo(Guid.NewGuid().ToString());
                    stockItem.ItemId = det.ItemId;
                    stockItem.WarehouseId = mWarehouse;
                    stockItem.CreatedBy = User.Identity.Name;
                    stockItem.CreatedDate = DateTime.Now;
                    stockItem.DataStatus = EnumDataStatus.New.ToString();
                }
                else
                {
                    stockItem.ModifiedBy = User.Identity.Name;
                    stockItem.ModifiedDate = DateTime.Now;
                    stockItem.DataStatus = EnumDataStatus.Updated.ToString();
                }
                if (addStock)
                {
                    stockItem.ItemStock = stockItem.ItemStock + det.TransDetQty.Value;
                }
                else
                {
                    stockItem.ItemStock = stockItem.ItemStock - det.TransDetQty.Value;
                }

                if (isSave)
                {
                    _tStockItemRepository.Save(stockItem);
                }
                else
                {
                    _tStockItemRepository.Update(stockItem);
                }

                //save stock card
                stockCard = new TStockCard();
                //stockCard.SetAssignedIdTo(Guid.NewGuid().ToString());
                stockCard.CreatedBy = User.Identity.Name;
                stockCard.CreatedDate = DateTime.Now;
                stockCard.DataStatus = EnumDataStatus.New.ToString();
                stockCard.ItemId = det.ItemId;
                stockCard.StockCardDate = Trans.TransDate;
                stockCard.StockCardDesc = Trans.TransDesc;
                stockCard.StockCardQty = det.TransDetQty;
                stockCard.StockCardSaldo = stockItem.ItemStock;
                stockCard.StockCardStatus = addStock;
                stockCard.TransDetId = det;
                stockCard.WarehouseId = mWarehouse;
                _tStockCardRepository.Save(stockCard);
            }
        }

        private void UpdateStockDetail(TTrans Trans, TTransDet det, bool addStock, MWarehouse mWarehouse)
        {
            if (addStock)
            {
                TStock stock = new TStock();
                stock.SetAssignedIdTo(Guid.NewGuid().ToString());
                stock.ItemId = det.ItemId;
                stock.TransDetId = det;
                stock.StockDate = Trans.TransDate;
                stock.StockDesc = det.TransDetDesc;
                stock.StockPrice = det.TransDetPrice;
                stock.StockQty = det.TransDetQty;
                stock.StockStatus = Trans.TransStatus;
                stock.WarehouseId = mWarehouse;
                stock.DataStatus = EnumDataStatus.New.ToString();
                stock.CreatedBy = User.Identity.Name;
                stock.CreatedDate = DateTime.Now;
                _tStockRepository.Save(stock);
            }
            else
            {
                IList list = _tStockRepository.GetSisaStockList(det.ItemId, mWarehouse);
                TStock stock;
                decimal? qty = det.TransDetQty;
                object[] arr;
                decimal? sisa;
                TStockRef stockRef;
                for (int i = 0; i < list.Count; i++)
                {
                    arr = (object[])list[i];
                    stock = arr[0] as TStock;
                    sisa = (decimal)arr[1];

                    stockRef = new TStockRef(stock);
                    stockRef.SetAssignedIdTo(Guid.NewGuid().ToString());
                    //stockRef.StockId = stock;
                    if (sisa >= qty)
                    {
                        stockRef.StockRefQty = qty;
                    }
                    else
                    {
                        stockRef.StockRefQty = sisa;
                    }
                    stockRef.TransDetId = det;
                    stockRef.StockRefPrice = det.TransDetPrice;
                    stockRef.StockRefDate = Trans.TransDate;
                    stockRef.StockRefStatus = Trans.TransStatus;
                    stockRef.StockRefDesc = det.TransDetDesc;
                    stockRef.CreatedBy = User.Identity.Name;
                    stockRef.CreatedDate = DateTime.Now;
                    stockRef.DataStatus = EnumDataStatus.New.ToString();
                    _tStockRefRepository.Save(stockRef);

                    qty = qty - sisa;
                    if (qty <= 0)
                    {
                        break;
                    }
                }


            }

        }

        public ActionResult Budgeting()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Budgeting);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Budgeting(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        public ActionResult Sales()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.Sales);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Sales(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        public ActionResult ReturSales()
        {
            TransactionFormViewModel viewModel = SetViewModelByStatus(EnumTransactionStatus.ReturSales);


            ListDetTrans = new List<TTransDet>();
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReturSales(TTrans Trans, FormCollection formCollection)
        {
            return SaveTransaction(Trans, formCollection);
        }

        [Transaction]
        public virtual ActionResult GetListTrans(string transStatus, string warehouseId, string transBy)
        {
            IList<TTrans> transes;
            //if (!string.IsNullOrEmpty(transStatus))
            MWarehouse warehouse = _mWarehouseRepository.Get(warehouseId);
            {
                transes = _tTransRepository.GetByWarehouseStatusTransBy(warehouse, transStatus, transBy);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:{1}", string.Empty, "-Pilih Faktur-");
            foreach (TTrans trans in transes)
            {
                sb.AppendFormat(";{0}:{1}", trans.Id, trans.TransFactur);
            }
            return Content(sb.ToString());
        }

        [Transaction]
        public virtual ActionResult Billing()
        {
            BillingFormViewModel viewModel = BillingFormViewModel.CreateBillingViewModel(_mRoomRepository, _mEmployeeRepository, _mCustomerRepository, _tTransRoomRepository);

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]      // Helps avoid CSRF attacks
        [Transaction]                   // Wraps a transaction around the action
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Billing(TTrans Trans, FormCollection formCollection)
        {
            if (formCollection["btnIn"] != null)
            {
                return SaveTransRoom(Trans, formCollection);
            }
            else if (formCollection["btnPaid"] != null)
            {
                return UpdateTransRoom(Trans, formCollection);
            }
            else if (formCollection["btnCancel"] != null)
            {
                return DeleteTransRoom(Trans, formCollection);
            }
            else if (formCollection["btnPrint"] != null)
            {
                SetReportDataForPrint(formCollection["TransId"]);
               
       
                var e = new
                {
                    Success = false,
                    Message = "redirect",
                    RoomStatus = EnumTransRoomStatus.New.ToString()
                };
                return Json(e, JsonRequestBehavior.AllowGet); 
            }
            return View();
        }

        private void SetReportDataForPrint(string TransId)
        {
            ReportDataSource[] repCol = new ReportDataSource[3];
            TTrans trans = _tTransRepository.Get(TransId);
            IList<TTrans> listTrans = new List<TTrans>();
            listTrans.Add(trans);
            var list = from det in listTrans
                       select new
                       {
                           det.TransFactur,
                           det.TransDate,
                           det.TransSubTotal,
                           det.TransBy,
                           det.TransDesc,
                           det.TransDiscount,
                           det.TransStatus
                           // EmployeeId = det.EmployeeId.Id
                       }
       ;
            ReportDataSource reportDataSource = new ReportDataSource("TransViewModel", list.ToList());
            repCol[0] = reportDataSource;

            IList<TTransDet> listDetail = trans.TransDets;
            var listDet = from det in listDetail
                          select new
                          {
                              // det.PacketId,
                              EmployeeId = det.EmployeeId.Id,
                              EmployeeName = det.EmployeeId.PersonId.PersonName,
                              PacketId = det.PacketId.Id,
                              det.PacketId.PacketName,
                              det.TransDetPrice,
                              det.TransDetQty,
                              det.TransDetDisc,
                              det.TransDetCommissionProduct,
                              det.TransDetCommissionService,
                              det.TransDetNo,
                              det.TransDetTotal
                          }
      ;
            reportDataSource = new ReportDataSource("TransDetViewModel", listDet.ToList());
            repCol[1] = reportDataSource;

            TTransRoom troom = _tTransRoomRepository.Get(TransId);
            IList<TTransRoom> listTransroom = new List<TTransRoom>();
            listTransroom.Add(troom);
            var listRoom = from det in listTransroom
                           select new
                           {
                               det.RoomId.Id,
                               det.RoomInDate,
                               det.RoomOutDate,
                               det.RoomStatus,
                               det.RoomVoucherPaid,
                               det.RoomCashPaid,
                               det.RoomCreditPaid,
                               det.RoomCommissionProduct,
                               det.RoomCommissionService
                           }
      ;
            reportDataSource = new ReportDataSource("TransRoomViewModel", listRoom.ToList());
            repCol[2] = reportDataSource;
            Session["ReportData"] = repCol;
        }

        private ActionResult DeleteTransRoom(TTrans Trans, FormCollection formCollection)
        {
            _tTransRoomRepository.DbContext.BeginTransaction();

            TTransRoom troom = _tTransRoomRepository.Get(formCollection["TransId"]);
            if (troom != null)
            {
                _tTransRoomRepository.Delete(troom);
            }
            TTrans trans = _tTransRepository.Get(formCollection["TransId"]);
            if (trans != null)
            {
                _tTransRepository.Delete(trans);
            }

            string Message = string.Empty;
            bool Success = true;
            try
            {
                _tTransRoomRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.GetBaseException().Message;
                _tTransRoomRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            var e = new
            {
                Success ,
                Message ,
                RoomStatus = EnumTransRoomStatus.New.ToString()
            };
            return Json(e, JsonRequestBehavior.AllowGet);
        }

        private ActionResult UpdateTransRoom(TTrans Trans, FormCollection formCollection)
        {
            _tTransRoomRepository.DbContext.BeginTransaction();
            TTrans trans = _tTransRepository.Get(formCollection["TransId"]);
            if (!string.IsNullOrEmpty(formCollection["hidPaymentSubTotal"]))
            {
                string hidPaymentSubTotal = formCollection["hidPaymentSubTotal"].Replace(",", "");
                trans.TransSubTotal = Convert.ToDecimal(hidPaymentSubTotal);
            }
            _tTransRepository.Update(trans);

            TTransRoom troom = _tTransRoomRepository.Get(formCollection["TransId"]);
            troom.RoomStatus = EnumTransRoomStatus.Paid.ToString();
            if (!string.IsNullOrEmpty(formCollection["paymentCash"]))
            {
                string paymentCash = formCollection["paymentCash"].Replace(",", "");
                troom.RoomCashPaid = Convert.ToDecimal(paymentCash);
            }
            if (!string.IsNullOrEmpty(formCollection["paymentVoucher"]))
            {
                string paymentVoucher = formCollection["paymentVoucher"].Replace(",", "");
                troom.RoomVoucherPaid = Convert.ToDecimal(paymentVoucher);
            }
            if (!string.IsNullOrEmpty(formCollection["paymentCreditCard"]))
            {
                string paymentCreditCard = formCollection["paymentCreditCard"].Replace(",", "");
                troom.RoomCreditPaid = Convert.ToDecimal(paymentCreditCard);
            }
            troom.RoomOutDate = DateTime.Now;
            troom.ModifiedBy = User.Identity.Name;
            troom.ModifiedDate = DateTime.Now;
            troom.DataStatus = EnumDataStatus.Updated.ToString();
            _tTransRoomRepository.Update(troom);

            string Message = string.Empty;
            bool Success = true;
            try
            {
                _tTransRoomRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.GetBaseException().Message;
                _tTransRoomRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            var e = new
                        {
                            Success ,
                            Message,
                            RoomStatus = EnumTransRoomStatus.Paid.ToString()
                        };
            return Json(e, JsonRequestBehavior.AllowGet);
            // return View("Status");
        }

        private ActionResult SaveTransRoom(TTrans Trans, FormCollection formCollection)
        {
            _tTransRepository.DbContext.BeginTransaction();
            if (Trans == null)
            {
                Trans = new TTrans();
            }
            Trans.SetAssignedIdTo(formCollection["TransId"]);
            Trans.TransStatus = EnumTransactionStatus.Service.ToString();
            if (!string.IsNullOrEmpty(formCollection["TransDiscount"]))
            {
                string TransDiscount = formCollection["TransDiscount"].Replace(",", "");
                Trans.TransDiscount = Convert.ToDecimal(TransDiscount);
            }

            Trans.TransDate = DateTime.Today;
            Trans.CreatedDate = DateTime.Now;
            Trans.CreatedBy = User.Identity.Name;
            Trans.DataStatus = Enums.EnumDataStatus.New.ToString();
            _tTransRepository.Save(Trans);


            TTransRoom troom = new TTransRoom();
            troom.SetAssignedIdTo(Trans.Id);
            if (!string.IsNullOrEmpty(formCollection["RoomInDate"]))
                troom.RoomInDate = Convert.ToDateTime(formCollection["RoomInDate"]);
            if (!string.IsNullOrEmpty(formCollection["RoomOutDate"]))
                troom.RoomOutDate = Convert.ToDateTime(formCollection["RoomOutDate"]);
            troom.RoomStatus = EnumTransRoomStatus.In.ToString();
            if (!string.IsNullOrEmpty(formCollection["RoomId"]))
            {
                troom.RoomId = _mRoomRepository.Get(formCollection["RoomId"]);
            }
            troom.CreatedDate = DateTime.Now;
            troom.CreatedBy = User.Identity.Name;
            troom.DataStatus = Enums.EnumDataStatus.New.ToString();
            _tTransRoomRepository.Save(troom);

            string Message = string.Empty;
            bool Success = true;
            try
            {
                _tTransRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.GetBaseException().Message;
                _tTransRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            var e = new
            {
                Success ,
                Message,
                RoomStatus = EnumTransRoomStatus.In.ToString()
            };
            return Json(e, JsonRequestBehavior.AllowGet);
            //return View("Status");
        }

        public virtual ActionResult GetJsonTransRoom(string roomId)
        {
            MRoom room = _mRoomRepository.Get(roomId);
            TTransRoom troom = _tTransRoomRepository.GetByRoom(room);
            if (troom == null)
            {
                troom = new TTransRoom();
                troom.SetAssignedIdTo(Guid.NewGuid().ToString());
                troom.RoomStatus = EnumTransRoomStatus.New.ToString();
                troom.RoomInDate = DateTime.Now;

            }
            var t = new
            {
                troom.Id,
                troom.RoomInDate,
                troom.RoomOutDate,
                troom.RoomStatus,
                troom.RoomBookDate,
                troom.RoomCommissionService,
                troom.RoomCommissionProduct
            };
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetJsonTrans(string transId)
        {
            TTrans trans = null;
            if (!string.IsNullOrEmpty(transId))
            {
                trans = _tTransRepository.Get(transId);
            }
            if (trans == null)
            {
                trans = new TTrans();
                trans.SetAssignedIdTo(Guid.NewGuid().ToString());

            }
            string CustomerName = string.Empty;
            if (!string.IsNullOrEmpty(trans.TransBy))
            {
                CustomerName = _mCustomerRepository.Get(trans.TransBy).PersonId.PersonName;
            }
            var j = new
                        {
                            trans.Id,
                            TransDiscount = trans.TransDiscount.HasValue ? trans.TransDiscount.Value.ToString(Helper.CommonHelper.NumberFormat) : null,
                            trans.TransBy,
                            CustomerName
                        };
            return Json(j, JsonRequestBehavior.AllowGet);
        }
    }
}
