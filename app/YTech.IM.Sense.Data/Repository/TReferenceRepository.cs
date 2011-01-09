using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;

namespace YTech.IM.Sense.Data.Repository
{
    public class TReferenceRepository : NHibernateRepositoryWithTypedId<TReference, string>, ITReferenceRepository
    {
    }
}
