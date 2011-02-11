﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Enums;

namespace YTech.IM.Sense.Web.Controllers.ViewModel
{
    public class TransactionFormViewModel
    {
        public static TransactionFormViewModel CreateTransactionFormViewModel(ITTransRepository transRepository, IMWarehouseRepository mWarehouseRepository, IMSupplierRepository mSupplierRepository,IMCustomerRepository mCustomerRepository)
        {
            TransactionFormViewModel viewModel = new TransactionFormViewModel();

            IList<MWarehouse> list = mWarehouseRepository.GetAll();
            MWarehouse mWarehouse = new MWarehouse();
            mWarehouse.WarehouseName = "-Pilih Gudang-";
            list.Insert(0, mWarehouse);
            viewModel.WarehouseList = new SelectList(list, "Id", "WarehouseName");
            viewModel.WarehouseToList = new SelectList(list, "Id", "WarehouseName");

            //IList<MSupplier> listSupplier = mSupplierRepository.GetAll();
            //MSupplier mSupplier = new MSupplier();
            //mSupplier.SupplierName = "-Pilih Supplier-";
            //listSupplier.Insert(0, mSupplier);
            //viewModel.SupplierList = new SelectList(listSupplier, "Id", "SupplierName");

            //var listCustomer = mCustomerRepository.GetAll();
            //MCustomer mCustomer = new MCustomer();
            ////mCustomer.SupplierName = "-Pilih Supplier-";
            //listCustomer.Insert(0, mCustomer);
            //var custs = from cust in listCustomer
            //            select new { Id = cust.Id, Name =cust.PersonId.PersonName };
            //viewModel.TransByList = new SelectList(custs, "Id", "Name");

            //fill payment method
            var values = from EnumPaymentMethod e in Enum.GetValues(typeof(EnumPaymentMethod))
                         select new { ID = e, Name = e.ToString() };

            viewModel.PaymentMethodList = new SelectList(values, "Id", "Name");

            viewModel.ViewWarehouseTo = false;
            viewModel.ViewTransBy = false;
            viewModel.ViewDate = false;
            viewModel.ViewFactur = false;
            viewModel.UsePrice = EnumPrice.None;

            return viewModel;
        }

        public TTrans Trans { get; internal set; }
        public IList<TTransDet> ListOfTransDet { get; internal set; }

        public SelectList WarehouseList { get; internal set; }
        public SelectList WarehouseToList { get; internal set; }
        //public SelectList SupplierList { get; internal set; }
        public SelectList TransByList { get; internal set; }
        public SelectList PaymentMethodList { get; internal set; }
        public bool ViewWarehouse { get; internal set; }
        public bool ViewWarehouseTo { get; internal set; }
        public bool ViewTransBy { get; internal set; }
        public bool ViewCustomer { get; internal set; }
        public bool ViewDate { get; internal set; }
        public bool ViewFactur { get; internal set; }
        public bool ViewPrice { get; internal set; }
        public bool ViewPaymentMethod { get; internal set; }
        public string Title { get; internal set; }
        public string TransByText { get; internal set; }
        public EnumPrice UsePrice { get; internal set; }

    }
}
