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
using YTech.IM.Sense.Core.Transaction.Accounting;
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Web.Controllers.ViewModel;

namespace YTech.IM.Sense.Web.Controllers.Transaction
{
    public partial class InventoryController
    {
        private void SaveJournal(TTrans trans, decimal totalHPP)
        {
            AbstractTransaction tr = null;
            //set class to its transaction
            if (trans.TransStatus.Equals(EnumTransactionStatus.Purchase.ToString()))
            {
                tr = new Purchase();
            }
            else if (trans.TransStatus.Equals(EnumTransactionStatus.Sales.ToString()))
            {
                tr = new Sales();
            }
            else if (trans.TransStatus.Equals(EnumTransactionStatus.Service.ToString()))
            {
                tr = new Service();
            }
            else if (trans.TransStatus.Equals(EnumTransactionStatus.ReturPurchase.ToString()))
            {
                tr = new ReturPurchase();
            }
            else if (trans.TransStatus.Equals(EnumTransactionStatus.ReturSales.ToString()))
            {
                tr = new ReturSales();
            }
            else if (trans.TransStatus.Equals(EnumTransactionStatus.Mutation.ToString()))
            {
                tr = new Mutation();
            }

            //return if no class specified
            if (tr == null)
            {
                return;
            }

            tr.UserName = User.Identity.Name;
            tr.AccountRefRepository = _mAccountRefRepository;
            tr.JournalRepository = _tJournalRepository;
            tr.SaveJournal(trans, totalHPP);
        }
    }
}
