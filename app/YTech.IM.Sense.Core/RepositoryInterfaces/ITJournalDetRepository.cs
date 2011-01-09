using System;
using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Accounting;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITJournalDetRepository : INHibernateRepositoryWithTypedId<TJournalDet, string>
    {
        IList<TJournalDet> GetForReport(DateTime? dateFrom, DateTime? dateTo, MCostCenter costCenter);
    }
}
