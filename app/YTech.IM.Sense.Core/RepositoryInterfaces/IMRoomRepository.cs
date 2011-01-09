using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface IMRoomRepository : INHibernateRepositoryWithTypedId<MRoom, string>
    {
        IEnumerable<MRoom> GetPagedPacketList(string orderCol, string orderBy, int pageIndex, int maxRows, ref int totalRows);
    }
}
