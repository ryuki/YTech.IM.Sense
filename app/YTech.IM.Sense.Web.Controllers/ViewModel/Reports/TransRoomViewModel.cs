using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YTech.IM.Sense.Core.Transaction;

namespace YTech.IM.Sense.Web.Controllers.ViewModel.Reports
{
    public class TransRoomViewModel : TTransRoom
    {
        public decimal? TransSubTotal { get; set; }
        public decimal? TransDiscount { get; set; }
        public DateTime? TransDate { get; set; }
        public string TransFactur { get; set; }
    }
}
