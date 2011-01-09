using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface IMAccountRepository : INHibernateRepositoryWithTypedId<MAccount, string>
    {
        IEnumerable<MAccount> GetPagedAccountList(string orderCol, string orderBy, int pageIndex, int maxRows, ref int totalRows,MAccountCat accountCat);
        IList<MAccount> GetByAccountCat(MAccountCat accountCat);
    }
}
