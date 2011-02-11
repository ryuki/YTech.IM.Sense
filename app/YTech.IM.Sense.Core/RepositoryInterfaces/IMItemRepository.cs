﻿using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
    public interface IMItemRepository : INHibernateRepositoryWithTypedId<MItem, string>
    {
        IEnumerable<MItem> GetPagedItemList(string orderCol, string orderBy, int pageIndex, int maxRows, ref int totalRows, string itemId, string itemName); 
    }
}
