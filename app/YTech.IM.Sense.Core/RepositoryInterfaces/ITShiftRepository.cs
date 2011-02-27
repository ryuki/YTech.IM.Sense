using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface ITShiftRepository : INHibernateRepositoryWithTypedId<TShift, string>
    {
        TShift GetLastShiftByDate(System.DateTime? shiftDate);

        TShift GetByDateAndShiftNo(System.DateTime? shiftDate, int? shiftNo);
    }
}
