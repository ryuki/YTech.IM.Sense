using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Enums;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITReferenceRepository : INHibernateRepositoryWithTypedId<TReference, string>
    {
        TReference GetByReferenceType(EnumReferenceType referenceType);

    }
}
