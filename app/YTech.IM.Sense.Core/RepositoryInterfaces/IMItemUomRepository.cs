using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport.NHibernate;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.RepositoryInterfaces
{
   public interface IMItemUomRepository : INHibernateRepositoryWithTypedId<MItemUom, string>
   {
       MItemUom GetByItem(MItem item);
   }
}
