using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITTransDetRepository : INHibernateRepositoryWithTypedId<TTransDet, string>
    {
        IList<TTransDet> GetByItemWarehouse(MItem item, MWarehouse warehouse);

        decimal? GetTotalUsed(MItem item, MWarehouse warehouse);

        IList<TTransDet> GetListByRoom(MRoom room);

        IList<TTransDet> GetListByTransId(string transId, Enums.EnumTransactionStatus enumTransactionStatus);

        IList<TTransDet> GetListByTrans(TTrans trans);

        IList<TTransDet> GetListByDate(Enums.EnumTransactionStatus enumTransactionStatus, System.DateTime? dateFrom, System.DateTime? dateTo);
    }
}
