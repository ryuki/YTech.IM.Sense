﻿using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Reservation;
using YTech.IM.Sense.Enums;

namespace YTech.IM.Sense.Data.Repository
{
    public class TReservationDetailRepository : NHibernateRepositoryWithTypedId<TReservationDetail, string>, ITReservationDetailRepository
    {
    }
}
