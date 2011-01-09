using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface IRefPersonRepository : INHibernateRepositoryWithTypedId<RefPerson, string>
    {
        
    }
}
