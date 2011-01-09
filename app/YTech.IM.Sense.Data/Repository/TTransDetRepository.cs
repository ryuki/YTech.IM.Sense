﻿using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;

namespace YTech.IM.Sense.Data.Repository
{
    public class TTransDetRepository : NHibernateRepositoryWithTypedId<TTransDet, string>, ITTransDetRepository
    {
        public IList<TTransDet> GetByItemWarehouse(MItem item, MWarehouse warehouse)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   select det
                                from TTransDet as det
                                    left outer join det.TransId trans
                                    where trans.TransStatus = :TransStatus ");
            if (item != null)
            {
                sql.AppendLine(@"   and det.ItemId = :item");
            }
            if (warehouse != null)
            {
                sql.AppendLine(@"   and trans.WarehouseId = :warehouse");
            }
            IQuery q = Session.CreateQuery(sql.ToString());
            q.SetString("TransStatus", "Budgeting");
            if (item != null)
            {
                q.SetEntity("item", item);
            }
            if (warehouse != null)
            {
                q.SetEntity("warehouse", warehouse);
            }
            return q.List<TTransDet>();
        }

        public decimal? GetTotalUsed(MItem item, MWarehouse warehouse)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   select sum(det.TransDetQty)
                                from TTransDet as det
                                    left outer join det.TransId trans
                                    where trans.TransStatus = :TransStatus ");
            if (item != null)
            {
                sql.AppendLine(@"   and det.ItemId = :item");
            }
            if (warehouse != null)
            {
                sql.AppendLine(@"   and trans.WarehouseId = :warehouse");
            }

            IQuery q = Session.CreateQuery(sql.ToString());
            q.SetString("TransStatus", "Using");
            if (item != null)
            {
                q.SetEntity("item", item);
            }
            if (warehouse != null)
            {
                q.SetEntity("warehouse", warehouse);
            }
            if (q.UniqueResult() != null)
            {
                 return (decimal)q.UniqueResult();
            }
            return null;
        }
    }
}
