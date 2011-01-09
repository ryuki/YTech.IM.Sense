using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITStockItemRepository : INHibernateRepositoryWithTypedId<TStockItem, string>
    {
        TStockItem GetByItemAndWarehouse(MItem mItem, MWarehouse mWarehouse);

        IList<TStockItem> GetByItemWarehouse(MItem item, MWarehouse warehouse);
    }
}
