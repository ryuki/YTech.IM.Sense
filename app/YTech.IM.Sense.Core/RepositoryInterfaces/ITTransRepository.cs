using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITTransRepository : INHibernateRepositoryWithTypedId<TTrans, string>
    {
        IList<TTrans> GetByWarehouseStatusTransBy(MWarehouse warehouse, string transStatus, string transBy);

    }
}
