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
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Web.Controllers.ViewModel;

namespace YTech.IM.Sense.Web.Controllers.Transaction
{
    [HandleError]
    public class InventoryController : Controller
    {
        private readonly ITTransRepository _tTransRepository;
        private readonly IMWarehouseRepository _mWarehouseRepository;
        private readonly IMSupplierRepository _mSupplierRepository;
        private readonly IMItemRepository _mItemRepository;
        private readonly ITStockCardRepository _tStockCardRepository;
        private readonly ITStockItemRepository _tStockItemRepository;

        public InventoryController(ITTransRepository tTransRepository, IMWarehouseRepository mWarehouseRepository, IMSupplierRepository mSupplierRepository, IMItemRepository mItemRepository, ITStockCardRepository tStockCardRepository, ITStockItemRepository tStockItemRepository)
        {
            Check.Require(tTransRepository != null, "tTransRepository may not be null");
            Check.Require(mWarehouseRepository != null, "mWarehouseRepository may not be null");
            Check.Require(mSupplierRepository != null, "mSupplierRepository may not be null");
            Check.Require(mItemRepository != null, "mItemRepository may not be null");
            Check.Require(tStockCardRepository != null, "tStockCardRepository may not be null");
            Check.Require(tStockItemRepository != null, "tStockItemRepository may not be null");

            this._tTransRepository = tTransRepository;
            this._mWarehouseRepository = mWarehouseRepository;
            this._mSupplierRepository = mSupplierRepository;
            this._mItemRepository = mItemRepository;
            this._tStockCardRepository = tStockCardRepository;
            this._tStockItemRepository = tStockItemRepository;
        }

        public ActionResult Index()
        {
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository);
            viewModel.Trans = SetNewTrans(EnumTransactionStatus.PurchaseOrder);
            SetViewModelByStatus(viewModel, EnumTransactionStatus.PurchaseOrder);

            ListDetTrans = new List<TTransDet>();

            return View(viewModel);
        }

        private void SetViewModelByStatus(TransactionFormViewModel viewModel, EnumTransactionStatus enumTransactionStatus)
        {
            switch (enumTransactionStatus)
            {
                case EnumTransactionStatus.PurchaseOrder:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Order Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewSupplier = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    break;
                case EnumTransactionStatus.Purchase:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewSupplier = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    break;
                case EnumTransactionStatus.ReturPurchase:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Retur Pembelian";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewSupplier = true;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    break;
                case EnumTransactionStatus.Sales:
                    break;
                case EnumTransactionStatus.ReturSales:
                    break;
                case EnumTransactionStatus.Mutation:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Mutasi Stok";
                    viewModel.ViewWarehouseTo = true;
                    viewModel.ViewSupplier = false;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    break;
                case EnumTransactionStatus.Adjusment:
                    viewModel.ViewWarehouse = true;
                    viewModel.Title = "Penyesuaian Stok";
                    viewModel.ViewWarehouseTo = false;
                    viewModel.ViewSupplier = false;
                    viewModel.ViewDate = true;
                    viewModel.ViewFactur = true;
                    break;
            }

            ViewData["CurrentItem"] = viewModel.Title;
            //ViewData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.NotSaved;
        }

        private TTrans SetNewTrans(EnumTransactionStatus enumTransactionStatus)
        {
            TTrans trans = new TTrans();
            trans.TransDate = DateTime.Today;
            // trans.TransFactur = "yahu";
            trans.SetAssignedIdTo(Guid.NewGuid().ToString());
            trans.TransStatus = enumTransactionStatus.ToString();
            return trans;
        }

        public ActionResult Purchase()
        {
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository);
            viewModel.Trans = SetNewTrans(EnumTransactionStatus.Purchase);
            SetViewModelByStatus(viewModel, EnumTransactionStatus.Purchase);

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

        public ActionResult ReturPurchase()
        {
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository);
            viewModel.Trans = SetNewTrans(EnumTransactionStatus.ReturPurchase);
            SetViewModelByStatus(viewModel, EnumTransactionStatus.ReturPurchase);


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

        public ActionResult Mutation()
        {
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository);
            viewModel.Trans = SetNewTrans(EnumTransactionStatus.Mutation);
            SetViewModelByStatus(viewModel, EnumTransactionStatus.Mutation);


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
            TransactionFormViewModel viewModel = TransactionFormViewModel.CreateTransactionFormViewModel(_tTransRepository, _mWarehouseRepository, _mSupplierRepository);
            viewModel.Trans = SetNewTrans(EnumTransactionStatus.Adjusment);
            SetViewModelByStatus(viewModel, EnumTransactionStatus.Adjusment);


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

        [Transaction]
        public virtual ActionResult List(string sidx, string sord, int page, int rows)
        {
            int totalRecords = 0;
            var transDets = ListDetTrans;
            int pageSize = rows;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (
                    from det in transDets
                    select new
                    {
                        i = det.Id.ToString(),
                        cell = new string[] {
                             det.Id,
                            det.ItemId != null ? det.ItemId.Id : null, 
                            det.ItemId != null ? det.ItemId.ItemName : null,
                            det.TransDetPrice.Value.ToString(),
                            det.TransDetQty.Value.ToString(),
                            det.TransDetDisc.Value.ToString(),
                            det.TransDetTotal.Value.ToString(),
                            det.TransDetDesc
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

        public ActionResult Insert(TTransDet viewModel, FormCollection formCollection)
        {
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
              
            }

            TTransDet detToInsert;
            IList<TTransDet> listDet = new List<TTransDet>();
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
                listDet.Add(detToInsert);
            }
            _tTransRepository.Save(Trans);
            _tTransRepository.DbContext.CommitTransaction();

            _tStockCardRepository.DbContext.BeginTransaction();
            foreach (TTransDet det in listDet)
            {
                //save stock
                if (Trans.TransStatus.Equals(EnumTransactionStatus.Mutation.ToString()))
                {
                    SaveStock(Trans, det, false, Trans.WarehouseId);
                    SaveStock(Trans, det, true, Trans.WarehouseIdTo);
                }
                else if (calculateStock)
                {
                    SaveStock(Trans, det, addStock, Trans.WarehouseId);
                }
            }

            try
            {
                _tStockCardRepository.DbContext.CommitTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Success;
            }
            catch (Exception)
            {
                _tTransRepository.DbContext.RollbackTransaction();
                TempData[EnumCommonViewData.SaveState.ToString()] = EnumSaveState.Failed;
            }
            if (!Trans.TransStatus.Equals(EnumTransactionStatus.PurchaseOrder.ToString()))
            {
                return RedirectToAction(Trans.TransStatus.ToString());
            }
            return RedirectToAction("Index");
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
    }
}
