using System;
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
   public class DetailItemFormViewModel
    {
       public static DetailItemFormViewModel Create(string packetId, IMPacketItemCatRepository mPacketItemCatRepository)
        {
            DetailItemFormViewModel viewModel = new DetailItemFormViewModel();
           viewModel.PacketItemCatList = mPacketItemCatRepository.GetByPacketId(packetId);
            return viewModel;
        }
        public IList<MPacketItemCat> PacketItemCatList { get; internal set; }
    }
}
