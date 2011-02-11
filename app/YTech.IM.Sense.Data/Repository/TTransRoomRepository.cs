using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Core.Transaction.Inventory;

namespace YTech.IM.Sense.Data.Repository
{
    public class TTransRoomRepository : NHibernateRepositoryWithTypedId<TTransRoom, string>, ITTransRoomRepository
    {
        public TTransRoom GetByRoom(MRoom room)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"   select troom
                                from TTransRoom as troom
                                    where troom.RoomStatus = :RoomStatus ");
            if (room != null)
            {
                sql.AppendLine(@"   and troom.RoomId = :room");
            }
            IQuery q = Session.CreateQuery(sql.ToString());
            q.SetString("RoomStatus", Enums.EnumTransRoomStatus.In.ToString());
            if (room != null)
            {
                q.SetEntity("room", room);
            }
            return q.UniqueResult<TTransRoom>();
        }
    }
}
