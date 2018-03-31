using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ZCXJ_CS.Domain;

namespace ZCXJ_CS.Repository
{
    public class WorkTicketMap : EntityTypeConfiguration<WorkTicket>
    {
        public WorkTicketMap()
        {
            HasKey(wt => wt.planNo);
            Property(wt => wt.planNo).IsRequired().HasMaxLength(64);
            Property(wt => wt.prodNo).IsRequired().HasMaxLength(64);
        }
    }
}
