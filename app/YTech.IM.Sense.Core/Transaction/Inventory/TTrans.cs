﻿using System.Collections.Generic;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;
using System;
using SharpArch.Core;
using YTech.IM.Sense.Core.Master;

namespace YTech.IM.Sense.Core.Transaction
{
    public class TTrans : EntityWithTypedId<string>, IHasAssignedId<string>
    {
        public TTrans()
        {
            InitMembers();
        }

        /// <summary>
        /// Since we want to leverage automatic properties, init appropriate members here.
        /// </summary>
        private void InitMembers()
        {
            TransDets = new List<TTransDet>();
        }


        [DomainSignature]
        [NotNull, NotEmpty]
        public virtual MWarehouse WarehouseId { get; set; }
        public virtual MWarehouse WarehouseIdTo { get; set; }
        public virtual DateTime? TransDate { get; set; }
        public virtual string TransBy { get; set; }
        public virtual TTrans TransRefId { get; set; }
        public virtual string TransFactur { get; set; }
        public virtual MEmployee EmployeeId { get; set; }
        public virtual string TransDueDate { get; set; }
        public virtual string TransPaymentMethod { get; set; }
        public virtual decimal? TransSubTotal { get; set; }
        public virtual decimal? TransDiscount { get; set; }
        public virtual decimal? TransTax { get; set; }
        public virtual string TransStatus { get; set; }
        public virtual string TransDesc { get; set; }

        public virtual IList<TTransDet> TransDets { get; protected set; }

        public virtual string DataStatus { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }

        #region Implementation of IHasAssignedId<string>

        public virtual void SetAssignedIdTo(string assignedId)
        {
            Check.Require(!string.IsNullOrEmpty(assignedId), "Assigned Id may not be null or empty");
            Id = assignedId.Trim();
        }

        #endregion
    }
}
