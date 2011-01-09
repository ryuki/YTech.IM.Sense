using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YTech.IM.Sense.Core.Transaction.Accounting;

namespace YTech.IM.Sense.Web.Controllers.ViewModel.Reports
{
   public class RecAccountViewModel : TRecAccount
    {
       public string AccountName { get; set; }
       public string AccountCatId { get; set; }
       public string AccountCatName { get; set; }
       public string CostCenterName { get; set; }
       public string AccountParentId { get; set; }
    }
}
