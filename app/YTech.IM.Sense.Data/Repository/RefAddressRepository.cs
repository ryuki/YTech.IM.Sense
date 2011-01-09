using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;

namespace YTech.IM.Sense.Data.Repository
{
    public class RefAddressRepository : NHibernateRepositoryWithTypedId<RefAddress, string>, IRefAddressRepository
    {
    }
}
