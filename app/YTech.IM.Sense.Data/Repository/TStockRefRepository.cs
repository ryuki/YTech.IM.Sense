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
    public class TStockRefRepository : NHibernateRepositoryWithTypedId<TStockRef,string >, ITStockRefRepository
    {
       
    }
}
