using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Data.Repository
{
    public class TStockItemRepository : NHibernateRepositoryWithTypedId<TStockItem, string>, ITStockItemRepository
    {
        #region Implementation of ITStockItemRepository

        public TStockItem GetByItemAndWarehouse(MItem mItem, MWarehouse mWarehouse)
        {
            ICriteria criteria = Session.CreateCriteria(typeof (TStockItem))
                .Add(Expression.Eq("ItemId", mItem))
                .Add(Expression.Eq("WarehouseId", mWarehouse));
            return (TStockItem)criteria.UniqueResult();
        }

        public IList<TStockItem> GetByItemWarehouse(MItem item, MWarehouse warehouse)
        {
            ICriteria criteria = Session.CreateCriteria(typeof (TStockItem));
            if (item != null)
            {
                criteria.Add(Expression.Eq("ItemId", item));
            }
            if (warehouse != null)
            {
                criteria.Add(Expression.Eq("WarehouseId", warehouse));
            }
            return criteria.List<TStockItem>();
        }

        #endregion
    }
}
