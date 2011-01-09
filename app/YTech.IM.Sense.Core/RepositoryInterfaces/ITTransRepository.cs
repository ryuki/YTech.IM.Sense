using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITTransRepository : INHibernateRepositoryWithTypedId<TTrans, string>
    {
    }
}
