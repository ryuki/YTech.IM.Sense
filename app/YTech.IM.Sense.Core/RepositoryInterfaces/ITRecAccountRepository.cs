using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Accounting;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITRecAccountRepository : INHibernateRepositoryWithTypedId<TRecAccount, string>
    {
        void RunClosing (TRecPeriod recPeriod);
        IList<TRecAccount> GetByAccountType(string accountCatType, MCostCenter costCenter, TRecPeriod recPeriod);
    }
}
