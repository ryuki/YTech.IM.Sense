using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using YTech.IM.Sense.Core.Master;
using YTech.IM.Sense.Core.RepositoryInterfaces;

namespace YTech.IM.Sense.Data.Repository
{
    public class MRoomRepository : NHibernateRepositoryWithTypedId<MRoom, string>, IMRoomRepository
    {
        #region IMRoomRepository Members

        public IEnumerable<MRoom> GetPagedPacketList(string orderCol, string orderBy, int pageIndex, int maxRows, ref int totalRows)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(MRoom));

            //calculate total rows
            totalRows = Session.CreateCriteria(typeof(MRoom))
                .SetProjection(Projections.RowCount())
                .FutureValue<int>().Value;

            //get list results
            criteria.SetMaxResults(maxRows)
              .SetFirstResult((pageIndex - 1) * maxRows)
              .AddOrder(new Order(orderCol, orderBy.Equals("asc") ? true : false))
              ;

            IEnumerable<MRoom> list = criteria.List<MRoom>();
            return list;
        }

        #endregion
    }
}
