using System;
using System.Collections;
using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;
using YTech.IM.Sense.Core.Transaction.Reservation;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
   public interface ITReservationRepository : INHibernateRepositoryWithTypedId<TReservation, string>
    {
    }
}
