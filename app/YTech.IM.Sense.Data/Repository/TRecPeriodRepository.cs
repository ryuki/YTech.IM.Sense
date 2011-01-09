using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction.Accounting;

namespace YTech.IM.Sense.Data.Repository
{
    public class TRecPeriodRepository : NHibernateRepositoryWithTypedId<TRecPeriod, string>, ITRecPeriodRepository
    {
        public DateTime? GetLastDateClosing()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(TRecPeriod))
            .SetProjection(Projections.Max("PeriodTo"));
          object obj =  criteria.UniqueResult();
            if (obj != null)
            {
                return Convert.ToDateTime(obj);
            }
            else
            {
                return null;
            }

            DateTime dt = criteria.FutureValue<DateTime>().Value;
            return dt;
            try
            {
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
