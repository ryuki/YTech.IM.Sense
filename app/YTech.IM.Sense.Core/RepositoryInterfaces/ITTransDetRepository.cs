using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITTransDetRepository : INHibernateRepositoryWithTypedId<TTransDet, string>
    {
        IList<TTransDet> GetByItemWarehouse(MItem item, MWarehouse warehouse);

        decimal? GetTotalUsed(MItem item, MWarehouse warehouse);
    }
}
