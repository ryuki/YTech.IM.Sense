using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;

namespace YTech.IM.Sense.Data.Repository
{
    public class RefPersonRepository : NHibernateRepositoryWithTypedId<RefPerson, string>, IRefPersonRepository
    {
    }
}
