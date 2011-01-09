using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Accounting;

namespace YTech.IM.Sense.Web.Controllers.ViewModel.Reports
{
    public class TransDetViewModel : TTransDet
    {
        public string ItemName { get; set; }
        public decimal TotalUsed { get; set; }
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
    }
}
